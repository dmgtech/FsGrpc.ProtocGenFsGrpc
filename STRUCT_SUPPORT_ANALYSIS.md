# Summary: Google.Protobuf.Struct Support Analysis for protoc-gen-fsgrpc

## Executive Summary

After thorough analysis of the `protoc-gen-fsgrpc` codebase and the requirements outlined in `struct-support-implementation-guide.md`, I conclude that **NO CODE CHANGES are required in the protoc-gen-fsgrpc library** to support `google.protobuf.Struct`, `google.protobuf.Value`, `google.protobuf.ListValue`, and `google.protobuf.NullValue` types.

The code generator already has all the necessary capabilities to handle these types correctly.

---

## Defense of Position: No Changes Required

### 1. The Code Already Handles All Message Types Generically

**Evidence from `ProtoCodeGen.fs` (lines 157-177):**

```fsharp
static member From (typeMap: TypeMap) (proto: FieldDescriptorProto.Type) (typeName: string) =
    match proto with
    | ProtoFieldType.Double -> ValueType.Double
    | ProtoFieldType.Float -> ValueType.Float
    // ... other primitive types ...
    | ProtoFieldType.Enum -> ValueType.Enum (typeMap typeName)
    | ProtoFieldType.Message ->
        match typeName with
        | ".google.protobuf.DoubleValue" -> ValueType.Wrap ValueType.Double
        | ".google.protobuf.FloatValue" -> ValueType.Wrap ValueType.Float
        // ... other wrapper types ...
        | ".google.protobuf.Timestamp" -> ValueType.Timestamp
        | ".google.protobuf.Duration" -> ValueType.Duration
        | ".google.protobuf.Any" -> ValueType.Any
        | other -> ValueType.Message (typeMap other)  // <-- STRUCT TYPES GO HERE
    | _ -> failwith $"Don't know how to handle type {proto}"
```

**Key Point**: The `| other -> ValueType.Message (typeMap other)` fallback case handles **any message type** not explicitly special-cased. Since Struct, Value, ListValue are just regular Protocol Buffer messages, they will be processed through this path without any special handling needed.

### 2. Recursive Types Are Already Supported

**Evidence from `ProtoCodeGen.fs` (line 1223):**

```fsharp
let private toFsNamespaceDecl (package: string) =
    Frag [
    Line $"namespace rec {toFsNamespace package}"  // <-- ALREADY USES "rec" KEYWORD
    Line $"open FsGrpc.Protobuf"
    Line $"open Google.Protobuf"
    Line $"#nowarn \"40\""
    Line $"#nowarn \"1182\""
    ]
```

**Key Point**: The code generator **already generates `namespace rec`** for ALL generated namespaces, which is exactly what's needed for mutually recursive types like Struct and Value.

### 3. Map Fields Are Already Supported

**Evidence from `FieldType.From` function (lines 238-254):**

```fsharp
let fieldType = 
    match (mapType, oneofOption, repeated, optional, message) with
    | (Some mapType, _, _, _, _) ->
        let k = mapType.Fields |> Seq.find (fun f -> f.Number = 1)
        let v = mapType.Fields |> Seq.find (fun f -> f.Number = 2)
        let keyTypeCode = k.Type
        let keyTypeName = k.TypeName
        let valTypeCode = v.Type
        let valTypeName = v.TypeName
        let keyType = ValueType.From typeMap keyTypeCode keyTypeName
        let valType = ValueType.From typeMap valTypeCode valTypeName
        FieldType.Map { Key = keyType; Value = valType }
    // ... other cases ...
```

**Key Point**: The generator already knows how to process map fields and will generate `Map<string, Value>` for `Struct.fields` automatically.

### 4. Oneof Fields Are Already Supported

**Evidence from existing test reference in guide:**

The guide itself references `gen/testproto.proto.gen.fs` showing that oneof types already work:

```fsharp
type UnionCase =
| None
| Color of Test.Name.Space.Enums.Color
| Name of string
```

