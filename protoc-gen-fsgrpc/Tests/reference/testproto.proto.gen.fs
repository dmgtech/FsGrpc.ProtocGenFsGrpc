namespace rec Test.Name.Space
open FsGrpc.Protobuf
open Google.Protobuf
#nowarn "40"
#nowarn "1182"


[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module TestMessage =

    [<System.Runtime.CompilerServices.IsByRefLike>]
    type Builder =
        struct
            val mutable TestInt: int // (1)
            val mutable TestDouble: double // (2)
            val mutable TestFixed32: uint // (3)
            val mutable TestString: string // (4)
            val mutable TestBytes: FsGrpc.Bytes // (5)
            val mutable TestFloat: float32 // (6)
            val mutable TestInt64: int64 // (7)
            val mutable TestUint64: uint64 // (8)
            val mutable TestFixed64: uint64 // (9)
            val mutable TestBool: bool // (10)
            val mutable TestUint32: uint32 // (11)
            val mutable TestSfixed32: int // (12)
            val mutable TestSfixed64: int64 // (13)
            val mutable TestSint32: int // (14)
            val mutable TestSint64: int64 // (15)
        end
        with
        member x.Put ((tag, reader): int * Reader) =
            match tag with
            | 1 -> x.TestInt <- ValueCodec.Int32.ReadValue reader
            | 2 -> x.TestDouble <- ValueCodec.Double.ReadValue reader
            | 3 -> x.TestFixed32 <- ValueCodec.Fixed32.ReadValue reader
            | 4 -> x.TestString <- ValueCodec.String.ReadValue reader
            | 5 -> x.TestBytes <- ValueCodec.Bytes.ReadValue reader
            | 6 -> x.TestFloat <- ValueCodec.Float.ReadValue reader
            | 7 -> x.TestInt64 <- ValueCodec.Int64.ReadValue reader
            | 8 -> x.TestUint64 <- ValueCodec.UInt64.ReadValue reader
            | 9 -> x.TestFixed64 <- ValueCodec.Fixed64.ReadValue reader
            | 10 -> x.TestBool <- ValueCodec.Bool.ReadValue reader
            | 11 -> x.TestUint32 <- ValueCodec.UInt32.ReadValue reader
            | 12 -> x.TestSfixed32 <- ValueCodec.SFixed32.ReadValue reader
            | 13 -> x.TestSfixed64 <- ValueCodec.SFixed64.ReadValue reader
            | 14 -> x.TestSint32 <- ValueCodec.SInt32.ReadValue reader
            | 15 -> x.TestSint64 <- ValueCodec.SInt64.ReadValue reader
            | _ -> reader.SkipLastField()
        member x.Build : Test.Name.Space.TestMessage = {
            TestInt = x.TestInt
            TestDouble = x.TestDouble
            TestFixed32 = x.TestFixed32
            TestString = x.TestString |> orEmptyString
            TestBytes = x.TestBytes
            TestFloat = x.TestFloat
            TestInt64 = x.TestInt64
            TestUint64 = x.TestUint64
            TestFixed64 = x.TestFixed64
            TestBool = x.TestBool
            TestUint32 = x.TestUint32
            TestSfixed32 = x.TestSfixed32
            TestSfixed64 = x.TestSfixed64
            TestSint32 = x.TestSint32
            TestSint64 = x.TestSint64
            }

type private _TestMessage = TestMessage
[<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.MessageConverter>)>]
[<FsGrpc.Protobuf.Message>]
[<StructuralEquality;StructuralComparison>]
type TestMessage = {
    // Field Declarations
    [<System.Text.Json.Serialization.JsonPropertyName("testInt")>] TestInt: int // (1)
    [<System.Text.Json.Serialization.JsonPropertyName("testDouble")>] TestDouble: double // (2)
    [<System.Text.Json.Serialization.JsonPropertyName("testFixed32")>] TestFixed32: uint // (3)
    [<System.Text.Json.Serialization.JsonPropertyName("testString")>] TestString: string // (4)
    [<System.Text.Json.Serialization.JsonPropertyName("testBytes")>] TestBytes: FsGrpc.Bytes // (5)
    [<System.Text.Json.Serialization.JsonPropertyName("testFloat")>] TestFloat: float32 // (6)
    [<System.Text.Json.Serialization.JsonPropertyName("testInt64")>] TestInt64: int64 // (7)
    [<System.Text.Json.Serialization.JsonPropertyName("testUint64")>] TestUint64: uint64 // (8)
    [<System.Text.Json.Serialization.JsonPropertyName("testFixed64")>] TestFixed64: uint64 // (9)
    [<System.Text.Json.Serialization.JsonPropertyName("testBool")>] TestBool: bool // (10)
    [<System.Text.Json.Serialization.JsonPropertyName("testUint32")>] TestUint32: uint32 // (11)
    [<System.Text.Json.Serialization.JsonPropertyName("testSfixed32")>] TestSfixed32: int // (12)
    [<System.Text.Json.Serialization.JsonPropertyName("testSfixed64")>] TestSfixed64: int64 // (13)
    [<System.Text.Json.Serialization.JsonPropertyName("testSint32")>] TestSint32: int // (14)
    [<System.Text.Json.Serialization.JsonPropertyName("testSint64")>] TestSint64: int64 // (15)
    }
    with
    static member Proto : Lazy<ProtoDef<TestMessage>> =
        lazy
        // Field Definitions
        let TestInt = FieldCodec.Primitive ValueCodec.Int32 (1, "testInt")
        let TestDouble = FieldCodec.Primitive ValueCodec.Double (2, "testDouble")
        let TestFixed32 = FieldCodec.Primitive ValueCodec.Fixed32 (3, "testFixed32")
        let TestString = FieldCodec.Primitive ValueCodec.String (4, "testString")
        let TestBytes = FieldCodec.Primitive ValueCodec.Bytes (5, "testBytes")
        let TestFloat = FieldCodec.Primitive ValueCodec.Float (6, "testFloat")
        let TestInt64 = FieldCodec.Primitive ValueCodec.Int64 (7, "testInt64")
        let TestUint64 = FieldCodec.Primitive ValueCodec.UInt64 (8, "testUint64")
        let TestFixed64 = FieldCodec.Primitive ValueCodec.Fixed64 (9, "testFixed64")
        let TestBool = FieldCodec.Primitive ValueCodec.Bool (10, "testBool")
        let TestUint32 = FieldCodec.Primitive ValueCodec.UInt32 (11, "testUint32")
        let TestSfixed32 = FieldCodec.Primitive ValueCodec.SFixed32 (12, "testSfixed32")
        let TestSfixed64 = FieldCodec.Primitive ValueCodec.SFixed64 (13, "testSfixed64")
        let TestSint32 = FieldCodec.Primitive ValueCodec.SInt32 (14, "testSint32")
        let TestSint64 = FieldCodec.Primitive ValueCodec.SInt64 (15, "testSint64")
        // Proto Definition Implementation
        { // ProtoDef<TestMessage>
            Name = "TestMessage"
            Empty = {
                TestInt = TestInt.GetDefault()
                TestDouble = TestDouble.GetDefault()
                TestFixed32 = TestFixed32.GetDefault()
                TestString = TestString.GetDefault()
                TestBytes = TestBytes.GetDefault()
                TestFloat = TestFloat.GetDefault()
                TestInt64 = TestInt64.GetDefault()
                TestUint64 = TestUint64.GetDefault()
                TestFixed64 = TestFixed64.GetDefault()
                TestBool = TestBool.GetDefault()
                TestUint32 = TestUint32.GetDefault()
                TestSfixed32 = TestSfixed32.GetDefault()
                TestSfixed64 = TestSfixed64.GetDefault()
                TestSint32 = TestSint32.GetDefault()
                TestSint64 = TestSint64.GetDefault()
                }
            Size = fun (m: TestMessage) ->
                0
                + TestInt.CalcFieldSize m.TestInt
                + TestDouble.CalcFieldSize m.TestDouble
                + TestFixed32.CalcFieldSize m.TestFixed32
                + TestString.CalcFieldSize m.TestString
                + TestBytes.CalcFieldSize m.TestBytes
                + TestFloat.CalcFieldSize m.TestFloat
                + TestInt64.CalcFieldSize m.TestInt64
                + TestUint64.CalcFieldSize m.TestUint64
                + TestFixed64.CalcFieldSize m.TestFixed64
                + TestBool.CalcFieldSize m.TestBool
                + TestUint32.CalcFieldSize m.TestUint32
                + TestSfixed32.CalcFieldSize m.TestSfixed32
                + TestSfixed64.CalcFieldSize m.TestSfixed64
                + TestSint32.CalcFieldSize m.TestSint32
                + TestSint64.CalcFieldSize m.TestSint64
            Encode = fun (w: Google.Protobuf.CodedOutputStream) (m: TestMessage) ->
                TestInt.WriteField w m.TestInt
                TestDouble.WriteField w m.TestDouble
                TestFixed32.WriteField w m.TestFixed32
                TestString.WriteField w m.TestString
                TestBytes.WriteField w m.TestBytes
                TestFloat.WriteField w m.TestFloat
                TestInt64.WriteField w m.TestInt64
                TestUint64.WriteField w m.TestUint64
                TestFixed64.WriteField w m.TestFixed64
                TestBool.WriteField w m.TestBool
                TestUint32.WriteField w m.TestUint32
                TestSfixed32.WriteField w m.TestSfixed32
                TestSfixed64.WriteField w m.TestSfixed64
                TestSint32.WriteField w m.TestSint32
                TestSint64.WriteField w m.TestSint64
            Decode = fun (r: Google.Protobuf.CodedInputStream) ->
                let mutable builder = new Test.Name.Space.TestMessage.Builder()
                let mutable tag = 0
                while read r &tag do
                    builder.Put (tag, r)
                builder.Build
            EncodeJson = fun (o: JsonOptions) ->
                let writeTestInt = TestInt.WriteJsonField o
                let writeTestDouble = TestDouble.WriteJsonField o
                let writeTestFixed32 = TestFixed32.WriteJsonField o
                let writeTestString = TestString.WriteJsonField o
                let writeTestBytes = TestBytes.WriteJsonField o
                let writeTestFloat = TestFloat.WriteJsonField o
                let writeTestInt64 = TestInt64.WriteJsonField o
                let writeTestUint64 = TestUint64.WriteJsonField o
                let writeTestFixed64 = TestFixed64.WriteJsonField o
                let writeTestBool = TestBool.WriteJsonField o
                let writeTestUint32 = TestUint32.WriteJsonField o
                let writeTestSfixed32 = TestSfixed32.WriteJsonField o
                let writeTestSfixed64 = TestSfixed64.WriteJsonField o
                let writeTestSint32 = TestSint32.WriteJsonField o
                let writeTestSint64 = TestSint64.WriteJsonField o
                let encode (w: System.Text.Json.Utf8JsonWriter) (m: TestMessage) =
                    writeTestInt w m.TestInt
                    writeTestDouble w m.TestDouble
                    writeTestFixed32 w m.TestFixed32
                    writeTestString w m.TestString
                    writeTestBytes w m.TestBytes
                    writeTestFloat w m.TestFloat
                    writeTestInt64 w m.TestInt64
                    writeTestUint64 w m.TestUint64
                    writeTestFixed64 w m.TestFixed64
                    writeTestBool w m.TestBool
                    writeTestUint32 w m.TestUint32
                    writeTestSfixed32 w m.TestSfixed32
                    writeTestSfixed64 w m.TestSfixed64
                    writeTestSint32 w m.TestSint32
                    writeTestSint64 w m.TestSint64
                encode
            DecodeJson = fun (node: System.Text.Json.Nodes.JsonNode) ->
                let update value (kvPair: System.Collections.Generic.KeyValuePair<string,System.Text.Json.Nodes.JsonNode>) : TestMessage =
                    match kvPair.Key with
                    | "testInt" -> { value with TestInt = TestInt.ReadJsonField kvPair.Value }
                    | "testDouble" -> { value with TestDouble = TestDouble.ReadJsonField kvPair.Value }
                    | "testFixed32" -> { value with TestFixed32 = TestFixed32.ReadJsonField kvPair.Value }
                    | "testString" -> { value with TestString = TestString.ReadJsonField kvPair.Value }
                    | "testBytes" -> { value with TestBytes = TestBytes.ReadJsonField kvPair.Value }
                    | "testFloat" -> { value with TestFloat = TestFloat.ReadJsonField kvPair.Value }
                    | "testInt64" -> { value with TestInt64 = TestInt64.ReadJsonField kvPair.Value }
                    | "testUint64" -> { value with TestUint64 = TestUint64.ReadJsonField kvPair.Value }
                    | "testFixed64" -> { value with TestFixed64 = TestFixed64.ReadJsonField kvPair.Value }
                    | "testBool" -> { value with TestBool = TestBool.ReadJsonField kvPair.Value }
                    | "testUint32" -> { value with TestUint32 = TestUint32.ReadJsonField kvPair.Value }
                    | "testSfixed32" -> { value with TestSfixed32 = TestSfixed32.ReadJsonField kvPair.Value }
                    | "testSfixed64" -> { value with TestSfixed64 = TestSfixed64.ReadJsonField kvPair.Value }
                    | "testSint32" -> { value with TestSint32 = TestSint32.ReadJsonField kvPair.Value }
                    | "testSint64" -> { value with TestSint64 = TestSint64.ReadJsonField kvPair.Value }
                    | _ -> value
                Seq.fold update _TestMessage.empty (node.AsObject ())
        }
    static member empty
        with get() = Test.Name.Space._TestMessage.Proto.Value.Empty

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module Nest =

    [<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    module Inner =

        [<System.Runtime.CompilerServices.IsByRefLike>]
        type Builder =
            struct
                val mutable InnerName: string // (1)
            end
            with
            member x.Put ((tag, reader): int * Reader) =
                match tag with
                | 1 -> x.InnerName <- ValueCodec.String.ReadValue reader
                | _ -> reader.SkipLastField()
            member x.Build : Test.Name.Space.Nest.Inner = {
                InnerName = x.InnerName |> orEmptyString
                }

    type private _Inner = Inner
    [<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.MessageConverter>)>]
    [<FsGrpc.Protobuf.Message>]
    [<StructuralEquality;StructuralComparison>]
    type Inner = {
        // Field Declarations
        [<System.Text.Json.Serialization.JsonPropertyName("innerName")>] InnerName: string // (1)
        }
        with
        static member Proto : Lazy<ProtoDef<Inner>> =
            lazy
            // Field Definitions
            let InnerName = FieldCodec.Primitive ValueCodec.String (1, "innerName")
            // Proto Definition Implementation
            { // ProtoDef<Inner>
                Name = "Inner"
                Empty = {
                    InnerName = InnerName.GetDefault()
                    }
                Size = fun (m: Inner) ->
                    0
                    + InnerName.CalcFieldSize m.InnerName
                Encode = fun (w: Google.Protobuf.CodedOutputStream) (m: Inner) ->
                    InnerName.WriteField w m.InnerName
                Decode = fun (r: Google.Protobuf.CodedInputStream) ->
                    let mutable builder = new Test.Name.Space.Nest.Inner.Builder()
                    let mutable tag = 0
                    while read r &tag do
                        builder.Put (tag, r)
                    builder.Build
                EncodeJson = fun (o: JsonOptions) ->
                    let writeInnerName = InnerName.WriteJsonField o
                    let encode (w: System.Text.Json.Utf8JsonWriter) (m: Inner) =
                        writeInnerName w m.InnerName
                    encode
                DecodeJson = fun (node: System.Text.Json.Nodes.JsonNode) ->
                    let update value (kvPair: System.Collections.Generic.KeyValuePair<string,System.Text.Json.Nodes.JsonNode>) : Inner =
                        match kvPair.Key with
                        | "innerName" -> { value with InnerName = InnerName.ReadJsonField kvPair.Value }
                        | _ -> value
                    Seq.fold update _Inner.empty (node.AsObject ())
            }
        static member empty
            with get() = Test.Name.Space.Nest._Inner.Proto.Value.Empty

    [<System.Runtime.CompilerServices.IsByRefLike>]
    type Builder =
        struct
            val mutable Name: string // (1)
            val mutable Children: RepeatedBuilder<Test.Name.Space.Nest> // (2)
            val mutable Inner: OptionBuilder<Test.Name.Space.Nest.Inner> // (3)
            val mutable Special: OptionBuilder<Test.Name.Space.Special> // (4)
        end
        with
        member x.Put ((tag, reader): int * Reader) =
            match tag with
            | 1 -> x.Name <- ValueCodec.String.ReadValue reader
            | 2 -> x.Children.Add (ValueCodec.Message<Test.Name.Space.Nest>.ReadValue reader)
            | 3 -> x.Inner.Set (ValueCodec.Message<Test.Name.Space.Nest.Inner>.ReadValue reader)
            | 4 -> x.Special.Set (ValueCodec.Message<Test.Name.Space.Special>.ReadValue reader)
            | _ -> reader.SkipLastField()
        member x.Build : Test.Name.Space.Nest = {
            Name = x.Name |> orEmptyString
            Children = x.Children.Build
            Inner = x.Inner.Build
            Special = x.Special.Build
            }

