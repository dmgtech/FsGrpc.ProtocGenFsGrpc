namespace rec Ex.Ample
open FsGrpc.Protobuf
open Google.Protobuf
#nowarn "40"
#nowarn "1182"


/// <summary>This is an enumeration</summary>
[<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.EnumConverter<EnumType>>)>]
type EnumType =
/// <summary>This is a (default) enumeraton option</summary>
| [<FsGrpc.Protobuf.ProtobufName("ENUM_TYPE_NONE")>] None = 0
/// <summary>This is another enumeration option</summary>
| [<FsGrpc.Protobuf.ProtobufName("ENUM_TYPE_ONE")>] One = 1
| [<FsGrpc.Protobuf.ProtobufName("ENUM_TYPE_TWO")>] Two = 2

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module Inner =

    [<System.Runtime.CompilerServices.IsByRefLike>]
    type Builder =
        struct
            val mutable IntFixed: int // (13)
            val mutable LongFixed: int64 // (14)
            val mutable ZigzagInt: int // (15)
            val mutable ZigzagLong: int64 // (16)
            val mutable Nested: OptionBuilder<Ex.Ample.Outer.Nested> // (17)
            val mutable NestedEnum: Ex.Ample.Outer.NestEnumeration // (18)
        end
        with
        member x.Put ((tag, reader): int * Reader) =
            match tag with
            | 13 -> x.IntFixed <- ValueCodec.SFixed32.ReadValue reader
            | 14 -> x.LongFixed <- ValueCodec.SFixed64.ReadValue reader
            | 15 -> x.ZigzagInt <- ValueCodec.SInt32.ReadValue reader
            | 16 -> x.ZigzagLong <- ValueCodec.SInt64.ReadValue reader
            | 17 -> x.Nested.Set (ValueCodec.Message<Ex.Ample.Outer.Nested>.ReadValue reader)
            | 18 -> x.NestedEnum <- ValueCodec.Enum<Ex.Ample.Outer.NestEnumeration>.ReadValue reader
            | _ -> reader.SkipLastField()
        member x.Build : Ex.Ample.Inner = {
            IntFixed = x.IntFixed
            LongFixed = x.LongFixed
            ZigzagInt = x.ZigzagInt
            ZigzagLong = x.ZigzagLong
            Nested = x.Nested.Build
            NestedEnum = x.NestedEnum
            }

/// <summary>
/// This is a comment
///    that has multiple lines, where subsequent lines
///    exhibit indentation
/// 
/// We want to ensure that the indentation
///    of comments like these
///    is preserved
/// </summary>
type private _Inner = Inner
[<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.MessageConverter>)>]
[<FsGrpc.Protobuf.Message>]
[<StructuralEquality;StructuralComparison>]
type Inner = {
    // Field Declarations
    [<System.Text.Json.Serialization.JsonPropertyName("intFixed")>] IntFixed: int // (13)
    [<System.Text.Json.Serialization.JsonPropertyName("longFixed")>] LongFixed: int64 // (14)
    [<System.Text.Json.Serialization.JsonPropertyName("zigzagInt")>] ZigzagInt: int // (15)
    [<System.Text.Json.Serialization.JsonPropertyName("zigzagLong")>] ZigzagLong: int64 // (16)
    [<System.Text.Json.Serialization.JsonPropertyName("nested")>] Nested: Ex.Ample.Outer.Nested option // (17)
    [<System.Text.Json.Serialization.JsonPropertyName("nestedEnum")>] NestedEnum: Ex.Ample.Outer.NestEnumeration // (18)
    }
    with
    static member Proto : Lazy<ProtoDef<Inner>> =
        lazy
        // Field Definitions
        let IntFixed = FieldCodec.Primitive ValueCodec.SFixed32 (13, "intFixed")
        let LongFixed = FieldCodec.Primitive ValueCodec.SFixed64 (14, "longFixed")
        let ZigzagInt = FieldCodec.Primitive ValueCodec.SInt32 (15, "zigzagInt")
        let ZigzagLong = FieldCodec.Primitive ValueCodec.SInt64 (16, "zigzagLong")
        let Nested = FieldCodec.Optional ValueCodec.Message<Ex.Ample.Outer.Nested> (17, "nested")
        let NestedEnum = FieldCodec.Primitive ValueCodec.Enum<Ex.Ample.Outer.NestEnumeration> (18, "nestedEnum")
        // Proto Definition Implementation
        { // ProtoDef<Inner>
            Name = "Inner"
            Empty = {
                IntFixed = IntFixed.GetDefault()
                LongFixed = LongFixed.GetDefault()
                ZigzagInt = ZigzagInt.GetDefault()
                ZigzagLong = ZigzagLong.GetDefault()
                Nested = Nested.GetDefault()
                NestedEnum = NestedEnum.GetDefault()
                }
            Size = fun (m: Inner) ->
                0
                + IntFixed.CalcFieldSize m.IntFixed
                + LongFixed.CalcFieldSize m.LongFixed
                + ZigzagInt.CalcFieldSize m.ZigzagInt
                + ZigzagLong.CalcFieldSize m.ZigzagLong
                + Nested.CalcFieldSize m.Nested
                + NestedEnum.CalcFieldSize m.NestedEnum
            Encode = fun (w: Google.Protobuf.CodedOutputStream) (m: Inner) ->
                IntFixed.WriteField w m.IntFixed
                LongFixed.WriteField w m.LongFixed
                ZigzagInt.WriteField w m.ZigzagInt
                ZigzagLong.WriteField w m.ZigzagLong
                Nested.WriteField w m.Nested
                NestedEnum.WriteField w m.NestedEnum
            Decode = fun (r: Google.Protobuf.CodedInputStream) ->
                let mutable builder = new Ex.Ample.Inner.Builder()
                let mutable tag = 0
                while read r &tag do
                    builder.Put (tag, r)
                builder.Build
            EncodeJson = fun (o: JsonOptions) ->
                let writeIntFixed = IntFixed.WriteJsonField o
                let writeLongFixed = LongFixed.WriteJsonField o
                let writeZigzagInt = ZigzagInt.WriteJsonField o
                let writeZigzagLong = ZigzagLong.WriteJsonField o
                let writeNested = Nested.WriteJsonField o
                let writeNestedEnum = NestedEnum.WriteJsonField o
                let encode (w: System.Text.Json.Utf8JsonWriter) (m: Inner) =
                    writeIntFixed w m.IntFixed
                    writeLongFixed w m.LongFixed
                    writeZigzagInt w m.ZigzagInt
                    writeZigzagLong w m.ZigzagLong
                    writeNested w m.Nested
                    writeNestedEnum w m.NestedEnum
                encode
            DecodeJson = fun (node: System.Text.Json.Nodes.JsonNode) ->
                let update value (kvPair: System.Collections.Generic.KeyValuePair<string,System.Text.Json.Nodes.JsonNode>) : Inner =
                    match kvPair.Key with
                    | "intFixed" -> { value with IntFixed = IntFixed.ReadJsonField kvPair.Value }
                    | "longFixed" -> { value with LongFixed = LongFixed.ReadJsonField kvPair.Value }
                    | "zigzagInt" -> { value with ZigzagInt = ZigzagInt.ReadJsonField kvPair.Value }
                    | "zigzagLong" -> { value with ZigzagLong = ZigzagLong.ReadJsonField kvPair.Value }
                    | "nested" -> { value with Nested = Nested.ReadJsonField kvPair.Value }
                    | "nestedEnum" -> { value with NestedEnum = NestedEnum.ReadJsonField kvPair.Value }
                    | _ -> value
                Seq.fold update _Inner.empty (node.AsObject ())
        }
    static member empty
        with get() = Ex.Ample._Inner.Proto.Value.Empty

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module Outer =

    [<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.OneofConverter<UnionCase>>)>]
    [<CompilationRepresentation(CompilationRepresentationFlags.UseNullAsTrueValue)>]
    [<StructuralEquality;StructuralComparison>]
    [<RequireQualifiedAccess>]
    type UnionCase =
    | None
    /// <summary>a oneof option that is a message</summary>
    | [<System.Text.Json.Serialization.JsonPropertyName("innerOption")>] InnerOption of Ex.Ample.Inner
    /// <summary>a oneof option that is a string</summary>
    | [<System.Text.Json.Serialization.JsonPropertyName("stringOption")>] StringOption of string
    /// <summary>a message type from another file</summary>
    | [<System.Text.Json.Serialization.JsonPropertyName("importedOption")>] ImportedOption of Ex.Ample.Importable.Args
    /// <summary>the fsgrpc bytes type</summary>
    | [<System.Text.Json.Serialization.JsonPropertyName("bytesOption")>] BytesOption of FsGrpc.Bytes
    with
        static member OneofCodec : Lazy<OneofCodec<UnionCase>> = 
            lazy
            let InnerOption = FieldCodec.OneofCase "union" ValueCodec.Message<Ex.Ample.Inner> (25, "innerOption")
            let StringOption = FieldCodec.OneofCase "union" ValueCodec.String (26, "stringOption")
            let ImportedOption = FieldCodec.OneofCase "union" ValueCodec.Message<Ex.Ample.Importable.Args> (30, "importedOption")
            let BytesOption = FieldCodec.OneofCase "union" ValueCodec.Bytes (48, "bytesOption")
            let Union = FieldCodec.Oneof "union" (FSharp.Collections.Map [
                ("innerOption", fun node -> UnionCase.InnerOption (InnerOption.ReadJsonField node))
                ("stringOption", fun node -> UnionCase.StringOption (StringOption.ReadJsonField node))
                ("importedOption", fun node -> UnionCase.ImportedOption (ImportedOption.ReadJsonField node))
                ("bytesOption", fun node -> UnionCase.BytesOption (BytesOption.ReadJsonField node))
                ])
            Union

    [<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    module Nested =

        [<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
        module DoubleNested =

            [<System.Runtime.CompilerServices.IsByRefLike>]
            type Builder =
                struct
                end
                with
                member x.Put ((tag, reader): int * Reader) =
                    match tag with
                    | _ -> reader.SkipLastField()
                member x.Build = DoubleNested.empty

        [<StructuralEquality;StructuralComparison>]
        type DoubleNested = | Unused
            with
            static member empty = Unused 
            static member Proto : Lazy<ProtoDef<DoubleNested>> =
                lazy
                // Proto Definition Implementation
                { // ProtoDef<DoubleNested>
                    Name = "DoubleNested"
                    Empty = DoubleNested.empty
                    Size = fun (m: DoubleNested) ->
                        0
                    Encode = fun (w: Google.Protobuf.CodedOutputStream) (m: DoubleNested) ->
                        ()
                    Decode = fun (r: Google.Protobuf.CodedInputStream) ->
                        let mutable tag = 0
                        while read r &tag do
                            r.SkipLastField()
                        DoubleNested.empty
                    EncodeJson = fun _ _ _ -> ()
                    DecodeJson = fun _ -> DoubleNested.empty
                }

        [<System.Runtime.CompilerServices.IsByRefLike>]
        type Builder =
            struct
                val mutable Enums: RepeatedBuilder<Ex.Ample.Outer.NestEnumeration> // (1)
                val mutable Inner: OptionBuilder<Ex.Ample.Inner> // (2)
            end
            with
            member x.Put ((tag, reader): int * Reader) =
                match tag with
                | 1 -> x.Enums.AddRange ((ValueCodec.Packed ValueCodec.Enum<Ex.Ample.Outer.NestEnumeration>).ReadValue reader)
                | 2 -> x.Inner.Set (ValueCodec.Message<Ex.Ample.Inner>.ReadValue reader)
                | _ -> reader.SkipLastField()
            member x.Build : Ex.Ample.Outer.Nested = {
                Enums = x.Enums.Build
                Inner = x.Inner.Build
                }

    type private _Nested = Nested
    [<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.MessageConverter>)>]
    [<FsGrpc.Protobuf.Message>]
    [<StructuralEquality;StructuralComparison>]
    type Nested = {
        // Field Declarations
        [<System.Text.Json.Serialization.JsonPropertyName("enums")>] Enums: Ex.Ample.Outer.NestEnumeration list // (1)
        [<System.Text.Json.Serialization.JsonPropertyName("inner")>] Inner: Ex.Ample.Inner option // (2)
        }
        with
        static member Proto : Lazy<ProtoDef<Nested>> =
            lazy
            // Field Definitions
            let Enums = FieldCodec.Primitive (ValueCodec.Packed ValueCodec.Enum<Ex.Ample.Outer.NestEnumeration>) (1, "enums")
            let Inner = FieldCodec.Optional ValueCodec.Message<Ex.Ample.Inner> (2, "inner")
            // Proto Definition Implementation
            { // ProtoDef<Nested>
                Name = "Nested"
                Empty = {
                    Enums = Enums.GetDefault()
                    Inner = Inner.GetDefault()
                    }
                Size = fun (m: Nested) ->
                    0
                    + Enums.CalcFieldSize m.Enums
                    + Inner.CalcFieldSize m.Inner
                Encode = fun (w: Google.Protobuf.CodedOutputStream) (m: Nested) ->
                    Enums.WriteField w m.Enums
                    Inner.WriteField w m.Inner
                Decode = fun (r: Google.Protobuf.CodedInputStream) ->
                    let mutable builder = new Ex.Ample.Outer.Nested.Builder()
                    let mutable tag = 0
                    while read r &tag do
                        builder.Put (tag, r)
                    builder.Build
                EncodeJson = fun (o: JsonOptions) ->
                    let writeEnums = Enums.WriteJsonField o
                    let writeInner = Inner.WriteJsonField o
                    let encode (w: System.Text.Json.Utf8JsonWriter) (m: Nested) =
                        writeEnums w m.Enums
                        writeInner w m.Inner
                    encode
                DecodeJson = fun (node: System.Text.Json.Nodes.JsonNode) ->
                    let update value (kvPair: System.Collections.Generic.KeyValuePair<string,System.Text.Json.Nodes.JsonNode>) : Nested =
                        match kvPair.Key with
                        | "enums" -> { value with Enums = Enums.ReadJsonField kvPair.Value }
                        | "inner" -> { value with Inner = Inner.ReadJsonField kvPair.Value }
                        | _ -> value
                    Seq.fold update _Nested.empty (node.AsObject ())
            }
        static member empty
            with get() = Ex.Ample.Outer._Nested.Proto.Value.Empty

    /// <summary>this enumeration is nested under another class</summary>
    [<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.EnumConverter<NestEnumeration>>)>]
    type NestEnumeration =
    | [<FsGrpc.Protobuf.ProtobufName("NEST_ENUMERATION_BLACK")>] Black = 0
    | [<FsGrpc.Protobuf.ProtobufName("NEST_ENUMERATION_RED")>] Red = 1
    | [<FsGrpc.Protobuf.ProtobufName("NEST_ENUMERATION_BLUE")>] Blue = 2

    [<System.Runtime.CompilerServices.IsByRefLike>]
    type Builder =
        struct
            val mutable DoubleVal: double // (1)
            val mutable FloatVal: float32 // (2)
            val mutable LongVal: int64 // (3)
            val mutable UlongVal: uint64 // (4)
            val mutable IntVal: int // (5)
            val mutable UlongFixed: uint64 // (6)
            val mutable UintFixed: uint // (7)
            val mutable BoolVal: bool // (8)
            val mutable StringVal: string // (9)
            val mutable BytesVal: FsGrpc.Bytes // (10)
            val mutable UintVal: uint32 // (11)
            val mutable EnumVal: Ex.Ample.EnumType // (12)
            val mutable Inner: OptionBuilder<Ex.Ample.Inner> // (17)
            val mutable Doubles: RepeatedBuilder<double> // (18)
            val mutable Inners: RepeatedBuilder<Ex.Ample.Inner> // (19)
            val mutable Map: MapBuilder<string, string> // (20)
            val mutable MapInner: MapBuilder<string, Ex.Ample.Inner> // (21)
            val mutable MapInts: MapBuilder<int64, int> // (22)
            val mutable MapBool: MapBuilder<bool, string> // (23)
            val mutable Recursive: OptionBuilder<Ex.Ample.Outer> // (24)
            val mutable Union: OptionBuilder<Ex.Ample.Outer.UnionCase>
            val mutable Nested: OptionBuilder<Ex.Ample.Outer.Nested> // (27)
            val mutable Imported: OptionBuilder<Ex.Ample.Importable.Imported> // (28)
            val mutable EnumImported: Ex.Ample.Importable.Imported.EnumForImport // (29)
            val mutable MaybeDouble: OptionBuilder<double> // (33)
            val mutable MaybeFloat: OptionBuilder<float32> // (34)
            val mutable MaybeInt64: OptionBuilder<int64> // (35)
            val mutable MaybeUint64: OptionBuilder<uint64> // (36)
            val mutable MaybeInt32: OptionBuilder<int> // (37)
            val mutable MaybeUint32: OptionBuilder<uint32> // (38)
            val mutable MaybeBool: OptionBuilder<bool> // (39)
            val mutable MaybeString: OptionBuilder<string> // (40)
            val mutable MaybeBytes: OptionBuilder<FsGrpc.Bytes> // (41)
            val mutable Timestamp: OptionBuilder<NodaTime.Instant> // (42)
            val mutable Duration: OptionBuilder<NodaTime.Duration> // (43)
            val mutable OptionalInt32: OptionBuilder<int> // (44)
            val mutable MaybesInt64: RepeatedBuilder<int64> // (45)
            val mutable Timestamps: RepeatedBuilder<NodaTime.Instant> // (46)
            val mutable Anything: OptionBuilder<FsGrpc.Protobuf.Any> // (47)
        end
        with
        member x.Put ((tag, reader): int * Reader) =
            match tag with
            | 1 -> x.DoubleVal <- ValueCodec.Double.ReadValue reader
            | 2 -> x.FloatVal <- ValueCodec.Float.ReadValue reader
            | 3 -> x.LongVal <- ValueCodec.Int64.ReadValue reader
            | 4 -> x.UlongVal <- ValueCodec.UInt64.ReadValue reader
            | 5 -> x.IntVal <- ValueCodec.Int32.ReadValue reader
            | 6 -> x.UlongFixed <- ValueCodec.Fixed64.ReadValue reader
            | 7 -> x.UintFixed <- ValueCodec.Fixed32.ReadValue reader
            | 8 -> x.BoolVal <- ValueCodec.Bool.ReadValue reader
            | 9 -> x.StringVal <- ValueCodec.String.ReadValue reader
            | 10 -> x.BytesVal <- ValueCodec.Bytes.ReadValue reader
            | 11 -> x.UintVal <- ValueCodec.UInt32.ReadValue reader
            | 12 -> x.EnumVal <- ValueCodec.Enum<Ex.Ample.EnumType>.ReadValue reader
            | 17 -> x.Inner.Set (ValueCodec.Message<Ex.Ample.Inner>.ReadValue reader)
            | 18 -> x.Doubles.AddRange ((ValueCodec.Packed ValueCodec.Double).ReadValue reader)
            | 19 -> x.Inners.Add (ValueCodec.Message<Ex.Ample.Inner>.ReadValue reader)
            | 20 -> x.Map.Add ((ValueCodec.MapRecord ValueCodec.String ValueCodec.String).ReadValue reader)
            | 21 -> x.MapInner.Add ((ValueCodec.MapRecord ValueCodec.String ValueCodec.Message<Ex.Ample.Inner>).ReadValue reader)
            | 22 -> x.MapInts.Add ((ValueCodec.MapRecord ValueCodec.Int64 ValueCodec.Int32).ReadValue reader)
            | 23 -> x.MapBool.Add ((ValueCodec.MapRecord ValueCodec.Bool ValueCodec.String).ReadValue reader)
            | 24 -> x.Recursive.Set (ValueCodec.Message<Ex.Ample.Outer>.ReadValue reader)
            | 25 -> x.Union.Set (UnionCase.InnerOption (ValueCodec.Message<Ex.Ample.Inner>.ReadValue reader))
            | 26 -> x.Union.Set (UnionCase.StringOption (ValueCodec.String.ReadValue reader))
            | 30 -> x.Union.Set (UnionCase.ImportedOption (ValueCodec.Message<Ex.Ample.Importable.Args>.ReadValue reader))
            | 48 -> x.Union.Set (UnionCase.BytesOption (ValueCodec.Bytes.ReadValue reader))
            | 27 -> x.Nested.Set (ValueCodec.Message<Ex.Ample.Outer.Nested>.ReadValue reader)
            | 28 -> x.Imported.Set (ValueCodec.Message<Ex.Ample.Importable.Imported>.ReadValue reader)
            | 29 -> x.EnumImported <- ValueCodec.Enum<Ex.Ample.Importable.Imported.EnumForImport>.ReadValue reader
            | 33 -> x.MaybeDouble.Set ((ValueCodec.Wrap ValueCodec.Double).ReadValue reader)
            | 34 -> x.MaybeFloat.Set ((ValueCodec.Wrap ValueCodec.Float).ReadValue reader)
            | 35 -> x.MaybeInt64.Set ((ValueCodec.Wrap ValueCodec.Int64).ReadValue reader)
            | 36 -> x.MaybeUint64.Set ((ValueCodec.Wrap ValueCodec.UInt64).ReadValue reader)
            | 37 -> x.MaybeInt32.Set ((ValueCodec.Wrap ValueCodec.Int32).ReadValue reader)
            | 38 -> x.MaybeUint32.Set ((ValueCodec.Wrap ValueCodec.UInt32).ReadValue reader)
            | 39 -> x.MaybeBool.Set ((ValueCodec.Wrap ValueCodec.Bool).ReadValue reader)
            | 40 -> x.MaybeString.Set ((ValueCodec.Wrap ValueCodec.String).ReadValue reader)
            | 41 -> x.MaybeBytes.Set ((ValueCodec.Wrap ValueCodec.Bytes).ReadValue reader)
            | 42 -> x.Timestamp.Set (ValueCodec.Timestamp.ReadValue reader)
            | 43 -> x.Duration.Set (ValueCodec.Duration.ReadValue reader)
            | 44 -> x.OptionalInt32.Set (ValueCodec.Int32.ReadValue reader)
            | 45 -> x.MaybesInt64.Add ((ValueCodec.Wrap ValueCodec.Int64).ReadValue reader)
            | 46 -> x.Timestamps.Add (ValueCodec.Timestamp.ReadValue reader)
            | 47 -> x.Anything.Set (ValueCodec.Any.ReadValue reader)
            | _ -> reader.SkipLastField()
        member x.Build : Ex.Ample.Outer = {
            DoubleVal = x.DoubleVal
            FloatVal = x.FloatVal
            LongVal = x.LongVal
            UlongVal = x.UlongVal
            IntVal = x.IntVal
            UlongFixed = x.UlongFixed
            UintFixed = x.UintFixed
            BoolVal = x.BoolVal
            StringVal = x.StringVal |> orEmptyString
            BytesVal = x.BytesVal
            UintVal = x.UintVal
            EnumVal = x.EnumVal
            Inner = x.Inner.Build
            Doubles = x.Doubles.Build
            Inners = x.Inners.Build
            Map = x.Map.Build
            MapInner = x.MapInner.Build
            MapInts = x.MapInts.Build
            MapBool = x.MapBool.Build
            Recursive = x.Recursive.Build
            Union = x.Union.Build |> (Option.defaultValue UnionCase.None)
            Nested = x.Nested.Build
            Imported = x.Imported.Build
            EnumImported = x.EnumImported
            MaybeDouble = x.MaybeDouble.Build
            MaybeFloat = x.MaybeFloat.Build
            MaybeInt64 = x.MaybeInt64.Build
            MaybeUint64 = x.MaybeUint64.Build
            MaybeInt32 = x.MaybeInt32.Build
            MaybeUint32 = x.MaybeUint32.Build
            MaybeBool = x.MaybeBool.Build
            MaybeString = x.MaybeString.Build
            MaybeBytes = x.MaybeBytes.Build
            Timestamp = x.Timestamp.Build
            Duration = x.Duration.Build
            OptionalInt32 = x.OptionalInt32.Build
            MaybesInt64 = x.MaybesInt64.Build
            Timestamps = x.Timestamps.Build
            Anything = x.Anything.Build
            }

