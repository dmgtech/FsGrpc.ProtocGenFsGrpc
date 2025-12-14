# Struct Support Implementation Guide for protoc-gen-fsgrpc

## Context

This document provides instructions for implementing code generation support for `google.protobuf.Struct` and `google.protobuf.Value` types in the `protoc-gen-fsgrpc` code generator.

### Background

The FsGrpc runtime library currently supports most Protocol Buffer well-known types (Duration, Timestamp, Wrappers), but does not generate F# code for `google.protobuf.Struct` and `google.protobuf.Value`. These types are used to represent arbitrary JSON-like structured data in Protocol Buffers.

## Problem Statement

When running `buf generate --include-imports --include-wkt` in the FsGrpc.Tests project, the code generator does not produce F# bindings for:
- `google.protobuf.Struct`
- `google.protobuf.Value`
- `google.protobuf.ListValue`
- `google.protobuf.NullValue`

This causes compilation errors when trying to use these types in F# code.

### Expected Error
```
FS0039: The value, constructor, namespace or type 'Struct' is not defined in 'Google.Protobuf'
```

## Protocol Buffer Definitions

### struct.proto Structure

```protobuf
// google/protobuf/struct.proto
message Struct {
  map<string, Value> fields = 1;
}

message Value {
  oneof kind {
    NullValue null_value = 1;
    double number_value = 2;
    string string_value = 3;
    bool bool_value = 4;
    Struct struct_value = 5;
    ListValue list_value = 6;
  }
}

message ListValue {
  repeated Value values = 1;
}

enum NullValue {
  NULL_VALUE = 0;
}
```

### Key Characteristics

1. **Recursive Structure**: `Struct` contains `Value`, and `Value` can contain `Struct` (mutual recursion)
2. **Map Field**: `Struct.fields` is a `map<string, Value>`
3. **Oneof Field**: `Value` is a discriminated union with 6 cases
4. **Special JSON Serialization**: These types have custom JSON representations per Proto3 JSON spec

## Expected F# Generated Code

### Location
Generated code should appear in:
```
FsGrpc.Tests/gen/google/protobuf/struct.proto.gen.fs
```

### Expected F# Type Structure

Based on the pattern used for other well-known types in FsGrpc:

```fsharp
namespace rec Google.Protobuf
open FsGrpc.Protobuf
open Google.Protobuf
#nowarn "40"
#nowarn "1182"

// NullValue enum
[<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.EnumConverter<NullValue>>)>]
type NullValue =
| [<FsGrpc.Protobuf.ProtobufName("NULL_VALUE")>] NullValue = 0

// Value discriminated union (oneof)
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

    type Builder = // ... builder implementation

type private _Value = Value
[<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.MessageConverter>)>]
[<FsGrpc.Protobuf.Message>]
[<StructuralEquality;StructuralComparison>]
type Value = {
    Kind: Value.Kind
}
with
    static member Proto : Lazy<ProtoDef<Value>> = // ... proto definition
    static member empty = // ... empty value

// Struct type
[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module Struct =
    type Builder = // ... builder with MapBuilder<string, Value>

type private _Struct = Struct
[<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.MessageConverter>)>]
[<FsGrpc.Protobuf.Message>]
[<StructuralEquality;StructuralComparison>]
type Struct = {
    [<System.Text.Json.Serialization.JsonPropertyName("fields")>] Fields: Map<string, Value>
}
with
    static member Proto : Lazy<ProtoDef<Struct>> = // ... proto definition
    static member empty = // ... empty struct

// ListValue type
[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module ListValue =
    type Builder = // ... builder with RepeatedBuilder<Value>

type private _ListValue = ListValue
[<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.MessageConverter>)>]
[<FsGrpc.Protobuf.Message>]
[<StructuralEquality;StructuralComparison>]
type ListValue = {
    [<System.Text.Json.Serialization.JsonPropertyName("values")>] Values: Value list
}
with
    static member Proto : Lazy<ProtoDef<ListValue>> = // ... proto definition
    static member empty = // ... empty list value
```

## Implementation Requirements

### 1. Code Generator Changes

The protoc-gen-fsgrpc plugin needs to:

1. **Process struct.proto**: Ensure `google/protobuf/struct.proto` is included when `--include-wkt` flag is used
2. **Handle Recursive Types**: Generate forward declarations using `rec` keyword in the namespace
3. **Generate Map Fields**: Use `MapBuilder<string, Value>` in the Builder and `Map<string, Value>` in the record
4. **Generate Oneof with Recursive Case**: Handle the `Value.Kind` oneof that contains a `StructValue` case pointing back to `Struct`

### 2. Special Considerations

#### Recursive Type Handling
```fsharp
namespace rec Google.Protobuf  // <-- rec keyword needed
```

#### Builder for Recursive Types
The Builder needs to handle the mutual recursion:
```fsharp
type Builder =
    struct
        val mutable Kind: OptionBuilder<Value.Kind>
    end
```