type private _Nest = Nest
[<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.MessageConverter>)>]
[<FsGrpc.Protobuf.Message>]
[<StructuralEquality;StructuralComparison>]
type Nest = {
    // Field Declarations
    [<System.Text.Json.Serialization.JsonPropertyName("name")>] Name: string // (1)
    [<System.Text.Json.Serialization.JsonPropertyName("children")>] Children: Test.Name.Space.Nest list // (2)
    [<System.Text.Json.Serialization.JsonPropertyName("inner")>] Inner: Test.Name.Space.Nest.Inner option // (3)
    [<System.Text.Json.Serialization.JsonPropertyName("special")>] Special: Test.Name.Space.Special option // (4)
    }
    with
    static member Proto : Lazy<ProtoDef<Nest>> =
        lazy
        // Field Definitions
        let Name = FieldCodec.Primitive ValueCodec.String (1, "name")
        let Children = FieldCodec.Repeated ValueCodec.Message<Test.Name.Space.Nest> (2, "children")
        let Inner = FieldCodec.Optional ValueCodec.Message<Test.Name.Space.Nest.Inner> (3, "inner")
        let Special = FieldCodec.Optional ValueCodec.Message<Test.Name.Space.Special> (4, "special")
        // Proto Definition Implementation
        { // ProtoDef<Nest>
            Name = "Nest"
            Empty = {
                Name = Name.GetDefault()
                Children = Children.GetDefault()
                Inner = Inner.GetDefault()
                Special = Special.GetDefault()
                }
            Size = fun (m: Nest) ->
                0
                + Name.CalcFieldSize m.Name
                + Children.CalcFieldSize m.Children
                + Inner.CalcFieldSize m.Inner
                + Special.CalcFieldSize m.Special
            Encode = fun (w: Google.Protobuf.CodedOutputStream) (m: Nest) ->
                Name.WriteField w m.Name
                Children.WriteField w m.Children
                Inner.WriteField w m.Inner
                Special.WriteField w m.Special
            Decode = fun (r: Google.Protobuf.CodedInputStream) ->
                let mutable builder = new Test.Name.Space.Nest.Builder()
                let mutable tag = 0
                while read r &tag do
                    builder.Put (tag, r)
                builder.Build
            EncodeJson = fun (o: JsonOptions) ->
                let writeName = Name.WriteJsonField o
                let writeChildren = Children.WriteJsonField o
                let writeInner = Inner.WriteJsonField o
                let writeSpecial = Special.WriteJsonField o
                let encode (w: System.Text.Json.Utf8JsonWriter) (m: Nest) =
                    writeName w m.Name
                    writeChildren w m.Children
                    writeInner w m.Inner
                    writeSpecial w m.Special
                encode
            DecodeJson = fun (node: System.Text.Json.Nodes.JsonNode) ->
                let update value (kvPair: System.Collections.Generic.KeyValuePair<string,System.Text.Json.Nodes.JsonNode>) : Nest =
                    match kvPair.Key with
                    | "name" -> { value with Name = Name.ReadJsonField kvPair.Value }
                    | "children" -> { value with Children = Children.ReadJsonField kvPair.Value }
                    | "inner" -> { value with Inner = Inner.ReadJsonField kvPair.Value }
                    | "special" -> { value with Special = Special.ReadJsonField kvPair.Value }
                    | _ -> value
                Seq.fold update _Nest.empty (node.AsObject ())
        }
    static member empty
        with get() = Test.Name.Space._Nest.Proto.Value.Empty

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module Special =

    [<System.Runtime.CompilerServices.IsByRefLike>]
    type Builder =
        struct
            val mutable IntList: RepeatedBuilder<int> // (1)
            val mutable DoubleList: RepeatedBuilder<double> // (2)
            val mutable Fixed32List: RepeatedBuilder<uint> // (3)
            val mutable StringList: RepeatedBuilder<string> // (4)
            val mutable Dictionary: MapBuilder<string, string> // (16)
        end
        with
        member x.Put ((tag, reader): int * Reader) =
            match tag with
            | 1 -> x.IntList.AddRange ((ValueCodec.Packed ValueCodec.Int32).ReadValue reader)
            | 2 -> x.DoubleList.AddRange ((ValueCodec.Packed ValueCodec.Double).ReadValue reader)
            | 3 -> x.Fixed32List.AddRange ((ValueCodec.Packed ValueCodec.Fixed32).ReadValue reader)
            | 4 -> x.StringList.Add (ValueCodec.String.ReadValue reader)
            | 16 -> x.Dictionary.Add ((ValueCodec.MapRecord ValueCodec.String ValueCodec.String).ReadValue reader)
            | _ -> reader.SkipLastField()
        member x.Build : Test.Name.Space.Special = {
            IntList = x.IntList.Build
            DoubleList = x.DoubleList.Build
            Fixed32List = x.Fixed32List.Build
            StringList = x.StringList.Build
            Dictionary = x.Dictionary.Build
            }

type private _Special = Special
[<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.MessageConverter>)>]
[<FsGrpc.Protobuf.Message>]
[<StructuralEquality;StructuralComparison>]
type Special = {
    // Field Declarations
    [<System.Text.Json.Serialization.JsonPropertyName("intList")>] IntList: int list // (1)
    [<System.Text.Json.Serialization.JsonPropertyName("doubleList")>] DoubleList: double list // (2)
    [<System.Text.Json.Serialization.JsonPropertyName("fixed32List")>] Fixed32List: uint list // (3)
    [<System.Text.Json.Serialization.JsonPropertyName("stringList")>] StringList: string list // (4)
    [<System.Text.Json.Serialization.JsonPropertyName("dictionary")>] Dictionary: Map<string, string> // (16)
    }
    with
    static member Proto : Lazy<ProtoDef<Special>> =
        lazy
        // Field Definitions
        let IntList = FieldCodec.Primitive (ValueCodec.Packed ValueCodec.Int32) (1, "intList")
        let DoubleList = FieldCodec.Primitive (ValueCodec.Packed ValueCodec.Double) (2, "doubleList")
        let Fixed32List = FieldCodec.Primitive (ValueCodec.Packed ValueCodec.Fixed32) (3, "fixed32List")
        let StringList = FieldCodec.Repeated ValueCodec.String (4, "stringList")
        let Dictionary = FieldCodec.Map ValueCodec.String ValueCodec.String (16, "dictionary")
        // Proto Definition Implementation
        { // ProtoDef<Special>
            Name = "Special"
            Empty = {
                IntList = IntList.GetDefault()
                DoubleList = DoubleList.GetDefault()
                Fixed32List = Fixed32List.GetDefault()
                StringList = StringList.GetDefault()
                Dictionary = Dictionary.GetDefault()
                }
            Size = fun (m: Special) ->
                0
                + IntList.CalcFieldSize m.IntList
                + DoubleList.CalcFieldSize m.DoubleList
                + Fixed32List.CalcFieldSize m.Fixed32List
                + StringList.CalcFieldSize m.StringList
                + Dictionary.CalcFieldSize m.Dictionary
            Encode = fun (w: Google.Protobuf.CodedOutputStream) (m: Special) ->
                IntList.WriteField w m.IntList
                DoubleList.WriteField w m.DoubleList
                Fixed32List.WriteField w m.Fixed32List
                StringList.WriteField w m.StringList
                Dictionary.WriteField w m.Dictionary
            Decode = fun (r: Google.Protobuf.CodedInputStream) ->
                let mutable builder = new Test.Name.Space.Special.Builder()
                let mutable tag = 0
                while read r &tag do
                    builder.Put (tag, r)
                builder.Build
            EncodeJson = fun (o: JsonOptions) ->
                let writeIntList = IntList.WriteJsonField o
                let writeDoubleList = DoubleList.WriteJsonField o
                let writeFixed32List = Fixed32List.WriteJsonField o
                let writeStringList = StringList.WriteJsonField o
                let writeDictionary = Dictionary.WriteJsonField o
                let encode (w: System.Text.Json.Utf8JsonWriter) (m: Special) =
                    writeIntList w m.IntList
                    writeDoubleList w m.DoubleList
                    writeFixed32List w m.Fixed32List
                    writeStringList w m.StringList
                    writeDictionary w m.Dictionary
                encode
            DecodeJson = fun (node: System.Text.Json.Nodes.JsonNode) ->
                let update value (kvPair: System.Collections.Generic.KeyValuePair<string,System.Text.Json.Nodes.JsonNode>) : Special =
                    match kvPair.Key with
                    | "intList" -> { value with IntList = IntList.ReadJsonField kvPair.Value }
                    | "doubleList" -> { value with DoubleList = DoubleList.ReadJsonField kvPair.Value }
                    | "fixed32List" -> { value with Fixed32List = Fixed32List.ReadJsonField kvPair.Value }
                    | "stringList" -> { value with StringList = StringList.ReadJsonField kvPair.Value }
                    | "dictionary" -> { value with Dictionary = Dictionary.ReadJsonField kvPair.Value }
                    | _ -> value
                Seq.fold update _Special.empty (node.AsObject ())
        }
    static member empty
        with get() = Test.Name.Space._Special.Proto.Value.Empty

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module Enums =

    [<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.OneofConverter<UnionCase>>)>]
    [<CompilationRepresentation(CompilationRepresentationFlags.UseNullAsTrueValue)>]
    [<StructuralEquality;StructuralComparison>]
    [<RequireQualifiedAccess>]
    type UnionCase =
    | None
    | [<System.Text.Json.Serialization.JsonPropertyName("color")>] Color of Test.Name.Space.Enums.Color
    | [<System.Text.Json.Serialization.JsonPropertyName("name")>] Name of string
    with
        static member OneofCodec : Lazy<OneofCodec<UnionCase>> = 
            lazy
            let Color = FieldCodec.OneofCase "union" ValueCodec.Enum<Test.Name.Space.Enums.Color> (4, "color")
            let Name = FieldCodec.OneofCase "union" ValueCodec.String (5, "name")
            let Union = FieldCodec.Oneof "union" (FSharp.Collections.Map [
                ("color", fun node -> UnionCase.Color (Color.ReadJsonField node))
                ("name", fun node -> UnionCase.Name (Name.ReadJsonField node))
                ])
            Union

    [<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.EnumConverter<Color>>)>]
    type Color =
    | [<FsGrpc.Protobuf.ProtobufName("COLOR_BLACK")>] Black = 0
    | [<FsGrpc.Protobuf.ProtobufName("COLOR_RED")>] Red = 1
    | [<FsGrpc.Protobuf.ProtobufName("COLOR_GREEN")>] Green = 2
    | [<FsGrpc.Protobuf.ProtobufName("COLOR_BLUE")>] Blue = 3

    [<System.Runtime.CompilerServices.IsByRefLike>]
    type Builder =
        struct
            val mutable MainColor: Test.Name.Space.Enums.Color // (1)
            val mutable OtherColors: RepeatedBuilder<Test.Name.Space.Enums.Color> // (2)
            val mutable ByName: MapBuilder<string, Test.Name.Space.Enums.Color> // (3)
            val mutable Union: OptionBuilder<Test.Name.Space.Enums.UnionCase>
            val mutable MaybeColor: OptionBuilder<Test.Name.Space.Enums.Color> // (6)
        end
        with
        member x.Put ((tag, reader): int * Reader) =
            match tag with
            | 1 -> x.MainColor <- ValueCodec.Enum<Test.Name.Space.Enums.Color>.ReadValue reader
            | 2 -> x.OtherColors.AddRange ((ValueCodec.Packed ValueCodec.Enum<Test.Name.Space.Enums.Color>).ReadValue reader)
            | 3 -> x.ByName.Add ((ValueCodec.MapRecord ValueCodec.String ValueCodec.Enum<Test.Name.Space.Enums.Color>).ReadValue reader)
            | 4 -> x.Union.Set (UnionCase.Color (ValueCodec.Enum<Test.Name.Space.Enums.Color>.ReadValue reader))
            | 5 -> x.Union.Set (UnionCase.Name (ValueCodec.String.ReadValue reader))
            | 6 -> x.MaybeColor.Set (ValueCodec.Enum<Test.Name.Space.Enums.Color>.ReadValue reader)
            | _ -> reader.SkipLastField()
        member x.Build : Test.Name.Space.Enums = {
            MainColor = x.MainColor
            OtherColors = x.OtherColors.Build
            ByName = x.ByName.Build
            Union = x.Union.Build |> (Option.defaultValue UnionCase.None)
            MaybeColor = x.MaybeColor.Build
            }