/// <summary>This is an "outer" message that will contain other messages</summary>
type private _Outer = Outer
[<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.MessageConverter>)>]
[<FsGrpc.Protobuf.Message>]
[<StructuralEquality;StructuralComparison>]
type Outer = {
    // Field Declarations
    /// <summary>primitive double value</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("doubleVal")>] DoubleVal: double // (1)
    /// <summary>priviate float value</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("floatVal")>] FloatVal: float32 // (2)
    /// <summary>primitive int64 value</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("longVal")>] LongVal: int64 // (3)
    /// <summary>primitive uint64 value</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("ulongVal")>] UlongVal: uint64 // (4)
    /// <summary>primitive int32 value</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("intVal")>] IntVal: int // (5)
    /// <summary>primitive fixed64 value</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("ulongFixed")>] UlongFixed: uint64 // (6)
    /// <summary>primitive fixed32 value</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("uintFixed")>] UintFixed: uint // (7)
    /// <summary>primitive bool value</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("boolVal")>] BoolVal: bool // (8)
    /// <summary>primitive string value</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("stringVal")>] StringVal: string // (9)
    /// <summary>primitive bytes value</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("bytesVal")>] BytesVal: FsGrpc.Bytes // (10)
    /// <summary>primitive uint32 value</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("uintVal")>] UintVal: uint32 // (11)
    /// <summary>enum value</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("enumVal")>] EnumVal: Ex.Ample.EnumType // (12)
    /// <summary>message value (inner)</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("inner")>] Inner: Ex.Ample.Inner option // (17)
    /// <summary>repeated of packable primitive</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("doubles")>] Doubles: double list // (18)
    /// <summary>repeated of message</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("inners")>] Inners: Ex.Ample.Inner list // (19)
    /// <summary>map with string keys</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("map")>] Map: Map<string, string> // (20)
    /// <summary>map with message values</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("mapInner")>] MapInner: Map<string, Ex.Ample.Inner> // (21)
    /// <summary>map with int keys</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("mapInts")>] MapInts: Map<int64, int> // (22)
    /// <summary>map with bool keys (which is allowed 🤷)</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("mapBool")>] MapBool: Map<bool, string> // (23)
    /// <summary>message value of the same type (recursive)</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("recursive")>] Recursive: Ex.Ample.Outer option // (24)
    /// <summary>a oneof value</summary>
    Union: Ex.Ample.Outer.UnionCase
    /// <summary>a message that is defined inside this message</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("nested")>] Nested: Ex.Ample.Outer.Nested option // (27)
    /// <summary>a message type that is imported from another file</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("imported")>] Imported: Ex.Ample.Importable.Imported option // (28)
    /// <summary>an enumeration imported from another file</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("enumImported")>] EnumImported: Ex.Ample.Importable.Imported.EnumForImport // (29)
    /// <summary>a wrapped double value (the old way of doing optional double)</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("maybeDouble")>] MaybeDouble: double option // (33)
    /// <summary>a wrapped float value (the old way of doing optional float)</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("maybeFloat")>] MaybeFloat: float32 option // (34)
    /// <summary>a wrapped int64 value (the old way of doing optional int64)</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("maybeInt64")>] MaybeInt64: int64 option // (35)
    /// <summary>a wrapped uint64 value (the old way of doing optional uint64)</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("maybeUint64")>] MaybeUint64: uint64 option // (36)
    /// <summary>a wrapped int32 value (the old way of doing optional int32)</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("maybeInt32")>] MaybeInt32: int option // (37)
    /// <summary>a wrapped uint32 value (the old way of doing optional uint32)</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("maybeUint32")>] MaybeUint32: uint32 option // (38)
    /// <summary>a wrapped bool value (the old way of doing optional bool)</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("maybeBool")>] MaybeBool: bool option // (39)
    /// <summary>a wrapped string value (the old way of doing optional string)</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("maybeString")>] MaybeString: string option // (40)
    /// <summary>a wrapped bytes value (the old way of doing optional bytes)</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("maybeBytes")>] MaybeBytes: FsGrpc.Bytes option // (41)
    /// <summary>the well-known timestamp</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("timestamp")>] Timestamp: NodaTime.Instant option // (42)
    /// <summary>the well-known duration</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("duration")>] Duration: NodaTime.Duration option // (43)
    /// <summary>a proto3 optional int</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("optionalInt32")>] OptionalInt32: int option // (44)
    /// <summary>a repeated of the old wrapped int64</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("maybesInt64")>] MaybesInt64: int64 list // (45)
    /// <summary>a repeated of the well-known timestamp</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("timestamps")>] Timestamps: NodaTime.Instant list // (46)
    /// <summary>the Any type</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("anything")>] Anything: FsGrpc.Protobuf.Any option // (47)
    }
    with
    static member Proto : Lazy<ProtoDef<Outer>> =
        lazy
        // Field Definitions
        let DoubleVal = FieldCodec.Primitive ValueCodec.Double (1, "doubleVal")
        let FloatVal = FieldCodec.Primitive ValueCodec.Float (2, "floatVal")
        let LongVal = FieldCodec.Primitive ValueCodec.Int64 (3, "longVal")
        let UlongVal = FieldCodec.Primitive ValueCodec.UInt64 (4, "ulongVal")
        let IntVal = FieldCodec.Primitive ValueCodec.Int32 (5, "intVal")
        let UlongFixed = FieldCodec.Primitive ValueCodec.Fixed64 (6, "ulongFixed")
        let UintFixed = FieldCodec.Primitive ValueCodec.Fixed32 (7, "uintFixed")
        let BoolVal = FieldCodec.Primitive ValueCodec.Bool (8, "boolVal")
        let StringVal = FieldCodec.Primitive ValueCodec.String (9, "stringVal")
        let BytesVal = FieldCodec.Primitive ValueCodec.Bytes (10, "bytesVal")
        let UintVal = FieldCodec.Primitive ValueCodec.UInt32 (11, "uintVal")
        let EnumVal = FieldCodec.Primitive ValueCodec.Enum<Ex.Ample.EnumType> (12, "enumVal")
        let Inner = FieldCodec.Optional ValueCodec.Message<Ex.Ample.Inner> (17, "inner")
        let Doubles = FieldCodec.Primitive (ValueCodec.Packed ValueCodec.Double) (18, "doubles")
        let Inners = FieldCodec.Repeated ValueCodec.Message<Ex.Ample.Inner> (19, "inners")
        let Map = FieldCodec.Map ValueCodec.String ValueCodec.String (20, "map")
        let MapInner = FieldCodec.Map ValueCodec.String ValueCodec.Message<Ex.Ample.Inner> (21, "mapInner")
        let MapInts = FieldCodec.Map ValueCodec.Int64 ValueCodec.Int32 (22, "mapInts")
        let MapBool = FieldCodec.Map ValueCodec.Bool ValueCodec.String (23, "mapBool")
        let Recursive = FieldCodec.Optional ValueCodec.Message<Ex.Ample.Outer> (24, "recursive")
        let InnerOption = FieldCodec.OneofCase "union" ValueCodec.Message<Ex.Ample.Inner> (25, "innerOption")
        let StringOption = FieldCodec.OneofCase "union" ValueCodec.String (26, "stringOption")
        let ImportedOption = FieldCodec.OneofCase "union" ValueCodec.Message<Ex.Ample.Importable.Args> (30, "importedOption")
        let BytesOption = FieldCodec.OneofCase "union" ValueCodec.Bytes (48, "bytesOption")
        let Nested = FieldCodec.Optional ValueCodec.Message<Ex.Ample.Outer.Nested> (27, "nested")
        let Imported = FieldCodec.Optional ValueCodec.Message<Ex.Ample.Importable.Imported> (28, "imported")
        let EnumImported = FieldCodec.Primitive ValueCodec.Enum<Ex.Ample.Importable.Imported.EnumForImport> (29, "enumImported")
        let MaybeDouble = FieldCodec.Optional (ValueCodec.Wrap ValueCodec.Double) (33, "maybeDouble")
        let MaybeFloat = FieldCodec.Optional (ValueCodec.Wrap ValueCodec.Float) (34, "maybeFloat")
        let MaybeInt64 = FieldCodec.Optional (ValueCodec.Wrap ValueCodec.Int64) (35, "maybeInt64")
        let MaybeUint64 = FieldCodec.Optional (ValueCodec.Wrap ValueCodec.UInt64) (36, "maybeUint64")
        let MaybeInt32 = FieldCodec.Optional (ValueCodec.Wrap ValueCodec.Int32) (37, "maybeInt32")
        let MaybeUint32 = FieldCodec.Optional (ValueCodec.Wrap ValueCodec.UInt32) (38, "maybeUint32")
        let MaybeBool = FieldCodec.Optional (ValueCodec.Wrap ValueCodec.Bool) (39, "maybeBool")
        let MaybeString = FieldCodec.Optional (ValueCodec.Wrap ValueCodec.String) (40, "maybeString")
        let MaybeBytes = FieldCodec.Optional (ValueCodec.Wrap ValueCodec.Bytes) (41, "maybeBytes")
        let Timestamp = FieldCodec.Optional ValueCodec.Timestamp (42, "timestamp")
        let Duration = FieldCodec.Optional ValueCodec.Duration (43, "duration")
        let OptionalInt32 = FieldCodec.Optional ValueCodec.Int32 (44, "optionalInt32")
        let MaybesInt64 = FieldCodec.Repeated (ValueCodec.Wrap ValueCodec.Int64) (45, "maybesInt64")
        let Timestamps = FieldCodec.Repeated ValueCodec.Timestamp (46, "timestamps")
        let Anything = FieldCodec.Optional ValueCodec.Any (47, "anything")
        let Union = FieldCodec.Oneof "union" (FSharp.Collections.Map [
            ("innerOption", fun node -> Ex.Ample.Outer.UnionCase.InnerOption (InnerOption.ReadJsonField node))
            ("stringOption", fun node -> Ex.Ample.Outer.UnionCase.StringOption (StringOption.ReadJsonField node))
            ("importedOption", fun node -> Ex.Ample.Outer.UnionCase.ImportedOption (ImportedOption.ReadJsonField node))
            ("bytesOption", fun node -> Ex.Ample.Outer.UnionCase.BytesOption (BytesOption.ReadJsonField node))
            ])
        // Proto Definition Implementation
        { // ProtoDef<Outer>
            Name = "Outer"
            Empty = {
                DoubleVal = DoubleVal.GetDefault()
                FloatVal = FloatVal.GetDefault()
                LongVal = LongVal.GetDefault()
                UlongVal = UlongVal.GetDefault()
                IntVal = IntVal.GetDefault()
                UlongFixed = UlongFixed.GetDefault()
                UintFixed = UintFixed.GetDefault()
                BoolVal = BoolVal.GetDefault()
                StringVal = StringVal.GetDefault()
                BytesVal = BytesVal.GetDefault()
                UintVal = UintVal.GetDefault()
                EnumVal = EnumVal.GetDefault()
                Inner = Inner.GetDefault()
                Doubles = Doubles.GetDefault()
                Inners = Inners.GetDefault()
                Map = Map.GetDefault()
                MapInner = MapInner.GetDefault()
                MapInts = MapInts.GetDefault()
                MapBool = MapBool.GetDefault()
                Recursive = Recursive.GetDefault()
                Union = Ex.Ample.Outer.UnionCase.None
                Nested = Nested.GetDefault()
                Imported = Imported.GetDefault()
                EnumImported = EnumImported.GetDefault()
                MaybeDouble = MaybeDouble.GetDefault()
                MaybeFloat = MaybeFloat.GetDefault()
                MaybeInt64 = MaybeInt64.GetDefault()
                MaybeUint64 = MaybeUint64.GetDefault()
                MaybeInt32 = MaybeInt32.GetDefault()
                MaybeUint32 = MaybeUint32.GetDefault()
                MaybeBool = MaybeBool.GetDefault()
                MaybeString = MaybeString.GetDefault()
                MaybeBytes = MaybeBytes.GetDefault()
                Timestamp = Timestamp.GetDefault()
                Duration = Duration.GetDefault()
                OptionalInt32 = OptionalInt32.GetDefault()
                MaybesInt64 = MaybesInt64.GetDefault()
                Timestamps = Timestamps.GetDefault()
                Anything = Anything.GetDefault()
                }
            Size = fun (m: Outer) ->
                0
                + DoubleVal.CalcFieldSize m.DoubleVal
                + FloatVal.CalcFieldSize m.FloatVal
                + LongVal.CalcFieldSize m.LongVal
                + UlongVal.CalcFieldSize m.UlongVal
                + IntVal.CalcFieldSize m.IntVal
                + UlongFixed.CalcFieldSize m.UlongFixed
                + UintFixed.CalcFieldSize m.UintFixed
                + BoolVal.CalcFieldSize m.BoolVal
                + StringVal.CalcFieldSize m.StringVal
                + BytesVal.CalcFieldSize m.BytesVal
                + UintVal.CalcFieldSize m.UintVal
                + EnumVal.CalcFieldSize m.EnumVal
                + Inner.CalcFieldSize m.Inner
                + Doubles.CalcFieldSize m.Doubles
                + Inners.CalcFieldSize m.Inners
                + Map.CalcFieldSize m.Map
                + MapInner.CalcFieldSize m.MapInner
                + MapInts.CalcFieldSize m.MapInts
                + MapBool.CalcFieldSize m.MapBool
                + Recursive.CalcFieldSize m.Recursive
                + match m.Union with
                    | Ex.Ample.Outer.UnionCase.None -> 0
                    | Ex.Ample.Outer.UnionCase.InnerOption v -> InnerOption.CalcFieldSize v
                    | Ex.Ample.Outer.UnionCase.StringOption v -> StringOption.CalcFieldSize v
                    | Ex.Ample.Outer.UnionCase.ImportedOption v -> ImportedOption.CalcFieldSize v
                    | Ex.Ample.Outer.UnionCase.BytesOption v -> BytesOption.CalcFieldSize v
                + Nested.CalcFieldSize m.Nested
                + Imported.CalcFieldSize m.Imported
                + EnumImported.CalcFieldSize m.EnumImported
                + MaybeDouble.CalcFieldSize m.MaybeDouble
                + MaybeFloat.CalcFieldSize m.MaybeFloat
                + MaybeInt64.CalcFieldSize m.MaybeInt64
                + MaybeUint64.CalcFieldSize m.MaybeUint64
                + MaybeInt32.CalcFieldSize m.MaybeInt32
                + MaybeUint32.CalcFieldSize m.MaybeUint32
                + MaybeBool.CalcFieldSize m.MaybeBool
                + MaybeString.CalcFieldSize m.MaybeString
                + MaybeBytes.CalcFieldSize m.MaybeBytes
                + Timestamp.CalcFieldSize m.Timestamp
                + Duration.CalcFieldSize m.Duration
                + OptionalInt32.CalcFieldSize m.OptionalInt32
                + MaybesInt64.CalcFieldSize m.MaybesInt64
                + Timestamps.CalcFieldSize m.Timestamps
                + Anything.CalcFieldSize m.Anything
            Encode = fun (w: Google.Protobuf.CodedOutputStream) (m: Outer) ->
                DoubleVal.WriteField w m.DoubleVal
                FloatVal.WriteField w m.FloatVal
                LongVal.WriteField w m.LongVal
                UlongVal.WriteField w m.UlongVal
                IntVal.WriteField w m.IntVal
                UlongFixed.WriteField w m.UlongFixed
                UintFixed.WriteField w m.UintFixed
                BoolVal.WriteField w m.BoolVal
                StringVal.WriteField w m.StringVal
                BytesVal.WriteField w m.BytesVal
                UintVal.WriteField w m.UintVal
                EnumVal.WriteField w m.EnumVal
                Inner.WriteField w m.Inner
                Doubles.WriteField w m.Doubles
                Inners.WriteField w m.Inners
                Map.WriteField w m.Map
                MapInner.WriteField w m.MapInner
                MapInts.WriteField w m.MapInts
                MapBool.WriteField w m.MapBool
                Recursive.WriteField w m.Recursive
                (match m.Union with
                | Ex.Ample.Outer.UnionCase.None -> ()
                | Ex.Ample.Outer.UnionCase.InnerOption v -> InnerOption.WriteField w v
                | Ex.Ample.Outer.UnionCase.StringOption v -> StringOption.WriteField w v
                | Ex.Ample.Outer.UnionCase.ImportedOption v -> ImportedOption.WriteField w v
                | Ex.Ample.Outer.UnionCase.BytesOption v -> BytesOption.WriteField w v
                )
                Nested.WriteField w m.Nested
                Imported.WriteField w m.Imported
                EnumImported.WriteField w m.EnumImported
                MaybeDouble.WriteField w m.MaybeDouble
                MaybeFloat.WriteField w m.MaybeFloat
                MaybeInt64.WriteField w m.MaybeInt64
                MaybeUint64.WriteField w m.MaybeUint64
                MaybeInt32.WriteField w m.MaybeInt32
                MaybeUint32.WriteField w m.MaybeUint32
                MaybeBool.WriteField w m.MaybeBool
                MaybeString.WriteField w m.MaybeString
                MaybeBytes.WriteField w m.MaybeBytes
                Timestamp.WriteField w m.Timestamp
                Duration.WriteField w m.Duration
                OptionalInt32.WriteField w m.OptionalInt32
                MaybesInt64.WriteField w m.MaybesInt64
                Timestamps.WriteField w m.Timestamps
                Anything.WriteField w m.Anything
            Decode = fun (r: Google.Protobuf.CodedInputStream) ->
                let mutable builder = new Ex.Ample.Outer.Builder()
                let mutable tag = 0
                while read r &tag do
                    builder.Put (tag, r)
                builder.Build
            EncodeJson = fun (o: JsonOptions) ->
                let writeDoubleVal = DoubleVal.WriteJsonField o
                let writeFloatVal = FloatVal.WriteJsonField o
                let writeLongVal = LongVal.WriteJsonField o
                let writeUlongVal = UlongVal.WriteJsonField o
                let writeIntVal = IntVal.WriteJsonField o
                let writeUlongFixed = UlongFixed.WriteJsonField o
                let writeUintFixed = UintFixed.WriteJsonField o
                let writeBoolVal = BoolVal.WriteJsonField o
                let writeStringVal = StringVal.WriteJsonField o
                let writeBytesVal = BytesVal.WriteJsonField o
                let writeUintVal = UintVal.WriteJsonField o
                let writeEnumVal = EnumVal.WriteJsonField o
                let writeInner = Inner.WriteJsonField o
                let writeDoubles = Doubles.WriteJsonField o
                let writeInners = Inners.WriteJsonField o
                let writeMap = Map.WriteJsonField o
                let writeMapInner = MapInner.WriteJsonField o
                let writeMapInts = MapInts.WriteJsonField o
                let writeMapBool = MapBool.WriteJsonField o
                let writeRecursive = Recursive.WriteJsonField o
                let writeUnionNone = Union.WriteJsonNoneCase o
                let writeInnerOption = InnerOption.WriteJsonField o
                let writeStringOption = StringOption.WriteJsonField o
                let writeImportedOption = ImportedOption.WriteJsonField o
                let writeBytesOption = BytesOption.WriteJsonField o
                let writeNested = Nested.WriteJsonField o
                let writeImported = Imported.WriteJsonField o
                let writeEnumImported = EnumImported.WriteJsonField o
                let writeMaybeDouble = MaybeDouble.WriteJsonField o
                let writeMaybeFloat = MaybeFloat.WriteJsonField o
                let writeMaybeInt64 = MaybeInt64.WriteJsonField o
                let writeMaybeUint64 = MaybeUint64.WriteJsonField o
                let writeMaybeInt32 = MaybeInt32.WriteJsonField o
                let writeMaybeUint32 = MaybeUint32.WriteJsonField o
                let writeMaybeBool = MaybeBool.WriteJsonField o
                let writeMaybeString = MaybeString.WriteJsonField o
                let writeMaybeBytes = MaybeBytes.WriteJsonField o
                let writeTimestamp = Timestamp.WriteJsonField o
                let writeDuration = Duration.WriteJsonField o
                let writeOptionalInt32 = OptionalInt32.WriteJsonField o
                let writeMaybesInt64 = MaybesInt64.WriteJsonField o
                let writeTimestamps = Timestamps.WriteJsonField o
                let writeAnything = Anything.WriteJsonField o
                let encode (w: System.Text.Json.Utf8JsonWriter) (m: Outer) =
                    writeDoubleVal w m.DoubleVal
                    writeFloatVal w m.FloatVal
                    writeLongVal w m.LongVal
                    writeUlongVal w m.UlongVal
                    writeIntVal w m.IntVal
                    writeUlongFixed w m.UlongFixed
                    writeUintFixed w m.UintFixed
                    writeBoolVal w m.BoolVal
                    writeStringVal w m.StringVal
                    writeBytesVal w m.BytesVal
                    writeUintVal w m.UintVal
                    writeEnumVal w m.EnumVal
                    writeInner w m.Inner
                    writeDoubles w m.Doubles
                    writeInners w m.Inners
                    writeMap w m.Map
                    writeMapInner w m.MapInner
                    writeMapInts w m.MapInts
                    writeMapBool w m.MapBool
                    writeRecursive w m.Recursive
                    (match m.Union with
                    | Ex.Ample.Outer.UnionCase.None -> writeUnionNone w
                    | Ex.Ample.Outer.UnionCase.InnerOption v -> writeInnerOption w v
                    | Ex.Ample.Outer.UnionCase.StringOption v -> writeStringOption w v
                    | Ex.Ample.Outer.UnionCase.ImportedOption v -> writeImportedOption w v
                    | Ex.Ample.Outer.UnionCase.BytesOption v -> writeBytesOption w v
                    )
                    writeNested w m.Nested
                    writeImported w m.Imported
                    writeEnumImported w m.EnumImported
                    writeMaybeDouble w m.MaybeDouble
                    writeMaybeFloat w m.MaybeFloat
                    writeMaybeInt64 w m.MaybeInt64
                    writeMaybeUint64 w m.MaybeUint64
                    writeMaybeInt32 w m.MaybeInt32
                    writeMaybeUint32 w m.MaybeUint32
                    writeMaybeBool w m.MaybeBool
                    writeMaybeString w m.MaybeString
                    writeMaybeBytes w m.MaybeBytes
                    writeTimestamp w m.Timestamp
                    writeDuration w m.Duration
                    writeOptionalInt32 w m.OptionalInt32
                    writeMaybesInt64 w m.MaybesInt64
                    writeTimestamps w m.Timestamps
                    writeAnything w m.Anything
                encode
            DecodeJson = fun (node: System.Text.Json.Nodes.JsonNode) ->
                let update value (kvPair: System.Collections.Generic.KeyValuePair<string,System.Text.Json.Nodes.JsonNode>) : Outer =
                    match kvPair.Key with
                    | "doubleVal" -> { value with DoubleVal = DoubleVal.ReadJsonField kvPair.Value }
                    | "floatVal" -> { value with FloatVal = FloatVal.ReadJsonField kvPair.Value }
                    | "longVal" -> { value with LongVal = LongVal.ReadJsonField kvPair.Value }
                    | "ulongVal" -> { value with UlongVal = UlongVal.ReadJsonField kvPair.Value }
                    | "intVal" -> { value with IntVal = IntVal.ReadJsonField kvPair.Value }
                    | "ulongFixed" -> { value with UlongFixed = UlongFixed.ReadJsonField kvPair.Value }
                    | "uintFixed" -> { value with UintFixed = UintFixed.ReadJsonField kvPair.Value }
                    | "boolVal" -> { value with BoolVal = BoolVal.ReadJsonField kvPair.Value }
                    | "stringVal" -> { value with StringVal = StringVal.ReadJsonField kvPair.Value }
                    | "bytesVal" -> { value with BytesVal = BytesVal.ReadJsonField kvPair.Value }
                    | "uintVal" -> { value with UintVal = UintVal.ReadJsonField kvPair.Value }
                    | "enumVal" -> { value with EnumVal = EnumVal.ReadJsonField kvPair.Value }
                    | "inner" -> { value with Inner = Inner.ReadJsonField kvPair.Value }
                    | "doubles" -> { value with Doubles = Doubles.ReadJsonField kvPair.Value }
                    | "inners" -> { value with Inners = Inners.ReadJsonField kvPair.Value }
                    | "map" -> { value with Map = Map.ReadJsonField kvPair.Value }
                    | "mapInner" -> { value with MapInner = MapInner.ReadJsonField kvPair.Value }
                    | "mapInts" -> { value with MapInts = MapInts.ReadJsonField kvPair.Value }
                    | "mapBool" -> { value with MapBool = MapBool.ReadJsonField kvPair.Value }
                    | "recursive" -> { value with Recursive = Recursive.ReadJsonField kvPair.Value }
                    | "innerOption" -> { value with Union = Ex.Ample.Outer.UnionCase.InnerOption (InnerOption.ReadJsonField kvPair.Value) }
                    | "stringOption" -> { value with Union = Ex.Ample.Outer.UnionCase.StringOption (StringOption.ReadJsonField kvPair.Value) }
                    | "importedOption" -> { value with Union = Ex.Ample.Outer.UnionCase.ImportedOption (ImportedOption.ReadJsonField kvPair.Value) }
                    | "bytesOption" -> { value with Union = Ex.Ample.Outer.UnionCase.BytesOption (BytesOption.ReadJsonField kvPair.Value) }
                    | "union" -> { value with Union = Union.ReadJsonField kvPair.Value }
                    | "nested" -> { value with Nested = Nested.ReadJsonField kvPair.Value }
                    | "imported" -> { value with Imported = Imported.ReadJsonField kvPair.Value }
                    | "enumImported" -> { value with EnumImported = EnumImported.ReadJsonField kvPair.Value }
                    | "maybeDouble" -> { value with MaybeDouble = MaybeDouble.ReadJsonField kvPair.Value }
                    | "maybeFloat" -> { value with MaybeFloat = MaybeFloat.ReadJsonField kvPair.Value }
                    | "maybeInt64" -> { value with MaybeInt64 = MaybeInt64.ReadJsonField kvPair.Value }
                    | "maybeUint64" -> { value with MaybeUint64 = MaybeUint64.ReadJsonField kvPair.Value }
                    | "maybeInt32" -> { value with MaybeInt32 = MaybeInt32.ReadJsonField kvPair.Value }
                    | "maybeUint32" -> { value with MaybeUint32 = MaybeUint32.ReadJsonField kvPair.Value }
                    | "maybeBool" -> { value with MaybeBool = MaybeBool.ReadJsonField kvPair.Value }
                    | "maybeString" -> { value with MaybeString = MaybeString.ReadJsonField kvPair.Value }
                    | "maybeBytes" -> { value with MaybeBytes = MaybeBytes.ReadJsonField kvPair.Value }
                    | "timestamp" -> { value with Timestamp = Timestamp.ReadJsonField kvPair.Value }
                    | "duration" -> { value with Duration = Duration.ReadJsonField kvPair.Value }
                    | "optionalInt32" -> { value with OptionalInt32 = OptionalInt32.ReadJsonField kvPair.Value }
                    | "maybesInt64" -> { value with MaybesInt64 = MaybesInt64.ReadJsonField kvPair.Value }
                    | "timestamps" -> { value with Timestamps = Timestamps.ReadJsonField kvPair.Value }
                    | "anything" -> { value with Anything = Anything.ReadJsonField kvPair.Value }
                    | _ -> value
                Seq.fold update _Outer.empty (node.AsObject ())
        }
    static member empty
        with get() = Ex.Ample._Outer.Proto.Value.Empty

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module ResultEvent =

    [<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    module Record =

        [<System.Runtime.CompilerServices.IsByRefLike>]
        type Builder =
            struct
                val mutable Key: string // (1)
                val mutable Value: string // (2)
            end
            with
            member x.Put ((tag, reader): int * Reader) =
                match tag with
                | 1 -> x.Key <- ValueCodec.String.ReadValue reader
                | 2 -> x.Value <- ValueCodec.String.ReadValue reader
                | _ -> reader.SkipLastField()
            member x.Build : Ex.Ample.ResultEvent.Record = {
                Key = x.Key |> orEmptyString
                Value = x.Value |> orEmptyString
                }

    type private _Record = Record
    [<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.MessageConverter>)>]
    [<FsGrpc.Protobuf.Message>]
    [<StructuralEquality;StructuralComparison>]
    type Record = {
        // Field Declarations
        [<System.Text.Json.Serialization.JsonPropertyName("key")>] Key: string // (1)
        [<System.Text.Json.Serialization.JsonPropertyName("value")>] Value: string // (2)
        }
        with
        static member Proto : Lazy<ProtoDef<Record>> =
            lazy
            // Field Definitions
            let Key = FieldCodec.Primitive ValueCodec.String (1, "key")
            let Value = FieldCodec.Primitive ValueCodec.String (2, "value")
            // Proto Definition Implementation
            { // ProtoDef<Record>
                Name = "Record"
                Empty = {
                    Key = Key.GetDefault()
                    Value = Value.GetDefault()
                    }
                Size = fun (m: Record) ->
                    0
                    + Key.CalcFieldSize m.Key
                    + Value.CalcFieldSize m.Value
                Encode = fun (w: Google.Protobuf.CodedOutputStream) (m: Record) ->
                    Key.WriteField w m.Key
                    Value.WriteField w m.Value
                Decode = fun (r: Google.Protobuf.CodedInputStream) ->
                    let mutable builder = new Ex.Ample.ResultEvent.Record.Builder()
                    let mutable tag = 0
                    while read r &tag do
                        builder.Put (tag, r)
                    builder.Build
                EncodeJson = fun (o: JsonOptions) ->
                    let writeKey = Key.WriteJsonField o
                    let writeValue = Value.WriteJsonField o
                    let encode (w: System.Text.Json.Utf8JsonWriter) (m: Record) =
                        writeKey w m.Key
                        writeValue w m.Value
                    encode
                DecodeJson = fun (node: System.Text.Json.Nodes.JsonNode) ->
                    let update value (kvPair: System.Collections.Generic.KeyValuePair<string,System.Text.Json.Nodes.JsonNode>) : Record =
                        match kvPair.Key with
                        | "key" -> { value with Key = Key.ReadJsonField kvPair.Value }
                        | "value" -> { value with Value = Value.ReadJsonField kvPair.Value }
                        | _ -> value
                    Seq.fold update _Record.empty (node.AsObject ())
            }
        static member empty
            with get() = Ex.Ample.ResultEvent._Record.Proto.Value.Empty

    [<System.Runtime.CompilerServices.IsByRefLike>]
    type Builder =
        struct
            val mutable SubscriptionState: Ex.Ample.EnumType // (1)
            val mutable Records: RepeatedBuilder<Ex.Ample.ResultEvent.Record> // (2)
        end
        with
        member x.Put ((tag, reader): int * Reader) =
            match tag with
            | 1 -> x.SubscriptionState <- ValueCodec.Enum<Ex.Ample.EnumType>.ReadValue reader
            | 2 -> x.Records.Add (ValueCodec.Message<Ex.Ample.ResultEvent.Record>.ReadValue reader)
            | _ -> reader.SkipLastField()
        member x.Build : Ex.Ample.ResultEvent = {
            SubscriptionState = x.SubscriptionState
            Records = x.Records.Build
            }