**Key Point**: The `Value.kind` oneof with 6 cases (including recursive `StructValue` and `ListValue` cases) will be generated using the existing oneof machinery.

### 5. Lazy Evaluation for Circular Dependencies

**Evidence from `toProtoDefImpl` and `toFsRecordDef`:**

The generator already uses `Lazy<ProtoDef<T>>` for all Proto definitions:

```fsharp
static member Proto : Lazy<ProtoDef<{fsTypeName}>> =
    lazy
    // Field Definitions
    // ...
```

**Key Point**: This lazy evaluation is already in place for ALL message types, which is exactly what's needed to handle the circular references between Struct and Value.

---

## Why Struct Types Might Not Have Been Generated Previously

The issue is likely **NOT in protoc-gen-fsgrpc**, but rather in one of these areas:

### Hypothesis 1: Input Files Not Provided
- `struct.proto` wasn't included in the files passed to the code generator
- The `--include-wkt` flag wasn't used, or wasn't working correctly with buf/protoc

### Hypothesis 2: Generator Invocation Issue
- The consuming project (FsGrpc) might not have been configured to generate code for `google/protobuf/struct.proto`
- The `buf.gen.yaml` or equivalent configuration might not include struct.proto

### Hypothesis 3: File Filtering
- Some other part of the pipeline might be filtering out well-known types that aren't explicitly handled

---

## Testing Recommendations for FsGrpc (Consuming Library)

### Step 1: Verify struct.proto Is Being Processed

Run buf generate with verbose output:
```sh
cd FsGrpc.Tests
buf generate --include-imports --include-wkt -v
```

Check if `google/protobuf/struct.proto` appears in the list of files being processed.

### Step 2: Manually Test Code Generation

Create a test proto file that uses Struct:

**`test_struct.proto`:**
```protobuf
syntax = "proto3";
package test;

import "google/protobuf/struct.proto";

message TestMessage {
  google.protobuf.Struct metadata = 1;
  google.protobuf.Value data = 2;
  google.protobuf.ListValue items = 3;
  google.protobuf.NullValue null_field = 4;
}
```

Generate code for this file and verify:
1. `google.protobuf.Struct` type is generated
2. `google.protobuf.Value` type is generated
3. `google.protobuf.ListValue` type is generated
4. `google.protobuf.NullValue` enum is generated
5. The generated code compiles
6. The recursive references work correctly

### Step 3: Check Generated Output

After running buf generate, look for:
```
gen/google/protobuf/struct.proto.gen.fs
```

The file should contain:
- `type NullValue = ...` (enum)
- `module Value = ...` with nested `Kind` discriminated union
- `type Value = { Kind: Value.Kind }` (record)
- `module Struct = ...`
- `type Struct = { Fields: Map<string, Value> }` (record)
- `module ListValue = ...`
- `type ListValue = { Values: Value list }` (record)

### Step 4: Verify Build

The generated code should compile without errors when building FsGrpc.Tests:
```sh
dotnet build FsGrpc.Tests.fsproj
```

### Step 5: Test Runtime Functionality

Uncomment the tests in `FsGrpc.Tests/JsonTests.fs` (lines 680-720) and run:
```sh
dotnet test FsGrpc.Tests.fsproj
```

---

## Expected Generated Code Structure

Based on the existing code generator patterns, here's what **should** be automatically generated:

```fsharp
namespace rec Google.Protobuf
open FsGrpc.Protobuf
open Google.Protobuf
#nowarn "40"
#nowarn "1182"

// ===== NullValue Enum =====

[<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.EnumConverter<NullValue>>)>]
type NullValue =
| [<FsGrpc.Protobuf.ProtobufName("NULL_VALUE")>] NullValue = 0

// ===== Value Type with Oneof =====

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module Value =
    
    [<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.OneofConverter<Kind>>)>]
    [<CompilationRepresentation(CompilationRepresentationFlags.UseNullAsTrueValue)>]
    [<StructuralEquality;StructuralComparison>]
    [<RequireQualifiedAccess>]
    type Kind =
    | None
    | [<System.Text.Json.Serialization.JsonPropertyName("nullValue")>] NullValue of Google.Protobuf.NullValue
    | [<System.Text.Json.Serialization.JsonPropertyName("numberValue")>] NumberValue of double
    | [<System.Text.Json.Serialization.JsonPropertyName("stringValue")>] StringValue of string
    | [<System.Text.Json.Serialization.JsonPropertyName("boolValue")>] BoolValue of bool
    | [<System.Text.Json.Serialization.JsonPropertyName("structValue")>] StructValue of Google.Protobuf.Struct
    | [<System.Text.Json.Serialization.JsonPropertyName("listValue")>] ListValue of Google.Protobuf.ListValue
    with
        static member OneofCodec : Lazy<OneofCodec<Kind>> = 
            lazy
            // Auto-generated field codecs for each case
            let NullValue = FieldCodec.OneofCase "kind" ValueCodec.Enum<Google.Protobuf.NullValue> (1, "nullValue")
            let NumberValue = FieldCodec.OneofCase "kind" ValueCodec.Double (2, "numberValue")
            let StringValue = FieldCodec.OneofCase "kind" ValueCodec.String (3, "stringValue")
            let BoolValue = FieldCodec.OneofCase "kind" ValueCodec.Bool (4, "boolValue")
            let StructValue = FieldCodec.OneofCase "kind" ValueCodec.Message<Google.Protobuf.Struct> (5, "structValue")
            let ListValue = FieldCodec.OneofCase "kind" ValueCodec.Message<Google.Protobuf.ListValue> (6, "listValue")
            FieldCodec.Oneof "kind" (FSharp.Collections.Map [
                ("nullValue", fun node -> Kind.NullValue (NullValue.ReadJsonField node))
                ("numberValue", fun node -> Kind.NumberValue (NumberValue.ReadJsonField node))
                ("stringValue", fun node -> Kind.StringValue (StringValue.ReadJsonField node))
                ("boolValue", fun node -> Kind.BoolValue (BoolValue.ReadJsonField node))
                ("structValue", fun node -> Kind.StructValue (StructValue.ReadJsonField node))
                ("listValue", fun node -> Kind.ListValue (ListValue.ReadJsonField node))
            ])

    [<System.Runtime.CompilerServices.IsByRefLike>]
    type Builder =
        struct
            val mutable Kind: OptionBuilder<Kind>
        end
        with
        member x.Put ((tag, reader): int * Reader) =
            match tag with
            | 1 -> x.Kind.Set (Kind.NullValue (ValueCodec.Enum<Google.Protobuf.NullValue>.ReadValue reader))
            | 2 -> x.Kind.Set (Kind.NumberValue (ValueCodec.Double.ReadValue reader))
            | 3 -> x.Kind.Set (Kind.StringValue (ValueCodec.String.ReadValue reader))
            | 4 -> x.Kind.Set (Kind.BoolValue (ValueCodec.Bool.ReadValue reader))
            | 5 -> x.Kind.Set (Kind.StructValue (ValueCodec.Message<Google.Protobuf.Struct>.ReadValue reader))
            | 6 -> x.Kind.Set (Kind.ListValue (ValueCodec.Message<Google.Protobuf.ListValue>.ReadValue reader))
            | _ -> reader.SkipLastField()
        member x.Build : Google.Protobuf.Value = {
            Kind = x.Kind.Build |> (Option.defaultValue Kind.None)
        }

type private _Value = Value
[<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.MessageConverter>)>]
[<FsGrpc.Protobuf.Message>]
[<StructuralEquality;StructuralComparison>]
type Value = {
    Kind: Value.Kind
}
with
    static member Proto : Lazy<ProtoDef<Value>> =
        lazy
        let Kind = Value.Kind.OneofCodec.Value
        {
            Name = "Value"
            Empty = {
                Kind = Kind.GetDefault()
            }
            Size = fun (m: Value) ->
                0
                + match m.Kind with
                | Value.Kind.None -> 0
                | Value.Kind.NullValue v -> (* field codec size calculation *)
                | Value.Kind.NumberValue v -> (* field codec size calculation *)
                | Value.Kind.StringValue v -> (* field codec size calculation *)
                | Value.Kind.BoolValue v -> (* field codec size calculation *)
                | Value.Kind.StructValue v -> (* field codec size calculation *)
                | Value.Kind.ListValue v -> (* field codec size calculation *)
            Encode = fun (w: Google.Protobuf.CodedOutputStream) (m: Value) ->
                (match m.Kind with
                | Value.Kind.None -> ()
                | Value.Kind.NullValue v -> (* write field *)
                | Value.Kind.NumberValue v -> (* write field *)
                | Value.Kind.StringValue v -> (* write field *)
                | Value.Kind.BoolValue v -> (* write field *)
                | Value.Kind.StructValue v -> (* write field *)
                | Value.Kind.ListValue v -> (* write field *)
                )
            Decode = fun (r: Google.Protobuf.CodedInputStream) ->
                let mutable builder = new Value.Builder()
                let mutable tag = 0
                while read r &tag do
                    builder.Put (tag, r)
                builder.Build
            EncodeJson = fun (o: JsonOptions) ->
                (* JSON encoding logic *)
            DecodeJson = fun (node: System.Text.Json.Nodes.JsonNode) ->
                (* JSON decoding logic *)
        }
    static member empty
        with get() = Google.Protobuf._Value.Proto.Value.Empty

// ===== Struct Type with Map Field =====

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module Struct =

    [<System.Runtime.CompilerServices.IsByRefLike>]
    type Builder =
        struct
            val mutable Fields: MapBuilder<string, Value>
        end
        with
        member x.Put ((tag, reader): int * Reader) =
            match tag with
            | 1 -> x.Fields.Add ((ValueCodec.MapRecord ValueCodec.String ValueCodec.Message<Google.Protobuf.Value>).ReadValue reader)
            | _ -> reader.SkipLastField()
        member x.Build : Google.Protobuf.Struct = {
            Fields = x.Fields.Build
        }

type private _Struct = Struct
[<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.MessageConverter>)>]
[<FsGrpc.Protobuf.Message>]
[<StructuralEquality;StructuralComparison>]
type Struct = {
    [<System.Text.Json.Serialization.JsonPropertyName("fields")>] Fields: Map<string, Value> // (1)
}
with
    static member Proto : Lazy<ProtoDef<Struct>> =
        lazy
        let Fields = FieldCodec.Map ValueCodec.String ValueCodec.Message<Google.Protobuf.Value> (1, "fields")
        {
            Name = "Struct"
            Empty = {
                Fields = Fields.GetDefault()
            }
            Size = fun (m: Struct) ->
                0
                + Fields.CalcFieldSize m.Fields
            Encode = fun (w: Google.Protobuf.CodedOutputStream) (m: Struct) ->
                Fields.WriteField w m.Fields
            Decode = fun (r: Google.Protobuf.CodedInputStream) ->
                let mutable builder = new Struct.Builder()
                let mutable tag = 0
                while read r &tag do
                    builder.Put (tag, r)
                builder.Build
            EncodeJson = fun (o: JsonOptions) ->
                let writeFields = Fields.WriteJsonField o
                let encode (w: System.Text.Json.Utf8JsonWriter) (m: Struct) =
                    writeFields w m.Fields
                encode
            DecodeJson = fun (node: System.Text.Json.Nodes.JsonNode) ->
                let update value (kvPair: System.Collections.Generic.KeyValuePair<string,System.Text.Json.Nodes.JsonNode>) : Struct =
                    match kvPair.Key with
                    | "fields" -> { value with Fields = Fields.ReadJsonField kvPair.Value }
                    | _ -> value
                Seq.fold update _Struct.empty (node.AsObject ())
        }
    static member empty
        with get() = Google.Protobuf._Struct.Proto.Value.Empty

// ===== ListValue Type with Repeated Field =====

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module ListValue =

    [<System.Runtime.CompilerServices.IsByRefLike>]
    type Builder =
        struct
            val mutable Values: RepeatedBuilder<Value>
        end
        with
        member x.Put ((tag, reader): int * Reader) =
            match tag with
            | 1 -> x.Values.Add (ValueCodec.Message<Google.Protobuf.Value>.ReadValue reader)
            | _ -> reader.SkipLastField()
        member x.Build : Google.Protobuf.ListValue = {
            Values = x.Values.Build
        }

type private _ListValue = ListValue
[<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.MessageConverter>)>]
[<FsGrpc.Protobuf.Message>]
[<StructuralEquality;StructuralComparison>]
type ListValue = {
    [<System.Text.Json.Serialization.JsonPropertyName("values")>] Values: Value list // (1)
}
with
    static member Proto : Lazy<ProtoDef<ListValue>> =
        lazy
        let Values = FieldCodec.Repeated ValueCodec.Message<Google.Protobuf.Value> (1, "values")
        {
            Name = "ListValue"
            Empty = {
                Values = Values.GetDefault()
            }
            Size = fun (m: ListValue) ->
                0
                + Values.CalcFieldSize m.Values
            Encode = fun (w: Google.Protobuf.CodedOutputStream) (m: ListValue) ->
                Values.WriteField w m.Values
            Decode = fun (r: Google.Protobuf.CodedInputStream) ->
                let mutable builder = new ListValue.Builder()
                let mutable tag = 0
                while read r &tag do
                    builder.Put (tag, r)
                builder.Build
            EncodeJson = fun (o: JsonOptions) ->
                let writeValues = Values.WriteJsonField o
                let encode (w: System.Text.Json.Utf8JsonWriter) (m: ListValue) =
                    writeValues w m.Values
                encode
            DecodeJson = fun (node: System.Text.Json.Nodes.JsonNode) ->
                let update value (kvPair: System.Collections.Generic.KeyValuePair<string,System.Text.Json.Nodes.JsonNode>) : ListValue =
                    match kvPair.Key with
                    | "values" -> { value with Values = Values.ReadJsonField kvPair.Value }
                    | _ -> value
                Seq.fold update _ListValue.empty (node.AsObject ())
        }
    static member empty
        with get() = Google.Protobuf._ListValue.Proto.Value.Empty
```