type private _Enums = Enums
[<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.MessageConverter>)>]
[<FsGrpc.Protobuf.Message>]
[<StructuralEquality;StructuralComparison>]
type Enums = {
    // Field Declarations
    [<System.Text.Json.Serialization.JsonPropertyName("mainColor")>] MainColor: Test.Name.Space.Enums.Color // (1)
    [<System.Text.Json.Serialization.JsonPropertyName("otherColors")>] OtherColors: Test.Name.Space.Enums.Color list // (2)
    [<System.Text.Json.Serialization.JsonPropertyName("byName")>] ByName: Map<string, Test.Name.Space.Enums.Color> // (3)
    Union: Test.Name.Space.Enums.UnionCase
    [<System.Text.Json.Serialization.JsonPropertyName("maybeColor")>] MaybeColor: Test.Name.Space.Enums.Color option // (6)
    }
    with
    static member Proto : Lazy<ProtoDef<Enums>> =
        lazy
        // Field Definitions
        let MainColor = FieldCodec.Primitive ValueCodec.Enum<Test.Name.Space.Enums.Color> (1, "mainColor")
        let OtherColors = FieldCodec.Primitive (ValueCodec.Packed ValueCodec.Enum<Test.Name.Space.Enums.Color>) (2, "otherColors")
        let ByName = FieldCodec.Map ValueCodec.String ValueCodec.Enum<Test.Name.Space.Enums.Color> (3, "byName")
        let Color = FieldCodec.OneofCase "union" ValueCodec.Enum<Test.Name.Space.Enums.Color> (4, "color")
        let Name = FieldCodec.OneofCase "union" ValueCodec.String (5, "name")
        let MaybeColor = FieldCodec.Optional ValueCodec.Enum<Test.Name.Space.Enums.Color> (6, "maybeColor")
        let Union = FieldCodec.Oneof "union" (FSharp.Collections.Map [
            ("color", fun node -> Test.Name.Space.Enums.UnionCase.Color (Color.ReadJsonField node))
            ("name", fun node -> Test.Name.Space.Enums.UnionCase.Name (Name.ReadJsonField node))
            ])
        // Proto Definition Implementation
        { // ProtoDef<Enums>
            Name = "Enums"
            Empty = {
                MainColor = MainColor.GetDefault()
                OtherColors = OtherColors.GetDefault()
                ByName = ByName.GetDefault()
                Union = Test.Name.Space.Enums.UnionCase.None
                MaybeColor = MaybeColor.GetDefault()
                }
            Size = fun (m: Enums) ->
                0
                + MainColor.CalcFieldSize m.MainColor
                + OtherColors.CalcFieldSize m.OtherColors
                + ByName.CalcFieldSize m.ByName
                + match m.Union with
                    | Test.Name.Space.Enums.UnionCase.None -> 0
                    | Test.Name.Space.Enums.UnionCase.Color v -> Color.CalcFieldSize v
                    | Test.Name.Space.Enums.UnionCase.Name v -> Name.CalcFieldSize v
                + MaybeColor.CalcFieldSize m.MaybeColor
            Encode = fun (w: Google.Protobuf.CodedOutputStream) (m: Enums) ->
                MainColor.WriteField w m.MainColor
                OtherColors.WriteField w m.OtherColors
                ByName.WriteField w m.ByName
                (match m.Union with
                | Test.Name.Space.Enums.UnionCase.None -> ()
                | Test.Name.Space.Enums.UnionCase.Color v -> Color.WriteField w v
                | Test.Name.Space.Enums.UnionCase.Name v -> Name.WriteField w v
                )
                MaybeColor.WriteField w m.MaybeColor
            Decode = fun (r: Google.Protobuf.CodedInputStream) ->
                let mutable builder = new Test.Name.Space.Enums.Builder()
                let mutable tag = 0
                while read r &tag do
                    builder.Put (tag, r)
                builder.Build
            EncodeJson = fun (o: JsonOptions) ->
                let writeMainColor = MainColor.WriteJsonField o
                let writeOtherColors = OtherColors.WriteJsonField o
                let writeByName = ByName.WriteJsonField o
                let writeUnionNone = Union.WriteJsonNoneCase o
                let writeColor = Color.WriteJsonField o
                let writeName = Name.WriteJsonField o
                let writeMaybeColor = MaybeColor.WriteJsonField o
                let encode (w: System.Text.Json.Utf8JsonWriter) (m: Enums) =
                    writeMainColor w m.MainColor
                    writeOtherColors w m.OtherColors
                    writeByName w m.ByName
                    (match m.Union with
                    | Test.Name.Space.Enums.UnionCase.None -> writeUnionNone w
                    | Test.Name.Space.Enums.UnionCase.Color v -> writeColor w v
                    | Test.Name.Space.Enums.UnionCase.Name v -> writeName w v
                    )
                    writeMaybeColor w m.MaybeColor
                encode
            DecodeJson = fun (node: System.Text.Json.Nodes.JsonNode) ->
                let update value (kvPair: System.Collections.Generic.KeyValuePair<string,System.Text.Json.Nodes.JsonNode>) : Enums =
                    match kvPair.Key with
                    | "mainColor" -> { value with MainColor = MainColor.ReadJsonField kvPair.Value }
                    | "otherColors" -> { value with OtherColors = OtherColors.ReadJsonField kvPair.Value }
                    | "byName" -> { value with ByName = ByName.ReadJsonField kvPair.Value }
                    | "color" -> { value with Union = Test.Name.Space.Enums.UnionCase.Color (Color.ReadJsonField kvPair.Value) }
                    | "name" -> { value with Union = Test.Name.Space.Enums.UnionCase.Name (Name.ReadJsonField kvPair.Value) }
                    | "union" -> { value with Union = Union.ReadJsonField kvPair.Value }
                    | "maybeColor" -> { value with MaybeColor = MaybeColor.ReadJsonField kvPair.Value }
                    | _ -> value
                Seq.fold update _Enums.empty (node.AsObject ())
        }
    static member empty
        with get() = Test.Name.Space._Enums.Proto.Value.Empty

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module Google =

    [<System.Runtime.CompilerServices.IsByRefLike>]
    type Builder =
        struct
            val mutable Int32Val: OptionBuilder<int> // (1)
            val mutable StringVal: OptionBuilder<string> // (2)
            val mutable Timestamp: OptionBuilder<NodaTime.Instant> // (3)
            val mutable Duration: OptionBuilder<NodaTime.Duration> // (4)
        end
        with
        member x.Put ((tag, reader): int * Reader) =
            match tag with
            | 1 -> x.Int32Val.Set ((ValueCodec.Wrap ValueCodec.Int32).ReadValue reader)
            | 2 -> x.StringVal.Set ((ValueCodec.Wrap ValueCodec.String).ReadValue reader)
            | 3 -> x.Timestamp.Set (ValueCodec.Timestamp.ReadValue reader)
            | 4 -> x.Duration.Set (ValueCodec.Duration.ReadValue reader)
            | _ -> reader.SkipLastField()
        member x.Build : Test.Name.Space.Google = {
            Int32Val = x.Int32Val.Build
            StringVal = x.StringVal.Build
            Timestamp = x.Timestamp.Build
            Duration = x.Duration.Build
            }