/// <summary>
/// This is an example of a
/// multiline-style comment
/// </summary>
type private _ResultEvent = ResultEvent
[<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.MessageConverter>)>]
[<FsGrpc.Protobuf.Message>]
[<StructuralEquality;StructuralComparison>]
type ResultEvent = {
    // Field Declarations
    [<System.Text.Json.Serialization.JsonPropertyName("subscriptionState")>] SubscriptionState: Ex.Ample.EnumType // (1)
    [<System.Text.Json.Serialization.JsonPropertyName("records")>] Records: Ex.Ample.ResultEvent.Record list // (2)
    }
    with
    static member Proto : Lazy<ProtoDef<ResultEvent>> =
        lazy
        // Field Definitions
        let SubscriptionState = FieldCodec.Primitive ValueCodec.Enum<Ex.Ample.EnumType> (1, "subscriptionState")
        let Records = FieldCodec.Repeated ValueCodec.Message<Ex.Ample.ResultEvent.Record> (2, "records")
        // Proto Definition Implementation
        { // ProtoDef<ResultEvent>
            Name = "ResultEvent"
            Empty = {
                SubscriptionState = SubscriptionState.GetDefault()
                Records = Records.GetDefault()
                }
            Size = fun (m: ResultEvent) ->
                0
                + SubscriptionState.CalcFieldSize m.SubscriptionState
                + Records.CalcFieldSize m.Records
            Encode = fun (w: Google.Protobuf.CodedOutputStream) (m: ResultEvent) ->
                SubscriptionState.WriteField w m.SubscriptionState
                Records.WriteField w m.Records
            Decode = fun (r: Google.Protobuf.CodedInputStream) ->
                let mutable builder = new Ex.Ample.ResultEvent.Builder()
                let mutable tag = 0
                while read r &tag do
                    builder.Put (tag, r)
                builder.Build
            EncodeJson = fun (o: JsonOptions) ->
                let writeSubscriptionState = SubscriptionState.WriteJsonField o
                let writeRecords = Records.WriteJsonField o
                let encode (w: System.Text.Json.Utf8JsonWriter) (m: ResultEvent) =
                    writeSubscriptionState w m.SubscriptionState
                    writeRecords w m.Records
                encode
            DecodeJson = fun (node: System.Text.Json.Nodes.JsonNode) ->
                let update value (kvPair: System.Collections.Generic.KeyValuePair<string,System.Text.Json.Nodes.JsonNode>) : ResultEvent =
                    match kvPair.Key with
                    | "subscriptionState" -> { value with SubscriptionState = SubscriptionState.ReadJsonField kvPair.Value }
                    | "records" -> { value with Records = Records.ReadJsonField kvPair.Value }
                    | _ -> value
                Seq.fold update _ResultEvent.empty (node.AsObject ())
        }
    static member empty
        with get() = Ex.Ample._ResultEvent.Proto.Value.Empty