#### Proto Definition with Lazy Evaluation
The `Proto` property must use `lazy` to handle circular dependencies:
```fsharp
static member Proto : Lazy<ProtoDef<Value>> =
    lazy
    // ... implementation that references Struct.Proto
```

### 3. JSON Serialization Special Cases

Per Proto3 JSON specification:
- `Struct` serializes directly as a JSON object (not wrapped)
- `Value` serializes as the underlying JSON value type (not as an object with a "kind" field)
- `ListValue` serializes as a JSON array
- `NullValue` serializes as JSON `null`

This may require custom JSON converters in the FsGrpc runtime library, but the generated code should use the standard converters initially.

## Reference Examples

### Existing Pattern: Oneof with Message Types
See `gen/testproto.proto.gen.fs` - `Enums.UnionCase`:
```fsharp
type UnionCase =
| None
| Color of Test.Name.Space.Enums.Color
| Name of string
```

### Existing Pattern: Map Fields
See `gen/testproto.proto.gen.fs` - `IntMap`:
```fsharp
type IntMap = {
    IntMap: Map<int, string>
}
```

### Existing Pattern: Recursive Types
See `gen/testproto.proto.gen.fs` - `Nest`:
```fsharp
type Nest = {
    Children: Test.Name.Space.Nest list  // Self-referential
}
```

### Existing Pattern: Well-Known Types
See `gen/google/protobuf/wrappers.proto.gen.fs` for how other well-known types are generated.

## Testing Strategy

Once implemented, verify by:

1. Run `buf generate --include-imports --include-wkt` in FsGrpc.Tests directory
2. Check that `gen/google/protobuf/struct.proto.gen.fs` is created
3. Build FsGrpc.Tests project - should compile without errors
4. The test file at `FsGrpc.Tests/JsonTests.fs` has commented-out tests that can be uncommented to verify functionality

## Test Cases to Enable

Location: `FsGrpc.Tests/JsonTests.fs` (lines ~680-720)

```fsharp
[<Fact>]
let ``Struct with simple fields serializes to JSON`` () =
    let structValue = Google.Protobuf.Struct.empty
    let actual = JsonSerializer.Serialize(structValue, ignoreDefault)
    let expected = """{}"""
    Assert.Equal(expected, actual)

[<Fact>]
let ``Struct deserializes from JSON`` () =
    let json = """{"name":"test","count":42,"active":true}"""
    let actual : Google.Protobuf.Struct = JsonSerializer.Deserialize(json)
    Assert.NotNull(actual)

[<Fact>]
let ``Struct round-trips through JSON`` () =
    let original = Google.Protobuf.Struct.empty
    let serialized = JsonSerializer.Serialize(original)
    let deserialized : Google.Protobuf.Struct = JsonSerializer.Deserialize(serialized)
    Assert.Equal(original, deserialized)
```

## Dependencies

### FsGrpc Runtime Support
The generated code depends on these primitives from `FsGrpc.Protobuf`:
- `ValueCodec.Double`
- `ValueCodec.String`
- `ValueCodec.Bool`
- `ValueCodec.Enum<NullValue>`
- `ValueCodec.Message<Struct>` (recursive)
- `ValueCodec.Message<ListValue>`
- `FieldCodec.Map` for the fields map
- `FieldCodec.Repeated` for ListValue.values
- `FieldCodec.OneofCase` for Value.Kind cases
- `MapBuilder<'K,'V>`
- `OptionBuilder<'T>`
- `RepeatedBuilder<'T>`

These already exist in the FsGrpc runtime, so no changes should be needed there initially.

## Success Criteria

1. ? `struct.proto` is processed by the code generator
2. ? Generated file `struct.proto.gen.fs` appears in correct location
3. ? FsGrpc.Tests project compiles without errors
4. ? `Google.Protobuf.Struct.empty` is accessible from F# code
5. ? Struct types can be serialized to/from protocol buffer wire format
6. ? Struct types can be serialized to/from JSON
7. ? Test cases in JsonTests.fs pass when uncommented

## Questions to Answer During Implementation

1. Does buf/protoc already provide struct.proto, or does it need to be added explicitly?
2. How does the code generator handle the `rec` keyword for mutually recursive types?
3. Are there existing test cases in protoc-gen-fsgrpc for recursive message types?
4. Does the generator need special handling for the Proto3 JSON canonical representation of Struct?

## Next Steps After protoc-gen-fsgrpc Changes

After implementing in protoc-gen-fsgrpc:
1. Return to FsGrpc repository
2. Re-run code generation: `cd FsGrpc\FsGrpc.Tests && buf generate --include-imports --include-wkt`
3. Verify generated code appears
4. Uncomment tests in `JsonTests.fs`
5. Run tests to verify functionality
6. Add any needed runtime support to `FsGrpc\Protobuf.fs` if tests fail

## Additional Resources

- Proto3 JSON Specification: https://protobuf.dev/programming-guides/proto3/#json
- google.protobuf.Struct documentation: https://protobuf.dev/reference/protobuf/google.protobuf/#struct
- FsGrpc GitHub: https://github.com/dmgtech/fsgrpc