type private _Google = Google
[<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.MessageConverter>)>]
[<FsGrpc.Protobuf.Message>]
[<StructuralEquality;StructuralComparison>]
type Google = {
    // Field Declarations
    [<System.Text.Json.Serialization.JsonPropertyName("int32Val")>] Int32Val: int option // (1)
    [<System.Text.Json.Serialization.JsonPropertyName("stringVal")>] StringVal: string option // (2)
    [<System.Text.Json.Serialization.JsonPropertyName("timestamp")>] Timestamp: NodaTime.Instant option // (3)
    [<System.Text.Json.Serialization.JsonPropertyName("duration")>] Duration: NodaTime.Duration option // (4)
    }
    with
    static member Proto : Lazy<ProtoDef<Google>> =
        lazy
        // Field Definitions
        let Int32Val = FieldCodec.Optional (ValueCodec.Wrap ValueCodec.Int32) (1, "int32Val")
        let StringVal = FieldCodec.Optional (ValueCodec.Wrap ValueCodec.String) (2, "stringVal")
        let Timestamp = FieldCodec.Optional ValueCodec.Timestamp (3, "timestamp")
        let Duration = FieldCodec.Optional ValueCodec.Duration (4, "duration")
        // Proto Definition Implementation
        { // ProtoDef<Google>
            Name = "Google"
            Empty = {
                Int32Val = Int32Val.GetDefault()
                StringVal = StringVal.GetDefault()
                Timestamp = Timestamp.GetDefault()
                Duration = Duration.GetDefault()
                }
            Size = fun (m: Google) ->
                0
                + Int32Val.CalcFieldSize m.Int32Val
                + StringVal.CalcFieldSize m.StringVal
                + Timestamp.CalcFieldSize m.Timestamp
                + Duration.CalcFieldSize m.Duration
            Encode = fun (w: Google.Protobuf.CodedOutputStream) (m: Google) ->
                Int32Val.WriteField w m.Int32Val
                StringVal.WriteField w m.StringVal
                Timestamp.WriteField w m.Timestamp
                Duration.WriteField w m.Duration
            Decode = fun (r: Google.Protobuf.CodedInputStream) ->
                let mutable builder = new Test.Name.Space.Google.Builder()
                let mutable tag = 0
                while read r &tag do
                    builder.Put (tag, r)
                builder.Build
            EncodeJson = fun (o: JsonOptions) ->
                let writeInt32Val = Int32Val.WriteJsonField o
                let writeStringVal = StringVal.WriteJsonField o
                let writeTimestamp = Timestamp.WriteJsonField o
                let writeDuration = Duration.WriteJsonField o
                let encode (w: System.Text.Json.Utf8JsonWriter) (m: Google) =
                    writeInt32Val w m.Int32Val
                    writeStringVal w m.StringVal
                    writeTimestamp w m.Timestamp
                    writeDuration w m.Duration
                encode
            DecodeJson = fun (node: System.Text.Json.Nodes.JsonNode) ->
                let update value (kvPair: System.Collections.Generic.KeyValuePair<string,System.Text.Json.Nodes.JsonNode>) : Google =
                    match kvPair.Key with
                    | "int32Val" -> { value with Int32Val = Int32Val.ReadJsonField kvPair.Value }
                    | "stringVal" -> { value with StringVal = StringVal.ReadJsonField kvPair.Value }
                    | "timestamp" -> { value with Timestamp = Timestamp.ReadJsonField kvPair.Value }
                    | "duration" -> { value with Duration = Duration.ReadJsonField kvPair.Value }
                    | _ -> value
                Seq.fold update _Google.empty (node.AsObject ())
        }
    static member empty
        with get() = Test.Name.Space._Google.Proto.Value.Empty

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module IntMap =

    [<System.Runtime.CompilerServices.IsByRefLike>]
    type Builder =
        struct
            val mutable IntMap: MapBuilder<int, string> // (1)
        end
        with
        member x.Put ((tag, reader): int * Reader) =
            match tag with
            | 1 -> x.IntMap.Add ((ValueCodec.MapRecord ValueCodec.Int32 ValueCodec.String).ReadValue reader)
            | _ -> reader.SkipLastField()
        member x.Build : Test.Name.Space.IntMap = {
            IntMap = x.IntMap.Build
            }

type private _IntMap = IntMap
[<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.MessageConverter>)>]
[<FsGrpc.Protobuf.Message>]
[<StructuralEquality;StructuralComparison>]
type IntMap = {
    // Field Declarations
    [<System.Text.Json.Serialization.JsonPropertyName("intMap")>] IntMap: Map<int, string> // (1)
    }
    with
    static member Proto : Lazy<ProtoDef<IntMap>> =
        lazy
        // Field Definitions
        let IntMap = FieldCodec.Map ValueCodec.Int32 ValueCodec.String (1, "intMap")
        // Proto Definition Implementation
        { // ProtoDef<IntMap>
            Name = "IntMap"
            Empty = {
                IntMap = IntMap.GetDefault()
                }
            Size = fun (m: IntMap) ->
                0
                + IntMap.CalcFieldSize m.IntMap
            Encode = fun (w: Google.Protobuf.CodedOutputStream) (m: IntMap) ->
                IntMap.WriteField w m.IntMap
            Decode = fun (r: Google.Protobuf.CodedInputStream) ->
                let mutable builder = new Test.Name.Space.IntMap.Builder()
                let mutable tag = 0
                while read r &tag do
                    builder.Put (tag, r)
                builder.Build
            EncodeJson = fun (o: JsonOptions) ->
                let writeIntMap = IntMap.WriteJsonField o
                let encode (w: System.Text.Json.Utf8JsonWriter) (m: IntMap) =
                    writeIntMap w m.IntMap
                encode
            DecodeJson = fun (node: System.Text.Json.Nodes.JsonNode) ->
                let update value (kvPair: System.Collections.Generic.KeyValuePair<string,System.Text.Json.Nodes.JsonNode>) : IntMap =
                    match kvPair.Key with
                    | "intMap" -> { value with IntMap = IntMap.ReadJsonField kvPair.Value }
                    | _ -> value
                Seq.fold update _IntMap.empty (node.AsObject ())
        }
    static member empty
        with get() = Test.Name.Space._IntMap.Proto.Value.Empty

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module HelloRequest =

    [<System.Runtime.CompilerServices.IsByRefLike>]
    type Builder =
        struct
            val mutable Name: string // (1)
        end
        with
        member x.Put ((tag, reader): int * Reader) =
            match tag with
            | 1 -> x.Name <- ValueCodec.String.ReadValue reader
            | _ -> reader.SkipLastField()
        member x.Build : Test.Name.Space.HelloRequest = {
            Name = x.Name |> orEmptyString
            }

type private _HelloRequest = HelloRequest
[<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.MessageConverter>)>]
[<FsGrpc.Protobuf.Message>]
[<StructuralEquality;StructuralComparison>]
type HelloRequest = {
    // Field Declarations
    [<System.Text.Json.Serialization.JsonPropertyName("name")>] Name: string // (1)
    }
    with
    static member Proto : Lazy<ProtoDef<HelloRequest>> =
        lazy
        // Field Definitions
        let Name = FieldCodec.Primitive ValueCodec.String (1, "name")
        // Proto Definition Implementation
        { // ProtoDef<HelloRequest>
            Name = "HelloRequest"
            Empty = {
                Name = Name.GetDefault()
                }
            Size = fun (m: HelloRequest) ->
                0
                + Name.CalcFieldSize m.Name
            Encode = fun (w: Google.Protobuf.CodedOutputStream) (m: HelloRequest) ->
                Name.WriteField w m.Name
            Decode = fun (r: Google.Protobuf.CodedInputStream) ->
                let mutable builder = new Test.Name.Space.HelloRequest.Builder()
                let mutable tag = 0
                while read r &tag do
                    builder.Put (tag, r)
                builder.Build
            EncodeJson = fun (o: JsonOptions) ->
                let writeName = Name.WriteJsonField o
                let encode (w: System.Text.Json.Utf8JsonWriter) (m: HelloRequest) =
                    writeName w m.Name
                encode
            DecodeJson = fun (node: System.Text.Json.Nodes.JsonNode) ->
                let update value (kvPair: System.Collections.Generic.KeyValuePair<string,System.Text.Json.Nodes.JsonNode>) : HelloRequest =
                    match kvPair.Key with
                    | "name" -> { value with Name = Name.ReadJsonField kvPair.Value }
                    | _ -> value
                Seq.fold update _HelloRequest.empty (node.AsObject ())
        }
    static member empty
        with get() = Test.Name.Space._HelloRequest.Proto.Value.Empty

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module HelloReply =

    [<System.Runtime.CompilerServices.IsByRefLike>]
    type Builder =
        struct
            val mutable Message: string // (1)
        end
        with
        member x.Put ((tag, reader): int * Reader) =
            match tag with
            | 1 -> x.Message <- ValueCodec.String.ReadValue reader
            | _ -> reader.SkipLastField()
        member x.Build : Test.Name.Space.HelloReply = {
            Message = x.Message |> orEmptyString
            }

type private _HelloReply = HelloReply
[<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.MessageConverter>)>]
[<FsGrpc.Protobuf.Message>]
[<StructuralEquality;StructuralComparison>]
type HelloReply = {
    // Field Declarations
    [<System.Text.Json.Serialization.JsonPropertyName("message")>] Message: string // (1)
    }
    with
    static member Proto : Lazy<ProtoDef<HelloReply>> =
        lazy
        // Field Definitions
        let Message = FieldCodec.Primitive ValueCodec.String (1, "message")
        // Proto Definition Implementation
        { // ProtoDef<HelloReply>
            Name = "HelloReply"
            Empty = {
                Message = Message.GetDefault()
                }
            Size = fun (m: HelloReply) ->
                0
                + Message.CalcFieldSize m.Message
            Encode = fun (w: Google.Protobuf.CodedOutputStream) (m: HelloReply) ->
                Message.WriteField w m.Message
            Decode = fun (r: Google.Protobuf.CodedInputStream) ->
                let mutable builder = new Test.Name.Space.HelloReply.Builder()
                let mutable tag = 0
                while read r &tag do
                    builder.Put (tag, r)
                builder.Build
            EncodeJson = fun (o: JsonOptions) ->
                let writeMessage = Message.WriteJsonField o
                let encode (w: System.Text.Json.Utf8JsonWriter) (m: HelloReply) =
                    writeMessage w m.Message
                encode
            DecodeJson = fun (node: System.Text.Json.Nodes.JsonNode) ->
                let update value (kvPair: System.Collections.Generic.KeyValuePair<string,System.Text.Json.Nodes.JsonNode>) : HelloReply =
                    match kvPair.Key with
                    | "message" -> { value with Message = Message.ReadJsonField kvPair.Value }
                    | _ -> value
                Seq.fold update _HelloReply.empty (node.AsObject ())
        }
    static member empty
        with get() = Test.Name.Space._HelloReply.Proto.Value.Empty

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module EmptyMessage =

    [<System.Runtime.CompilerServices.IsByRefLike>]
    type Builder =
        struct
        end
        with
        member x.Put ((tag, reader): int * Reader) =
            match tag with
            | _ -> reader.SkipLastField()
        member x.Build = EmptyMessage.empty

[<StructuralEquality;StructuralComparison>]
type EmptyMessage = | Unused
    with
    static member empty = Unused 
    static member Proto : Lazy<ProtoDef<EmptyMessage>> =
        lazy
        // Proto Definition Implementation
        { // ProtoDef<EmptyMessage>
            Name = "EmptyMessage"
            Empty = EmptyMessage.empty
            Size = fun (m: EmptyMessage) ->
                0
            Encode = fun (w: Google.Protobuf.CodedOutputStream) (m: EmptyMessage) ->
                ()
            Decode = fun (r: Google.Protobuf.CodedInputStream) ->
                let mutable tag = 0
                while read r &tag do
                    r.SkipLastField()
                EmptyMessage.empty
            EncodeJson = fun _ _ _ -> ()
            DecodeJson = fun _ -> EmptyMessage.empty
        }

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module OneofWithNoParamsWrapper =

    [<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.OneofConverter<EmptyCase>>)>]
    [<CompilationRepresentation(CompilationRepresentationFlags.UseNullAsTrueValue)>]
    [<StructuralEquality;StructuralComparison>]
    [<RequireQualifiedAccess>]
    type EmptyCase =
    | None
    | [<System.Text.Json.Serialization.JsonPropertyName("first")>] First of Test.Name.Space.EmptyMessage
    | [<System.Text.Json.Serialization.JsonPropertyName("second")>] Second of Test.Name.Space.EmptyMessage
    with
        static member OneofCodec : Lazy<OneofCodec<EmptyCase>> = 
            lazy
            let First = FieldCodec.OneofCase "Empty" ValueCodec.Message<Test.Name.Space.EmptyMessage> (1, "first")
            let Second = FieldCodec.OneofCase "Empty" ValueCodec.Message<Test.Name.Space.EmptyMessage> (2, "second")
            let Empty = FieldCodec.Oneof "Empty" (FSharp.Collections.Map [
                ("first", fun node -> EmptyCase.First (First.ReadJsonField node))
                ("second", fun node -> EmptyCase.Second (Second.ReadJsonField node))
                ])
            Empty

    [<System.Runtime.CompilerServices.IsByRefLike>]
    type Builder =
        struct
            val mutable Empty: OptionBuilder<Test.Name.Space.OneofWithNoParamsWrapper.EmptyCase>
        end
        with
        member x.Put ((tag, reader): int * Reader) =
            match tag with
            | 1 -> x.Empty.Set (EmptyCase.First (ValueCodec.Message<Test.Name.Space.EmptyMessage>.ReadValue reader))
            | 2 -> x.Empty.Set (EmptyCase.Second (ValueCodec.Message<Test.Name.Space.EmptyMessage>.ReadValue reader))
            | _ -> reader.SkipLastField()
        member x.Build : Test.Name.Space.OneofWithNoParamsWrapper = {
            Empty = x.Empty.Build |> (Option.defaultValue EmptyCase.None)
            }