namespace Ex.Ample.Optics
open Focal.Core
module Inner =
    let ``intFixed`` : ILens'<Ex.Ample.Inner,int> =
        {
            _getter = { _get = fun (s: Ex.Ample.Inner) -> s.IntFixed }
            _setter = { _over = fun a2b s -> { s with IntFixed = a2b s.IntFixed } }
        }
    let ``longFixed`` : ILens'<Ex.Ample.Inner,int64> =
        {
            _getter = { _get = fun (s: Ex.Ample.Inner) -> s.LongFixed }
            _setter = { _over = fun a2b s -> { s with LongFixed = a2b s.LongFixed } }
        }
    let ``zigzagInt`` : ILens'<Ex.Ample.Inner,int> =
        {
            _getter = { _get = fun (s: Ex.Ample.Inner) -> s.ZigzagInt }
            _setter = { _over = fun a2b s -> { s with ZigzagInt = a2b s.ZigzagInt } }
        }
    let ``zigzagLong`` : ILens'<Ex.Ample.Inner,int64> =
        {
            _getter = { _get = fun (s: Ex.Ample.Inner) -> s.ZigzagLong }
            _setter = { _over = fun a2b s -> { s with ZigzagLong = a2b s.ZigzagLong } }
        }
    let ``nested`` : ILens'<Ex.Ample.Inner,Ex.Ample.Outer.Nested option> =
        {
            _getter = { _get = fun (s: Ex.Ample.Inner) -> s.Nested }
            _setter = { _over = fun a2b s -> { s with Nested = a2b s.Nested } }
        }
    let ``nestedEnum`` : ILens'<Ex.Ample.Inner,Ex.Ample.Outer.NestEnumeration> =
        {
            _getter = { _get = fun (s: Ex.Ample.Inner) -> s.NestedEnum }
            _setter = { _over = fun a2b s -> { s with NestedEnum = a2b s.NestedEnum } }
        }