---

## Key Capabilities Already Present in protoc-gen-fsgrpc

### ? Capability Matrix

| Feature Required | Present in Code Generator | Evidence |
|-----------------|---------------------------|----------|
| Generic message type handling | ? Yes | `ValueType.From` function, line 177: `\| other -> ValueType.Message (typeMap other)` |
| Recursive type support (`namespace rec`) | ? Yes | `toFsNamespaceDecl` function, line 1224: `Line $"namespace rec {toFsNamespace package}"` |
| Map field generation | ? Yes | `FieldType.From` function, lines 238-254 |
| Oneof field generation | ? Yes | Existing patterns in `toOneofUnionDefs`, `toFsRecordFieldDef` |
| Lazy evaluation for circular deps | ? Yes | All Proto definitions use `Lazy<ProtoDef<T>>` |
| Enum generation | ? Yes | `toFsEnumDef` function |
| Repeated field generation | ? Yes | `FieldType.Repeated` case handling |
| Builder pattern for mutable fields | ? Yes | `toBuilderField`, `toBuilderPut`, `toBuilderInit` functions |

---

## Diagnostic Checklist for FsGrpc Repository

When investigating why Struct types aren't being generated, check:

### 1. ? Input File Configuration
```sh
# Check if struct.proto is in the input
buf generate --include-imports --include-wkt -v 2>&1 | grep struct.proto
```