type private _OneofWithNoParamsWrapper = OneofWithNoParamsWrapper
[<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.MessageConverter>)>]
[<FsGrpc.Protobuf.Message>]
[<StructuralEquality;StructuralComparison>]
type OneofWithNoParamsWrapper = {
    // Field Declarations
    Empty: Test.Name.Space.OneofWithNoParamsWrapper.EmptyCase
    }
    with
    static member Proto : Lazy<ProtoDef<OneofWithNoParamsWrapper>> =
        lazy
        // Field Definitions
        let First = FieldCodec.OneofCase "Empty" ValueCodec.Message<Test.Name.Space.EmptyMessage> (1, "first")
        let Second = FieldCodec.OneofCase "Empty" ValueCodec.Message<Test.Name.Space.EmptyMessage> (2, "second")
        let Empty = FieldCodec.Oneof "Empty" (FSharp.Collections.Map [
            ("first", fun node -> Test.Name.Space.OneofWithNoParamsWrapper.EmptyCase.First (First.ReadJsonField node))
            ("second", fun node -> Test.Name.Space.OneofWithNoParamsWrapper.EmptyCase.Second (Second.ReadJsonField node))
            ])
        // Proto Definition Implementation
        { // ProtoDef<OneofWithNoParamsWrapper>
            Name = "OneofWithNoParamsWrapper"
            Empty = {
                Empty = Test.Name.Space.OneofWithNoParamsWrapper.EmptyCase.None
                }
            Size = fun (m: OneofWithNoParamsWrapper) ->
                0
                + match m.Empty with
                    | Test.Name.Space.OneofWithNoParamsWrapper.EmptyCase.None -> 0
                    | Test.Name.Space.OneofWithNoParamsWrapper.EmptyCase.First v -> First.CalcFieldSize v
                    | Test.Name.Space.OneofWithNoParamsWrapper.EmptyCase.Second v -> Second.CalcFieldSize v
            Encode = fun (w: Google.Protobuf.CodedOutputStream) (m: OneofWithNoParamsWrapper) ->
                (match m.Empty with
                | Test.Name.Space.OneofWithNoParamsWrapper.EmptyCase.None -> ()
                | Test.Name.Space.OneofWithNoParamsWrapper.EmptyCase.First v -> First.WriteField w v
                | Test.Name.Space.OneofWithNoParamsWrapper.EmptyCase.Second v -> Second.WriteField w v
                )
            Decode = fun (r: Google.Protobuf.CodedInputStream) ->
                let mutable builder = new Test.Name.Space.OneofWithNoParamsWrapper.Builder()
                let mutable tag = 0
                while read r &tag do
                    builder.Put (tag, r)
                builder.Build
            EncodeJson = fun (o: JsonOptions) ->
                let writeEmptyNone = Empty.WriteJsonNoneCase o
                let writeFirst = First.WriteJsonField o
                let writeSecond = Second.WriteJsonField o
                let encode (w: System.Text.Json.Utf8JsonWriter) (m: OneofWithNoParamsWrapper) =
                    (match m.Empty with
                    | Test.Name.Space.OneofWithNoParamsWrapper.EmptyCase.None -> writeEmptyNone w
                    | Test.Name.Space.OneofWithNoParamsWrapper.EmptyCase.First v -> writeFirst w v
                    | Test.Name.Space.OneofWithNoParamsWrapper.EmptyCase.Second v -> writeSecond w v
                    )
                encode
            DecodeJson = fun (node: System.Text.Json.Nodes.JsonNode) ->
                let update value (kvPair: System.Collections.Generic.KeyValuePair<string,System.Text.Json.Nodes.JsonNode>) : OneofWithNoParamsWrapper =
                    match kvPair.Key with
                    | "first" -> { value with Empty = Test.Name.Space.OneofWithNoParamsWrapper.EmptyCase.First (First.ReadJsonField kvPair.Value) }
                    | "second" -> { value with Empty = Test.Name.Space.OneofWithNoParamsWrapper.EmptyCase.Second (Second.ReadJsonField kvPair.Value) }
                    | "empty" -> { value with Empty = Empty.ReadJsonField kvPair.Value }
                    | _ -> value
                Seq.fold update _OneofWithNoParamsWrapper.empty (node.AsObject ())
        }
    static member empty
        with get() = Test.Name.Space._OneofWithNoParamsWrapper.Proto.Value.Empty

namespace Test.Name.Space.Optics
open Focal.Core
module TestMessage =
    let ``testInt`` : ILens'<Test.Name.Space.TestMessage,int> =
        {
            _getter = { _get = fun (s: Test.Name.Space.TestMessage) -> s.TestInt }
            _setter = { _over = fun a2b s -> { s with TestInt = a2b s.TestInt } }
        }
    let ``testDouble`` : ILens'<Test.Name.Space.TestMessage,double> =
        {
            _getter = { _get = fun (s: Test.Name.Space.TestMessage) -> s.TestDouble }
            _setter = { _over = fun a2b s -> { s with TestDouble = a2b s.TestDouble } }
        }
    let ``testFixed32`` : ILens'<Test.Name.Space.TestMessage,uint> =
        {
            _getter = { _get = fun (s: Test.Name.Space.TestMessage) -> s.TestFixed32 }
            _setter = { _over = fun a2b s -> { s with TestFixed32 = a2b s.TestFixed32 } }
        }
    let ``testString`` : ILens'<Test.Name.Space.TestMessage,string> =
        {
            _getter = { _get = fun (s: Test.Name.Space.TestMessage) -> s.TestString }
            _setter = { _over = fun a2b s -> { s with TestString = a2b s.TestString } }
        }
    let ``testBytes`` : ILens'<Test.Name.Space.TestMessage,FsGrpc.Bytes> =
        {
            _getter = { _get = fun (s: Test.Name.Space.TestMessage) -> s.TestBytes }
            _setter = { _over = fun a2b s -> { s with TestBytes = a2b s.TestBytes } }
        }
    let ``testFloat`` : ILens'<Test.Name.Space.TestMessage,float32> =
        {
            _getter = { _get = fun (s: Test.Name.Space.TestMessage) -> s.TestFloat }
            _setter = { _over = fun a2b s -> { s with TestFloat = a2b s.TestFloat } }
        }
    let ``testInt64`` : ILens'<Test.Name.Space.TestMessage,int64> =
        {
            _getter = { _get = fun (s: Test.Name.Space.TestMessage) -> s.TestInt64 }
            _setter = { _over = fun a2b s -> { s with TestInt64 = a2b s.TestInt64 } }
        }
    let ``testUint64`` : ILens'<Test.Name.Space.TestMessage,uint64> =
        {
            _getter = { _get = fun (s: Test.Name.Space.TestMessage) -> s.TestUint64 }
            _setter = { _over = fun a2b s -> { s with TestUint64 = a2b s.TestUint64 } }
        }
    let ``testFixed64`` : ILens'<Test.Name.Space.TestMessage,uint64> =
        {
            _getter = { _get = fun (s: Test.Name.Space.TestMessage) -> s.TestFixed64 }
            _setter = { _over = fun a2b s -> { s with TestFixed64 = a2b s.TestFixed64 } }
        }
    let ``testBool`` : ILens'<Test.Name.Space.TestMessage,bool> =
        {
            _getter = { _get = fun (s: Test.Name.Space.TestMessage) -> s.TestBool }
            _setter = { _over = fun a2b s -> { s with TestBool = a2b s.TestBool } }
        }
    let ``testUint32`` : ILens'<Test.Name.Space.TestMessage,uint32> =
        {
            _getter = { _get = fun (s: Test.Name.Space.TestMessage) -> s.TestUint32 }
            _setter = { _over = fun a2b s -> { s with TestUint32 = a2b s.TestUint32 } }
        }
    let ``testSfixed32`` : ILens'<Test.Name.Space.TestMessage,int> =
        {
            _getter = { _get = fun (s: Test.Name.Space.TestMessage) -> s.TestSfixed32 }
            _setter = { _over = fun a2b s -> { s with TestSfixed32 = a2b s.TestSfixed32 } }
        }
    let ``testSfixed64`` : ILens'<Test.Name.Space.TestMessage,int64> =
        {
            _getter = { _get = fun (s: Test.Name.Space.TestMessage) -> s.TestSfixed64 }
            _setter = { _over = fun a2b s -> { s with TestSfixed64 = a2b s.TestSfixed64 } }
        }
    let ``testSint32`` : ILens'<Test.Name.Space.TestMessage,int> =
        {
            _getter = { _get = fun (s: Test.Name.Space.TestMessage) -> s.TestSint32 }
            _setter = { _over = fun a2b s -> { s with TestSint32 = a2b s.TestSint32 } }
        }
    let ``testSint64`` : ILens'<Test.Name.Space.TestMessage,int64> =
        {
            _getter = { _get = fun (s: Test.Name.Space.TestMessage) -> s.TestSint64 }
            _setter = { _over = fun a2b s -> { s with TestSint64 = a2b s.TestSint64 } }
        }
module Nest =
    let ``name`` : ILens'<Test.Name.Space.Nest,string> =
        {
            _getter = { _get = fun (s: Test.Name.Space.Nest) -> s.Name }
            _setter = { _over = fun a2b s -> { s with Name = a2b s.Name } }
        }
    let ``children`` : ILens'<Test.Name.Space.Nest,Test.Name.Space.Nest list> =
        {
            _getter = { _get = fun (s: Test.Name.Space.Nest) -> s.Children }
            _setter = { _over = fun a2b s -> { s with Children = a2b s.Children } }
        }
    let ``inner`` : ILens'<Test.Name.Space.Nest,Test.Name.Space.Nest.Inner option> =
        {
            _getter = { _get = fun (s: Test.Name.Space.Nest) -> s.Inner }
            _setter = { _over = fun a2b s -> { s with Inner = a2b s.Inner } }
        }
    let ``special`` : ILens'<Test.Name.Space.Nest,Test.Name.Space.Special option> =
        {
            _getter = { _get = fun (s: Test.Name.Space.Nest) -> s.Special }
            _setter = { _over = fun a2b s -> { s with Special = a2b s.Special } }
        }
    module Inner =
        let ``innerName`` : ILens'<Test.Name.Space.Nest.Inner,string> =
            {
                _getter = { _get = fun (s: Test.Name.Space.Nest.Inner) -> s.InnerName }
                _setter = { _over = fun a2b s -> { s with InnerName = a2b s.InnerName } }
            }
module Special =
    let ``intList`` : ILens'<Test.Name.Space.Special,int list> =
        {
            _getter = { _get = fun (s: Test.Name.Space.Special) -> s.IntList }
            _setter = { _over = fun a2b s -> { s with IntList = a2b s.IntList } }
        }
    let ``doubleList`` : ILens'<Test.Name.Space.Special,double list> =
        {
            _getter = { _get = fun (s: Test.Name.Space.Special) -> s.DoubleList }
            _setter = { _over = fun a2b s -> { s with DoubleList = a2b s.DoubleList } }
        }
    let ``fixed32List`` : ILens'<Test.Name.Space.Special,uint list> =
        {
            _getter = { _get = fun (s: Test.Name.Space.Special) -> s.Fixed32List }
            _setter = { _over = fun a2b s -> { s with Fixed32List = a2b s.Fixed32List } }
        }
    let ``stringList`` : ILens'<Test.Name.Space.Special,string list> =
        {
            _getter = { _get = fun (s: Test.Name.Space.Special) -> s.StringList }
            _setter = { _over = fun a2b s -> { s with StringList = a2b s.StringList } }
        }
    let ``dictionary`` : ILens'<Test.Name.Space.Special,Map<string, string>> =
        {
            _getter = { _get = fun (s: Test.Name.Space.Special) -> s.Dictionary }
            _setter = { _over = fun a2b s -> { s with Dictionary = a2b s.Dictionary } }
        }
module Enums =
    module UnionPrisms =
        let ifColor : IPrism'<Test.Name.Space.Enums.UnionCase,Test.Name.Space.Enums.Color> =
            {
                _unto = fun a -> Test.Name.Space.Enums.UnionCase.Color a
                _which = fun s ->
                    match s with
                    | Test.Name.Space.Enums.UnionCase.Color a -> Ok a
                    | _ -> Error s
            }
        let ifName : IPrism'<Test.Name.Space.Enums.UnionCase,string> =
            {
                _unto = fun a -> Test.Name.Space.Enums.UnionCase.Name a
                _which = fun s ->
                    match s with
                    | Test.Name.Space.Enums.UnionCase.Name a -> Ok a
                    | _ -> Error s
            }
    let ``mainColor`` : ILens'<Test.Name.Space.Enums,Test.Name.Space.Enums.Color> =
        {
            _getter = { _get = fun (s: Test.Name.Space.Enums) -> s.MainColor }
            _setter = { _over = fun a2b s -> { s with MainColor = a2b s.MainColor } }
        }
    let ``otherColors`` : ILens'<Test.Name.Space.Enums,Test.Name.Space.Enums.Color list> =
        {
            _getter = { _get = fun (s: Test.Name.Space.Enums) -> s.OtherColors }
            _setter = { _over = fun a2b s -> { s with OtherColors = a2b s.OtherColors } }
        }
    let ``byName`` : ILens'<Test.Name.Space.Enums,Map<string, Test.Name.Space.Enums.Color>> =
        {
            _getter = { _get = fun (s: Test.Name.Space.Enums) -> s.ByName }
            _setter = { _over = fun a2b s -> { s with ByName = a2b s.ByName } }
        }
    let ``union`` : ILens'<Test.Name.Space.Enums,Test.Name.Space.Enums.UnionCase> =
        {
            _getter = { _get = fun (s: Test.Name.Space.Enums) -> s.Union }
            _setter = { _over = fun a2b s -> { s with Union = a2b s.Union } }
        }
    let ``maybeColor`` : ILens'<Test.Name.Space.Enums,Test.Name.Space.Enums.Color option> =
        {
            _getter = { _get = fun (s: Test.Name.Space.Enums) -> s.MaybeColor }
            _setter = { _over = fun a2b s -> { s with MaybeColor = a2b s.MaybeColor } }
        }