module Outer =
    module UnionPrisms =
        let ifInnerOption : IPrism'<Ex.Ample.Outer.UnionCase,Ex.Ample.Inner> =
            {
                _unto = fun a -> Ex.Ample.Outer.UnionCase.InnerOption a
                _which = fun s ->
                    match s with
                    | Ex.Ample.Outer.UnionCase.InnerOption a -> Ok a
                    | _ -> Error s
            }
        let ifStringOption : IPrism'<Ex.Ample.Outer.UnionCase,string> =
            {
                _unto = fun a -> Ex.Ample.Outer.UnionCase.StringOption a
                _which = fun s ->
                    match s with
                    | Ex.Ample.Outer.UnionCase.StringOption a -> Ok a
                    | _ -> Error s
            }
        let ifImportedOption : IPrism'<Ex.Ample.Outer.UnionCase,Ex.Ample.Importable.Args> =
            {
                _unto = fun a -> Ex.Ample.Outer.UnionCase.ImportedOption a
                _which = fun s ->
                    match s with
                    | Ex.Ample.Outer.UnionCase.ImportedOption a -> Ok a
                    | _ -> Error s
            }
        let ifBytesOption : IPrism'<Ex.Ample.Outer.UnionCase,FsGrpc.Bytes> =
            {
                _unto = fun a -> Ex.Ample.Outer.UnionCase.BytesOption a
                _which = fun s ->
                    match s with
                    | Ex.Ample.Outer.UnionCase.BytesOption a -> Ok a
                    | _ -> Error s
            }
    let ``doubleVal`` : ILens'<Ex.Ample.Outer,double> =
        {
            _getter = { _get = fun (s: Ex.Ample.Outer) -> s.DoubleVal }
            _setter = { _over = fun a2b s -> { s with DoubleVal = a2b s.DoubleVal } }
        }
    let ``floatVal`` : ILens'<Ex.Ample.Outer,float32> =
        {
            _getter = { _get = fun (s: Ex.Ample.Outer) -> s.FloatVal }
            _setter = { _over = fun a2b s -> { s with FloatVal = a2b s.FloatVal } }
        }
    let ``longVal`` : ILens'<Ex.Ample.Outer,int64> =
        {
            _getter = { _get = fun (s: Ex.Ample.Outer) -> s.LongVal }
            _setter = { _over = fun a2b s -> { s with LongVal = a2b s.LongVal } }
        }
    let ``ulongVal`` : ILens'<Ex.Ample.Outer,uint64> =
        {
            _getter = { _get = fun (s: Ex.Ample.Outer) -> s.UlongVal }
            _setter = { _over = fun a2b s -> { s with UlongVal = a2b s.UlongVal } }
        }
    let ``intVal`` : ILens'<Ex.Ample.Outer,int> =
        {
            _getter = { _get = fun (s: Ex.Ample.Outer) -> s.IntVal }
            _setter = { _over = fun a2b s -> { s with IntVal = a2b s.IntVal } }
        }
    let ``ulongFixed`` : ILens'<Ex.Ample.Outer,uint64> =
        {
            _getter = { _get = fun (s: Ex.Ample.Outer) -> s.UlongFixed }
            _setter = { _over = fun a2b s -> { s with UlongFixed = a2b s.UlongFixed } }
        }
    let ``uintFixed`` : ILens'<Ex.Ample.Outer,uint> =
        {
            _getter = { _get = fun (s: Ex.Ample.Outer) -> s.UintFixed }
            _setter = { _over = fun a2b s -> { s with UintFixed = a2b s.UintFixed } }
        }
    let ``boolVal`` : ILens'<Ex.Ample.Outer,bool> =
        {
            _getter = { _get = fun (s: Ex.Ample.Outer) -> s.BoolVal }
            _setter = { _over = fun a2b s -> { s with BoolVal = a2b s.BoolVal } }
        }
    let ``stringVal`` : ILens'<Ex.Ample.Outer,string> =
        {
            _getter = { _get = fun (s: Ex.Ample.Outer) -> s.StringVal }
            _setter = { _over = fun a2b s -> { s with StringVal = a2b s.StringVal } }
        }
    let ``bytesVal`` : ILens'<Ex.Ample.Outer,FsGrpc.Bytes> =
        {
            _getter = { _get = fun (s: Ex.Ample.Outer) -> s.BytesVal }
            _setter = { _over = fun a2b s -> { s with BytesVal = a2b s.BytesVal } }
        }
    let ``uintVal`` : ILens'<Ex.Ample.Outer,uint32> =
        {
            _getter = { _get = fun (s: Ex.Ample.Outer) -> s.UintVal }
            _setter = { _over = fun a2b s -> { s with UintVal = a2b s.UintVal } }
        }
    let ``enumVal`` : ILens'<Ex.Ample.Outer,Ex.Ample.EnumType> =
        {
            _getter = { _get = fun (s: Ex.Ample.Outer) -> s.EnumVal }
            _setter = { _over = fun a2b s -> { s with EnumVal = a2b s.EnumVal } }
        }
    let ``inner`` : ILens'<Ex.Ample.Outer,Ex.Ample.Inner option> =
        {
            _getter = { _get = fun (s: Ex.Ample.Outer) -> s.Inner }
            _setter = { _over = fun a2b s -> { s with Inner = a2b s.Inner } }
        }
    let ``doubles`` : ILens'<Ex.Ample.Outer,double list> =
        {
            _getter = { _get = fun (s: Ex.Ample.Outer) -> s.Doubles }
            _setter = { _over = fun a2b s -> { s with Doubles = a2b s.Doubles } }
        }
    let ``inners`` : ILens'<Ex.Ample.Outer,Ex.Ample.Inner list> =
        {
            _getter = { _get = fun (s: Ex.Ample.Outer) -> s.Inners }
            _setter = { _over = fun a2b s -> { s with Inners = a2b s.Inners } }
        }
    let ``map`` : ILens'<Ex.Ample.Outer,Map<string, string>> =
        {
            _getter = { _get = fun (s: Ex.Ample.Outer) -> s.Map }
            _setter = { _over = fun a2b s -> { s with Map = a2b s.Map } }
        }
    let ``mapInner`` : ILens'<Ex.Ample.Outer,Map<string, Ex.Ample.Inner>> =
        {
            _getter = { _get = fun (s: Ex.Ample.Outer) -> s.MapInner }
            _setter = { _over = fun a2b s -> { s with MapInner = a2b s.MapInner } }
        }
    let ``mapInts`` : ILens'<Ex.Ample.Outer,Map<int64, int>> =
        {
            _getter = { _get = fun (s: Ex.Ample.Outer) -> s.MapInts }
            _setter = { _over = fun a2b s -> { s with MapInts = a2b s.MapInts } }
        }
    let ``mapBool`` : ILens'<Ex.Ample.Outer,Map<bool, string>> =
        {
            _getter = { _get = fun (s: Ex.Ample.Outer) -> s.MapBool }
            _setter = { _over = fun a2b s -> { s with MapBool = a2b s.MapBool } }
        }
    let ``recursive`` : ILens'<Ex.Ample.Outer,Ex.Ample.Outer option> =
        {
            _getter = { _get = fun (s: Ex.Ample.Outer) -> s.Recursive }
            _setter = { _over = fun a2b s -> { s with Recursive = a2b s.Recursive } }
        }
    let ``union`` : ILens'<Ex.Ample.Outer,Ex.Ample.Outer.UnionCase> =
        {
            _getter = { _get = fun (s: Ex.Ample.Outer) -> s.Union }
            _setter = { _over = fun a2b s -> { s with Union = a2b s.Union } }
        }
    let ``nested`` : ILens'<Ex.Ample.Outer,Ex.Ample.Outer.Nested option> =
        {
            _getter = { _get = fun (s: Ex.Ample.Outer) -> s.Nested }
            _setter = { _over = fun a2b s -> { s with Nested = a2b s.Nested } }
        }
    let ``imported`` : ILens'<Ex.Ample.Outer,Ex.Ample.Importable.Imported option> =
        {
            _getter = { _get = fun (s: Ex.Ample.Outer) -> s.Imported }
            _setter = { _over = fun a2b s -> { s with Imported = a2b s.Imported } }
        }
    let ``enumImported`` : ILens'<Ex.Ample.Outer,Ex.Ample.Importable.Imported.EnumForImport> =
        {
            _getter = { _get = fun (s: Ex.Ample.Outer) -> s.EnumImported }
            _setter = { _over = fun a2b s -> { s with EnumImported = a2b s.EnumImported } }
        }
    let ``maybeDouble`` : ILens'<Ex.Ample.Outer,double option> =
        {
            _getter = { _get = fun (s: Ex.Ample.Outer) -> s.MaybeDouble }
            _setter = { _over = fun a2b s -> { s with MaybeDouble = a2b s.MaybeDouble } }
        }
    let ``maybeFloat`` : ILens'<Ex.Ample.Outer,float32 option> =
        {
            _getter = { _get = fun (s: Ex.Ample.Outer) -> s.MaybeFloat }
            _setter = { _over = fun a2b s -> { s with MaybeFloat = a2b s.MaybeFloat } }
        }
    let ``maybeInt64`` : ILens'<Ex.Ample.Outer,int64 option> =
        {
            _getter = { _get = fun (s: Ex.Ample.Outer) -> s.MaybeInt64 }
            _setter = { _over = fun a2b s -> { s with MaybeInt64 = a2b s.MaybeInt64 } }
        }
    let ``maybeUint64`` : ILens'<Ex.Ample.Outer,uint64 option> =
        {
            _getter = { _get = fun (s: Ex.Ample.Outer) -> s.MaybeUint64 }
            _setter = { _over = fun a2b s -> { s with MaybeUint64 = a2b s.MaybeUint64 } }
        }
    let ``maybeInt32`` : ILens'<Ex.Ample.Outer,int option> =
        {
            _getter = { _get = fun (s: Ex.Ample.Outer) -> s.MaybeInt32 }
            _setter = { _over = fun a2b s -> { s with MaybeInt32 = a2b s.MaybeInt32 } }
        }
    let ``maybeUint32`` : ILens'<Ex.Ample.Outer,uint32 option> =
        {
            _getter = { _get = fun (s: Ex.Ample.Outer) -> s.MaybeUint32 }
            _setter = { _over = fun a2b s -> { s with MaybeUint32 = a2b s.MaybeUint32 } }
        }
    let ``maybeBool`` : ILens'<Ex.Ample.Outer,bool option> =
        {
            _getter = { _get = fun (s: Ex.Ample.Outer) -> s.MaybeBool }
            _setter = { _over = fun a2b s -> { s with MaybeBool = a2b s.MaybeBool } }
        }
    let ``maybeString`` : ILens'<Ex.Ample.Outer,string option> =
        {
            _getter = { _get = fun (s: Ex.Ample.Outer) -> s.MaybeString }
            _setter = { _over = fun a2b s -> { s with MaybeString = a2b s.MaybeString } }
        }
    let ``maybeBytes`` : ILens'<Ex.Ample.Outer,FsGrpc.Bytes option> =
        {
            _getter = { _get = fun (s: Ex.Ample.Outer) -> s.MaybeBytes }
            _setter = { _over = fun a2b s -> { s with MaybeBytes = a2b s.MaybeBytes } }
        }
    let ``timestamp`` : ILens'<Ex.Ample.Outer,NodaTime.Instant option> =
        {
            _getter = { _get = fun (s: Ex.Ample.Outer) -> s.Timestamp }
            _setter = { _over = fun a2b s -> { s with Timestamp = a2b s.Timestamp } }
        }
    let ``duration`` : ILens'<Ex.Ample.Outer,NodaTime.Duration option> =
        {
            _getter = { _get = fun (s: Ex.Ample.Outer) -> s.Duration }
            _setter = { _over = fun a2b s -> { s with Duration = a2b s.Duration } }
        }
    let ``optionalInt32`` : ILens'<Ex.Ample.Outer,int option> =
        {
            _getter = { _get = fun (s: Ex.Ample.Outer) -> s.OptionalInt32 }
            _setter = { _over = fun a2b s -> { s with OptionalInt32 = a2b s.OptionalInt32 } }
        }
    let ``maybesInt64`` : ILens'<Ex.Ample.Outer,int64 list> =
        {
            _getter = { _get = fun (s: Ex.Ample.Outer) -> s.MaybesInt64 }
            _setter = { _over = fun a2b s -> { s with MaybesInt64 = a2b s.MaybesInt64 } }
        }
    let ``timestamps`` : ILens'<Ex.Ample.Outer,NodaTime.Instant list> =
        {
            _getter = { _get = fun (s: Ex.Ample.Outer) -> s.Timestamps }
            _setter = { _over = fun a2b s -> { s with Timestamps = a2b s.Timestamps } }
        }
    let ``anything`` : ILens'<Ex.Ample.Outer,FsGrpc.Protobuf.Any option> =
        {
            _getter = { _get = fun (s: Ex.Ample.Outer) -> s.Anything }
            _setter = { _over = fun a2b s -> { s with Anything = a2b s.Anything } }
        }
    module Nested =
        let ``enums`` : ILens'<Ex.Ample.Outer.Nested,Ex.Ample.Outer.NestEnumeration list> =
            {
                _getter = { _get = fun (s: Ex.Ample.Outer.Nested) -> s.Enums }
                _setter = { _over = fun a2b s -> { s with Enums = a2b s.Enums } }
            }
        let ``inner`` : ILens'<Ex.Ample.Outer.Nested,Ex.Ample.Inner option> =
            {
                _getter = { _get = fun (s: Ex.Ample.Outer.Nested) -> s.Inner }
                _setter = { _over = fun a2b s -> { s with Inner = a2b s.Inner } }
            }