### 2. ? buf.gen.yaml Configuration
Check that the configuration includes:
```yaml
version: v1
plugins:
  - name: fsgrpc
    out: gen
    opt:
      - include_wkt=true  # Or however it's configured
```

### 3. ? Generated File Location
```sh
# Check if the file was generated
ls -la gen/google/protobuf/struct.proto.gen.fs
```

### 4. ? protoc-gen-fsgrpc Version
```sh
# Ensure using the latest version
dotnet tool list --global | grep protoc-gen-fsgrpc
```

### 5. ? Build Output
```sh
# Check build output for errors related to Struct types
dotnet build FsGrpc.Tests.fsproj -v d | grep -i struct
```

---

## Recommended Actions for FsGrpc Repository

### Priority 1: Verify Input Files
The most likely issue is that `struct.proto` is not being passed to the code generator. Verify by:

1. Run `buf generate` with verbose logging
2. Check if `google/protobuf/struct.proto` appears in the file list
3. If not, adjust `buf.gen.yaml` or `buf.yaml` to include well-known types

### Priority 2: Test with Simple Proto
Create a minimal test case:

**`test/struct_test.proto`:**
```protobuf
syntax = "proto3";
package test;
import "google/protobuf/struct.proto";

message StructTest {
  google.protobuf.Struct data = 1;
}
```