module Google =
    let ``int32Val`` : ILens'<Test.Name.Space.Google,int option> =
        {
            _getter = { _get = fun (s: Test.Name.Space.Google) -> s.Int32Val }
            _setter = { _over = fun a2b s -> { s with Int32Val = a2b s.Int32Val } }
        }
    let ``stringVal`` : ILens'<Test.Name.Space.Google,string option> =
        {
            _getter = { _get = fun (s: Test.Name.Space.Google) -> s.StringVal }
            _setter = { _over = fun a2b s -> { s with StringVal = a2b s.StringVal } }
        }
    let ``timestamp`` : ILens'<Test.Name.Space.Google,NodaTime.Instant option> =
        {
            _getter = { _get = fun (s: Test.Name.Space.Google) -> s.Timestamp }
            _setter = { _over = fun a2b s -> { s with Timestamp = a2b s.Timestamp } }
        }
    let ``duration`` : ILens'<Test.Name.Space.Google,NodaTime.Duration option> =
        {
            _getter = { _get = fun (s: Test.Name.Space.Google) -> s.Duration }
            _setter = { _over = fun a2b s -> { s with Duration = a2b s.Duration } }
        }
module IntMap =
    let ``intMap`` : ILens'<Test.Name.Space.IntMap,Map<int, string>> =
        {
            _getter = { _get = fun (s: Test.Name.Space.IntMap) -> s.IntMap }
            _setter = { _over = fun a2b s -> { s with IntMap = a2b s.IntMap } }
        }
module HelloRequest =
    let ``name`` : ILens'<Test.Name.Space.HelloRequest,string> =
        {
            _getter = { _get = fun (s: Test.Name.Space.HelloRequest) -> s.Name }
            _setter = { _over = fun a2b s -> { s with Name = a2b s.Name } }
        }
module HelloReply =
    let ``message`` : ILens'<Test.Name.Space.HelloReply,string> =
        {
            _getter = { _get = fun (s: Test.Name.Space.HelloReply) -> s.Message }
            _setter = { _over = fun a2b s -> { s with Message = a2b s.Message } }
        }
module OneofWithNoParamsWrapper =
    module EmptyPrisms =
        let ifFirst : IPrism'<Test.Name.Space.OneofWithNoParamsWrapper.EmptyCase,Test.Name.Space.EmptyMessage> =
            {
                _unto = fun a -> Test.Name.Space.OneofWithNoParamsWrapper.EmptyCase.First a
                _which = fun s ->
                    match s with
                    | Test.Name.Space.OneofWithNoParamsWrapper.EmptyCase.First a -> Ok a
                    | _ -> Error s
            }
        let ifSecond : IPrism'<Test.Name.Space.OneofWithNoParamsWrapper.EmptyCase,Test.Name.Space.EmptyMessage> =
            {
                _unto = fun a -> Test.Name.Space.OneofWithNoParamsWrapper.EmptyCase.Second a
                _which = fun s ->
                    match s with
                    | Test.Name.Space.OneofWithNoParamsWrapper.EmptyCase.Second a -> Ok a
                    | _ -> Error s
            }
    let ``empty`` : ILens'<Test.Name.Space.OneofWithNoParamsWrapper,Test.Name.Space.OneofWithNoParamsWrapper.EmptyCase> =
        {
            _getter = { _get = fun (s: Test.Name.Space.OneofWithNoParamsWrapper) -> s.Empty }
            _setter = { _over = fun a2b s -> { s with Empty = a2b s.Empty } }
        }