module ResultEvent =
    let ``subscriptionState`` : ILens'<Ex.Ample.ResultEvent,Ex.Ample.EnumType> =
        {
            _getter = { _get = fun (s: Ex.Ample.ResultEvent) -> s.SubscriptionState }
            _setter = { _over = fun a2b s -> { s with SubscriptionState = a2b s.SubscriptionState } }
        }
    let ``records`` : ILens'<Ex.Ample.ResultEvent,Ex.Ample.ResultEvent.Record list> =
        {
            _getter = { _get = fun (s: Ex.Ample.ResultEvent) -> s.Records }
            _setter = { _over = fun a2b s -> { s with Records = a2b s.Records } }
        }
    module Record =
        let ``key`` : ILens'<Ex.Ample.ResultEvent.Record,string> =
            {
                _getter = { _get = fun (s: Ex.Ample.ResultEvent.Record) -> s.Key }
                _setter = { _over = fun a2b s -> { s with Key = a2b s.Key } }
            }
        let ``value`` : ILens'<Ex.Ample.ResultEvent.Record,string> =
            {
                _getter = { _get = fun (s: Ex.Ample.ResultEvent.Record) -> s.Value }
                _setter = { _over = fun a2b s -> { s with Value = a2b s.Value } }
            }

namespace Ex.Ample
open Focal.Core
open System.Runtime.CompilerServices
[<Extension>]
type OpticsExtensionMethods_example_proto =
    [<Extension>]
    static member inline IntFixed(lens : ILens<'a,'b,Ex.Ample.Inner,Ex.Ample.Inner>) : ILens<'a,'b,int,int> =
        lens.ComposeWith(Ex.Ample.Optics.Inner.``intFixed``)
    [<Extension>]
    static member inline IntFixed(traversal : ITraversal<'a,'b,Ex.Ample.Inner,Ex.Ample.Inner>) : ITraversal<'a,'b,int,int> =
        traversal.ComposeWith(Ex.Ample.Optics.Inner.``intFixed``)
    [<Extension>]
    static member inline LongFixed(lens : ILens<'a,'b,Ex.Ample.Inner,Ex.Ample.Inner>) : ILens<'a,'b,int64,int64> =
        lens.ComposeWith(Ex.Ample.Optics.Inner.``longFixed``)
    [<Extension>]
    static member inline LongFixed(traversal : ITraversal<'a,'b,Ex.Ample.Inner,Ex.Ample.Inner>) : ITraversal<'a,'b,int64,int64> =
        traversal.ComposeWith(Ex.Ample.Optics.Inner.``longFixed``)
    [<Extension>]
    static member inline ZigzagInt(lens : ILens<'a,'b,Ex.Ample.Inner,Ex.Ample.Inner>) : ILens<'a,'b,int,int> =
        lens.ComposeWith(Ex.Ample.Optics.Inner.``zigzagInt``)
    [<Extension>]
    static member inline ZigzagInt(traversal : ITraversal<'a,'b,Ex.Ample.Inner,Ex.Ample.Inner>) : ITraversal<'a,'b,int,int> =
        traversal.ComposeWith(Ex.Ample.Optics.Inner.``zigzagInt``)
    [<Extension>]
    static member inline ZigzagLong(lens : ILens<'a,'b,Ex.Ample.Inner,Ex.Ample.Inner>) : ILens<'a,'b,int64,int64> =
        lens.ComposeWith(Ex.Ample.Optics.Inner.``zigzagLong``)
    [<Extension>]
    static member inline ZigzagLong(traversal : ITraversal<'a,'b,Ex.Ample.Inner,Ex.Ample.Inner>) : ITraversal<'a,'b,int64,int64> =
        traversal.ComposeWith(Ex.Ample.Optics.Inner.``zigzagLong``)
    [<Extension>]
    static member inline Nested(lens : ILens<'a,'b,Ex.Ample.Inner,Ex.Ample.Inner>) : ILens<'a,'b,Ex.Ample.Outer.Nested option,Ex.Ample.Outer.Nested option> =
        lens.ComposeWith(Ex.Ample.Optics.Inner.``nested``)
    [<Extension>]
    static member inline Nested(traversal : ITraversal<'a,'b,Ex.Ample.Inner,Ex.Ample.Inner>) : ITraversal<'a,'b,Ex.Ample.Outer.Nested option,Ex.Ample.Outer.Nested option> =
        traversal.ComposeWith(Ex.Ample.Optics.Inner.``nested``)
    [<Extension>]
    static member inline NestedEnum(lens : ILens<'a,'b,Ex.Ample.Inner,Ex.Ample.Inner>) : ILens<'a,'b,Ex.Ample.Outer.NestEnumeration,Ex.Ample.Outer.NestEnumeration> =
        lens.ComposeWith(Ex.Ample.Optics.Inner.``nestedEnum``)
    [<Extension>]
    static member inline NestedEnum(traversal : ITraversal<'a,'b,Ex.Ample.Inner,Ex.Ample.Inner>) : ITraversal<'a,'b,Ex.Ample.Outer.NestEnumeration,Ex.Ample.Outer.NestEnumeration> =
        traversal.ComposeWith(Ex.Ample.Optics.Inner.``nestedEnum``)
    [<Extension>]
    static member inline DoubleVal(lens : ILens<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ILens<'a,'b,double,double> =
        lens.ComposeWith(Ex.Ample.Optics.Outer.``doubleVal``)
    [<Extension>]
    static member inline DoubleVal(traversal : ITraversal<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ITraversal<'a,'b,double,double> =
        traversal.ComposeWith(Ex.Ample.Optics.Outer.``doubleVal``)
    [<Extension>]
    static member inline FloatVal(lens : ILens<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ILens<'a,'b,float32,float32> =
        lens.ComposeWith(Ex.Ample.Optics.Outer.``floatVal``)
    [<Extension>]
    static member inline FloatVal(traversal : ITraversal<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ITraversal<'a,'b,float32,float32> =
        traversal.ComposeWith(Ex.Ample.Optics.Outer.``floatVal``)
    [<Extension>]
    static member inline LongVal(lens : ILens<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ILens<'a,'b,int64,int64> =
        lens.ComposeWith(Ex.Ample.Optics.Outer.``longVal``)
    [<Extension>]
    static member inline LongVal(traversal : ITraversal<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ITraversal<'a,'b,int64,int64> =
        traversal.ComposeWith(Ex.Ample.Optics.Outer.``longVal``)
    [<Extension>]
    static member inline UlongVal(lens : ILens<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ILens<'a,'b,uint64,uint64> =
        lens.ComposeWith(Ex.Ample.Optics.Outer.``ulongVal``)
    [<Extension>]
    static member inline UlongVal(traversal : ITraversal<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ITraversal<'a,'b,uint64,uint64> =
        traversal.ComposeWith(Ex.Ample.Optics.Outer.``ulongVal``)
    [<Extension>]
    static member inline IntVal(lens : ILens<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ILens<'a,'b,int,int> =
        lens.ComposeWith(Ex.Ample.Optics.Outer.``intVal``)
    [<Extension>]
    static member inline IntVal(traversal : ITraversal<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ITraversal<'a,'b,int,int> =
        traversal.ComposeWith(Ex.Ample.Optics.Outer.``intVal``)
    [<Extension>]
    static member inline UlongFixed(lens : ILens<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ILens<'a,'b,uint64,uint64> =
        lens.ComposeWith(Ex.Ample.Optics.Outer.``ulongFixed``)
    [<Extension>]
    static member inline UlongFixed(traversal : ITraversal<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ITraversal<'a,'b,uint64,uint64> =
        traversal.ComposeWith(Ex.Ample.Optics.Outer.``ulongFixed``)
    [<Extension>]
    static member inline UintFixed(lens : ILens<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ILens<'a,'b,uint,uint> =
        lens.ComposeWith(Ex.Ample.Optics.Outer.``uintFixed``)
    [<Extension>]
    static member inline UintFixed(traversal : ITraversal<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ITraversal<'a,'b,uint,uint> =
        traversal.ComposeWith(Ex.Ample.Optics.Outer.``uintFixed``)
    [<Extension>]
    static member inline BoolVal(lens : ILens<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ILens<'a,'b,bool,bool> =
        lens.ComposeWith(Ex.Ample.Optics.Outer.``boolVal``)
    [<Extension>]
    static member inline BoolVal(traversal : ITraversal<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ITraversal<'a,'b,bool,bool> =
        traversal.ComposeWith(Ex.Ample.Optics.Outer.``boolVal``)
    [<Extension>]
    static member inline StringVal(lens : ILens<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ILens<'a,'b,string,string> =
        lens.ComposeWith(Ex.Ample.Optics.Outer.``stringVal``)
    [<Extension>]
    static member inline StringVal(traversal : ITraversal<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ITraversal<'a,'b,string,string> =
        traversal.ComposeWith(Ex.Ample.Optics.Outer.``stringVal``)
    [<Extension>]
    static member inline BytesVal(lens : ILens<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ILens<'a,'b,FsGrpc.Bytes,FsGrpc.Bytes> =
        lens.ComposeWith(Ex.Ample.Optics.Outer.``bytesVal``)
    [<Extension>]
    static member inline BytesVal(traversal : ITraversal<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ITraversal<'a,'b,FsGrpc.Bytes,FsGrpc.Bytes> =
        traversal.ComposeWith(Ex.Ample.Optics.Outer.``bytesVal``)
    [<Extension>]
    static member inline UintVal(lens : ILens<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ILens<'a,'b,uint32,uint32> =
        lens.ComposeWith(Ex.Ample.Optics.Outer.``uintVal``)
    [<Extension>]
    static member inline UintVal(traversal : ITraversal<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ITraversal<'a,'b,uint32,uint32> =
        traversal.ComposeWith(Ex.Ample.Optics.Outer.``uintVal``)
    [<Extension>]
    static member inline EnumVal(lens : ILens<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ILens<'a,'b,Ex.Ample.EnumType,Ex.Ample.EnumType> =
        lens.ComposeWith(Ex.Ample.Optics.Outer.``enumVal``)
    [<Extension>]
    static member inline EnumVal(traversal : ITraversal<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ITraversal<'a,'b,Ex.Ample.EnumType,Ex.Ample.EnumType> =
        traversal.ComposeWith(Ex.Ample.Optics.Outer.``enumVal``)
    [<Extension>]
    static member inline Inner(lens : ILens<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ILens<'a,'b,Ex.Ample.Inner option,Ex.Ample.Inner option> =
        lens.ComposeWith(Ex.Ample.Optics.Outer.``inner``)
    [<Extension>]
    static member inline Inner(traversal : ITraversal<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ITraversal<'a,'b,Ex.Ample.Inner option,Ex.Ample.Inner option> =
        traversal.ComposeWith(Ex.Ample.Optics.Outer.``inner``)
    [<Extension>]
    static member inline Doubles(lens : ILens<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ILens<'a,'b,double list,double list> =
        lens.ComposeWith(Ex.Ample.Optics.Outer.``doubles``)
    [<Extension>]
    static member inline Doubles(traversal : ITraversal<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ITraversal<'a,'b,double list,double list> =
        traversal.ComposeWith(Ex.Ample.Optics.Outer.``doubles``)
    [<Extension>]
    static member inline Inners(lens : ILens<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ILens<'a,'b,Ex.Ample.Inner list,Ex.Ample.Inner list> =
        lens.ComposeWith(Ex.Ample.Optics.Outer.``inners``)
    [<Extension>]
    static member inline Inners(traversal : ITraversal<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ITraversal<'a,'b,Ex.Ample.Inner list,Ex.Ample.Inner list> =
        traversal.ComposeWith(Ex.Ample.Optics.Outer.``inners``)
    [<Extension>]
    static member inline Map(lens : ILens<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ILens<'a,'b,Map<string, string>,Map<string, string>> =
        lens.ComposeWith(Ex.Ample.Optics.Outer.``map``)
    [<Extension>]
    static member inline Map(traversal : ITraversal<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ITraversal<'a,'b,Map<string, string>,Map<string, string>> =
        traversal.ComposeWith(Ex.Ample.Optics.Outer.``map``)
    [<Extension>]
    static member inline MapInner(lens : ILens<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ILens<'a,'b,Map<string, Ex.Ample.Inner>,Map<string, Ex.Ample.Inner>> =
        lens.ComposeWith(Ex.Ample.Optics.Outer.``mapInner``)
    [<Extension>]
    static member inline MapInner(traversal : ITraversal<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ITraversal<'a,'b,Map<string, Ex.Ample.Inner>,Map<string, Ex.Ample.Inner>> =
        traversal.ComposeWith(Ex.Ample.Optics.Outer.``mapInner``)
    [<Extension>]
    static member inline MapInts(lens : ILens<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ILens<'a,'b,Map<int64, int>,Map<int64, int>> =
        lens.ComposeWith(Ex.Ample.Optics.Outer.``mapInts``)
    [<Extension>]
    static member inline MapInts(traversal : ITraversal<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ITraversal<'a,'b,Map<int64, int>,Map<int64, int>> =
        traversal.ComposeWith(Ex.Ample.Optics.Outer.``mapInts``)
    [<Extension>]
    static member inline MapBool(lens : ILens<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ILens<'a,'b,Map<bool, string>,Map<bool, string>> =
        lens.ComposeWith(Ex.Ample.Optics.Outer.``mapBool``)
    [<Extension>]
    static member inline MapBool(traversal : ITraversal<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ITraversal<'a,'b,Map<bool, string>,Map<bool, string>> =
        traversal.ComposeWith(Ex.Ample.Optics.Outer.``mapBool``)
    [<Extension>]
    static member inline Recursive(lens : ILens<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ILens<'a,'b,Ex.Ample.Outer option,Ex.Ample.Outer option> =
        lens.ComposeWith(Ex.Ample.Optics.Outer.``recursive``)
    [<Extension>]
    static member inline Recursive(traversal : ITraversal<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ITraversal<'a,'b,Ex.Ample.Outer option,Ex.Ample.Outer option> =
        traversal.ComposeWith(Ex.Ample.Optics.Outer.``recursive``)
    [<Extension>]
    static member inline Union(lens : ILens<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ILens<'a,'b,Ex.Ample.Outer.UnionCase,Ex.Ample.Outer.UnionCase> =
        lens.ComposeWith(Ex.Ample.Optics.Outer.``union``)
    [<Extension>]
    static member inline Union(traversal : ITraversal<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ITraversal<'a,'b,Ex.Ample.Outer.UnionCase,Ex.Ample.Outer.UnionCase> =
        traversal.ComposeWith(Ex.Ample.Optics.Outer.``union``)
    [<Extension>]
    static member inline Nested(lens : ILens<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ILens<'a,'b,Ex.Ample.Outer.Nested option,Ex.Ample.Outer.Nested option> =
        lens.ComposeWith(Ex.Ample.Optics.Outer.``nested``)
    [<Extension>]
    static member inline Nested(traversal : ITraversal<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ITraversal<'a,'b,Ex.Ample.Outer.Nested option,Ex.Ample.Outer.Nested option> =
        traversal.ComposeWith(Ex.Ample.Optics.Outer.``nested``)
    [<Extension>]
    static member inline Imported(lens : ILens<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ILens<'a,'b,Ex.Ample.Importable.Imported option,Ex.Ample.Importable.Imported option> =
        lens.ComposeWith(Ex.Ample.Optics.Outer.``imported``)
    [<Extension>]
    static member inline Imported(traversal : ITraversal<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ITraversal<'a,'b,Ex.Ample.Importable.Imported option,Ex.Ample.Importable.Imported option> =
        traversal.ComposeWith(Ex.Ample.Optics.Outer.``imported``)
    [<Extension>]
    static member inline EnumImported(lens : ILens<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ILens<'a,'b,Ex.Ample.Importable.Imported.EnumForImport,Ex.Ample.Importable.Imported.EnumForImport> =
        lens.ComposeWith(Ex.Ample.Optics.Outer.``enumImported``)
    [<Extension>]
    static member inline EnumImported(traversal : ITraversal<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ITraversal<'a,'b,Ex.Ample.Importable.Imported.EnumForImport,Ex.Ample.Importable.Imported.EnumForImport> =
        traversal.ComposeWith(Ex.Ample.Optics.Outer.``enumImported``)
    [<Extension>]
    static member inline MaybeDouble(lens : ILens<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ILens<'a,'b,double option,double option> =
        lens.ComposeWith(Ex.Ample.Optics.Outer.``maybeDouble``)
    [<Extension>]
    static member inline MaybeDouble(traversal : ITraversal<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ITraversal<'a,'b,double option,double option> =
        traversal.ComposeWith(Ex.Ample.Optics.Outer.``maybeDouble``)
    [<Extension>]
    static member inline MaybeFloat(lens : ILens<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ILens<'a,'b,float32 option,float32 option> =
        lens.ComposeWith(Ex.Ample.Optics.Outer.``maybeFloat``)
    [<Extension>]
    static member inline MaybeFloat(traversal : ITraversal<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ITraversal<'a,'b,float32 option,float32 option> =
        traversal.ComposeWith(Ex.Ample.Optics.Outer.``maybeFloat``)
    [<Extension>]
    static member inline MaybeInt64(lens : ILens<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ILens<'a,'b,int64 option,int64 option> =
        lens.ComposeWith(Ex.Ample.Optics.Outer.``maybeInt64``)
    [<Extension>]
    static member inline MaybeInt64(traversal : ITraversal<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ITraversal<'a,'b,int64 option,int64 option> =
        traversal.ComposeWith(Ex.Ample.Optics.Outer.``maybeInt64``)
    [<Extension>]
    static member inline MaybeUint64(lens : ILens<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ILens<'a,'b,uint64 option,uint64 option> =
        lens.ComposeWith(Ex.Ample.Optics.Outer.``maybeUint64``)
    [<Extension>]
    static member inline MaybeUint64(traversal : ITraversal<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ITraversal<'a,'b,uint64 option,uint64 option> =
        traversal.ComposeWith(Ex.Ample.Optics.Outer.``maybeUint64``)
    [<Extension>]
    static member inline MaybeInt32(lens : ILens<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ILens<'a,'b,int option,int option> =
        lens.ComposeWith(Ex.Ample.Optics.Outer.``maybeInt32``)
    [<Extension>]
    static member inline MaybeInt32(traversal : ITraversal<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ITraversal<'a,'b,int option,int option> =
        traversal.ComposeWith(Ex.Ample.Optics.Outer.``maybeInt32``)
    [<Extension>]
    static member inline MaybeUint32(lens : ILens<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ILens<'a,'b,uint32 option,uint32 option> =
        lens.ComposeWith(Ex.Ample.Optics.Outer.``maybeUint32``)
    [<Extension>]
    static member inline MaybeUint32(traversal : ITraversal<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ITraversal<'a,'b,uint32 option,uint32 option> =
        traversal.ComposeWith(Ex.Ample.Optics.Outer.``maybeUint32``)
    [<Extension>]
    static member inline MaybeBool(lens : ILens<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ILens<'a,'b,bool option,bool option> =
        lens.ComposeWith(Ex.Ample.Optics.Outer.``maybeBool``)
    [<Extension>]
    static member inline MaybeBool(traversal : ITraversal<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ITraversal<'a,'b,bool option,bool option> =
        traversal.ComposeWith(Ex.Ample.Optics.Outer.``maybeBool``)
    [<Extension>]
    static member inline MaybeString(lens : ILens<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ILens<'a,'b,string option,string option> =
        lens.ComposeWith(Ex.Ample.Optics.Outer.``maybeString``)
    [<Extension>]
    static member inline MaybeString(traversal : ITraversal<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ITraversal<'a,'b,string option,string option> =
        traversal.ComposeWith(Ex.Ample.Optics.Outer.``maybeString``)
    [<Extension>]
    static member inline MaybeBytes(lens : ILens<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ILens<'a,'b,FsGrpc.Bytes option,FsGrpc.Bytes option> =
        lens.ComposeWith(Ex.Ample.Optics.Outer.``maybeBytes``)
    [<Extension>]
    static member inline MaybeBytes(traversal : ITraversal<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ITraversal<'a,'b,FsGrpc.Bytes option,FsGrpc.Bytes option> =
        traversal.ComposeWith(Ex.Ample.Optics.Outer.``maybeBytes``)
    [<Extension>]
    static member inline Timestamp(lens : ILens<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ILens<'a,'b,NodaTime.Instant option,NodaTime.Instant option> =
        lens.ComposeWith(Ex.Ample.Optics.Outer.``timestamp``)
    [<Extension>]
    static member inline Timestamp(traversal : ITraversal<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ITraversal<'a,'b,NodaTime.Instant option,NodaTime.Instant option> =
        traversal.ComposeWith(Ex.Ample.Optics.Outer.``timestamp``)
    [<Extension>]
    static member inline Duration(lens : ILens<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ILens<'a,'b,NodaTime.Duration option,NodaTime.Duration option> =
        lens.ComposeWith(Ex.Ample.Optics.Outer.``duration``)
    [<Extension>]
    static member inline Duration(traversal : ITraversal<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ITraversal<'a,'b,NodaTime.Duration option,NodaTime.Duration option> =
        traversal.ComposeWith(Ex.Ample.Optics.Outer.``duration``)
    [<Extension>]
    static member inline OptionalInt32(lens : ILens<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ILens<'a,'b,int option,int option> =
        lens.ComposeWith(Ex.Ample.Optics.Outer.``optionalInt32``)
    [<Extension>]
    static member inline OptionalInt32(traversal : ITraversal<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ITraversal<'a,'b,int option,int option> =
        traversal.ComposeWith(Ex.Ample.Optics.Outer.``optionalInt32``)
    [<Extension>]
    static member inline MaybesInt64(lens : ILens<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ILens<'a,'b,int64 list,int64 list> =
        lens.ComposeWith(Ex.Ample.Optics.Outer.``maybesInt64``)
    [<Extension>]
    static member inline MaybesInt64(traversal : ITraversal<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ITraversal<'a,'b,int64 list,int64 list> =
        traversal.ComposeWith(Ex.Ample.Optics.Outer.``maybesInt64``)
    [<Extension>]
    static member inline Timestamps(lens : ILens<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ILens<'a,'b,NodaTime.Instant list,NodaTime.Instant list> =
        lens.ComposeWith(Ex.Ample.Optics.Outer.``timestamps``)
    [<Extension>]
    static member inline Timestamps(traversal : ITraversal<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ITraversal<'a,'b,NodaTime.Instant list,NodaTime.Instant list> =
        traversal.ComposeWith(Ex.Ample.Optics.Outer.``timestamps``)
    [<Extension>]
    static member inline Anything(lens : ILens<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ILens<'a,'b,FsGrpc.Protobuf.Any option,FsGrpc.Protobuf.Any option> =
        lens.ComposeWith(Ex.Ample.Optics.Outer.``anything``)
    [<Extension>]
    static member inline Anything(traversal : ITraversal<'a,'b,Ex.Ample.Outer,Ex.Ample.Outer>) : ITraversal<'a,'b,FsGrpc.Protobuf.Any option,FsGrpc.Protobuf.Any option> =
        traversal.ComposeWith(Ex.Ample.Optics.Outer.``anything``)
    [<Extension>]
    static member inline IfInnerOption(prism : IPrism<'s,'t,Ex.Ample.Outer.UnionCase,Ex.Ample.Outer.UnionCase>) : IPrism<'s,'t,Ex.Ample.Inner,Ex.Ample.Inner> = 
        prism.ComposeWith(Ex.Ample.Optics.Outer.UnionPrisms.ifInnerOption)
    [<Extension>]
    static member inline IfInnerOption(traversal : ITraversal<'s,'t,Ex.Ample.Outer.UnionCase,Ex.Ample.Outer.UnionCase>) : ITraversal<'s,'t,Ex.Ample.Inner,Ex.Ample.Inner> = 
        traversal.ComposeWith(Ex.Ample.Optics.Outer.UnionPrisms.ifInnerOption)
    [<Extension>]
    static member inline IfStringOption(prism : IPrism<'s,'t,Ex.Ample.Outer.UnionCase,Ex.Ample.Outer.UnionCase>) : IPrism<'s,'t,string,string> = 
        prism.ComposeWith(Ex.Ample.Optics.Outer.UnionPrisms.ifStringOption)
    [<Extension>]
    static member inline IfStringOption(traversal : ITraversal<'s,'t,Ex.Ample.Outer.UnionCase,Ex.Ample.Outer.UnionCase>) : ITraversal<'s,'t,string,string> = 
        traversal.ComposeWith(Ex.Ample.Optics.Outer.UnionPrisms.ifStringOption)
    [<Extension>]
    static member inline IfImportedOption(prism : IPrism<'s,'t,Ex.Ample.Outer.UnionCase,Ex.Ample.Outer.UnionCase>) : IPrism<'s,'t,Ex.Ample.Importable.Args,Ex.Ample.Importable.Args> = 
        prism.ComposeWith(Ex.Ample.Optics.Outer.UnionPrisms.ifImportedOption)
    [<Extension>]
    static member inline IfImportedOption(traversal : ITraversal<'s,'t,Ex.Ample.Outer.UnionCase,Ex.Ample.Outer.UnionCase>) : ITraversal<'s,'t,Ex.Ample.Importable.Args,Ex.Ample.Importable.Args> = 
        traversal.ComposeWith(Ex.Ample.Optics.Outer.UnionPrisms.ifImportedOption)
    [<Extension>]
    static member inline IfBytesOption(prism : IPrism<'s,'t,Ex.Ample.Outer.UnionCase,Ex.Ample.Outer.UnionCase>) : IPrism<'s,'t,FsGrpc.Bytes,FsGrpc.Bytes> = 
        prism.ComposeWith(Ex.Ample.Optics.Outer.UnionPrisms.ifBytesOption)
    [<Extension>]
    static member inline IfBytesOption(traversal : ITraversal<'s,'t,Ex.Ample.Outer.UnionCase,Ex.Ample.Outer.UnionCase>) : ITraversal<'s,'t,FsGrpc.Bytes,FsGrpc.Bytes> = 
        traversal.ComposeWith(Ex.Ample.Optics.Outer.UnionPrisms.ifBytesOption)
    [<Extension>]
    static member inline Enums(lens : ILens<'a,'b,Ex.Ample.Outer.Nested,Ex.Ample.Outer.Nested>) : ILens<'a,'b,Ex.Ample.Outer.NestEnumeration list,Ex.Ample.Outer.NestEnumeration list> =
        lens.ComposeWith(Ex.Ample.Optics.Outer.Nested.``enums``)
    [<Extension>]
    static member inline Enums(traversal : ITraversal<'a,'b,Ex.Ample.Outer.Nested,Ex.Ample.Outer.Nested>) : ITraversal<'a,'b,Ex.Ample.Outer.NestEnumeration list,Ex.Ample.Outer.NestEnumeration list> =
        traversal.ComposeWith(Ex.Ample.Optics.Outer.Nested.``enums``)
    [<Extension>]
    static member inline Inner(lens : ILens<'a,'b,Ex.Ample.Outer.Nested,Ex.Ample.Outer.Nested>) : ILens<'a,'b,Ex.Ample.Inner option,Ex.Ample.Inner option> =
        lens.ComposeWith(Ex.Ample.Optics.Outer.Nested.``inner``)
    [<Extension>]
    static member inline Inner(traversal : ITraversal<'a,'b,Ex.Ample.Outer.Nested,Ex.Ample.Outer.Nested>) : ITraversal<'a,'b,Ex.Ample.Inner option,Ex.Ample.Inner option> =
        traversal.ComposeWith(Ex.Ample.Optics.Outer.Nested.``inner``)
    [<Extension>]
    static member inline SubscriptionState(lens : ILens<'a,'b,Ex.Ample.ResultEvent,Ex.Ample.ResultEvent>) : ILens<'a,'b,Ex.Ample.EnumType,Ex.Ample.EnumType> =
        lens.ComposeWith(Ex.Ample.Optics.ResultEvent.``subscriptionState``)
    [<Extension>]
    static member inline SubscriptionState(traversal : ITraversal<'a,'b,Ex.Ample.ResultEvent,Ex.Ample.ResultEvent>) : ITraversal<'a,'b,Ex.Ample.EnumType,Ex.Ample.EnumType> =
        traversal.ComposeWith(Ex.Ample.Optics.ResultEvent.``subscriptionState``)
    [<Extension>]
    static member inline Records(lens : ILens<'a,'b,Ex.Ample.ResultEvent,Ex.Ample.ResultEvent>) : ILens<'a,'b,Ex.Ample.ResultEvent.Record list,Ex.Ample.ResultEvent.Record list> =
        lens.ComposeWith(Ex.Ample.Optics.ResultEvent.``records``)
    [<Extension>]
    static member inline Records(traversal : ITraversal<'a,'b,Ex.Ample.ResultEvent,Ex.Ample.ResultEvent>) : ITraversal<'a,'b,Ex.Ample.ResultEvent.Record list,Ex.Ample.ResultEvent.Record list> =
        traversal.ComposeWith(Ex.Ample.Optics.ResultEvent.``records``)
    [<Extension>]
    static member inline Key(lens : ILens<'a,'b,Ex.Ample.ResultEvent.Record,Ex.Ample.ResultEvent.Record>) : ILens<'a,'b,string,string> =
        lens.ComposeWith(Ex.Ample.Optics.ResultEvent.Record.``key``)
    [<Extension>]
    static member inline Key(traversal : ITraversal<'a,'b,Ex.Ample.ResultEvent.Record,Ex.Ample.ResultEvent.Record>) : ITraversal<'a,'b,string,string> =
        traversal.ComposeWith(Ex.Ample.Optics.ResultEvent.Record.``key``)
    [<Extension>]
    static member inline Value(lens : ILens<'a,'b,Ex.Ample.ResultEvent.Record,Ex.Ample.ResultEvent.Record>) : ILens<'a,'b,string,string> =
        lens.ComposeWith(Ex.Ample.Optics.ResultEvent.Record.``value``)
    [<Extension>]
    static member inline Value(traversal : ITraversal<'a,'b,Ex.Ample.ResultEvent.Record,Ex.Ample.ResultEvent.Record>) : ITraversal<'a,'b,string,string> =
        traversal.ComposeWith(Ex.Ample.Optics.ResultEvent.Record.``value``)

module ServiceOne =
    let private __Marshaller__ex_ample_importable_Imported = Grpc.Core.Marshallers.Create(
        (fun (x: Ex.Ample.Importable.Imported) -> FsGrpc.Protobuf.encode x),
        (fun (arr: byte array) -> FsGrpc.Protobuf.decode arr)
    )
    let private __Marshaller__ex_ample_ResultEvent = Grpc.Core.Marshallers.Create(
        (fun (x: Ex.Ample.ResultEvent) -> FsGrpc.Protobuf.encode x),
        (fun (arr: byte array) -> FsGrpc.Protobuf.decode arr)
    )
    let private __Marshaller__ex_ample_Inner = Grpc.Core.Marshallers.Create(
        (fun (x: Ex.Ample.Inner) -> FsGrpc.Protobuf.encode x),
        (fun (arr: byte array) -> FsGrpc.Protobuf.decode arr)
    )
    let private __Marshaller__ex_ample_Outer_Nested = Grpc.Core.Marshallers.Create(
        (fun (x: Ex.Ample.Outer.Nested) -> FsGrpc.Protobuf.encode x),
        (fun (arr: byte array) -> FsGrpc.Protobuf.decode arr)
    )
    let private __Marshaller__ex_ample_importable_Args = Grpc.Core.Marshallers.Create(
        (fun (x: Ex.Ample.Importable.Args) -> FsGrpc.Protobuf.encode x),
        (fun (arr: byte array) -> FsGrpc.Protobuf.decode arr)
    )
    let private __Method_ExampleUnaryRpc =
        Grpc.Core.Method<Ex.Ample.Inner,Ex.Ample.Importable.Imported>(
            Grpc.Core.MethodType.Unary,
            "ex.ample.ServiceOne",
            "ExampleUnaryRpc",
            __Marshaller__ex_ample_Inner,
            __Marshaller__ex_ample_importable_Imported
        )
    let private __Method_ExampleServerStreamingRpc =
        Grpc.Core.Method<Ex.Ample.Outer.Nested,Ex.Ample.Importable.Imported>(
            Grpc.Core.MethodType.ServerStreaming,
            "ex.ample.ServiceOne",
            "ExampleServerStreamingRpc",
            __Marshaller__ex_ample_Outer_Nested,
            __Marshaller__ex_ample_importable_Imported
        )
    let private __Method_ExampleSubscription =
        Grpc.Core.Method<Ex.Ample.Importable.Args,Ex.Ample.ResultEvent>(
            Grpc.Core.MethodType.ServerStreaming,
            "ex.ample.ServiceOne",
            "ExampleSubscription",
            __Marshaller__ex_ample_importable_Args,
            __Marshaller__ex_ample_ResultEvent
        )
    [<AbstractClass>]
    [<Grpc.Core.BindServiceMethod(typeof<ServiceBase>, "BindService")>]
    type ServiceBase() = 
        abstract member ExampleUnaryRpc : Ex.Ample.Inner -> Grpc.Core.ServerCallContext -> System.Threading.Tasks.Task<Ex.Ample.Importable.Imported>
        abstract member ExampleServerStreamingRpc : Ex.Ample.Outer.Nested -> Grpc.Core.IServerStreamWriter<Ex.Ample.Importable.Imported> -> Grpc.Core.ServerCallContext -> System.Threading.Tasks.Task
        abstract member ExampleSubscription : Ex.Ample.Importable.Args -> Grpc.Core.IServerStreamWriter<Ex.Ample.ResultEvent> -> Grpc.Core.ServerCallContext -> System.Threading.Tasks.Task
        static member BindService (serviceBinder: Grpc.Core.ServiceBinderBase) (serviceImpl: ServiceBase) =
            let serviceMethodOrNull =
                match box serviceImpl with
                | null -> Unchecked.defaultof<Grpc.Core.UnaryServerMethod<Ex.Ample.Inner,Ex.Ample.Importable.Imported>>
                | _ -> Grpc.Core.UnaryServerMethod<Ex.Ample.Inner,Ex.Ample.Importable.Imported>(serviceImpl.ExampleUnaryRpc)
            serviceBinder.AddMethod(__Method_ExampleUnaryRpc, serviceMethodOrNull) |> ignore
            let serviceMethodOrNull =
                match box serviceImpl with
                | null -> Unchecked.defaultof<Grpc.Core.ServerStreamingServerMethod<Ex.Ample.Outer.Nested,Ex.Ample.Importable.Imported>>
                | _ -> Grpc.Core.ServerStreamingServerMethod<Ex.Ample.Outer.Nested,Ex.Ample.Importable.Imported>(serviceImpl.ExampleServerStreamingRpc)
            serviceBinder.AddMethod(__Method_ExampleServerStreamingRpc, serviceMethodOrNull) |> ignore
            let serviceMethodOrNull =
                match box serviceImpl with
                | null -> Unchecked.defaultof<Grpc.Core.ServerStreamingServerMethod<Ex.Ample.Importable.Args,Ex.Ample.ResultEvent>>
                | _ -> Grpc.Core.ServerStreamingServerMethod<Ex.Ample.Importable.Args,Ex.Ample.ResultEvent>(serviceImpl.ExampleSubscription)
            serviceBinder.AddMethod(__Method_ExampleSubscription, serviceMethodOrNull) |> ignore
    type Client = 
        inherit Grpc.Core.ClientBase<Client>
        new () = { inherit Grpc.Core.ClientBase<Client>() }
        new (channel: Grpc.Core.ChannelBase) = { inherit Grpc.Core.ClientBase<Client>(channel) }
        new (callInvoker: Grpc.Core.CallInvoker) = { inherit Grpc.Core.ClientBase<Client>(callInvoker) }
        new (configuration: Grpc.Core.ClientBase.ClientBaseConfiguration) = { inherit Grpc.Core.ClientBase<Client>(configuration) }
        override this.NewInstance (configuration: Grpc.Core.ClientBase.ClientBaseConfiguration) = Client(configuration)
        member this.ExampleUnaryRpc (callOptions: Grpc.Core.CallOptions) (request: Ex.Ample.Inner) =
            this.CallInvoker.BlockingUnaryCall(__Method_ExampleUnaryRpc, Unchecked.defaultof<string>, callOptions, request)
        member this.ExampleUnaryRpcAsync (callOptions: Grpc.Core.CallOptions) (request: Ex.Ample.Inner) =
            this.CallInvoker.AsyncUnaryCall(__Method_ExampleUnaryRpc, Unchecked.defaultof<string>, callOptions, request)
        member this.ExampleServerStreamingRpcAsync (callOptions: Grpc.Core.CallOptions) (request: Ex.Ample.Outer.Nested) =
            this.CallInvoker.AsyncServerStreamingCall(__Method_ExampleServerStreamingRpc, Unchecked.defaultof<string>, callOptions, request)
        member this.ExampleSubscriptionAsync (callOptions: Grpc.Core.CallOptions) (request: Ex.Ample.Importable.Args) =
            this.CallInvoker.AsyncServerStreamingCall(__Method_ExampleSubscription, Unchecked.defaultof<string>, callOptions, request)