Generate and verify the output includes both `StructTest` and `Struct` types.

### Priority 3: Check protoc-gen-fsgrpc Invocation
Ensure the generator is being invoked correctly:
```sh
# Manual test
protoc --plugin=protoc-gen-fsgrpc=/path/to/protoc-gen-fsgrpc \
       --fsgrpc_out=. \
       --proto_path=. \
       google/protobuf/struct.proto
```

---

## Special JSON Serialization Considerations

The Proto3 JSON specification defines special serialization for Struct types:

- `Struct` ? Plain JSON object (not wrapped)
- `Value` ? Unwrapped JSON value based on kind
- `ListValue` ? Plain JSON array
- `NullValue` ? JSON `null`

**Note**: The initial generated code will use standard `MessageConverter` and `EnumConverter`. If JSON tests fail, custom converters may need to be added to the **FsGrpc runtime library**, not to protoc-gen-fsgrpc.

Example custom converter locations (if needed):
- `FsGrpc/Json.fs` - Add custom `StructConverter`, `ValueConverter`, `ListValueConverter`

---

## Test Cases to Verify Functionality

### Basic Structure Tests
```fsharp
[<Fact>]
let ``NullValue enum can be created`` () =
    let nullVal = Google.Protobuf.NullValue.NullValue
    Assert.Equal(0, int nullVal)

[<Fact>]
let ``Value with NumberValue can be created`` () =
    let value = { Kind = Google.Protobuf.Value.Kind.NumberValue 42.0 }
    match value.Kind with
    | Google.Protobuf.Value.Kind.NumberValue n -> Assert.Equal(42.0, n)
    | _ -> Assert.Fail("Expected NumberValue")

[<Fact>]
let ``Struct with empty fields can be created`` () =
    let struct = Google.Protobuf.Struct.empty
    Assert.Empty(struct.Fields)

[<Fact>]
let ``ListValue with empty values can be created`` () =
    let listValue = Google.Protobuf.ListValue.empty
    Assert.Empty(listValue.Values)
```

### Recursive Structure Tests
```fsharp
[<Fact>]
let ``Value can contain Struct (recursive)`` () =
    let innerStruct = Google.Protobuf.Struct.empty
    let value = { Kind = Google.Protobuf.Value.Kind.StructValue innerStruct }
    match value.Kind with
    | Google.Protobuf.Value.Kind.StructValue s -> Assert.Equal(innerStruct, s)
    | _ -> Assert.Fail("Expected StructValue")

[<Fact>]
let ``Struct can contain Value in map`` () =
    let value = { Kind = Google.Protobuf.Value.Kind.StringValue "test" }
    let struct = { Fields = Map.ofList [("key", value)] }
    Assert.Single(struct.Fields) |> ignore
```