namespace Test.Name.Space
open Focal.Core
open System.Runtime.CompilerServices
[<Extension>]
type OpticsExtensionMethods_testproto_proto =
    [<Extension>]
    static member inline TestInt(lens : ILens<'a,'b,Test.Name.Space.TestMessage,Test.Name.Space.TestMessage>) : ILens<'a,'b,int,int> =
        lens.ComposeWith(Test.Name.Space.Optics.TestMessage.``testInt``)
    [<Extension>]
    static member inline TestInt(traversal : ITraversal<'a,'b,Test.Name.Space.TestMessage,Test.Name.Space.TestMessage>) : ITraversal<'a,'b,int,int> =
        traversal.ComposeWith(Test.Name.Space.Optics.TestMessage.``testInt``)
    [<Extension>]
    static member inline TestDouble(lens : ILens<'a,'b,Test.Name.Space.TestMessage,Test.Name.Space.TestMessage>) : ILens<'a,'b,double,double> =
        lens.ComposeWith(Test.Name.Space.Optics.TestMessage.``testDouble``)
    [<Extension>]
    static member inline TestDouble(traversal : ITraversal<'a,'b,Test.Name.Space.TestMessage,Test.Name.Space.TestMessage>) : ITraversal<'a,'b,double,double> =
        traversal.ComposeWith(Test.Name.Space.Optics.TestMessage.``testDouble``)
    [<Extension>]
    static member inline TestFixed32(lens : ILens<'a,'b,Test.Name.Space.TestMessage,Test.Name.Space.TestMessage>) : ILens<'a,'b,uint,uint> =
        lens.ComposeWith(Test.Name.Space.Optics.TestMessage.``testFixed32``)
    [<Extension>]
    static member inline TestFixed32(traversal : ITraversal<'a,'b,Test.Name.Space.TestMessage,Test.Name.Space.TestMessage>) : ITraversal<'a,'b,uint,uint> =
        traversal.ComposeWith(Test.Name.Space.Optics.TestMessage.``testFixed32``)
    [<Extension>]
    static member inline TestString(lens : ILens<'a,'b,Test.Name.Space.TestMessage,Test.Name.Space.TestMessage>) : ILens<'a,'b,string,string> =
        lens.ComposeWith(Test.Name.Space.Optics.TestMessage.``testString``)
    [<Extension>]
    static member inline TestString(traversal : ITraversal<'a,'b,Test.Name.Space.TestMessage,Test.Name.Space.TestMessage>) : ITraversal<'a,'b,string,string> =
        traversal.ComposeWith(Test.Name.Space.Optics.TestMessage.``testString``)
    [<Extension>]
    static member inline TestBytes(lens : ILens<'a,'b,Test.Name.Space.TestMessage,Test.Name.Space.TestMessage>) : ILens<'a,'b,FsGrpc.Bytes,FsGrpc.Bytes> =
        lens.ComposeWith(Test.Name.Space.Optics.TestMessage.``testBytes``)
    [<Extension>]
    static member inline TestBytes(traversal : ITraversal<'a,'b,Test.Name.Space.TestMessage,Test.Name.Space.TestMessage>) : ITraversal<'a,'b,FsGrpc.Bytes,FsGrpc.Bytes> =
        traversal.ComposeWith(Test.Name.Space.Optics.TestMessage.``testBytes``)
    [<Extension>]
    static member inline TestFloat(lens : ILens<'a,'b,Test.Name.Space.TestMessage,Test.Name.Space.TestMessage>) : ILens<'a,'b,float32,float32> =
        lens.ComposeWith(Test.Name.Space.Optics.TestMessage.``testFloat``)
    [<Extension>]
    static member inline TestFloat(traversal : ITraversal<'a,'b,Test.Name.Space.TestMessage,Test.Name.Space.TestMessage>) : ITraversal<'a,'b,float32,float32> =
        traversal.ComposeWith(Test.Name.Space.Optics.TestMessage.``testFloat``)
    [<Extension>]
    static member inline TestInt64(lens : ILens<'a,'b,Test.Name.Space.TestMessage,Test.Name.Space.TestMessage>) : ILens<'a,'b,int64,int64> =
        lens.ComposeWith(Test.Name.Space.Optics.TestMessage.``testInt64``)
    [<Extension>]
    static member inline TestInt64(traversal : ITraversal<'a,'b,Test.Name.Space.TestMessage,Test.Name.Space.TestMessage>) : ITraversal<'a,'b,int64,int64> =
        traversal.ComposeWith(Test.Name.Space.Optics.TestMessage.``testInt64``)
    [<Extension>]
    static member inline TestUint64(lens : ILens<'a,'b,Test.Name.Space.TestMessage,Test.Name.Space.TestMessage>) : ILens<'a,'b,uint64,uint64> =
        lens.ComposeWith(Test.Name.Space.Optics.TestMessage.``testUint64``)
    [<Extension>]
    static member inline TestUint64(traversal : ITraversal<'a,'b,Test.Name.Space.TestMessage,Test.Name.Space.TestMessage>) : ITraversal<'a,'b,uint64,uint64> =
        traversal.ComposeWith(Test.Name.Space.Optics.TestMessage.``testUint64``)
    [<Extension>]
    static member inline TestFixed64(lens : ILens<'a,'b,Test.Name.Space.TestMessage,Test.Name.Space.TestMessage>) : ILens<'a,'b,uint64,uint64> =
        lens.ComposeWith(Test.Name.Space.Optics.TestMessage.``testFixed64``)
    [<Extension>]
    static member inline TestFixed64(traversal : ITraversal<'a,'b,Test.Name.Space.TestMessage,Test.Name.Space.TestMessage>) : ITraversal<'a,'b,uint64,uint64> =
        traversal.ComposeWith(Test.Name.Space.Optics.TestMessage.``testFixed64``)
    [<Extension>]
    static member inline TestBool(lens : ILens<'a,'b,Test.Name.Space.TestMessage,Test.Name.Space.TestMessage>) : ILens<'a,'b,bool,bool> =
        lens.ComposeWith(Test.Name.Space.Optics.TestMessage.``testBool``)
    [<Extension>]
    static member inline TestBool(traversal : ITraversal<'a,'b,Test.Name.Space.TestMessage,Test.Name.Space.TestMessage>) : ITraversal<'a,'b,bool,bool> =
        traversal.ComposeWith(Test.Name.Space.Optics.TestMessage.``testBool``)
    [<Extension>]
    static member inline TestUint32(lens : ILens<'a,'b,Test.Name.Space.TestMessage,Test.Name.Space.TestMessage>) : ILens<'a,'b,uint32,uint32> =
        lens.ComposeWith(Test.Name.Space.Optics.TestMessage.``testUint32``)
    [<Extension>]
    static member inline TestUint32(traversal : ITraversal<'a,'b,Test.Name.Space.TestMessage,Test.Name.Space.TestMessage>) : ITraversal<'a,'b,uint32,uint32> =
        traversal.ComposeWith(Test.Name.Space.Optics.TestMessage.``testUint32``)
    [<Extension>]
    static member inline TestSfixed32(lens : ILens<'a,'b,Test.Name.Space.TestMessage,Test.Name.Space.TestMessage>) : ILens<'a,'b,int,int> =
        lens.ComposeWith(Test.Name.Space.Optics.TestMessage.``testSfixed32``)
    [<Extension>]
    static member inline TestSfixed32(traversal : ITraversal<'a,'b,Test.Name.Space.TestMessage,Test.Name.Space.TestMessage>) : ITraversal<'a,'b,int,int> =
        traversal.ComposeWith(Test.Name.Space.Optics.TestMessage.``testSfixed32``)
    [<Extension>]
    static member inline TestSfixed64(lens : ILens<'a,'b,Test.Name.Space.TestMessage,Test.Name.Space.TestMessage>) : ILens<'a,'b,int64,int64> =
        lens.ComposeWith(Test.Name.Space.Optics.TestMessage.``testSfixed64``)
    [<Extension>]
    static member inline TestSfixed64(traversal : ITraversal<'a,'b,Test.Name.Space.TestMessage,Test.Name.Space.TestMessage>) : ITraversal<'a,'b,int64,int64> =
        traversal.ComposeWith(Test.Name.Space.Optics.TestMessage.``testSfixed64``)
    [<Extension>]
    static member inline TestSint32(lens : ILens<'a,'b,Test.Name.Space.TestMessage,Test.Name.Space.TestMessage>) : ILens<'a,'b,int,int> =
        lens.ComposeWith(Test.Name.Space.Optics.TestMessage.``testSint32``)
    [<Extension>]
    static member inline TestSint32(traversal : ITraversal<'a,'b,Test.Name.Space.TestMessage,Test.Name.Space.TestMessage>) : ITraversal<'a,'b,int,int> =
        traversal.ComposeWith(Test.Name.Space.Optics.TestMessage.``testSint32``)
    [<Extension>]
    static member inline TestSint64(lens : ILens<'a,'b,Test.Name.Space.TestMessage,Test.Name.Space.TestMessage>) : ILens<'a,'b,int64,int64> =
        lens.ComposeWith(Test.Name.Space.Optics.TestMessage.``testSint64``)
    [<Extension>]
    static member inline TestSint64(traversal : ITraversal<'a,'b,Test.Name.Space.TestMessage,Test.Name.Space.TestMessage>) : ITraversal<'a,'b,int64,int64> =
        traversal.ComposeWith(Test.Name.Space.Optics.TestMessage.``testSint64``)
    [<Extension>]
    static member inline Name(lens : ILens<'a,'b,Test.Name.Space.Nest,Test.Name.Space.Nest>) : ILens<'a,'b,string,string> =
        lens.ComposeWith(Test.Name.Space.Optics.Nest.``name``)
    [<Extension>]
    static member inline Name(traversal : ITraversal<'a,'b,Test.Name.Space.Nest,Test.Name.Space.Nest>) : ITraversal<'a,'b,string,string> =
        traversal.ComposeWith(Test.Name.Space.Optics.Nest.``name``)
    [<Extension>]
    static member inline Children(lens : ILens<'a,'b,Test.Name.Space.Nest,Test.Name.Space.Nest>) : ILens<'a,'b,Test.Name.Space.Nest list,Test.Name.Space.Nest list> =
        lens.ComposeWith(Test.Name.Space.Optics.Nest.``children``)
    [<Extension>]
    static member inline Children(traversal : ITraversal<'a,'b,Test.Name.Space.Nest,Test.Name.Space.Nest>) : ITraversal<'a,'b,Test.Name.Space.Nest list,Test.Name.Space.Nest list> =
        traversal.ComposeWith(Test.Name.Space.Optics.Nest.``children``)
    [<Extension>]
    static member inline Inner(lens : ILens<'a,'b,Test.Name.Space.Nest,Test.Name.Space.Nest>) : ILens<'a,'b,Test.Name.Space.Nest.Inner option,Test.Name.Space.Nest.Inner option> =
        lens.ComposeWith(Test.Name.Space.Optics.Nest.``inner``)
    [<Extension>]
    static member inline Inner(traversal : ITraversal<'a,'b,Test.Name.Space.Nest,Test.Name.Space.Nest>) : ITraversal<'a,'b,Test.Name.Space.Nest.Inner option,Test.Name.Space.Nest.Inner option> =
        traversal.ComposeWith(Test.Name.Space.Optics.Nest.``inner``)
    [<Extension>]
    static member inline Special(lens : ILens<'a,'b,Test.Name.Space.Nest,Test.Name.Space.Nest>) : ILens<'a,'b,Test.Name.Space.Special option,Test.Name.Space.Special option> =
        lens.ComposeWith(Test.Name.Space.Optics.Nest.``special``)
    [<Extension>]
    static member inline Special(traversal : ITraversal<'a,'b,Test.Name.Space.Nest,Test.Name.Space.Nest>) : ITraversal<'a,'b,Test.Name.Space.Special option,Test.Name.Space.Special option> =
        traversal.ComposeWith(Test.Name.Space.Optics.Nest.``special``)
    [<Extension>]
    static member inline InnerName(lens : ILens<'a,'b,Test.Name.Space.Nest.Inner,Test.Name.Space.Nest.Inner>) : ILens<'a,'b,string,string> =
        lens.ComposeWith(Test.Name.Space.Optics.Nest.Inner.``innerName``)
    [<Extension>]
    static member inline InnerName(traversal : ITraversal<'a,'b,Test.Name.Space.Nest.Inner,Test.Name.Space.Nest.Inner>) : ITraversal<'a,'b,string,string> =
        traversal.ComposeWith(Test.Name.Space.Optics.Nest.Inner.``innerName``)
    [<Extension>]
    static member inline IntList(lens : ILens<'a,'b,Test.Name.Space.Special,Test.Name.Space.Special>) : ILens<'a,'b,int list,int list> =
        lens.ComposeWith(Test.Name.Space.Optics.Special.``intList``)
    [<Extension>]
    static member inline IntList(traversal : ITraversal<'a,'b,Test.Name.Space.Special,Test.Name.Space.Special>) : ITraversal<'a,'b,int list,int list> =
        traversal.ComposeWith(Test.Name.Space.Optics.Special.``intList``)
    [<Extension>]
    static member inline DoubleList(lens : ILens<'a,'b,Test.Name.Space.Special,Test.Name.Space.Special>) : ILens<'a,'b,double list,double list> =
        lens.ComposeWith(Test.Name.Space.Optics.Special.``doubleList``)
    [<Extension>]
    static member inline DoubleList(traversal : ITraversal<'a,'b,Test.Name.Space.Special,Test.Name.Space.Special>) : ITraversal<'a,'b,double list,double list> =
        traversal.ComposeWith(Test.Name.Space.Optics.Special.``doubleList``)
    [<Extension>]
    static member inline Fixed32List(lens : ILens<'a,'b,Test.Name.Space.Special,Test.Name.Space.Special>) : ILens<'a,'b,uint list,uint list> =
        lens.ComposeWith(Test.Name.Space.Optics.Special.``fixed32List``)
    [<Extension>]
    static member inline Fixed32List(traversal : ITraversal<'a,'b,Test.Name.Space.Special,Test.Name.Space.Special>) : ITraversal<'a,'b,uint list,uint list> =
        traversal.ComposeWith(Test.Name.Space.Optics.Special.``fixed32List``)
    [<Extension>]
    static member inline StringList(lens : ILens<'a,'b,Test.Name.Space.Special,Test.Name.Space.Special>) : ILens<'a,'b,string list,string list> =
        lens.ComposeWith(Test.Name.Space.Optics.Special.``stringList``)
    [<Extension>]
    static member inline StringList(traversal : ITraversal<'a,'b,Test.Name.Space.Special,Test.Name.Space.Special>) : ITraversal<'a,'b,string list,string list> =
        traversal.ComposeWith(Test.Name.Space.Optics.Special.``stringList``)
    [<Extension>]
    static member inline Dictionary(lens : ILens<'a,'b,Test.Name.Space.Special,Test.Name.Space.Special>) : ILens<'a,'b,Map<string, string>,Map<string, string>> =
        lens.ComposeWith(Test.Name.Space.Optics.Special.``dictionary``)
    [<Extension>]
    static member inline Dictionary(traversal : ITraversal<'a,'b,Test.Name.Space.Special,Test.Name.Space.Special>) : ITraversal<'a,'b,Map<string, string>,Map<string, string>> =
        traversal.ComposeWith(Test.Name.Space.Optics.Special.``dictionary``)
    [<Extension>]
    static member inline MainColor(lens : ILens<'a,'b,Test.Name.Space.Enums,Test.Name.Space.Enums>) : ILens<'a,'b,Test.Name.Space.Enums.Color,Test.Name.Space.Enums.Color> =
        lens.ComposeWith(Test.Name.Space.Optics.Enums.``mainColor``)
    [<Extension>]
    static member inline MainColor(traversal : ITraversal<'a,'b,Test.Name.Space.Enums,Test.Name.Space.Enums>) : ITraversal<'a,'b,Test.Name.Space.Enums.Color,Test.Name.Space.Enums.Color> =
        traversal.ComposeWith(Test.Name.Space.Optics.Enums.``mainColor``)
    [<Extension>]
    static member inline OtherColors(lens : ILens<'a,'b,Test.Name.Space.Enums,Test.Name.Space.Enums>) : ILens<'a,'b,Test.Name.Space.Enums.Color list,Test.Name.Space.Enums.Color list> =
        lens.ComposeWith(Test.Name.Space.Optics.Enums.``otherColors``)
    [<Extension>]
    static member inline OtherColors(traversal : ITraversal<'a,'b,Test.Name.Space.Enums,Test.Name.Space.Enums>) : ITraversal<'a,'b,Test.Name.Space.Enums.Color list,Test.Name.Space.Enums.Color list> =
        traversal.ComposeWith(Test.Name.Space.Optics.Enums.``otherColors``)
    [<Extension>]
    static member inline ByName(lens : ILens<'a,'b,Test.Name.Space.Enums,Test.Name.Space.Enums>) : ILens<'a,'b,Map<string, Test.Name.Space.Enums.Color>,Map<string, Test.Name.Space.Enums.Color>> =
        lens.ComposeWith(Test.Name.Space.Optics.Enums.``byName``)
    [<Extension>]
    static member inline ByName(traversal : ITraversal<'a,'b,Test.Name.Space.Enums,Test.Name.Space.Enums>) : ITraversal<'a,'b,Map<string, Test.Name.Space.Enums.Color>,Map<string, Test.Name.Space.Enums.Color>> =
        traversal.ComposeWith(Test.Name.Space.Optics.Enums.``byName``)
    [<Extension>]
    static member inline Union(lens : ILens<'a,'b,Test.Name.Space.Enums,Test.Name.Space.Enums>) : ILens<'a,'b,Test.Name.Space.Enums.UnionCase,Test.Name.Space.Enums.UnionCase> =
        lens.ComposeWith(Test.Name.Space.Optics.Enums.``union``)
    [<Extension>]
    static member inline Union(traversal : ITraversal<'a,'b,Test.Name.Space.Enums,Test.Name.Space.Enums>) : ITraversal<'a,'b,Test.Name.Space.Enums.UnionCase,Test.Name.Space.Enums.UnionCase> =
        traversal.ComposeWith(Test.Name.Space.Optics.Enums.``union``)
    [<Extension>]
    static member inline MaybeColor(lens : ILens<'a,'b,Test.Name.Space.Enums,Test.Name.Space.Enums>) : ILens<'a,'b,Test.Name.Space.Enums.Color option,Test.Name.Space.Enums.Color option> =
        lens.ComposeWith(Test.Name.Space.Optics.Enums.``maybeColor``)
    [<Extension>]
    static member inline MaybeColor(traversal : ITraversal<'a,'b,Test.Name.Space.Enums,Test.Name.Space.Enums>) : ITraversal<'a,'b,Test.Name.Space.Enums.Color option,Test.Name.Space.Enums.Color option> =
        traversal.ComposeWith(Test.Name.Space.Optics.Enums.``maybeColor``)
    [<Extension>]
    static member inline IfColor(prism : IPrism<'s,'t,Test.Name.Space.Enums.UnionCase,Test.Name.Space.Enums.UnionCase>) : IPrism<'s,'t,Test.Name.Space.Enums.Color,Test.Name.Space.Enums.Color> = 
        prism.ComposeWith(Test.Name.Space.Optics.Enums.UnionPrisms.ifColor)
    [<Extension>]
    static member inline IfColor(traversal : ITraversal<'s,'t,Test.Name.Space.Enums.UnionCase,Test.Name.Space.Enums.UnionCase>) : ITraversal<'s,'t,Test.Name.Space.Enums.Color,Test.Name.Space.Enums.Color> = 
        traversal.ComposeWith(Test.Name.Space.Optics.Enums.UnionPrisms.ifColor)
    [<Extension>]
    static member inline IfName(prism : IPrism<'s,'t,Test.Name.Space.Enums.UnionCase,Test.Name.Space.Enums.UnionCase>) : IPrism<'s,'t,string,string> = 
        prism.ComposeWith(Test.Name.Space.Optics.Enums.UnionPrisms.ifName)
    [<Extension>]
    static member inline IfName(traversal : ITraversal<'s,'t,Test.Name.Space.Enums.UnionCase,Test.Name.Space.Enums.UnionCase>) : ITraversal<'s,'t,string,string> = 
        traversal.ComposeWith(Test.Name.Space.Optics.Enums.UnionPrisms.ifName)
    [<Extension>]
    static member inline Int32Val(lens : ILens<'a,'b,Test.Name.Space.Google,Test.Name.Space.Google>) : ILens<'a,'b,int option,int option> =
        lens.ComposeWith(Test.Name.Space.Optics.Google.``int32Val``)
    [<Extension>]
    static member inline Int32Val(traversal : ITraversal<'a,'b,Test.Name.Space.Google,Test.Name.Space.Google>) : ITraversal<'a,'b,int option,int option> =
        traversal.ComposeWith(Test.Name.Space.Optics.Google.``int32Val``)
    [<Extension>]
    static member inline StringVal(lens : ILens<'a,'b,Test.Name.Space.Google,Test.Name.Space.Google>) : ILens<'a,'b,string option,string option> =
        lens.ComposeWith(Test.Name.Space.Optics.Google.``stringVal``)
    [<Extension>]
    static member inline StringVal(traversal : ITraversal<'a,'b,Test.Name.Space.Google,Test.Name.Space.Google>) : ITraversal<'a,'b,string option,string option> =
        traversal.ComposeWith(Test.Name.Space.Optics.Google.``stringVal``)
    [<Extension>]
    static member inline Timestamp(lens : ILens<'a,'b,Test.Name.Space.Google,Test.Name.Space.Google>) : ILens<'a,'b,NodaTime.Instant option,NodaTime.Instant option> =
        lens.ComposeWith(Test.Name.Space.Optics.Google.``timestamp``)
    [<Extension>]
    static member inline Timestamp(traversal : ITraversal<'a,'b,Test.Name.Space.Google,Test.Name.Space.Google>) : ITraversal<'a,'b,NodaTime.Instant option,NodaTime.Instant option> =
        traversal.ComposeWith(Test.Name.Space.Optics.Google.``timestamp``)
    [<Extension>]
    static member inline Duration(lens : ILens<'a,'b,Test.Name.Space.Google,Test.Name.Space.Google>) : ILens<'a,'b,NodaTime.Duration option,NodaTime.Duration option> =
        lens.ComposeWith(Test.Name.Space.Optics.Google.``duration``)
    [<Extension>]
    static member inline Duration(traversal : ITraversal<'a,'b,Test.Name.Space.Google,Test.Name.Space.Google>) : ITraversal<'a,'b,NodaTime.Duration option,NodaTime.Duration option> =
        traversal.ComposeWith(Test.Name.Space.Optics.Google.``duration``)
    [<Extension>]
    static member inline IntMap(lens : ILens<'a,'b,Test.Name.Space.IntMap,Test.Name.Space.IntMap>) : ILens<'a,'b,Map<int, string>,Map<int, string>> =
        lens.ComposeWith(Test.Name.Space.Optics.IntMap.``intMap``)
    [<Extension>]
    static member inline IntMap(traversal : ITraversal<'a,'b,Test.Name.Space.IntMap,Test.Name.Space.IntMap>) : ITraversal<'a,'b,Map<int, string>,Map<int, string>> =
        traversal.ComposeWith(Test.Name.Space.Optics.IntMap.``intMap``)
    [<Extension>]
    static member inline Name(lens : ILens<'a,'b,Test.Name.Space.HelloRequest,Test.Name.Space.HelloRequest>) : ILens<'a,'b,string,string> =
        lens.ComposeWith(Test.Name.Space.Optics.HelloRequest.``name``)
    [<Extension>]
    static member inline Name(traversal : ITraversal<'a,'b,Test.Name.Space.HelloRequest,Test.Name.Space.HelloRequest>) : ITraversal<'a,'b,string,string> =
        traversal.ComposeWith(Test.Name.Space.Optics.HelloRequest.``name``)
    [<Extension>]
    static member inline Message(lens : ILens<'a,'b,Test.Name.Space.HelloReply,Test.Name.Space.HelloReply>) : ILens<'a,'b,string,string> =
        lens.ComposeWith(Test.Name.Space.Optics.HelloReply.``message``)
    [<Extension>]
    static member inline Message(traversal : ITraversal<'a,'b,Test.Name.Space.HelloReply,Test.Name.Space.HelloReply>) : ITraversal<'a,'b,string,string> =
        traversal.ComposeWith(Test.Name.Space.Optics.HelloReply.``message``)
    [<Extension>]
    static member inline Empty(lens : ILens<'a,'b,Test.Name.Space.OneofWithNoParamsWrapper,Test.Name.Space.OneofWithNoParamsWrapper>) : ILens<'a,'b,Test.Name.Space.OneofWithNoParamsWrapper.EmptyCase,Test.Name.Space.OneofWithNoParamsWrapper.EmptyCase> =
        lens.ComposeWith(Test.Name.Space.Optics.OneofWithNoParamsWrapper.``empty``)
    [<Extension>]
    static member inline Empty(traversal : ITraversal<'a,'b,Test.Name.Space.OneofWithNoParamsWrapper,Test.Name.Space.OneofWithNoParamsWrapper>) : ITraversal<'a,'b,Test.Name.Space.OneofWithNoParamsWrapper.EmptyCase,Test.Name.Space.OneofWithNoParamsWrapper.EmptyCase> =
        traversal.ComposeWith(Test.Name.Space.Optics.OneofWithNoParamsWrapper.``empty``)
    [<Extension>]
    static member inline IfFirst(prism : IPrism<'s,'t,Test.Name.Space.OneofWithNoParamsWrapper.EmptyCase,Test.Name.Space.OneofWithNoParamsWrapper.EmptyCase>) : IPrism<'s,'t,Test.Name.Space.EmptyMessage,Test.Name.Space.EmptyMessage> = 
        prism.ComposeWith(Test.Name.Space.Optics.OneofWithNoParamsWrapper.EmptyPrisms.ifFirst)
    [<Extension>]
    static member inline IfFirst(traversal : ITraversal<'s,'t,Test.Name.Space.OneofWithNoParamsWrapper.EmptyCase,Test.Name.Space.OneofWithNoParamsWrapper.EmptyCase>) : ITraversal<'s,'t,Test.Name.Space.EmptyMessage,Test.Name.Space.EmptyMessage> = 
        traversal.ComposeWith(Test.Name.Space.Optics.OneofWithNoParamsWrapper.EmptyPrisms.ifFirst)
    [<Extension>]
    static member inline IfSecond(prism : IPrism<'s,'t,Test.Name.Space.OneofWithNoParamsWrapper.EmptyCase,Test.Name.Space.OneofWithNoParamsWrapper.EmptyCase>) : IPrism<'s,'t,Test.Name.Space.EmptyMessage,Test.Name.Space.EmptyMessage> = 
        prism.ComposeWith(Test.Name.Space.Optics.OneofWithNoParamsWrapper.EmptyPrisms.ifSecond)
    [<Extension>]
    static member inline IfSecond(traversal : ITraversal<'s,'t,Test.Name.Space.OneofWithNoParamsWrapper.EmptyCase,Test.Name.Space.OneofWithNoParamsWrapper.EmptyCase>) : ITraversal<'s,'t,Test.Name.Space.EmptyMessage,Test.Name.Space.EmptyMessage> = 
        traversal.ComposeWith(Test.Name.Space.Optics.OneofWithNoParamsWrapper.EmptyPrisms.ifSecond)