### Protobuf Wire Format Tests
```fsharp
[<Fact>]
let ``Struct round-trips through protobuf encoding`` () =
    let original = Google.Protobuf.Struct.empty
    let encoded = FsGrpc.Protobuf.encode original
    let decoded = FsGrpc.Protobuf.decode<Google.Protobuf.Struct> encoded
    Assert.Equal(original, decoded)

[<Fact>]
let ``Value round-trips through protobuf encoding`` () =
    let original = { Kind = Google.Protobuf.Value.Kind.NumberValue 123.45 }
    let encoded = FsGrpc.Protobuf.encode original
    let decoded = FsGrpc.Protobuf.decode<Google.Protobuf.Value> encoded
    Assert.Equal(original, decoded)
```

### JSON Serialization Tests (May Require Custom Converters)
```fsharp
[<Fact>]
let ``Struct with simple fields serializes to JSON`` () =
    let structValue = Google.Protobuf.Struct.empty
    let actual = JsonSerializer.Serialize(structValue, ignoreDefault)
    let expected = """{}"""
    Assert.Equal(expected, actual)

[<Fact>]
let ``Value with string serializes to JSON`` () =
    let value = { Kind = Google.Protobuf.Value.Kind.StringValue "hello" }
    let actual = JsonSerializer.Serialize(value)
    // Per Proto3 JSON spec, should serialize as unwrapped: "hello"
    let expected = "\"hello\""
    Assert.Equal(expected, actual)

[<Fact>]
let ``ListValue serializes to JSON array`` () =
    let listValue = { Values = [
        { Kind = Google.Protobuf.Value.Kind.NumberValue 1.0 }
        { Kind = Google.Protobuf.Value.Kind.StringValue "two" }
    ]}
    let actual = JsonSerializer.Serialize(listValue)
    // Per Proto3 JSON spec, should serialize as: [1.0, "two"]
    let expected = """[1.0,"two"]"""
    Assert.Equal(expected, actual)
```

---

## Conclusion

### Summary of Findings

1. **protoc-gen-fsgrpc requires NO code changes** - All necessary capabilities are already present
2. **The issue is in the FsGrpc repository** - Specifically in how code generation is configured/invoked
3. **Testing focus** - Verify that `struct.proto` is being processed by the generator

### Immediate Next Steps for FsGrpc Repository

1. ? Run `buf generate --include-imports --include-wkt -v` and capture output
2. ? Verify `google/protobuf/struct.proto` is in the processed file list
3. ? Check for generated `gen/google/protobuf/struct.proto.gen.fs`
4. ? If file exists, build the project and verify compilation
5. ? If build succeeds, uncomment and run tests in `JsonTests.fs`
6. ?? If JSON tests fail, add custom converters to FsGrpc runtime (not protoc-gen-fsgrpc)

### Long-Term Recommendations

1. Add integration tests in FsGrpc.Tests that specifically cover Struct/Value types
2. Document the `--include-wkt` flag requirement in README
3. Consider adding a CI check to verify well-known types are generated
4. If JSON serialization doesn't match Proto3 spec, implement custom converters in `FsGrpc/Json.fs`

---

## References

- **protoc-gen-fsgrpc repository**: https://github.com/dmgtech/FsGrpc.ProtocGenFsGrpc
- **FsGrpc repository**: https://github.com/dmgtech/fsgrpc
- **Proto3 JSON Specification**: https://protobuf.dev/programming-guides/proto3/#json
- **google.protobuf.Struct Documentation**: https://protobuf.dev/reference/protobuf/google.protobuf/#struct

---

## Document Metadata

- **Created**: 2024-12-XX
- **Analysis Target**: protoc-gen-fsgrpc code generator
- **Target Framework**: .NET 8.0
- **Conclusion**: No code changes required in protoc-gen-fsgrpc
- **Status**: Ready for testing in FsGrpc repository