module Greeter =
    let private __Marshaller__test_name_space_HelloReply = Grpc.Core.Marshallers.Create(
        (fun (x: Test.Name.Space.HelloReply) -> FsGrpc.Protobuf.encode x),
        (fun (arr: byte array) -> FsGrpc.Protobuf.decode arr)
    )
    let private __Marshaller__test_name_space_HelloRequest = Grpc.Core.Marshallers.Create(
        (fun (x: Test.Name.Space.HelloRequest) -> FsGrpc.Protobuf.encode x),
        (fun (arr: byte array) -> FsGrpc.Protobuf.decode arr)
    )
    let private __Method_SayHello =
        Grpc.Core.Method<Test.Name.Space.HelloRequest,Test.Name.Space.HelloReply>(
            Grpc.Core.MethodType.Unary,
            "test.name.space.Greeter",
            "SayHello",
            __Marshaller__test_name_space_HelloRequest,
            __Marshaller__test_name_space_HelloReply
        )
    let private __Method_SayHelloServerStreaming =
        Grpc.Core.Method<Test.Name.Space.HelloRequest,Test.Name.Space.HelloReply>(
            Grpc.Core.MethodType.ServerStreaming,
            "test.name.space.Greeter",
            "SayHelloServerStreaming",
            __Marshaller__test_name_space_HelloRequest,
            __Marshaller__test_name_space_HelloReply
        )
    let private __Method_SayHelloClientStreaming =
        Grpc.Core.Method<Test.Name.Space.HelloRequest,Test.Name.Space.HelloReply>(
            Grpc.Core.MethodType.ClientStreaming,
            "test.name.space.Greeter",
            "SayHelloClientStreaming",
            __Marshaller__test_name_space_HelloRequest,
            __Marshaller__test_name_space_HelloReply
        )
    let private __Method_SayHelloDuplexStreaming =
        Grpc.Core.Method<Test.Name.Space.HelloRequest,Test.Name.Space.HelloReply>(
            Grpc.Core.MethodType.DuplexStreaming,
            "test.name.space.Greeter",
            "SayHelloDuplexStreaming",
            __Marshaller__test_name_space_HelloRequest,
            __Marshaller__test_name_space_HelloReply
        )
    [<AbstractClass>]
    [<Grpc.Core.BindServiceMethod(typeof<ServiceBase>, "BindService")>]
    type ServiceBase() = 
        abstract member SayHello : Test.Name.Space.HelloRequest -> Grpc.Core.ServerCallContext -> System.Threading.Tasks.Task<Test.Name.Space.HelloReply>
        abstract member SayHelloServerStreaming : Test.Name.Space.HelloRequest -> Grpc.Core.IServerStreamWriter<Test.Name.Space.HelloReply> -> Grpc.Core.ServerCallContext -> System.Threading.Tasks.Task
        abstract member SayHelloClientStreaming : Grpc.Core.IAsyncStreamReader<Test.Name.Space.HelloRequest> -> Grpc.Core.ServerCallContext -> System.Threading.Tasks.Task<Test.Name.Space.HelloReply>
        abstract member SayHelloDuplexStreaming : Grpc.Core.IAsyncStreamReader<Test.Name.Space.HelloRequest> -> Grpc.Core.IServerStreamWriter<Test.Name.Space.HelloReply> -> Grpc.Core.ServerCallContext -> System.Threading.Tasks.Task
        static member BindService (serviceBinder: Grpc.Core.ServiceBinderBase) (serviceImpl: ServiceBase) =
            let serviceMethodOrNull =
                match box serviceImpl with
                | null -> Unchecked.defaultof<Grpc.Core.UnaryServerMethod<Test.Name.Space.HelloRequest,Test.Name.Space.HelloReply>>
                | _ -> Grpc.Core.UnaryServerMethod<Test.Name.Space.HelloRequest,Test.Name.Space.HelloReply>(serviceImpl.SayHello)
            serviceBinder.AddMethod(__Method_SayHello, serviceMethodOrNull) |> ignore
            let serviceMethodOrNull =
                match box serviceImpl with
                | null -> Unchecked.defaultof<Grpc.Core.ServerStreamingServerMethod<Test.Name.Space.HelloRequest,Test.Name.Space.HelloReply>>
                | _ -> Grpc.Core.ServerStreamingServerMethod<Test.Name.Space.HelloRequest,Test.Name.Space.HelloReply>(serviceImpl.SayHelloServerStreaming)
            serviceBinder.AddMethod(__Method_SayHelloServerStreaming, serviceMethodOrNull) |> ignore
            let serviceMethodOrNull =
                match box serviceImpl with
                | null -> Unchecked.defaultof<Grpc.Core.ClientStreamingServerMethod<Test.Name.Space.HelloRequest,Test.Name.Space.HelloReply>>
                | _ -> Grpc.Core.ClientStreamingServerMethod<Test.Name.Space.HelloRequest,Test.Name.Space.HelloReply>(serviceImpl.SayHelloClientStreaming)
            serviceBinder.AddMethod(__Method_SayHelloClientStreaming, serviceMethodOrNull) |> ignore
            let serviceMethodOrNull =
                match box serviceImpl with
                | null -> Unchecked.defaultof<Grpc.Core.DuplexStreamingServerMethod<Test.Name.Space.HelloRequest,Test.Name.Space.HelloReply>>
                | _ -> Grpc.Core.DuplexStreamingServerMethod<Test.Name.Space.HelloRequest,Test.Name.Space.HelloReply>(serviceImpl.SayHelloDuplexStreaming)
            serviceBinder.AddMethod(__Method_SayHelloDuplexStreaming, serviceMethodOrNull) |> ignore
    type Client = 
        inherit Grpc.Core.ClientBase<Client>
        new () = { inherit Grpc.Core.ClientBase<Client>() }
        new (channel: Grpc.Core.ChannelBase) = { inherit Grpc.Core.ClientBase<Client>(channel) }
        new (callInvoker: Grpc.Core.CallInvoker) = { inherit Grpc.Core.ClientBase<Client>(callInvoker) }
        new (configuration: Grpc.Core.ClientBase.ClientBaseConfiguration) = { inherit Grpc.Core.ClientBase<Client>(configuration) }
        override this.NewInstance (configuration: Grpc.Core.ClientBase.ClientBaseConfiguration) = Client(configuration)
        member this.SayHello (callOptions: Grpc.Core.CallOptions) (request: Test.Name.Space.HelloRequest) =
            this.CallInvoker.BlockingUnaryCall(__Method_SayHello, Unchecked.defaultof<string>, callOptions, request)
        member this.SayHelloAsync (callOptions: Grpc.Core.CallOptions) (request: Test.Name.Space.HelloRequest) =
            this.CallInvoker.AsyncUnaryCall(__Method_SayHello, Unchecked.defaultof<string>, callOptions, request)
        member this.SayHelloServerStreamingAsync (callOptions: Grpc.Core.CallOptions) (request: Test.Name.Space.HelloRequest) =
            this.CallInvoker.AsyncServerStreamingCall(__Method_SayHelloServerStreaming, Unchecked.defaultof<string>, callOptions, request)
        member this.SayHelloClientStreamingAsync (callOptions: Grpc.Core.CallOptions) =
            this.CallInvoker.AsyncClientStreamingCall(__Method_SayHelloClientStreaming, Unchecked.defaultof<string>, callOptions)
        member this.SayHelloDuplexStreamingAsync (callOptions: Grpc.Core.CallOptions) =
            this.CallInvoker.AsyncDuplexStreamingCall(__Method_SayHelloDuplexStreaming, Unchecked.defaultof<string>, callOptions)
