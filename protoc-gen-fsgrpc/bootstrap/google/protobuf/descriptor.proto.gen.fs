namespace rec Google.Protobuf
open FsGrpc.Protobuf
#nowarn "40"


[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module FileDescriptorSet =

    [<System.Runtime.CompilerServices.IsByRefLike>]
    type Builder =
        struct
            val mutable Files: RepeatedBuilder<Google.Protobuf.FileDescriptorProto> // (1)
        end
        with
        member x.Put ((tag, reader): int * Reader) =
            match tag with
            | 1 -> x.Files.Add (ValueCodec.Message<Google.Protobuf.FileDescriptorProto>.ReadValue reader)
            | _ -> reader.SkipLastField()
        member x.Build : Google.Protobuf.FileDescriptorSet = {
            Files = x.Files.Build
            }

/// <summary>
/// The protocol compiler can output a FileDescriptorSet containing the .proto
/// files it parses.
/// </summary>
type private _FileDescriptorSet = FileDescriptorSet
[<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.MessageConverter>)>]
[<FsGrpc.Protobuf.Message>]
type FileDescriptorSet = {
    // Field Declarations
    [<System.Text.Json.Serialization.JsonPropertyName("files")>] Files: Google.Protobuf.FileDescriptorProto list // (1)
    }
    with
    static member Proto : Lazy<ProtoDef<FileDescriptorSet>> =
        lazy
        // Field Definitions
        let Files = FieldCodec.Repeated ValueCodec.Message<Google.Protobuf.FileDescriptorProto> (1, "files")
        // Proto Definition Implementation
        { // ProtoDef<FileDescriptorSet>
            Name = "FileDescriptorSet"
            Empty = {
                Files = Files.GetDefault()
                }
            Size = fun (m: FileDescriptorSet) ->
                0
                + Files.CalcFieldSize m.Files
            Encode = fun (w: Google.Protobuf.CodedOutputStream) (m: FileDescriptorSet) ->
                Files.WriteField w m.Files
            Decode = fun (r: Google.Protobuf.CodedInputStream) ->
                let mutable builder = new Google.Protobuf.FileDescriptorSet.Builder()
                let mutable tag = 0
                while read r &tag do
                    builder.Put (tag, r)
                builder.Build
            EncodeJson = fun (o: JsonOptions) ->
                let writeFiles = Files.WriteJsonField o
                let encode (w: System.Text.Json.Utf8JsonWriter) (m: FileDescriptorSet) =
                    writeFiles w m.Files
                encode
            DecodeJson = fun (node: System.Text.Json.Nodes.JsonNode) ->
                let update value (kvPair: System.Collections.Generic.KeyValuePair<string,System.Text.Json.Nodes.JsonNode>) : FileDescriptorSet =
                    match kvPair.Key with
                    | "files" -> { value with Files = Files.ReadJsonField kvPair.Value }
                    | _ -> value
                Seq.fold update _FileDescriptorSet.empty (node.AsObject ())
        }
    static member empty
        with get() = Google.Protobuf._FileDescriptorSet.Proto.Value.Empty

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module FileDescriptorProto =

    [<System.Runtime.CompilerServices.IsByRefLike>]
    type Builder =
        struct
            val mutable Name: string // (1)
            val mutable Package: string // (2)
            val mutable Dependencies: RepeatedBuilder<string> // (3)
            val mutable PublicDependencies: RepeatedBuilder<int> // (10)
            val mutable WeakDependencies: RepeatedBuilder<int> // (11)
            val mutable MessageTypes: RepeatedBuilder<Google.Protobuf.DescriptorProto> // (4)
            val mutable EnumTypes: RepeatedBuilder<Google.Protobuf.EnumDescriptorProto> // (5)
            val mutable Services: RepeatedBuilder<Google.Protobuf.ServiceDescriptorProto> // (6)
            val mutable Extensions: RepeatedBuilder<Google.Protobuf.FieldDescriptorProto> // (7)
            val mutable Options: OptionBuilder<Google.Protobuf.FileOptions> // (8)
            val mutable SourceCodeInfo: OptionBuilder<Google.Protobuf.SourceCodeInfo> // (9)
            val mutable Syntax: string // (12)
        end
        with
        member x.Put ((tag, reader): int * Reader) =
            match tag with
            | 1 -> x.Name <- ValueCodec.String.ReadValue reader
            | 2 -> x.Package <- ValueCodec.String.ReadValue reader
            | 3 -> x.Dependencies.Add (ValueCodec.String.ReadValue reader)
            | 10 -> x.PublicDependencies.AddRange ((ValueCodec.Packed ValueCodec.Int32).ReadValue reader)
            | 11 -> x.WeakDependencies.AddRange ((ValueCodec.Packed ValueCodec.Int32).ReadValue reader)
            | 4 -> x.MessageTypes.Add (ValueCodec.Message<Google.Protobuf.DescriptorProto>.ReadValue reader)
            | 5 -> x.EnumTypes.Add (ValueCodec.Message<Google.Protobuf.EnumDescriptorProto>.ReadValue reader)
            | 6 -> x.Services.Add (ValueCodec.Message<Google.Protobuf.ServiceDescriptorProto>.ReadValue reader)
            | 7 -> x.Extensions.Add (ValueCodec.Message<Google.Protobuf.FieldDescriptorProto>.ReadValue reader)
            | 8 -> x.Options.Set (ValueCodec.Message<Google.Protobuf.FileOptions>.ReadValue reader)
            | 9 -> x.SourceCodeInfo.Set (ValueCodec.Message<Google.Protobuf.SourceCodeInfo>.ReadValue reader)
            | 12 -> x.Syntax <- ValueCodec.String.ReadValue reader
            | _ -> reader.SkipLastField()
        member x.Build : Google.Protobuf.FileDescriptorProto = {
            Name = x.Name |> orEmptyString
            Package = x.Package |> orEmptyString
            Dependencies = x.Dependencies.Build
            PublicDependencies = x.PublicDependencies.Build
            WeakDependencies = x.WeakDependencies.Build
            MessageTypes = x.MessageTypes.Build
            EnumTypes = x.EnumTypes.Build
            Services = x.Services.Build
            Extensions = x.Extensions.Build
            Options = x.Options.Build
            SourceCodeInfo = x.SourceCodeInfo.Build
            Syntax = x.Syntax |> orEmptyString
            }

/// <summary>Describes a complete .proto file.</summary>
type private _FileDescriptorProto = FileDescriptorProto
[<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.MessageConverter>)>]
[<FsGrpc.Protobuf.Message>]
type FileDescriptorProto = {
    // Field Declarations
    [<System.Text.Json.Serialization.JsonPropertyName("name")>] Name: string // (1)
    [<System.Text.Json.Serialization.JsonPropertyName("package")>] Package: string // (2)
    /// <summary>Names of files imported by this file.</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("dependencies")>] Dependencies: string list // (3)
    /// <summary>Indexes of the public imported files in the dependency list above.</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("publicDependencies")>] PublicDependencies: int list // (10)
    /// <summary>
    /// Indexes of the weak imported files in the dependency list.
    /// For Google-internal migration only. Do not use.
    /// </summary>
    [<System.Text.Json.Serialization.JsonPropertyName("weakDependencies")>] WeakDependencies: int list // (11)
    /// <summary>All top-level definitions in this file.</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("messageTypes")>] MessageTypes: Google.Protobuf.DescriptorProto list // (4)
    [<System.Text.Json.Serialization.JsonPropertyName("enumTypes")>] EnumTypes: Google.Protobuf.EnumDescriptorProto list // (5)
    [<System.Text.Json.Serialization.JsonPropertyName("services")>] Services: Google.Protobuf.ServiceDescriptorProto list // (6)
    [<System.Text.Json.Serialization.JsonPropertyName("extensions")>] Extensions: Google.Protobuf.FieldDescriptorProto list // (7)
    [<System.Text.Json.Serialization.JsonPropertyName("options")>] Options: Google.Protobuf.FileOptions option // (8)
    /// <summary>
    /// This field contains optional information about the original source code.
    /// You may safely remove this entire field without harming runtime
    /// functionality of the descriptors -- the information is needed only by
    /// development tools.
    /// </summary>
    [<System.Text.Json.Serialization.JsonPropertyName("sourceCodeInfo")>] SourceCodeInfo: Google.Protobuf.SourceCodeInfo option // (9)
    /// <summary>
    /// The syntax of the proto file.
    /// The supported values are "proto2" and "proto3".
    /// </summary>
    [<System.Text.Json.Serialization.JsonPropertyName("syntax")>] Syntax: string // (12)
    }
    with
    static member Proto : Lazy<ProtoDef<FileDescriptorProto>> =
        lazy
        // Field Definitions
        let Name = FieldCodec.Primitive ValueCodec.String (1, "name")
        let Package = FieldCodec.Primitive ValueCodec.String (2, "package")
        let Dependencies = FieldCodec.Repeated ValueCodec.String (3, "dependencies")
        let PublicDependencies = FieldCodec.Primitive (ValueCodec.Packed ValueCodec.Int32) (10, "publicDependencies")
        let WeakDependencies = FieldCodec.Primitive (ValueCodec.Packed ValueCodec.Int32) (11, "weakDependencies")
        let MessageTypes = FieldCodec.Repeated ValueCodec.Message<Google.Protobuf.DescriptorProto> (4, "messageTypes")
        let EnumTypes = FieldCodec.Repeated ValueCodec.Message<Google.Protobuf.EnumDescriptorProto> (5, "enumTypes")
        let Services = FieldCodec.Repeated ValueCodec.Message<Google.Protobuf.ServiceDescriptorProto> (6, "services")
        let Extensions = FieldCodec.Repeated ValueCodec.Message<Google.Protobuf.FieldDescriptorProto> (7, "extensions")
        let Options = FieldCodec.Optional ValueCodec.Message<Google.Protobuf.FileOptions> (8, "options")
        let SourceCodeInfo = FieldCodec.Optional ValueCodec.Message<Google.Protobuf.SourceCodeInfo> (9, "sourceCodeInfo")
        let Syntax = FieldCodec.Primitive ValueCodec.String (12, "syntax")
        // Proto Definition Implementation
        { // ProtoDef<FileDescriptorProto>
            Name = "FileDescriptorProto"
            Empty = {
                Name = Name.GetDefault()
                Package = Package.GetDefault()
                Dependencies = Dependencies.GetDefault()
                PublicDependencies = PublicDependencies.GetDefault()
                WeakDependencies = WeakDependencies.GetDefault()
                MessageTypes = MessageTypes.GetDefault()
                EnumTypes = EnumTypes.GetDefault()
                Services = Services.GetDefault()
                Extensions = Extensions.GetDefault()
                Options = Options.GetDefault()
                SourceCodeInfo = SourceCodeInfo.GetDefault()
                Syntax = Syntax.GetDefault()
                }
            Size = fun (m: FileDescriptorProto) ->
                0
                + Name.CalcFieldSize m.Name
                + Package.CalcFieldSize m.Package
                + Dependencies.CalcFieldSize m.Dependencies
                + PublicDependencies.CalcFieldSize m.PublicDependencies
                + WeakDependencies.CalcFieldSize m.WeakDependencies
                + MessageTypes.CalcFieldSize m.MessageTypes
                + EnumTypes.CalcFieldSize m.EnumTypes
                + Services.CalcFieldSize m.Services
                + Extensions.CalcFieldSize m.Extensions
                + Options.CalcFieldSize m.Options
                + SourceCodeInfo.CalcFieldSize m.SourceCodeInfo
                + Syntax.CalcFieldSize m.Syntax
            Encode = fun (w: Google.Protobuf.CodedOutputStream) (m: FileDescriptorProto) ->
                Name.WriteField w m.Name
                Package.WriteField w m.Package
                Dependencies.WriteField w m.Dependencies
                PublicDependencies.WriteField w m.PublicDependencies
                WeakDependencies.WriteField w m.WeakDependencies
                MessageTypes.WriteField w m.MessageTypes
                EnumTypes.WriteField w m.EnumTypes
                Services.WriteField w m.Services
                Extensions.WriteField w m.Extensions
                Options.WriteField w m.Options
                SourceCodeInfo.WriteField w m.SourceCodeInfo
                Syntax.WriteField w m.Syntax
            Decode = fun (r: Google.Protobuf.CodedInputStream) ->
                let mutable builder = new Google.Protobuf.FileDescriptorProto.Builder()
                let mutable tag = 0
                while read r &tag do
                    builder.Put (tag, r)
                builder.Build
            EncodeJson = fun (o: JsonOptions) ->
                let writeName = Name.WriteJsonField o
                let writePackage = Package.WriteJsonField o
                let writeDependencies = Dependencies.WriteJsonField o
                let writePublicDependencies = PublicDependencies.WriteJsonField o
                let writeWeakDependencies = WeakDependencies.WriteJsonField o
                let writeMessageTypes = MessageTypes.WriteJsonField o
                let writeEnumTypes = EnumTypes.WriteJsonField o
                let writeServices = Services.WriteJsonField o
                let writeExtensions = Extensions.WriteJsonField o
                let writeOptions = Options.WriteJsonField o
                let writeSourceCodeInfo = SourceCodeInfo.WriteJsonField o
                let writeSyntax = Syntax.WriteJsonField o
                let encode (w: System.Text.Json.Utf8JsonWriter) (m: FileDescriptorProto) =
                    writeName w m.Name
                    writePackage w m.Package
                    writeDependencies w m.Dependencies
                    writePublicDependencies w m.PublicDependencies
                    writeWeakDependencies w m.WeakDependencies
                    writeMessageTypes w m.MessageTypes
                    writeEnumTypes w m.EnumTypes
                    writeServices w m.Services
                    writeExtensions w m.Extensions
                    writeOptions w m.Options
                    writeSourceCodeInfo w m.SourceCodeInfo
                    writeSyntax w m.Syntax
                encode
            DecodeJson = fun (node: System.Text.Json.Nodes.JsonNode) ->
                let update value (kvPair: System.Collections.Generic.KeyValuePair<string,System.Text.Json.Nodes.JsonNode>) : FileDescriptorProto =
                    match kvPair.Key with
                    | "name" -> { value with Name = Name.ReadJsonField kvPair.Value }
                    | "package" -> { value with Package = Package.ReadJsonField kvPair.Value }
                    | "dependencies" -> { value with Dependencies = Dependencies.ReadJsonField kvPair.Value }
                    | "publicDependencies" -> { value with PublicDependencies = PublicDependencies.ReadJsonField kvPair.Value }
                    | "weakDependencies" -> { value with WeakDependencies = WeakDependencies.ReadJsonField kvPair.Value }
                    | "messageTypes" -> { value with MessageTypes = MessageTypes.ReadJsonField kvPair.Value }
                    | "enumTypes" -> { value with EnumTypes = EnumTypes.ReadJsonField kvPair.Value }
                    | "services" -> { value with Services = Services.ReadJsonField kvPair.Value }
                    | "extensions" -> { value with Extensions = Extensions.ReadJsonField kvPair.Value }
                    | "options" -> { value with Options = Options.ReadJsonField kvPair.Value }
                    | "sourceCodeInfo" -> { value with SourceCodeInfo = SourceCodeInfo.ReadJsonField kvPair.Value }
                    | "syntax" -> { value with Syntax = Syntax.ReadJsonField kvPair.Value }
                    | _ -> value
                Seq.fold update _FileDescriptorProto.empty (node.AsObject ())
        }
    static member empty
        with get() = Google.Protobuf._FileDescriptorProto.Proto.Value.Empty

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module DescriptorProto =

    [<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    module ExtensionRange =

        [<System.Runtime.CompilerServices.IsByRefLike>]
        type Builder =
            struct
                val mutable Start: int // (1)
                val mutable End: int // (2)
                val mutable Options: OptionBuilder<Google.Protobuf.ExtensionRangeOptions> // (3)
            end
            with
            member x.Put ((tag, reader): int * Reader) =
                match tag with
                | 1 -> x.Start <- ValueCodec.Int32.ReadValue reader
                | 2 -> x.End <- ValueCodec.Int32.ReadValue reader
                | 3 -> x.Options.Set (ValueCodec.Message<Google.Protobuf.ExtensionRangeOptions>.ReadValue reader)
                | _ -> reader.SkipLastField()
            member x.Build : Google.Protobuf.DescriptorProto.ExtensionRange = {
                Start = x.Start
                End = x.End
                Options = x.Options.Build
                }

    type private _ExtensionRange = ExtensionRange
    [<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.MessageConverter>)>]
    [<FsGrpc.Protobuf.Message>]
    type ExtensionRange = {
        // Field Declarations
        [<System.Text.Json.Serialization.JsonPropertyName("start")>] Start: int // (1)
        [<System.Text.Json.Serialization.JsonPropertyName("end")>] End: int // (2)
        [<System.Text.Json.Serialization.JsonPropertyName("options")>] Options: Google.Protobuf.ExtensionRangeOptions option // (3)
        }
        with
        static member Proto : Lazy<ProtoDef<ExtensionRange>> =
            lazy
            // Field Definitions
            let Start = FieldCodec.Primitive ValueCodec.Int32 (1, "start")
            let End = FieldCodec.Primitive ValueCodec.Int32 (2, "end")
            let Options = FieldCodec.Optional ValueCodec.Message<Google.Protobuf.ExtensionRangeOptions> (3, "options")
            // Proto Definition Implementation
            { // ProtoDef<ExtensionRange>
                Name = "ExtensionRange"
                Empty = {
                    Start = Start.GetDefault()
                    End = End.GetDefault()
                    Options = Options.GetDefault()
                    }
                Size = fun (m: ExtensionRange) ->
                    0
                    + Start.CalcFieldSize m.Start
                    + End.CalcFieldSize m.End
                    + Options.CalcFieldSize m.Options
                Encode = fun (w: Google.Protobuf.CodedOutputStream) (m: ExtensionRange) ->
                    Start.WriteField w m.Start
                    End.WriteField w m.End
                    Options.WriteField w m.Options
                Decode = fun (r: Google.Protobuf.CodedInputStream) ->
                    let mutable builder = new Google.Protobuf.DescriptorProto.ExtensionRange.Builder()
                    let mutable tag = 0
                    while read r &tag do
                        builder.Put (tag, r)
                    builder.Build
                EncodeJson = fun (o: JsonOptions) ->
                    let writeStart = Start.WriteJsonField o
                    let writeEnd = End.WriteJsonField o
                    let writeOptions = Options.WriteJsonField o
                    let encode (w: System.Text.Json.Utf8JsonWriter) (m: ExtensionRange) =
                        writeStart w m.Start
                        writeEnd w m.End
                        writeOptions w m.Options
                    encode
                DecodeJson = fun (node: System.Text.Json.Nodes.JsonNode) ->
                    let update value (kvPair: System.Collections.Generic.KeyValuePair<string,System.Text.Json.Nodes.JsonNode>) : ExtensionRange =
                        match kvPair.Key with
                        | "start" -> { value with Start = Start.ReadJsonField kvPair.Value }
                        | "end" -> { value with End = End.ReadJsonField kvPair.Value }
                        | "options" -> { value with Options = Options.ReadJsonField kvPair.Value }
                        | _ -> value
                    Seq.fold update _ExtensionRange.empty (node.AsObject ())
            }
        static member empty
            with get() = Google.Protobuf.DescriptorProto._ExtensionRange.Proto.Value.Empty

    [<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    module ReservedRange =

        [<System.Runtime.CompilerServices.IsByRefLike>]
        type Builder =
            struct
                val mutable Start: int // (1)
                val mutable End: int // (2)
            end
            with
            member x.Put ((tag, reader): int * Reader) =
                match tag with
                | 1 -> x.Start <- ValueCodec.Int32.ReadValue reader
                | 2 -> x.End <- ValueCodec.Int32.ReadValue reader
                | _ -> reader.SkipLastField()
            member x.Build : Google.Protobuf.DescriptorProto.ReservedRange = {
                Start = x.Start
                End = x.End
                }

    /// <summary>
    /// Range of reserved tag numbers. Reserved tag numbers may not be used by
    /// fields or extension ranges in the same message. Reserved ranges may
    /// not overlap.
    /// </summary>
    type private _ReservedRange = ReservedRange
    [<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.MessageConverter>)>]
    [<FsGrpc.Protobuf.Message>]
    type ReservedRange = {
        // Field Declarations
        [<System.Text.Json.Serialization.JsonPropertyName("start")>] Start: int // (1)
        [<System.Text.Json.Serialization.JsonPropertyName("end")>] End: int // (2)
        }
        with
        static member Proto : Lazy<ProtoDef<ReservedRange>> =
            lazy
            // Field Definitions
            let Start = FieldCodec.Primitive ValueCodec.Int32 (1, "start")
            let End = FieldCodec.Primitive ValueCodec.Int32 (2, "end")
            // Proto Definition Implementation
            { // ProtoDef<ReservedRange>
                Name = "ReservedRange"
                Empty = {
                    Start = Start.GetDefault()
                    End = End.GetDefault()
                    }
                Size = fun (m: ReservedRange) ->
                    0
                    + Start.CalcFieldSize m.Start
                    + End.CalcFieldSize m.End
                Encode = fun (w: Google.Protobuf.CodedOutputStream) (m: ReservedRange) ->
                    Start.WriteField w m.Start
                    End.WriteField w m.End
                Decode = fun (r: Google.Protobuf.CodedInputStream) ->
                    let mutable builder = new Google.Protobuf.DescriptorProto.ReservedRange.Builder()
                    let mutable tag = 0
                    while read r &tag do
                        builder.Put (tag, r)
                    builder.Build
                EncodeJson = fun (o: JsonOptions) ->
                    let writeStart = Start.WriteJsonField o
                    let writeEnd = End.WriteJsonField o
                    let encode (w: System.Text.Json.Utf8JsonWriter) (m: ReservedRange) =
                        writeStart w m.Start
                        writeEnd w m.End
                    encode
                DecodeJson = fun (node: System.Text.Json.Nodes.JsonNode) ->
                    let update value (kvPair: System.Collections.Generic.KeyValuePair<string,System.Text.Json.Nodes.JsonNode>) : ReservedRange =
                        match kvPair.Key with
                        | "start" -> { value with Start = Start.ReadJsonField kvPair.Value }
                        | "end" -> { value with End = End.ReadJsonField kvPair.Value }
                        | _ -> value
                    Seq.fold update _ReservedRange.empty (node.AsObject ())
            }
        static member empty
            with get() = Google.Protobuf.DescriptorProto._ReservedRange.Proto.Value.Empty

    [<System.Runtime.CompilerServices.IsByRefLike>]
    type Builder =
        struct
            val mutable Name: string // (1)
            val mutable Fields: RepeatedBuilder<Google.Protobuf.FieldDescriptorProto> // (2)
            val mutable Extensions: RepeatedBuilder<Google.Protobuf.FieldDescriptorProto> // (6)
            val mutable NestedTypes: RepeatedBuilder<Google.Protobuf.DescriptorProto> // (3)
            val mutable EnumTypes: RepeatedBuilder<Google.Protobuf.EnumDescriptorProto> // (4)
            val mutable ExtensionRanges: RepeatedBuilder<Google.Protobuf.DescriptorProto.ExtensionRange> // (5)
            val mutable OneofDecls: RepeatedBuilder<Google.Protobuf.OneofDescriptorProto> // (8)
            val mutable Options: OptionBuilder<Google.Protobuf.MessageOptions> // (7)
            val mutable ReservedRanges: RepeatedBuilder<Google.Protobuf.DescriptorProto.ReservedRange> // (9)
            val mutable ReservedNames: RepeatedBuilder<string> // (10)
        end
        with
        member x.Put ((tag, reader): int * Reader) =
            match tag with
            | 1 -> x.Name <- ValueCodec.String.ReadValue reader
            | 2 -> x.Fields.Add (ValueCodec.Message<Google.Protobuf.FieldDescriptorProto>.ReadValue reader)
            | 6 -> x.Extensions.Add (ValueCodec.Message<Google.Protobuf.FieldDescriptorProto>.ReadValue reader)
            | 3 -> x.NestedTypes.Add (ValueCodec.Message<Google.Protobuf.DescriptorProto>.ReadValue reader)
            | 4 -> x.EnumTypes.Add (ValueCodec.Message<Google.Protobuf.EnumDescriptorProto>.ReadValue reader)
            | 5 -> x.ExtensionRanges.Add (ValueCodec.Message<Google.Protobuf.DescriptorProto.ExtensionRange>.ReadValue reader)
            | 8 -> x.OneofDecls.Add (ValueCodec.Message<Google.Protobuf.OneofDescriptorProto>.ReadValue reader)
            | 7 -> x.Options.Set (ValueCodec.Message<Google.Protobuf.MessageOptions>.ReadValue reader)
            | 9 -> x.ReservedRanges.Add (ValueCodec.Message<Google.Protobuf.DescriptorProto.ReservedRange>.ReadValue reader)
            | 10 -> x.ReservedNames.Add (ValueCodec.String.ReadValue reader)
            | _ -> reader.SkipLastField()
        member x.Build : Google.Protobuf.DescriptorProto = {
            Name = x.Name |> orEmptyString
            Fields = x.Fields.Build
            Extensions = x.Extensions.Build
            NestedTypes = x.NestedTypes.Build
            EnumTypes = x.EnumTypes.Build
            ExtensionRanges = x.ExtensionRanges.Build
            OneofDecls = x.OneofDecls.Build
            Options = x.Options.Build
            ReservedRanges = x.ReservedRanges.Build
            ReservedNames = x.ReservedNames.Build
            }

/// <summary>Describes a message type.</summary>
type private _DescriptorProto = DescriptorProto
[<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.MessageConverter>)>]
[<FsGrpc.Protobuf.Message>]
type DescriptorProto = {
    // Field Declarations
    [<System.Text.Json.Serialization.JsonPropertyName("name")>] Name: string // (1)
    [<System.Text.Json.Serialization.JsonPropertyName("fields")>] Fields: Google.Protobuf.FieldDescriptorProto list // (2)
    [<System.Text.Json.Serialization.JsonPropertyName("extensions")>] Extensions: Google.Protobuf.FieldDescriptorProto list // (6)
    [<System.Text.Json.Serialization.JsonPropertyName("nestedTypes")>] NestedTypes: Google.Protobuf.DescriptorProto list // (3)
    [<System.Text.Json.Serialization.JsonPropertyName("enumTypes")>] EnumTypes: Google.Protobuf.EnumDescriptorProto list // (4)
    [<System.Text.Json.Serialization.JsonPropertyName("extensionRanges")>] ExtensionRanges: Google.Protobuf.DescriptorProto.ExtensionRange list // (5)
    [<System.Text.Json.Serialization.JsonPropertyName("oneofDecls")>] OneofDecls: Google.Protobuf.OneofDescriptorProto list // (8)
    [<System.Text.Json.Serialization.JsonPropertyName("options")>] Options: Google.Protobuf.MessageOptions option // (7)
    [<System.Text.Json.Serialization.JsonPropertyName("reservedRanges")>] ReservedRanges: Google.Protobuf.DescriptorProto.ReservedRange list // (9)
    /// <summary>
    /// Reserved field names, which may not be used by fields in the same message.
    /// A given name may only be reserved once.
    /// </summary>
    [<System.Text.Json.Serialization.JsonPropertyName("reservedNames")>] ReservedNames: string list // (10)
    }
    with
    static member Proto : Lazy<ProtoDef<DescriptorProto>> =
        lazy
        // Field Definitions
        let Name = FieldCodec.Primitive ValueCodec.String (1, "name")
        let Fields = FieldCodec.Repeated ValueCodec.Message<Google.Protobuf.FieldDescriptorProto> (2, "fields")
        let Extensions = FieldCodec.Repeated ValueCodec.Message<Google.Protobuf.FieldDescriptorProto> (6, "extensions")
        let NestedTypes = FieldCodec.Repeated ValueCodec.Message<Google.Protobuf.DescriptorProto> (3, "nestedTypes")
        let EnumTypes = FieldCodec.Repeated ValueCodec.Message<Google.Protobuf.EnumDescriptorProto> (4, "enumTypes")
        let ExtensionRanges = FieldCodec.Repeated ValueCodec.Message<Google.Protobuf.DescriptorProto.ExtensionRange> (5, "extensionRanges")
        let OneofDecls = FieldCodec.Repeated ValueCodec.Message<Google.Protobuf.OneofDescriptorProto> (8, "oneofDecls")
        let Options = FieldCodec.Optional ValueCodec.Message<Google.Protobuf.MessageOptions> (7, "options")
        let ReservedRanges = FieldCodec.Repeated ValueCodec.Message<Google.Protobuf.DescriptorProto.ReservedRange> (9, "reservedRanges")
        let ReservedNames = FieldCodec.Repeated ValueCodec.String (10, "reservedNames")
        // Proto Definition Implementation
        { // ProtoDef<DescriptorProto>
            Name = "DescriptorProto"
            Empty = {
                Name = Name.GetDefault()
                Fields = Fields.GetDefault()
                Extensions = Extensions.GetDefault()
                NestedTypes = NestedTypes.GetDefault()
                EnumTypes = EnumTypes.GetDefault()
                ExtensionRanges = ExtensionRanges.GetDefault()
                OneofDecls = OneofDecls.GetDefault()
                Options = Options.GetDefault()
                ReservedRanges = ReservedRanges.GetDefault()
                ReservedNames = ReservedNames.GetDefault()
                }
            Size = fun (m: DescriptorProto) ->
                0
                + Name.CalcFieldSize m.Name
                + Fields.CalcFieldSize m.Fields
                + Extensions.CalcFieldSize m.Extensions
                + NestedTypes.CalcFieldSize m.NestedTypes
                + EnumTypes.CalcFieldSize m.EnumTypes
                + ExtensionRanges.CalcFieldSize m.ExtensionRanges
                + OneofDecls.CalcFieldSize m.OneofDecls
                + Options.CalcFieldSize m.Options
                + ReservedRanges.CalcFieldSize m.ReservedRanges
                + ReservedNames.CalcFieldSize m.ReservedNames
            Encode = fun (w: Google.Protobuf.CodedOutputStream) (m: DescriptorProto) ->
                Name.WriteField w m.Name
                Fields.WriteField w m.Fields
                Extensions.WriteField w m.Extensions
                NestedTypes.WriteField w m.NestedTypes
                EnumTypes.WriteField w m.EnumTypes
                ExtensionRanges.WriteField w m.ExtensionRanges
                OneofDecls.WriteField w m.OneofDecls
                Options.WriteField w m.Options
                ReservedRanges.WriteField w m.ReservedRanges
                ReservedNames.WriteField w m.ReservedNames
            Decode = fun (r: Google.Protobuf.CodedInputStream) ->
                let mutable builder = new Google.Protobuf.DescriptorProto.Builder()
                let mutable tag = 0
                while read r &tag do
                    builder.Put (tag, r)
                builder.Build
            EncodeJson = fun (o: JsonOptions) ->
                let writeName = Name.WriteJsonField o
                let writeFields = Fields.WriteJsonField o
                let writeExtensions = Extensions.WriteJsonField o
                let writeNestedTypes = NestedTypes.WriteJsonField o
                let writeEnumTypes = EnumTypes.WriteJsonField o
                let writeExtensionRanges = ExtensionRanges.WriteJsonField o
                let writeOneofDecls = OneofDecls.WriteJsonField o
                let writeOptions = Options.WriteJsonField o
                let writeReservedRanges = ReservedRanges.WriteJsonField o
                let writeReservedNames = ReservedNames.WriteJsonField o
                let encode (w: System.Text.Json.Utf8JsonWriter) (m: DescriptorProto) =
                    writeName w m.Name
                    writeFields w m.Fields
                    writeExtensions w m.Extensions
                    writeNestedTypes w m.NestedTypes
                    writeEnumTypes w m.EnumTypes
                    writeExtensionRanges w m.ExtensionRanges
                    writeOneofDecls w m.OneofDecls
                    writeOptions w m.Options
                    writeReservedRanges w m.ReservedRanges
                    writeReservedNames w m.ReservedNames
                encode
            DecodeJson = fun (node: System.Text.Json.Nodes.JsonNode) ->
                let update value (kvPair: System.Collections.Generic.KeyValuePair<string,System.Text.Json.Nodes.JsonNode>) : DescriptorProto =
                    match kvPair.Key with
                    | "name" -> { value with Name = Name.ReadJsonField kvPair.Value }
                    | "fields" -> { value with Fields = Fields.ReadJsonField kvPair.Value }
                    | "extensions" -> { value with Extensions = Extensions.ReadJsonField kvPair.Value }
                    | "nestedTypes" -> { value with NestedTypes = NestedTypes.ReadJsonField kvPair.Value }
                    | "enumTypes" -> { value with EnumTypes = EnumTypes.ReadJsonField kvPair.Value }
                    | "extensionRanges" -> { value with ExtensionRanges = ExtensionRanges.ReadJsonField kvPair.Value }
                    | "oneofDecls" -> { value with OneofDecls = OneofDecls.ReadJsonField kvPair.Value }
                    | "options" -> { value with Options = Options.ReadJsonField kvPair.Value }
                    | "reservedRanges" -> { value with ReservedRanges = ReservedRanges.ReadJsonField kvPair.Value }
                    | "reservedNames" -> { value with ReservedNames = ReservedNames.ReadJsonField kvPair.Value }
                    | _ -> value
                Seq.fold update _DescriptorProto.empty (node.AsObject ())
        }
    static member empty
        with get() = Google.Protobuf._DescriptorProto.Proto.Value.Empty

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module ExtensionRangeOptions =

    [<System.Runtime.CompilerServices.IsByRefLike>]
    type Builder =
        struct
            val mutable UninterpretedOptions: RepeatedBuilder<Google.Protobuf.UninterpretedOption> // (999)
        end
        with
        member x.Put ((tag, reader): int * Reader) =
            match tag with
            | 999 -> x.UninterpretedOptions.Add (ValueCodec.Message<Google.Protobuf.UninterpretedOption>.ReadValue reader)
            | _ -> reader.SkipLastField()
        member x.Build : Google.Protobuf.ExtensionRangeOptions = {
            UninterpretedOptions = x.UninterpretedOptions.Build
            }

type private _ExtensionRangeOptions = ExtensionRangeOptions
[<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.MessageConverter>)>]
[<FsGrpc.Protobuf.Message>]
type ExtensionRangeOptions = {
    // Field Declarations
    /// <summary>The parser stores options it doesn't recognize here. See above.</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("uninterpretedOptions")>] UninterpretedOptions: Google.Protobuf.UninterpretedOption list // (999)
    }
    with
    static member Proto : Lazy<ProtoDef<ExtensionRangeOptions>> =
        lazy
        // Field Definitions
        let UninterpretedOptions = FieldCodec.Repeated ValueCodec.Message<Google.Protobuf.UninterpretedOption> (999, "uninterpretedOptions")
        // Proto Definition Implementation
        { // ProtoDef<ExtensionRangeOptions>
            Name = "ExtensionRangeOptions"
            Empty = {
                UninterpretedOptions = UninterpretedOptions.GetDefault()
                }
            Size = fun (m: ExtensionRangeOptions) ->
                0
                + UninterpretedOptions.CalcFieldSize m.UninterpretedOptions
            Encode = fun (w: Google.Protobuf.CodedOutputStream) (m: ExtensionRangeOptions) ->
                UninterpretedOptions.WriteField w m.UninterpretedOptions
            Decode = fun (r: Google.Protobuf.CodedInputStream) ->
                let mutable builder = new Google.Protobuf.ExtensionRangeOptions.Builder()
                let mutable tag = 0
                while read r &tag do
                    builder.Put (tag, r)
                builder.Build
            EncodeJson = fun (o: JsonOptions) ->
                let writeUninterpretedOptions = UninterpretedOptions.WriteJsonField o
                let encode (w: System.Text.Json.Utf8JsonWriter) (m: ExtensionRangeOptions) =
                    writeUninterpretedOptions w m.UninterpretedOptions
                encode
            DecodeJson = fun (node: System.Text.Json.Nodes.JsonNode) ->
                let update value (kvPair: System.Collections.Generic.KeyValuePair<string,System.Text.Json.Nodes.JsonNode>) : ExtensionRangeOptions =
                    match kvPair.Key with
                    | "uninterpretedOptions" -> { value with UninterpretedOptions = UninterpretedOptions.ReadJsonField kvPair.Value }
                    | _ -> value
                Seq.fold update _ExtensionRangeOptions.empty (node.AsObject ())
        }
    static member empty
        with get() = Google.Protobuf._ExtensionRangeOptions.Proto.Value.Empty

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module FieldDescriptorProto =

    [<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.EnumConverter<Type>>)>]
    type Type =
    | [<FsGrpc.Protobuf.ProtobufName("TYPE_UNSPECIFIED")>] Unspecified = 0
    /// <summary>
    /// 0 is reserved for errors.
    /// Order is weird for historical reasons.
    /// </summary>
    | [<FsGrpc.Protobuf.ProtobufName("TYPE_DOUBLE")>] Double = 1
    | [<FsGrpc.Protobuf.ProtobufName("TYPE_FLOAT")>] Float = 2
    /// <summary>
    /// Not ZigZag encoded.  Negative numbers take 10 bytes.  Use TYPE_SINT64 if
    /// negative values are likely.
    /// </summary>
    | [<FsGrpc.Protobuf.ProtobufName("TYPE_INT64")>] Int64 = 3
    | [<FsGrpc.Protobuf.ProtobufName("TYPE_UINT64")>] Uint64 = 4
    /// <summary>
    /// Not ZigZag encoded.  Negative numbers take 10 bytes.  Use TYPE_SINT32 if
    /// negative values are likely.
    /// </summary>
    | [<FsGrpc.Protobuf.ProtobufName("TYPE_INT32")>] Int32 = 5
    | [<FsGrpc.Protobuf.ProtobufName("TYPE_FIXED64")>] Fixed64 = 6
    | [<FsGrpc.Protobuf.ProtobufName("TYPE_FIXED32")>] Fixed32 = 7
    | [<FsGrpc.Protobuf.ProtobufName("TYPE_BOOL")>] Bool = 8
    | [<FsGrpc.Protobuf.ProtobufName("TYPE_STRING")>] String = 9
    /// <summary>
    /// Tag-delimited aggregate.
    /// Group type is deprecated and not supported in proto3. However, Proto3
    /// implementations should still be able to parse the group wire format and
    /// treat group fields as unknown fields.
    /// </summary>
    | [<FsGrpc.Protobuf.ProtobufName("TYPE_GROUP")>] Group = 10
    | [<FsGrpc.Protobuf.ProtobufName("TYPE_MESSAGE")>] Message = 11
    /// <summary>New in version 2.</summary>
    | [<FsGrpc.Protobuf.ProtobufName("TYPE_BYTES")>] Bytes = 12
    | [<FsGrpc.Protobuf.ProtobufName("TYPE_UINT32")>] Uint32 = 13
    | [<FsGrpc.Protobuf.ProtobufName("TYPE_ENUM")>] Enum = 14
    | [<FsGrpc.Protobuf.ProtobufName("TYPE_SFIXED32")>] Sfixed32 = 15
    | [<FsGrpc.Protobuf.ProtobufName("TYPE_SFIXED64")>] Sfixed64 = 16
    | [<FsGrpc.Protobuf.ProtobufName("TYPE_SINT32")>] Sint32 = 17
    | [<FsGrpc.Protobuf.ProtobufName("TYPE_SINT64")>] Sint64 = 18

    [<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.EnumConverter<Label>>)>]
    type Label =
    | [<FsGrpc.Protobuf.ProtobufName("LABEL_UNSPECIFIED")>] Unspecified = 0
    /// <summary>0 is reserved for errors</summary>
    | [<FsGrpc.Protobuf.ProtobufName("LABEL_OPTIONAL")>] Optional = 1
    | [<FsGrpc.Protobuf.ProtobufName("LABEL_REQUIRED")>] Required = 2
    | [<FsGrpc.Protobuf.ProtobufName("LABEL_REPEATED")>] Repeated = 3

    [<System.Runtime.CompilerServices.IsByRefLike>]
    type Builder =
        struct
            val mutable Name: string // (1)
            val mutable Number: int // (3)
            val mutable Label: Google.Protobuf.FieldDescriptorProto.Label // (4)
            val mutable Type: Google.Protobuf.FieldDescriptorProto.Type // (5)
            val mutable TypeName: string // (6)
            val mutable Extendee: string // (2)
            val mutable DefaultValue: string // (7)
            val mutable OneofIndex: OptionBuilder<int> // (9)
            val mutable JsonName: string // (10)
            val mutable Options: OptionBuilder<Google.Protobuf.FieldOptions> // (8)
            val mutable Proto3Optional: bool // (17)
        end
        with
        member x.Put ((tag, reader): int * Reader) =
            match tag with
            | 1 -> x.Name <- ValueCodec.String.ReadValue reader
            | 3 -> x.Number <- ValueCodec.Int32.ReadValue reader
            | 4 -> x.Label <- ValueCodec.Enum<Google.Protobuf.FieldDescriptorProto.Label>.ReadValue reader
            | 5 -> x.Type <- ValueCodec.Enum<Google.Protobuf.FieldDescriptorProto.Type>.ReadValue reader
            | 6 -> x.TypeName <- ValueCodec.String.ReadValue reader
            | 2 -> x.Extendee <- ValueCodec.String.ReadValue reader
            | 7 -> x.DefaultValue <- ValueCodec.String.ReadValue reader
            | 9 -> x.OneofIndex.Set (ValueCodec.Int32.ReadValue reader)
            | 10 -> x.JsonName <- ValueCodec.String.ReadValue reader
            | 8 -> x.Options.Set (ValueCodec.Message<Google.Protobuf.FieldOptions>.ReadValue reader)
            | 17 -> x.Proto3Optional <- ValueCodec.Bool.ReadValue reader
            | _ -> reader.SkipLastField()
        member x.Build : Google.Protobuf.FieldDescriptorProto = {
            Name = x.Name |> orEmptyString
            Number = x.Number
            Label = x.Label
            Type = x.Type
            TypeName = x.TypeName |> orEmptyString
            Extendee = x.Extendee |> orEmptyString
            DefaultValue = x.DefaultValue |> orEmptyString
            OneofIndex = x.OneofIndex.Build
            JsonName = x.JsonName |> orEmptyString
            Options = x.Options.Build
            Proto3Optional = x.Proto3Optional
            }

/// <summary>Describes a field within a message.</summary>
type private _FieldDescriptorProto = FieldDescriptorProto
[<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.MessageConverter>)>]
[<FsGrpc.Protobuf.Message>]
type FieldDescriptorProto = {
    // Field Declarations
    [<System.Text.Json.Serialization.JsonPropertyName("name")>] Name: string // (1)
    [<System.Text.Json.Serialization.JsonPropertyName("number")>] Number: int // (3)
    [<System.Text.Json.Serialization.JsonPropertyName("label")>] Label: Google.Protobuf.FieldDescriptorProto.Label // (4)
    /// <summary>
    /// If type_name is set, this need not be set.  If both this and type_name
    /// are set, this must be one of TYPE_ENUM, TYPE_MESSAGE or TYPE_GROUP.
    /// </summary>
    [<System.Text.Json.Serialization.JsonPropertyName("type")>] Type: Google.Protobuf.FieldDescriptorProto.Type // (5)
    /// <summary>
    /// For message and enum types, this is the name of the type.  If the name
    /// starts with a '.', it is fully-qualified.  Otherwise, C++-like scoping
    /// rules are used to find the type (i.e. first the nested types within this
    /// message are searched, then within the parent, on up to the root
    /// namespace).
    /// </summary>
    [<System.Text.Json.Serialization.JsonPropertyName("typeName")>] TypeName: string // (6)
    /// <summary>
    /// For extensions, this is the name of the type being extended.  It is
    /// resolved in the same manner as type_name.
    /// </summary>
    [<System.Text.Json.Serialization.JsonPropertyName("extendee")>] Extendee: string // (2)
    /// <summary>
    /// For numeric types, contains the original text representation of the value.
    /// For booleans, "true" or "false".
    /// For strings, contains the default text contents (not escaped in any way).
    /// For bytes, contains the C escaped value.  All bytes >= 128 are escaped.
    /// TODO(kenton):  Base-64 encode?
    /// </summary>
    [<System.Text.Json.Serialization.JsonPropertyName("defaultValue")>] DefaultValue: string // (7)
    /// <summary>
    /// If set, gives the index of a oneof in the containing type's oneof_decl
    /// list.  This field is a member of that oneof.
    /// TODO: convert to optional and support proto3 optional
    /// </summary>
    [<System.Text.Json.Serialization.JsonPropertyName("oneofIndex")>] OneofIndex: int option // (9)
    /// <summary>
    /// JSON name of this field. The value is set by protocol compiler. If the
    /// user has set a "json_name" option on this field, that option's value
    /// will be used. Otherwise, it's deduced from the field's name by converting
    /// it to camelCase.
    /// </summary>
    [<System.Text.Json.Serialization.JsonPropertyName("jsonName")>] JsonName: string // (10)
    [<System.Text.Json.Serialization.JsonPropertyName("options")>] Options: Google.Protobuf.FieldOptions option // (8)
    /// <summary>
    /// If true, this is a proto3 "optional". When a proto3 field is optional, it
    /// tracks presence regardless of field type.
    /// 
    /// When proto3_optional is true, this field must be belong to a oneof to
    /// signal to old proto3 clients that presence is tracked for this field. This
    /// oneof is known as a "synthetic" oneof, and this field must be its sole
    /// member (each proto3 optional field gets its own synthetic oneof). Synthetic
    /// oneofs exist in the descriptor only, and do not generate any API. Synthetic
    /// oneofs must be ordered after all "real" oneofs.
    /// 
    /// For message fields, proto3_optional doesn't create any semantic change,
    /// since non-repeated message fields always track presence. However it still
    /// indicates the semantic detail of whether the user wrote "optional" or not.
    /// This can be useful for round-tripping the .proto file. For consistency we
    /// give message fields a synthetic oneof also, even though it is not required
    /// to track presence. This is especially important because the parser can't
    /// tell if a field is a message or an enum, so it must always create a
    /// synthetic oneof.
    /// 
    /// Proto2 optional fields do not set this flag, because they already indicate
    /// optional with `LABEL_OPTIONAL`.
    /// </summary>
    [<System.Text.Json.Serialization.JsonPropertyName("proto3Optional")>] Proto3Optional: bool // (17)
    }
    with
    static member Proto : Lazy<ProtoDef<FieldDescriptorProto>> =
        lazy
        // Field Definitions
        let Name = FieldCodec.Primitive ValueCodec.String (1, "name")
        let Number = FieldCodec.Primitive ValueCodec.Int32 (3, "number")
        let Label = FieldCodec.Primitive ValueCodec.Enum<Google.Protobuf.FieldDescriptorProto.Label> (4, "label")
        let Type = FieldCodec.Primitive ValueCodec.Enum<Google.Protobuf.FieldDescriptorProto.Type> (5, "type")
        let TypeName = FieldCodec.Primitive ValueCodec.String (6, "typeName")
        let Extendee = FieldCodec.Primitive ValueCodec.String (2, "extendee")
        let DefaultValue = FieldCodec.Primitive ValueCodec.String (7, "defaultValue")
        let OneofIndex = FieldCodec.Optional ValueCodec.Int32 (9, "oneofIndex")
        let JsonName = FieldCodec.Primitive ValueCodec.String (10, "jsonName")
        let Options = FieldCodec.Optional ValueCodec.Message<Google.Protobuf.FieldOptions> (8, "options")
        let Proto3Optional = FieldCodec.Primitive ValueCodec.Bool (17, "proto3Optional")
        // Proto Definition Implementation
        { // ProtoDef<FieldDescriptorProto>
            Name = "FieldDescriptorProto"
            Empty = {
                Name = Name.GetDefault()
                Number = Number.GetDefault()
                Label = Label.GetDefault()
                Type = Type.GetDefault()
                TypeName = TypeName.GetDefault()
                Extendee = Extendee.GetDefault()
                DefaultValue = DefaultValue.GetDefault()
                OneofIndex = OneofIndex.GetDefault()
                JsonName = JsonName.GetDefault()
                Options = Options.GetDefault()
                Proto3Optional = Proto3Optional.GetDefault()
                }
            Size = fun (m: FieldDescriptorProto) ->
                0
                + Name.CalcFieldSize m.Name
                + Number.CalcFieldSize m.Number
                + Label.CalcFieldSize m.Label
                + Type.CalcFieldSize m.Type
                + TypeName.CalcFieldSize m.TypeName
                + Extendee.CalcFieldSize m.Extendee
                + DefaultValue.CalcFieldSize m.DefaultValue
                + OneofIndex.CalcFieldSize m.OneofIndex
                + JsonName.CalcFieldSize m.JsonName
                + Options.CalcFieldSize m.Options
                + Proto3Optional.CalcFieldSize m.Proto3Optional
            Encode = fun (w: Google.Protobuf.CodedOutputStream) (m: FieldDescriptorProto) ->
                Name.WriteField w m.Name
                Number.WriteField w m.Number
                Label.WriteField w m.Label
                Type.WriteField w m.Type
                TypeName.WriteField w m.TypeName
                Extendee.WriteField w m.Extendee
                DefaultValue.WriteField w m.DefaultValue
                OneofIndex.WriteField w m.OneofIndex
                JsonName.WriteField w m.JsonName
                Options.WriteField w m.Options
                Proto3Optional.WriteField w m.Proto3Optional
            Decode = fun (r: Google.Protobuf.CodedInputStream) ->
                let mutable builder = new Google.Protobuf.FieldDescriptorProto.Builder()
                let mutable tag = 0
                while read r &tag do
                    builder.Put (tag, r)
                builder.Build
            EncodeJson = fun (o: JsonOptions) ->
                let writeName = Name.WriteJsonField o
                let writeNumber = Number.WriteJsonField o
                let writeLabel = Label.WriteJsonField o
                let writeType = Type.WriteJsonField o
                let writeTypeName = TypeName.WriteJsonField o
                let writeExtendee = Extendee.WriteJsonField o
                let writeDefaultValue = DefaultValue.WriteJsonField o
                let writeOneofIndex = OneofIndex.WriteJsonField o
                let writeJsonName = JsonName.WriteJsonField o
                let writeOptions = Options.WriteJsonField o
                let writeProto3Optional = Proto3Optional.WriteJsonField o
                let encode (w: System.Text.Json.Utf8JsonWriter) (m: FieldDescriptorProto) =
                    writeName w m.Name
                    writeNumber w m.Number
                    writeLabel w m.Label
                    writeType w m.Type
                    writeTypeName w m.TypeName
                    writeExtendee w m.Extendee
                    writeDefaultValue w m.DefaultValue
                    writeOneofIndex w m.OneofIndex
                    writeJsonName w m.JsonName
                    writeOptions w m.Options
                    writeProto3Optional w m.Proto3Optional
                encode
            DecodeJson = fun (node: System.Text.Json.Nodes.JsonNode) ->
                let update value (kvPair: System.Collections.Generic.KeyValuePair<string,System.Text.Json.Nodes.JsonNode>) : FieldDescriptorProto =
                    match kvPair.Key with
                    | "name" -> { value with Name = Name.ReadJsonField kvPair.Value }
                    | "number" -> { value with Number = Number.ReadJsonField kvPair.Value }
                    | "label" -> { value with Label = Label.ReadJsonField kvPair.Value }
                    | "type" -> { value with Type = Type.ReadJsonField kvPair.Value }
                    | "typeName" -> { value with TypeName = TypeName.ReadJsonField kvPair.Value }
                    | "extendee" -> { value with Extendee = Extendee.ReadJsonField kvPair.Value }
                    | "defaultValue" -> { value with DefaultValue = DefaultValue.ReadJsonField kvPair.Value }
                    | "oneofIndex" -> { value with OneofIndex = OneofIndex.ReadJsonField kvPair.Value }
                    | "jsonName" -> { value with JsonName = JsonName.ReadJsonField kvPair.Value }
                    | "options" -> { value with Options = Options.ReadJsonField kvPair.Value }
                    | "proto3Optional" -> { value with Proto3Optional = Proto3Optional.ReadJsonField kvPair.Value }
                    | _ -> value
                Seq.fold update _FieldDescriptorProto.empty (node.AsObject ())
        }
    static member empty
        with get() = Google.Protobuf._FieldDescriptorProto.Proto.Value.Empty

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module OneofDescriptorProto =

    [<System.Runtime.CompilerServices.IsByRefLike>]
    type Builder =
        struct
            val mutable Name: string // (1)
            val mutable Options: OptionBuilder<Google.Protobuf.OneofOptions> // (2)
        end
        with
        member x.Put ((tag, reader): int * Reader) =
            match tag with
            | 1 -> x.Name <- ValueCodec.String.ReadValue reader
            | 2 -> x.Options.Set (ValueCodec.Message<Google.Protobuf.OneofOptions>.ReadValue reader)
            | _ -> reader.SkipLastField()
        member x.Build : Google.Protobuf.OneofDescriptorProto = {
            Name = x.Name |> orEmptyString
            Options = x.Options.Build
            }

/// <summary>Describes a oneof.</summary>
type private _OneofDescriptorProto = OneofDescriptorProto
[<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.MessageConverter>)>]
[<FsGrpc.Protobuf.Message>]
type OneofDescriptorProto = {
    // Field Declarations
    [<System.Text.Json.Serialization.JsonPropertyName("name")>] Name: string // (1)
    [<System.Text.Json.Serialization.JsonPropertyName("options")>] Options: Google.Protobuf.OneofOptions option // (2)
    }
    with
    static member Proto : Lazy<ProtoDef<OneofDescriptorProto>> =
        lazy
        // Field Definitions
        let Name = FieldCodec.Primitive ValueCodec.String (1, "name")
        let Options = FieldCodec.Optional ValueCodec.Message<Google.Protobuf.OneofOptions> (2, "options")
        // Proto Definition Implementation
        { // ProtoDef<OneofDescriptorProto>
            Name = "OneofDescriptorProto"
            Empty = {
                Name = Name.GetDefault()
                Options = Options.GetDefault()
                }
            Size = fun (m: OneofDescriptorProto) ->
                0
                + Name.CalcFieldSize m.Name
                + Options.CalcFieldSize m.Options
            Encode = fun (w: Google.Protobuf.CodedOutputStream) (m: OneofDescriptorProto) ->
                Name.WriteField w m.Name
                Options.WriteField w m.Options
            Decode = fun (r: Google.Protobuf.CodedInputStream) ->
                let mutable builder = new Google.Protobuf.OneofDescriptorProto.Builder()
                let mutable tag = 0
                while read r &tag do
                    builder.Put (tag, r)
                builder.Build
            EncodeJson = fun (o: JsonOptions) ->
                let writeName = Name.WriteJsonField o
                let writeOptions = Options.WriteJsonField o
                let encode (w: System.Text.Json.Utf8JsonWriter) (m: OneofDescriptorProto) =
                    writeName w m.Name
                    writeOptions w m.Options
                encode
            DecodeJson = fun (node: System.Text.Json.Nodes.JsonNode) ->
                let update value (kvPair: System.Collections.Generic.KeyValuePair<string,System.Text.Json.Nodes.JsonNode>) : OneofDescriptorProto =
                    match kvPair.Key with
                    | "name" -> { value with Name = Name.ReadJsonField kvPair.Value }
                    | "options" -> { value with Options = Options.ReadJsonField kvPair.Value }
                    | _ -> value
                Seq.fold update _OneofDescriptorProto.empty (node.AsObject ())
        }
    static member empty
        with get() = Google.Protobuf._OneofDescriptorProto.Proto.Value.Empty

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module EnumDescriptorProto =

    [<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    module EnumReservedRange =

        [<System.Runtime.CompilerServices.IsByRefLike>]
        type Builder =
            struct
                val mutable Start: int // (1)
                val mutable End: int // (2)
            end
            with
            member x.Put ((tag, reader): int * Reader) =
                match tag with
                | 1 -> x.Start <- ValueCodec.Int32.ReadValue reader
                | 2 -> x.End <- ValueCodec.Int32.ReadValue reader
                | _ -> reader.SkipLastField()
            member x.Build : Google.Protobuf.EnumDescriptorProto.EnumReservedRange = {
                Start = x.Start
                End = x.End
                }

    /// <summary>
    /// Range of reserved numeric values. Reserved values may not be used by
    /// entries in the same enum. Reserved ranges may not overlap.
    /// 
    /// Note that this is distinct from DescriptorProto.ReservedRange in that it
    /// is inclusive such that it can appropriately represent the entire int32
    /// domain.
    /// </summary>
    type private _EnumReservedRange = EnumReservedRange
    [<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.MessageConverter>)>]
    [<FsGrpc.Protobuf.Message>]
    type EnumReservedRange = {
        // Field Declarations
        [<System.Text.Json.Serialization.JsonPropertyName("start")>] Start: int // (1)
        [<System.Text.Json.Serialization.JsonPropertyName("end")>] End: int // (2)
        }
        with
        static member Proto : Lazy<ProtoDef<EnumReservedRange>> =
            lazy
            // Field Definitions
            let Start = FieldCodec.Primitive ValueCodec.Int32 (1, "start")
            let End = FieldCodec.Primitive ValueCodec.Int32 (2, "end")
            // Proto Definition Implementation
            { // ProtoDef<EnumReservedRange>
                Name = "EnumReservedRange"
                Empty = {
                    Start = Start.GetDefault()
                    End = End.GetDefault()
                    }
                Size = fun (m: EnumReservedRange) ->
                    0
                    + Start.CalcFieldSize m.Start
                    + End.CalcFieldSize m.End
                Encode = fun (w: Google.Protobuf.CodedOutputStream) (m: EnumReservedRange) ->
                    Start.WriteField w m.Start
                    End.WriteField w m.End
                Decode = fun (r: Google.Protobuf.CodedInputStream) ->
                    let mutable builder = new Google.Protobuf.EnumDescriptorProto.EnumReservedRange.Builder()
                    let mutable tag = 0
                    while read r &tag do
                        builder.Put (tag, r)
                    builder.Build
                EncodeJson = fun (o: JsonOptions) ->
                    let writeStart = Start.WriteJsonField o
                    let writeEnd = End.WriteJsonField o
                    let encode (w: System.Text.Json.Utf8JsonWriter) (m: EnumReservedRange) =
                        writeStart w m.Start
                        writeEnd w m.End
                    encode
                DecodeJson = fun (node: System.Text.Json.Nodes.JsonNode) ->
                    let update value (kvPair: System.Collections.Generic.KeyValuePair<string,System.Text.Json.Nodes.JsonNode>) : EnumReservedRange =
                        match kvPair.Key with
                        | "start" -> { value with Start = Start.ReadJsonField kvPair.Value }
                        | "end" -> { value with End = End.ReadJsonField kvPair.Value }
                        | _ -> value
                    Seq.fold update _EnumReservedRange.empty (node.AsObject ())
            }
        static member empty
            with get() = Google.Protobuf.EnumDescriptorProto._EnumReservedRange.Proto.Value.Empty

    [<System.Runtime.CompilerServices.IsByRefLike>]
    type Builder =
        struct
            val mutable Name: string // (1)
            val mutable Values: RepeatedBuilder<Google.Protobuf.EnumValueDescriptorProto> // (2)
            val mutable Options: OptionBuilder<Google.Protobuf.EnumOptions> // (3)
            val mutable ReservedRanges: RepeatedBuilder<Google.Protobuf.EnumDescriptorProto.EnumReservedRange> // (4)
            val mutable ReservedNames: RepeatedBuilder<string> // (5)
        end
        with
        member x.Put ((tag, reader): int * Reader) =
            match tag with
            | 1 -> x.Name <- ValueCodec.String.ReadValue reader
            | 2 -> x.Values.Add (ValueCodec.Message<Google.Protobuf.EnumValueDescriptorProto>.ReadValue reader)
            | 3 -> x.Options.Set (ValueCodec.Message<Google.Protobuf.EnumOptions>.ReadValue reader)
            | 4 -> x.ReservedRanges.Add (ValueCodec.Message<Google.Protobuf.EnumDescriptorProto.EnumReservedRange>.ReadValue reader)
            | 5 -> x.ReservedNames.Add (ValueCodec.String.ReadValue reader)
            | _ -> reader.SkipLastField()
        member x.Build : Google.Protobuf.EnumDescriptorProto = {
            Name = x.Name |> orEmptyString
            Values = x.Values.Build
            Options = x.Options.Build
            ReservedRanges = x.ReservedRanges.Build
            ReservedNames = x.ReservedNames.Build
            }

/// <summary>Describes an enum type.</summary>
type private _EnumDescriptorProto = EnumDescriptorProto
[<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.MessageConverter>)>]
[<FsGrpc.Protobuf.Message>]
type EnumDescriptorProto = {
    // Field Declarations
    [<System.Text.Json.Serialization.JsonPropertyName("name")>] Name: string // (1)
    [<System.Text.Json.Serialization.JsonPropertyName("values")>] Values: Google.Protobuf.EnumValueDescriptorProto list // (2)
    [<System.Text.Json.Serialization.JsonPropertyName("options")>] Options: Google.Protobuf.EnumOptions option // (3)
    /// <summary>
    /// Range of reserved numeric values. Reserved numeric values may not be used
    /// by enum values in the same enum declaration. Reserved ranges may not
    /// overlap.
    /// </summary>
    [<System.Text.Json.Serialization.JsonPropertyName("reservedRanges")>] ReservedRanges: Google.Protobuf.EnumDescriptorProto.EnumReservedRange list // (4)
    /// <summary>
    /// Reserved enum value names, which may not be reused. A given name may only
    /// be reserved once.
    /// </summary>
    [<System.Text.Json.Serialization.JsonPropertyName("reservedNames")>] ReservedNames: string list // (5)
    }
    with
    static member Proto : Lazy<ProtoDef<EnumDescriptorProto>> =
        lazy
        // Field Definitions
        let Name = FieldCodec.Primitive ValueCodec.String (1, "name")
        let Values = FieldCodec.Repeated ValueCodec.Message<Google.Protobuf.EnumValueDescriptorProto> (2, "values")
        let Options = FieldCodec.Optional ValueCodec.Message<Google.Protobuf.EnumOptions> (3, "options")
        let ReservedRanges = FieldCodec.Repeated ValueCodec.Message<Google.Protobuf.EnumDescriptorProto.EnumReservedRange> (4, "reservedRanges")
        let ReservedNames = FieldCodec.Repeated ValueCodec.String (5, "reservedNames")
        // Proto Definition Implementation
        { // ProtoDef<EnumDescriptorProto>
            Name = "EnumDescriptorProto"
            Empty = {
                Name = Name.GetDefault()
                Values = Values.GetDefault()
                Options = Options.GetDefault()
                ReservedRanges = ReservedRanges.GetDefault()
                ReservedNames = ReservedNames.GetDefault()
                }
            Size = fun (m: EnumDescriptorProto) ->
                0
                + Name.CalcFieldSize m.Name
                + Values.CalcFieldSize m.Values
                + Options.CalcFieldSize m.Options
                + ReservedRanges.CalcFieldSize m.ReservedRanges
                + ReservedNames.CalcFieldSize m.ReservedNames
            Encode = fun (w: Google.Protobuf.CodedOutputStream) (m: EnumDescriptorProto) ->
                Name.WriteField w m.Name
                Values.WriteField w m.Values
                Options.WriteField w m.Options
                ReservedRanges.WriteField w m.ReservedRanges
                ReservedNames.WriteField w m.ReservedNames
            Decode = fun (r: Google.Protobuf.CodedInputStream) ->
                let mutable builder = new Google.Protobuf.EnumDescriptorProto.Builder()
                let mutable tag = 0
                while read r &tag do
                    builder.Put (tag, r)
                builder.Build
            EncodeJson = fun (o: JsonOptions) ->
                let writeName = Name.WriteJsonField o
                let writeValues = Values.WriteJsonField o
                let writeOptions = Options.WriteJsonField o
                let writeReservedRanges = ReservedRanges.WriteJsonField o
                let writeReservedNames = ReservedNames.WriteJsonField o
                let encode (w: System.Text.Json.Utf8JsonWriter) (m: EnumDescriptorProto) =
                    writeName w m.Name
                    writeValues w m.Values
                    writeOptions w m.Options
                    writeReservedRanges w m.ReservedRanges
                    writeReservedNames w m.ReservedNames
                encode
            DecodeJson = fun (node: System.Text.Json.Nodes.JsonNode) ->
                let update value (kvPair: System.Collections.Generic.KeyValuePair<string,System.Text.Json.Nodes.JsonNode>) : EnumDescriptorProto =
                    match kvPair.Key with
                    | "name" -> { value with Name = Name.ReadJsonField kvPair.Value }
                    | "values" -> { value with Values = Values.ReadJsonField kvPair.Value }
                    | "options" -> { value with Options = Options.ReadJsonField kvPair.Value }
                    | "reservedRanges" -> { value with ReservedRanges = ReservedRanges.ReadJsonField kvPair.Value }
                    | "reservedNames" -> { value with ReservedNames = ReservedNames.ReadJsonField kvPair.Value }
                    | _ -> value
                Seq.fold update _EnumDescriptorProto.empty (node.AsObject ())
        }
    static member empty
        with get() = Google.Protobuf._EnumDescriptorProto.Proto.Value.Empty

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module EnumValueDescriptorProto =

    [<System.Runtime.CompilerServices.IsByRefLike>]
    type Builder =
        struct
            val mutable Name: string // (1)
            val mutable Number: int // (2)
            val mutable Options: OptionBuilder<Google.Protobuf.EnumValueOptions> // (3)
        end
        with
        member x.Put ((tag, reader): int * Reader) =
            match tag with
            | 1 -> x.Name <- ValueCodec.String.ReadValue reader
            | 2 -> x.Number <- ValueCodec.Int32.ReadValue reader
            | 3 -> x.Options.Set (ValueCodec.Message<Google.Protobuf.EnumValueOptions>.ReadValue reader)
            | _ -> reader.SkipLastField()
        member x.Build : Google.Protobuf.EnumValueDescriptorProto = {
            Name = x.Name |> orEmptyString
            Number = x.Number
            Options = x.Options.Build
            }

/// <summary>Describes a value within an enum.</summary>
type private _EnumValueDescriptorProto = EnumValueDescriptorProto
[<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.MessageConverter>)>]
[<FsGrpc.Protobuf.Message>]
type EnumValueDescriptorProto = {
    // Field Declarations
    [<System.Text.Json.Serialization.JsonPropertyName("name")>] Name: string // (1)
    [<System.Text.Json.Serialization.JsonPropertyName("number")>] Number: int // (2)
    [<System.Text.Json.Serialization.JsonPropertyName("options")>] Options: Google.Protobuf.EnumValueOptions option // (3)
    }
    with
    static member Proto : Lazy<ProtoDef<EnumValueDescriptorProto>> =
        lazy
        // Field Definitions
        let Name = FieldCodec.Primitive ValueCodec.String (1, "name")
        let Number = FieldCodec.Primitive ValueCodec.Int32 (2, "number")
        let Options = FieldCodec.Optional ValueCodec.Message<Google.Protobuf.EnumValueOptions> (3, "options")
        // Proto Definition Implementation
        { // ProtoDef<EnumValueDescriptorProto>
            Name = "EnumValueDescriptorProto"
            Empty = {
                Name = Name.GetDefault()
                Number = Number.GetDefault()
                Options = Options.GetDefault()
                }
            Size = fun (m: EnumValueDescriptorProto) ->
                0
                + Name.CalcFieldSize m.Name
                + Number.CalcFieldSize m.Number
                + Options.CalcFieldSize m.Options
            Encode = fun (w: Google.Protobuf.CodedOutputStream) (m: EnumValueDescriptorProto) ->
                Name.WriteField w m.Name
                Number.WriteField w m.Number
                Options.WriteField w m.Options
            Decode = fun (r: Google.Protobuf.CodedInputStream) ->
                let mutable builder = new Google.Protobuf.EnumValueDescriptorProto.Builder()
                let mutable tag = 0
                while read r &tag do
                    builder.Put (tag, r)
                builder.Build
            EncodeJson = fun (o: JsonOptions) ->
                let writeName = Name.WriteJsonField o
                let writeNumber = Number.WriteJsonField o
                let writeOptions = Options.WriteJsonField o
                let encode (w: System.Text.Json.Utf8JsonWriter) (m: EnumValueDescriptorProto) =
                    writeName w m.Name
                    writeNumber w m.Number
                    writeOptions w m.Options
                encode
            DecodeJson = fun (node: System.Text.Json.Nodes.JsonNode) ->
                let update value (kvPair: System.Collections.Generic.KeyValuePair<string,System.Text.Json.Nodes.JsonNode>) : EnumValueDescriptorProto =
                    match kvPair.Key with
                    | "name" -> { value with Name = Name.ReadJsonField kvPair.Value }
                    | "number" -> { value with Number = Number.ReadJsonField kvPair.Value }
                    | "options" -> { value with Options = Options.ReadJsonField kvPair.Value }
                    | _ -> value
                Seq.fold update _EnumValueDescriptorProto.empty (node.AsObject ())
        }
    static member empty
        with get() = Google.Protobuf._EnumValueDescriptorProto.Proto.Value.Empty

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module ServiceDescriptorProto =

    [<System.Runtime.CompilerServices.IsByRefLike>]
    type Builder =
        struct
            val mutable Name: string // (1)
            val mutable Methods: RepeatedBuilder<Google.Protobuf.MethodDescriptorProto> // (2)
            val mutable Options: OptionBuilder<Google.Protobuf.ServiceOptions> // (3)
        end
        with
        member x.Put ((tag, reader): int * Reader) =
            match tag with
            | 1 -> x.Name <- ValueCodec.String.ReadValue reader
            | 2 -> x.Methods.Add (ValueCodec.Message<Google.Protobuf.MethodDescriptorProto>.ReadValue reader)
            | 3 -> x.Options.Set (ValueCodec.Message<Google.Protobuf.ServiceOptions>.ReadValue reader)
            | _ -> reader.SkipLastField()
        member x.Build : Google.Protobuf.ServiceDescriptorProto = {
            Name = x.Name |> orEmptyString
            Methods = x.Methods.Build
            Options = x.Options.Build
            }

/// <summary>Describes a service.</summary>
type private _ServiceDescriptorProto = ServiceDescriptorProto
[<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.MessageConverter>)>]
[<FsGrpc.Protobuf.Message>]
type ServiceDescriptorProto = {
    // Field Declarations
    [<System.Text.Json.Serialization.JsonPropertyName("name")>] Name: string // (1)
    [<System.Text.Json.Serialization.JsonPropertyName("methods")>] Methods: Google.Protobuf.MethodDescriptorProto list // (2)
    [<System.Text.Json.Serialization.JsonPropertyName("options")>] Options: Google.Protobuf.ServiceOptions option // (3)
    }
    with
    static member Proto : Lazy<ProtoDef<ServiceDescriptorProto>> =
        lazy
        // Field Definitions
        let Name = FieldCodec.Primitive ValueCodec.String (1, "name")
        let Methods = FieldCodec.Repeated ValueCodec.Message<Google.Protobuf.MethodDescriptorProto> (2, "methods")
        let Options = FieldCodec.Optional ValueCodec.Message<Google.Protobuf.ServiceOptions> (3, "options")
        // Proto Definition Implementation
        { // ProtoDef<ServiceDescriptorProto>
            Name = "ServiceDescriptorProto"
            Empty = {
                Name = Name.GetDefault()
                Methods = Methods.GetDefault()
                Options = Options.GetDefault()
                }
            Size = fun (m: ServiceDescriptorProto) ->
                0
                + Name.CalcFieldSize m.Name
                + Methods.CalcFieldSize m.Methods
                + Options.CalcFieldSize m.Options
            Encode = fun (w: Google.Protobuf.CodedOutputStream) (m: ServiceDescriptorProto) ->
                Name.WriteField w m.Name
                Methods.WriteField w m.Methods
                Options.WriteField w m.Options
            Decode = fun (r: Google.Protobuf.CodedInputStream) ->
                let mutable builder = new Google.Protobuf.ServiceDescriptorProto.Builder()
                let mutable tag = 0
                while read r &tag do
                    builder.Put (tag, r)
                builder.Build
            EncodeJson = fun (o: JsonOptions) ->
                let writeName = Name.WriteJsonField o
                let writeMethods = Methods.WriteJsonField o
                let writeOptions = Options.WriteJsonField o
                let encode (w: System.Text.Json.Utf8JsonWriter) (m: ServiceDescriptorProto) =
                    writeName w m.Name
                    writeMethods w m.Methods
                    writeOptions w m.Options
                encode
            DecodeJson = fun (node: System.Text.Json.Nodes.JsonNode) ->
                let update value (kvPair: System.Collections.Generic.KeyValuePair<string,System.Text.Json.Nodes.JsonNode>) : ServiceDescriptorProto =
                    match kvPair.Key with
                    | "name" -> { value with Name = Name.ReadJsonField kvPair.Value }
                    | "methods" -> { value with Methods = Methods.ReadJsonField kvPair.Value }
                    | "options" -> { value with Options = Options.ReadJsonField kvPair.Value }
                    | _ -> value
                Seq.fold update _ServiceDescriptorProto.empty (node.AsObject ())
        }
    static member empty
        with get() = Google.Protobuf._ServiceDescriptorProto.Proto.Value.Empty

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module MethodDescriptorProto =

    [<System.Runtime.CompilerServices.IsByRefLike>]
    type Builder =
        struct
            val mutable Name: string // (1)
            val mutable InputType: string // (2)
            val mutable OutputType: string // (3)
            val mutable Options: OptionBuilder<Google.Protobuf.MethodOptions> // (4)
            val mutable ClientStreaming: bool // (5)
            val mutable ServerStreaming: bool // (6)
        end
        with
        member x.Put ((tag, reader): int * Reader) =
            match tag with
            | 1 -> x.Name <- ValueCodec.String.ReadValue reader
            | 2 -> x.InputType <- ValueCodec.String.ReadValue reader
            | 3 -> x.OutputType <- ValueCodec.String.ReadValue reader
            | 4 -> x.Options.Set (ValueCodec.Message<Google.Protobuf.MethodOptions>.ReadValue reader)
            | 5 -> x.ClientStreaming <- ValueCodec.Bool.ReadValue reader
            | 6 -> x.ServerStreaming <- ValueCodec.Bool.ReadValue reader
            | _ -> reader.SkipLastField()
        member x.Build : Google.Protobuf.MethodDescriptorProto = {
            Name = x.Name |> orEmptyString
            InputType = x.InputType |> orEmptyString
            OutputType = x.OutputType |> orEmptyString
            Options = x.Options.Build
            ClientStreaming = x.ClientStreaming
            ServerStreaming = x.ServerStreaming
            }

/// <summary>Describes a method of a service.</summary>
type private _MethodDescriptorProto = MethodDescriptorProto
[<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.MessageConverter>)>]
[<FsGrpc.Protobuf.Message>]
type MethodDescriptorProto = {
    // Field Declarations
    [<System.Text.Json.Serialization.JsonPropertyName("name")>] Name: string // (1)
    /// <summary>
    /// Input and output type names.  These are resolved in the same way as
    /// FieldDescriptorProto.type_name, but must refer to a message type.
    /// </summary>
    [<System.Text.Json.Serialization.JsonPropertyName("inputType")>] InputType: string // (2)
    [<System.Text.Json.Serialization.JsonPropertyName("outputType")>] OutputType: string // (3)
    [<System.Text.Json.Serialization.JsonPropertyName("options")>] Options: Google.Protobuf.MethodOptions option // (4)
    /// <summary>Identifies if client streams multiple client messages</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("clientStreaming")>] ClientStreaming: bool // (5)
    /// <summary>Identifies if server streams multiple server messages</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("serverStreaming")>] ServerStreaming: bool // (6)
    }
    with
    static member Proto : Lazy<ProtoDef<MethodDescriptorProto>> =
        lazy
        // Field Definitions
        let Name = FieldCodec.Primitive ValueCodec.String (1, "name")
        let InputType = FieldCodec.Primitive ValueCodec.String (2, "inputType")
        let OutputType = FieldCodec.Primitive ValueCodec.String (3, "outputType")
        let Options = FieldCodec.Optional ValueCodec.Message<Google.Protobuf.MethodOptions> (4, "options")
        let ClientStreaming = FieldCodec.Primitive ValueCodec.Bool (5, "clientStreaming")
        let ServerStreaming = FieldCodec.Primitive ValueCodec.Bool (6, "serverStreaming")
        // Proto Definition Implementation
        { // ProtoDef<MethodDescriptorProto>
            Name = "MethodDescriptorProto"
            Empty = {
                Name = Name.GetDefault()
                InputType = InputType.GetDefault()
                OutputType = OutputType.GetDefault()
                Options = Options.GetDefault()
                ClientStreaming = ClientStreaming.GetDefault()
                ServerStreaming = ServerStreaming.GetDefault()
                }
            Size = fun (m: MethodDescriptorProto) ->
                0
                + Name.CalcFieldSize m.Name
                + InputType.CalcFieldSize m.InputType
                + OutputType.CalcFieldSize m.OutputType
                + Options.CalcFieldSize m.Options
                + ClientStreaming.CalcFieldSize m.ClientStreaming
                + ServerStreaming.CalcFieldSize m.ServerStreaming
            Encode = fun (w: Google.Protobuf.CodedOutputStream) (m: MethodDescriptorProto) ->
                Name.WriteField w m.Name
                InputType.WriteField w m.InputType
                OutputType.WriteField w m.OutputType
                Options.WriteField w m.Options
                ClientStreaming.WriteField w m.ClientStreaming
                ServerStreaming.WriteField w m.ServerStreaming
            Decode = fun (r: Google.Protobuf.CodedInputStream) ->
                let mutable builder = new Google.Protobuf.MethodDescriptorProto.Builder()
                let mutable tag = 0
                while read r &tag do
                    builder.Put (tag, r)
                builder.Build
            EncodeJson = fun (o: JsonOptions) ->
                let writeName = Name.WriteJsonField o
                let writeInputType = InputType.WriteJsonField o
                let writeOutputType = OutputType.WriteJsonField o
                let writeOptions = Options.WriteJsonField o
                let writeClientStreaming = ClientStreaming.WriteJsonField o
                let writeServerStreaming = ServerStreaming.WriteJsonField o
                let encode (w: System.Text.Json.Utf8JsonWriter) (m: MethodDescriptorProto) =
                    writeName w m.Name
                    writeInputType w m.InputType
                    writeOutputType w m.OutputType
                    writeOptions w m.Options
                    writeClientStreaming w m.ClientStreaming
                    writeServerStreaming w m.ServerStreaming
                encode
            DecodeJson = fun (node: System.Text.Json.Nodes.JsonNode) ->
                let update value (kvPair: System.Collections.Generic.KeyValuePair<string,System.Text.Json.Nodes.JsonNode>) : MethodDescriptorProto =
                    match kvPair.Key with
                    | "name" -> { value with Name = Name.ReadJsonField kvPair.Value }
                    | "inputType" -> { value with InputType = InputType.ReadJsonField kvPair.Value }
                    | "outputType" -> { value with OutputType = OutputType.ReadJsonField kvPair.Value }
                    | "options" -> { value with Options = Options.ReadJsonField kvPair.Value }
                    | "clientStreaming" -> { value with ClientStreaming = ClientStreaming.ReadJsonField kvPair.Value }
                    | "serverStreaming" -> { value with ServerStreaming = ServerStreaming.ReadJsonField kvPair.Value }
                    | _ -> value
                Seq.fold update _MethodDescriptorProto.empty (node.AsObject ())
        }
    static member empty
        with get() = Google.Protobuf._MethodDescriptorProto.Proto.Value.Empty

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module FileOptions =

    /// <summary>Generated classes can be optimized for speed or code size.</summary>
    [<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.EnumConverter<OptimizeMode>>)>]
    type OptimizeMode =
    | [<FsGrpc.Protobuf.ProtobufName("UNSPECIFIED")>] Unspecified = 0
    | [<FsGrpc.Protobuf.ProtobufName("SPEED")>] Speed = 1
    /// <summary>etc.</summary>
    | [<FsGrpc.Protobuf.ProtobufName("CODE_SIZE")>] CodeSize = 2
    | [<FsGrpc.Protobuf.ProtobufName("LITE_RUNTIME")>] LiteRuntime = 3

    [<System.Runtime.CompilerServices.IsByRefLike>]
    type Builder =
        struct
            val mutable JavaPackage: string // (1)
            val mutable JavaOuterClassname: string // (8)
            val mutable JavaMultipleFiles: bool // (10)
            val mutable JavaGenerateEqualsAndHash: bool // (20)
            val mutable JavaStringCheckUtf8: bool // (27)
            val mutable OptimizeFor: Google.Protobuf.FileOptions.OptimizeMode // (9)
            val mutable GoPackage: string // (11)
            val mutable CcGenericServices: bool // (16)
            val mutable JavaGenericServices: bool // (17)
            val mutable PyGenericServices: bool // (18)
            val mutable PhpGenericServices: bool // (42)
            val mutable Deprecated: bool // (23)
            val mutable CcEnableArenas: bool // (31)
            val mutable ObjcClassPrefix: string // (36)
            val mutable CsharpNamespace: string // (37)
            val mutable SwiftPrefix: string // (39)
            val mutable PhpClassPrefix: string // (40)
            val mutable PhpNamespace: string // (41)
            val mutable PhpMetadataNamespace: string // (44)
            val mutable RubyPackage: string // (45)
            val mutable UninterpretedOptions: RepeatedBuilder<Google.Protobuf.UninterpretedOption> // (999)
        end
        with
        member x.Put ((tag, reader): int * Reader) =
            match tag with
            | 1 -> x.JavaPackage <- ValueCodec.String.ReadValue reader
            | 8 -> x.JavaOuterClassname <- ValueCodec.String.ReadValue reader
            | 10 -> x.JavaMultipleFiles <- ValueCodec.Bool.ReadValue reader
            | 20 -> x.JavaGenerateEqualsAndHash <- ValueCodec.Bool.ReadValue reader
            | 27 -> x.JavaStringCheckUtf8 <- ValueCodec.Bool.ReadValue reader
            | 9 -> x.OptimizeFor <- ValueCodec.Enum<Google.Protobuf.FileOptions.OptimizeMode>.ReadValue reader
            | 11 -> x.GoPackage <- ValueCodec.String.ReadValue reader
            | 16 -> x.CcGenericServices <- ValueCodec.Bool.ReadValue reader
            | 17 -> x.JavaGenericServices <- ValueCodec.Bool.ReadValue reader
            | 18 -> x.PyGenericServices <- ValueCodec.Bool.ReadValue reader
            | 42 -> x.PhpGenericServices <- ValueCodec.Bool.ReadValue reader
            | 23 -> x.Deprecated <- ValueCodec.Bool.ReadValue reader
            | 31 -> x.CcEnableArenas <- ValueCodec.Bool.ReadValue reader
            | 36 -> x.ObjcClassPrefix <- ValueCodec.String.ReadValue reader
            | 37 -> x.CsharpNamespace <- ValueCodec.String.ReadValue reader
            | 39 -> x.SwiftPrefix <- ValueCodec.String.ReadValue reader
            | 40 -> x.PhpClassPrefix <- ValueCodec.String.ReadValue reader
            | 41 -> x.PhpNamespace <- ValueCodec.String.ReadValue reader
            | 44 -> x.PhpMetadataNamespace <- ValueCodec.String.ReadValue reader
            | 45 -> x.RubyPackage <- ValueCodec.String.ReadValue reader
            | 999 -> x.UninterpretedOptions.Add (ValueCodec.Message<Google.Protobuf.UninterpretedOption>.ReadValue reader)
            | _ -> reader.SkipLastField()
        member x.Build : Google.Protobuf.FileOptions = {
            JavaPackage = x.JavaPackage |> orEmptyString
            JavaOuterClassname = x.JavaOuterClassname |> orEmptyString
            JavaMultipleFiles = x.JavaMultipleFiles
            JavaGenerateEqualsAndHash = x.JavaGenerateEqualsAndHash
            JavaStringCheckUtf8 = x.JavaStringCheckUtf8
            OptimizeFor = x.OptimizeFor
            GoPackage = x.GoPackage |> orEmptyString
            CcGenericServices = x.CcGenericServices
            JavaGenericServices = x.JavaGenericServices
            PyGenericServices = x.PyGenericServices
            PhpGenericServices = x.PhpGenericServices
            Deprecated = x.Deprecated
            CcEnableArenas = x.CcEnableArenas
            ObjcClassPrefix = x.ObjcClassPrefix |> orEmptyString
            CsharpNamespace = x.CsharpNamespace |> orEmptyString
            SwiftPrefix = x.SwiftPrefix |> orEmptyString
            PhpClassPrefix = x.PhpClassPrefix |> orEmptyString
            PhpNamespace = x.PhpNamespace |> orEmptyString
            PhpMetadataNamespace = x.PhpMetadataNamespace |> orEmptyString
            RubyPackage = x.RubyPackage |> orEmptyString
            UninterpretedOptions = x.UninterpretedOptions.Build
            }

type private _FileOptions = FileOptions
[<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.MessageConverter>)>]
[<FsGrpc.Protobuf.Message>]
type FileOptions = {
    // Field Declarations
    /// <summary>
    /// Sets the Java package where classes generated from this .proto will be
    /// placed.  By default, the proto package is used, but this is often
    /// inappropriate because proto packages do not normally start with backwards
    /// domain names.
    /// </summary>
    [<System.Text.Json.Serialization.JsonPropertyName("javaPackage")>] JavaPackage: string // (1)
    /// <summary>
    /// If set, all the classes from the .proto file are wrapped in a single
    /// outer class with the given name.  This applies to both Proto1
    /// (equivalent to the old "--one_java_file" option) and Proto2 (where
    /// a .proto always translates to a single class, but you may want to
    /// explicitly choose the class name).
    /// </summary>
    [<System.Text.Json.Serialization.JsonPropertyName("javaOuterClassname")>] JavaOuterClassname: string // (8)
    /// <summary>
    /// If set true, then the Java code generator will generate a separate .java
    /// file for each top-level message, enum, and service defined in the .proto
    /// file.  Thus, these types will *not* be nested inside the outer class
    /// named by java_outer_classname.  However, the outer class will still be
    /// generated to contain the file's getDescriptor() method as well as any
    /// top-level extensions defined in the file.
    /// </summary>
    [<System.Text.Json.Serialization.JsonPropertyName("javaMultipleFiles")>] JavaMultipleFiles: bool // (10)
    /// <summary>This option does nothing.</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("javaGenerateEqualsAndHash")>] JavaGenerateEqualsAndHash: bool // (20)
    /// <summary>
    /// If set true, then the Java2 code generator will generate code that
    /// throws an exception whenever an attempt is made to assign a non-UTF-8
    /// byte sequence to a string field.
    /// Message reflection will do the same.
    /// However, an extension field still accepts non-UTF-8 byte sequences.
    /// This option has no effect on when used with the lite runtime.
    /// </summary>
    [<System.Text.Json.Serialization.JsonPropertyName("javaStringCheckUtf8")>] JavaStringCheckUtf8: bool // (27)
    [<System.Text.Json.Serialization.JsonPropertyName("optimizeFor")>] OptimizeFor: Google.Protobuf.FileOptions.OptimizeMode // (9)
    /// <summary>
    /// Sets the Go package where structs generated from this .proto will be
    /// placed. If omitted, the Go package will be derived from the following:
    ///   - The basename of the package import path, if provided.
    ///   - Otherwise, the package statement in the .proto file, if present.
    ///   - Otherwise, the basename of the .proto file, without extension.
    /// </summary>
    [<System.Text.Json.Serialization.JsonPropertyName("goPackage")>] GoPackage: string // (11)
    /// <summary>
    /// Should generic services be generated in each language?  "Generic" services
    /// are not specific to any particular RPC system.  They are generated by the
    /// main code generators in each language (without additional plugins).
    /// Generic services were the only kind of service generation supported by
    /// early versions of google.protobuf.
    /// 
    /// Generic services are now considered deprecated in favor of using plugins
    /// that generate code specific to your particular RPC system.  Therefore,
    /// these default to false.  Old code which depends on generic services should
    /// explicitly set them to true.
    /// </summary>
    [<System.Text.Json.Serialization.JsonPropertyName("ccGenericServices")>] CcGenericServices: bool // (16)
    [<System.Text.Json.Serialization.JsonPropertyName("javaGenericServices")>] JavaGenericServices: bool // (17)
    [<System.Text.Json.Serialization.JsonPropertyName("pyGenericServices")>] PyGenericServices: bool // (18)
    [<System.Text.Json.Serialization.JsonPropertyName("phpGenericServices")>] PhpGenericServices: bool // (42)
    /// <summary>
    /// Is this file deprecated?
    /// Depending on the target platform, this can emit Deprecated annotations
    /// for everything in the file, or it will be completely ignored; in the very
    /// least, this is a formalization for deprecating files.
    /// </summary>
    [<System.Text.Json.Serialization.JsonPropertyName("deprecated")>] Deprecated: bool // (23)
    /// <summary>
    /// Enables the use of arenas for the proto messages in this file. This applies
    /// only to generated classes for C++.
    /// </summary>
    [<System.Text.Json.Serialization.JsonPropertyName("ccEnableArenas")>] CcEnableArenas: bool // (31)
    /// <summary>
    /// Sets the objective c class prefix which is prepended to all objective c
    /// generated classes from this .proto. There is no default.
    /// </summary>
    [<System.Text.Json.Serialization.JsonPropertyName("objcClassPrefix")>] ObjcClassPrefix: string // (36)
    /// <summary>Namespace for generated classes; defaults to the package.</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("csharpNamespace")>] CsharpNamespace: string // (37)
    /// <summary>
    /// By default Swift generators will take the proto package and CamelCase it
    /// replacing '.' with underscore and use that to prefix the types/symbols
    /// defined. When this options is provided, they will use this value instead
    /// to prefix the types/symbols defined.
    /// </summary>
    [<System.Text.Json.Serialization.JsonPropertyName("swiftPrefix")>] SwiftPrefix: string // (39)
    /// <summary>
    /// Sets the php class prefix which is prepended to all php generated classes
    /// from this .proto. Default is empty.
    /// </summary>
    [<System.Text.Json.Serialization.JsonPropertyName("phpClassPrefix")>] PhpClassPrefix: string // (40)
    /// <summary>
    /// Use this option to change the namespace of php generated classes. Default
    /// is empty. When this option is empty, the package name will be used for
    /// determining the namespace.
    /// </summary>
    [<System.Text.Json.Serialization.JsonPropertyName("phpNamespace")>] PhpNamespace: string // (41)
    /// <summary>
    /// Use this option to change the namespace of php generated metadata classes.
    /// Default is empty. When this option is empty, the proto file name will be
    /// used for determining the namespace.
    /// </summary>
    [<System.Text.Json.Serialization.JsonPropertyName("phpMetadataNamespace")>] PhpMetadataNamespace: string // (44)
    /// <summary>
    /// Use this option to change the package of ruby generated classes. Default
    /// is empty. When this option is not set, the package name will be used for
    /// determining the ruby package.
    /// </summary>
    [<System.Text.Json.Serialization.JsonPropertyName("rubyPackage")>] RubyPackage: string // (45)
    /// <summary>
    /// The parser stores options it doesn't recognize here.
    /// See the documentation for the "Options" section above.
    /// </summary>
    [<System.Text.Json.Serialization.JsonPropertyName("uninterpretedOptions")>] UninterpretedOptions: Google.Protobuf.UninterpretedOption list // (999)
    }
    with
    static member Proto : Lazy<ProtoDef<FileOptions>> =
        lazy
        // Field Definitions
        let JavaPackage = FieldCodec.Primitive ValueCodec.String (1, "javaPackage")
        let JavaOuterClassname = FieldCodec.Primitive ValueCodec.String (8, "javaOuterClassname")
        let JavaMultipleFiles = FieldCodec.Primitive ValueCodec.Bool (10, "javaMultipleFiles")
        let JavaGenerateEqualsAndHash = FieldCodec.Primitive ValueCodec.Bool (20, "javaGenerateEqualsAndHash")
        let JavaStringCheckUtf8 = FieldCodec.Primitive ValueCodec.Bool (27, "javaStringCheckUtf8")
        let OptimizeFor = FieldCodec.Primitive ValueCodec.Enum<Google.Protobuf.FileOptions.OptimizeMode> (9, "optimizeFor")
        let GoPackage = FieldCodec.Primitive ValueCodec.String (11, "goPackage")
        let CcGenericServices = FieldCodec.Primitive ValueCodec.Bool (16, "ccGenericServices")
        let JavaGenericServices = FieldCodec.Primitive ValueCodec.Bool (17, "javaGenericServices")
        let PyGenericServices = FieldCodec.Primitive ValueCodec.Bool (18, "pyGenericServices")
        let PhpGenericServices = FieldCodec.Primitive ValueCodec.Bool (42, "phpGenericServices")
        let Deprecated = FieldCodec.Primitive ValueCodec.Bool (23, "deprecated")
        let CcEnableArenas = FieldCodec.Primitive ValueCodec.Bool (31, "ccEnableArenas")
        let ObjcClassPrefix = FieldCodec.Primitive ValueCodec.String (36, "objcClassPrefix")
        let CsharpNamespace = FieldCodec.Primitive ValueCodec.String (37, "csharpNamespace")
        let SwiftPrefix = FieldCodec.Primitive ValueCodec.String (39, "swiftPrefix")
        let PhpClassPrefix = FieldCodec.Primitive ValueCodec.String (40, "phpClassPrefix")
        let PhpNamespace = FieldCodec.Primitive ValueCodec.String (41, "phpNamespace")
        let PhpMetadataNamespace = FieldCodec.Primitive ValueCodec.String (44, "phpMetadataNamespace")
        let RubyPackage = FieldCodec.Primitive ValueCodec.String (45, "rubyPackage")
        let UninterpretedOptions = FieldCodec.Repeated ValueCodec.Message<Google.Protobuf.UninterpretedOption> (999, "uninterpretedOptions")
        // Proto Definition Implementation
        { // ProtoDef<FileOptions>
            Name = "FileOptions"
            Empty = {
                JavaPackage = JavaPackage.GetDefault()
                JavaOuterClassname = JavaOuterClassname.GetDefault()
                JavaMultipleFiles = JavaMultipleFiles.GetDefault()
                JavaGenerateEqualsAndHash = JavaGenerateEqualsAndHash.GetDefault()
                JavaStringCheckUtf8 = JavaStringCheckUtf8.GetDefault()
                OptimizeFor = OptimizeFor.GetDefault()
                GoPackage = GoPackage.GetDefault()
                CcGenericServices = CcGenericServices.GetDefault()
                JavaGenericServices = JavaGenericServices.GetDefault()
                PyGenericServices = PyGenericServices.GetDefault()
                PhpGenericServices = PhpGenericServices.GetDefault()
                Deprecated = Deprecated.GetDefault()
                CcEnableArenas = CcEnableArenas.GetDefault()
                ObjcClassPrefix = ObjcClassPrefix.GetDefault()
                CsharpNamespace = CsharpNamespace.GetDefault()
                SwiftPrefix = SwiftPrefix.GetDefault()
                PhpClassPrefix = PhpClassPrefix.GetDefault()
                PhpNamespace = PhpNamespace.GetDefault()
                PhpMetadataNamespace = PhpMetadataNamespace.GetDefault()
                RubyPackage = RubyPackage.GetDefault()
                UninterpretedOptions = UninterpretedOptions.GetDefault()
                }
            Size = fun (m: FileOptions) ->
                0
                + JavaPackage.CalcFieldSize m.JavaPackage
                + JavaOuterClassname.CalcFieldSize m.JavaOuterClassname
                + JavaMultipleFiles.CalcFieldSize m.JavaMultipleFiles
                + JavaGenerateEqualsAndHash.CalcFieldSize m.JavaGenerateEqualsAndHash
                + JavaStringCheckUtf8.CalcFieldSize m.JavaStringCheckUtf8
                + OptimizeFor.CalcFieldSize m.OptimizeFor
                + GoPackage.CalcFieldSize m.GoPackage
                + CcGenericServices.CalcFieldSize m.CcGenericServices
                + JavaGenericServices.CalcFieldSize m.JavaGenericServices
                + PyGenericServices.CalcFieldSize m.PyGenericServices
                + PhpGenericServices.CalcFieldSize m.PhpGenericServices
                + Deprecated.CalcFieldSize m.Deprecated
                + CcEnableArenas.CalcFieldSize m.CcEnableArenas
                + ObjcClassPrefix.CalcFieldSize m.ObjcClassPrefix
                + CsharpNamespace.CalcFieldSize m.CsharpNamespace
                + SwiftPrefix.CalcFieldSize m.SwiftPrefix
                + PhpClassPrefix.CalcFieldSize m.PhpClassPrefix
                + PhpNamespace.CalcFieldSize m.PhpNamespace
                + PhpMetadataNamespace.CalcFieldSize m.PhpMetadataNamespace
                + RubyPackage.CalcFieldSize m.RubyPackage
                + UninterpretedOptions.CalcFieldSize m.UninterpretedOptions
            Encode = fun (w: Google.Protobuf.CodedOutputStream) (m: FileOptions) ->
                JavaPackage.WriteField w m.JavaPackage
                JavaOuterClassname.WriteField w m.JavaOuterClassname
                JavaMultipleFiles.WriteField w m.JavaMultipleFiles
                JavaGenerateEqualsAndHash.WriteField w m.JavaGenerateEqualsAndHash
                JavaStringCheckUtf8.WriteField w m.JavaStringCheckUtf8
                OptimizeFor.WriteField w m.OptimizeFor
                GoPackage.WriteField w m.GoPackage
                CcGenericServices.WriteField w m.CcGenericServices
                JavaGenericServices.WriteField w m.JavaGenericServices
                PyGenericServices.WriteField w m.PyGenericServices
                PhpGenericServices.WriteField w m.PhpGenericServices
                Deprecated.WriteField w m.Deprecated
                CcEnableArenas.WriteField w m.CcEnableArenas
                ObjcClassPrefix.WriteField w m.ObjcClassPrefix
                CsharpNamespace.WriteField w m.CsharpNamespace
                SwiftPrefix.WriteField w m.SwiftPrefix
                PhpClassPrefix.WriteField w m.PhpClassPrefix
                PhpNamespace.WriteField w m.PhpNamespace
                PhpMetadataNamespace.WriteField w m.PhpMetadataNamespace
                RubyPackage.WriteField w m.RubyPackage
                UninterpretedOptions.WriteField w m.UninterpretedOptions
            Decode = fun (r: Google.Protobuf.CodedInputStream) ->
                let mutable builder = new Google.Protobuf.FileOptions.Builder()
                let mutable tag = 0
                while read r &tag do
                    builder.Put (tag, r)
                builder.Build
            EncodeJson = fun (o: JsonOptions) ->
                let writeJavaPackage = JavaPackage.WriteJsonField o
                let writeJavaOuterClassname = JavaOuterClassname.WriteJsonField o
                let writeJavaMultipleFiles = JavaMultipleFiles.WriteJsonField o
                let writeJavaGenerateEqualsAndHash = JavaGenerateEqualsAndHash.WriteJsonField o
                let writeJavaStringCheckUtf8 = JavaStringCheckUtf8.WriteJsonField o
                let writeOptimizeFor = OptimizeFor.WriteJsonField o
                let writeGoPackage = GoPackage.WriteJsonField o
                let writeCcGenericServices = CcGenericServices.WriteJsonField o
                let writeJavaGenericServices = JavaGenericServices.WriteJsonField o
                let writePyGenericServices = PyGenericServices.WriteJsonField o
                let writePhpGenericServices = PhpGenericServices.WriteJsonField o
                let writeDeprecated = Deprecated.WriteJsonField o
                let writeCcEnableArenas = CcEnableArenas.WriteJsonField o
                let writeObjcClassPrefix = ObjcClassPrefix.WriteJsonField o
                let writeCsharpNamespace = CsharpNamespace.WriteJsonField o
                let writeSwiftPrefix = SwiftPrefix.WriteJsonField o
                let writePhpClassPrefix = PhpClassPrefix.WriteJsonField o
                let writePhpNamespace = PhpNamespace.WriteJsonField o
                let writePhpMetadataNamespace = PhpMetadataNamespace.WriteJsonField o
                let writeRubyPackage = RubyPackage.WriteJsonField o
                let writeUninterpretedOptions = UninterpretedOptions.WriteJsonField o
                let encode (w: System.Text.Json.Utf8JsonWriter) (m: FileOptions) =
                    writeJavaPackage w m.JavaPackage
                    writeJavaOuterClassname w m.JavaOuterClassname
                    writeJavaMultipleFiles w m.JavaMultipleFiles
                    writeJavaGenerateEqualsAndHash w m.JavaGenerateEqualsAndHash
                    writeJavaStringCheckUtf8 w m.JavaStringCheckUtf8
                    writeOptimizeFor w m.OptimizeFor
                    writeGoPackage w m.GoPackage
                    writeCcGenericServices w m.CcGenericServices
                    writeJavaGenericServices w m.JavaGenericServices
                    writePyGenericServices w m.PyGenericServices
                    writePhpGenericServices w m.PhpGenericServices
                    writeDeprecated w m.Deprecated
                    writeCcEnableArenas w m.CcEnableArenas
                    writeObjcClassPrefix w m.ObjcClassPrefix
                    writeCsharpNamespace w m.CsharpNamespace
                    writeSwiftPrefix w m.SwiftPrefix
                    writePhpClassPrefix w m.PhpClassPrefix
                    writePhpNamespace w m.PhpNamespace
                    writePhpMetadataNamespace w m.PhpMetadataNamespace
                    writeRubyPackage w m.RubyPackage
                    writeUninterpretedOptions w m.UninterpretedOptions
                encode
            DecodeJson = fun (node: System.Text.Json.Nodes.JsonNode) ->
                let update value (kvPair: System.Collections.Generic.KeyValuePair<string,System.Text.Json.Nodes.JsonNode>) : FileOptions =
                    match kvPair.Key with
                    | "javaPackage" -> { value with JavaPackage = JavaPackage.ReadJsonField kvPair.Value }
                    | "javaOuterClassname" -> { value with JavaOuterClassname = JavaOuterClassname.ReadJsonField kvPair.Value }
                    | "javaMultipleFiles" -> { value with JavaMultipleFiles = JavaMultipleFiles.ReadJsonField kvPair.Value }
                    | "javaGenerateEqualsAndHash" -> { value with JavaGenerateEqualsAndHash = JavaGenerateEqualsAndHash.ReadJsonField kvPair.Value }
                    | "javaStringCheckUtf8" -> { value with JavaStringCheckUtf8 = JavaStringCheckUtf8.ReadJsonField kvPair.Value }
                    | "optimizeFor" -> { value with OptimizeFor = OptimizeFor.ReadJsonField kvPair.Value }
                    | "goPackage" -> { value with GoPackage = GoPackage.ReadJsonField kvPair.Value }
                    | "ccGenericServices" -> { value with CcGenericServices = CcGenericServices.ReadJsonField kvPair.Value }
                    | "javaGenericServices" -> { value with JavaGenericServices = JavaGenericServices.ReadJsonField kvPair.Value }
                    | "pyGenericServices" -> { value with PyGenericServices = PyGenericServices.ReadJsonField kvPair.Value }
                    | "phpGenericServices" -> { value with PhpGenericServices = PhpGenericServices.ReadJsonField kvPair.Value }
                    | "deprecated" -> { value with Deprecated = Deprecated.ReadJsonField kvPair.Value }
                    | "ccEnableArenas" -> { value with CcEnableArenas = CcEnableArenas.ReadJsonField kvPair.Value }
                    | "objcClassPrefix" -> { value with ObjcClassPrefix = ObjcClassPrefix.ReadJsonField kvPair.Value }
                    | "csharpNamespace" -> { value with CsharpNamespace = CsharpNamespace.ReadJsonField kvPair.Value }
                    | "swiftPrefix" -> { value with SwiftPrefix = SwiftPrefix.ReadJsonField kvPair.Value }
                    | "phpClassPrefix" -> { value with PhpClassPrefix = PhpClassPrefix.ReadJsonField kvPair.Value }
                    | "phpNamespace" -> { value with PhpNamespace = PhpNamespace.ReadJsonField kvPair.Value }
                    | "phpMetadataNamespace" -> { value with PhpMetadataNamespace = PhpMetadataNamespace.ReadJsonField kvPair.Value }
                    | "rubyPackage" -> { value with RubyPackage = RubyPackage.ReadJsonField kvPair.Value }
                    | "uninterpretedOptions" -> { value with UninterpretedOptions = UninterpretedOptions.ReadJsonField kvPair.Value }
                    | _ -> value
                Seq.fold update _FileOptions.empty (node.AsObject ())
        }
    static member empty
        with get() = Google.Protobuf._FileOptions.Proto.Value.Empty

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module MessageOptions =

    [<System.Runtime.CompilerServices.IsByRefLike>]
    type Builder =
        struct
            val mutable MessageSetWireFormat: bool // (1)
            val mutable NoStandardDescriptorAccessor: bool // (2)
            val mutable Deprecated: bool // (3)
            val mutable MapEntry: bool // (7)
            val mutable UninterpretedOptions: RepeatedBuilder<Google.Protobuf.UninterpretedOption> // (999)
        end
        with
        member x.Put ((tag, reader): int * Reader) =
            match tag with
            | 1 -> x.MessageSetWireFormat <- ValueCodec.Bool.ReadValue reader
            | 2 -> x.NoStandardDescriptorAccessor <- ValueCodec.Bool.ReadValue reader
            | 3 -> x.Deprecated <- ValueCodec.Bool.ReadValue reader
            | 7 -> x.MapEntry <- ValueCodec.Bool.ReadValue reader
            | 999 -> x.UninterpretedOptions.Add (ValueCodec.Message<Google.Protobuf.UninterpretedOption>.ReadValue reader)
            | _ -> reader.SkipLastField()
        member x.Build : Google.Protobuf.MessageOptions = {
            MessageSetWireFormat = x.MessageSetWireFormat
            NoStandardDescriptorAccessor = x.NoStandardDescriptorAccessor
            Deprecated = x.Deprecated
            MapEntry = x.MapEntry
            UninterpretedOptions = x.UninterpretedOptions.Build
            }

type private _MessageOptions = MessageOptions
[<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.MessageConverter>)>]
[<FsGrpc.Protobuf.Message>]
type MessageOptions = {
    // Field Declarations
    /// <summary>
    /// Set true to use the old proto1 MessageSet wire format for extensions.
    /// This is provided for backwards-compatibility with the MessageSet wire
    /// format.  You should not use this for any other reason:  It's less
    /// efficient, has fewer features, and is more complicated.
    /// 
    /// The message must be defined exactly as follows:
    ///   message Foo {
    ///     option message_set_wire_format = true;
    ///     extensions 4 to max;
    ///   }
    /// Note that the message cannot have any defined fields; MessageSets only
    /// have extensions.
    /// 
    /// All extensions of your type must be singular messages; e.g. they cannot
    /// be int32s, enums, or repeated messages.
    /// 
    /// Because this is an option, the above two restrictions are not enforced by
    /// the protocol compiler.
    /// </summary>
    [<System.Text.Json.Serialization.JsonPropertyName("messageSetWireFormat")>] MessageSetWireFormat: bool // (1)
    /// <summary>
    /// Disables the generation of the standard "descriptor()" accessor, which can
    /// conflict with a field of the same name.  This is meant to make migration
    /// from proto1 easier; new code should avoid fields named "descriptor".
    /// </summary>
    [<System.Text.Json.Serialization.JsonPropertyName("noStandardDescriptorAccessor")>] NoStandardDescriptorAccessor: bool // (2)
    /// <summary>
    /// Is this message deprecated?
    /// Depending on the target platform, this can emit Deprecated annotations
    /// for the message, or it will be completely ignored; in the very least,
    /// this is a formalization for deprecating messages.
    /// </summary>
    [<System.Text.Json.Serialization.JsonPropertyName("deprecated")>] Deprecated: bool // (3)
    /// <summary>
    /// Whether the message is an automatically generated map entry type for the
    /// maps field.
    /// 
    /// For maps fields:
    ///     map<KeyType, ValueType> map_field = 1;
    /// The parsed descriptor looks like:
    ///     message MapFieldEntry {
    ///         option map_entry = true;
    ///         KeyType key = 1;
    ///         ValueType value = 2;
    ///     }
    ///     repeated MapFieldEntry map_field = 1;
    /// 
    /// Implementations may choose not to generate the map_entry=true message, but
    /// use a native map in the target language to hold the keys and values.
    /// The reflection APIs in such implementations still need to work as
    /// if the field is a repeated message field.
    /// 
    /// NOTE: Do not set the option in .proto files. Always use the maps syntax
    /// instead. The option should only be implicitly set by the proto compiler
    /// parser.
    /// </summary>
    [<System.Text.Json.Serialization.JsonPropertyName("mapEntry")>] MapEntry: bool // (7)
    /// <summary>The parser stores options it doesn't recognize here. See above.</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("uninterpretedOptions")>] UninterpretedOptions: Google.Protobuf.UninterpretedOption list // (999)
    }
    with
    static member Proto : Lazy<ProtoDef<MessageOptions>> =
        lazy
        // Field Definitions
        let MessageSetWireFormat = FieldCodec.Primitive ValueCodec.Bool (1, "messageSetWireFormat")
        let NoStandardDescriptorAccessor = FieldCodec.Primitive ValueCodec.Bool (2, "noStandardDescriptorAccessor")
        let Deprecated = FieldCodec.Primitive ValueCodec.Bool (3, "deprecated")
        let MapEntry = FieldCodec.Primitive ValueCodec.Bool (7, "mapEntry")
        let UninterpretedOptions = FieldCodec.Repeated ValueCodec.Message<Google.Protobuf.UninterpretedOption> (999, "uninterpretedOptions")
        // Proto Definition Implementation
        { // ProtoDef<MessageOptions>
            Name = "MessageOptions"
            Empty = {
                MessageSetWireFormat = MessageSetWireFormat.GetDefault()
                NoStandardDescriptorAccessor = NoStandardDescriptorAccessor.GetDefault()
                Deprecated = Deprecated.GetDefault()
                MapEntry = MapEntry.GetDefault()
                UninterpretedOptions = UninterpretedOptions.GetDefault()
                }
            Size = fun (m: MessageOptions) ->
                0
                + MessageSetWireFormat.CalcFieldSize m.MessageSetWireFormat
                + NoStandardDescriptorAccessor.CalcFieldSize m.NoStandardDescriptorAccessor
                + Deprecated.CalcFieldSize m.Deprecated
                + MapEntry.CalcFieldSize m.MapEntry
                + UninterpretedOptions.CalcFieldSize m.UninterpretedOptions
            Encode = fun (w: Google.Protobuf.CodedOutputStream) (m: MessageOptions) ->
                MessageSetWireFormat.WriteField w m.MessageSetWireFormat
                NoStandardDescriptorAccessor.WriteField w m.NoStandardDescriptorAccessor
                Deprecated.WriteField w m.Deprecated
                MapEntry.WriteField w m.MapEntry
                UninterpretedOptions.WriteField w m.UninterpretedOptions
            Decode = fun (r: Google.Protobuf.CodedInputStream) ->
                let mutable builder = new Google.Protobuf.MessageOptions.Builder()
                let mutable tag = 0
                while read r &tag do
                    builder.Put (tag, r)
                builder.Build
            EncodeJson = fun (o: JsonOptions) ->
                let writeMessageSetWireFormat = MessageSetWireFormat.WriteJsonField o
                let writeNoStandardDescriptorAccessor = NoStandardDescriptorAccessor.WriteJsonField o
                let writeDeprecated = Deprecated.WriteJsonField o
                let writeMapEntry = MapEntry.WriteJsonField o
                let writeUninterpretedOptions = UninterpretedOptions.WriteJsonField o
                let encode (w: System.Text.Json.Utf8JsonWriter) (m: MessageOptions) =
                    writeMessageSetWireFormat w m.MessageSetWireFormat
                    writeNoStandardDescriptorAccessor w m.NoStandardDescriptorAccessor
                    writeDeprecated w m.Deprecated
                    writeMapEntry w m.MapEntry
                    writeUninterpretedOptions w m.UninterpretedOptions
                encode
            DecodeJson = fun (node: System.Text.Json.Nodes.JsonNode) ->
                let update value (kvPair: System.Collections.Generic.KeyValuePair<string,System.Text.Json.Nodes.JsonNode>) : MessageOptions =
                    match kvPair.Key with
                    | "messageSetWireFormat" -> { value with MessageSetWireFormat = MessageSetWireFormat.ReadJsonField kvPair.Value }
                    | "noStandardDescriptorAccessor" -> { value with NoStandardDescriptorAccessor = NoStandardDescriptorAccessor.ReadJsonField kvPair.Value }
                    | "deprecated" -> { value with Deprecated = Deprecated.ReadJsonField kvPair.Value }
                    | "mapEntry" -> { value with MapEntry = MapEntry.ReadJsonField kvPair.Value }
                    | "uninterpretedOptions" -> { value with UninterpretedOptions = UninterpretedOptions.ReadJsonField kvPair.Value }
                    | _ -> value
                Seq.fold update _MessageOptions.empty (node.AsObject ())
        }
    static member empty
        with get() = Google.Protobuf._MessageOptions.Proto.Value.Empty

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module FieldOptions =

    [<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.EnumConverter<CType>>)>]
    type CType =
    /// <summary>Default mode.</summary>
    | [<FsGrpc.Protobuf.ProtobufName("STRING")>] String = 0
    | [<FsGrpc.Protobuf.ProtobufName("CORD")>] Cord = 1
    | [<FsGrpc.Protobuf.ProtobufName("STRING_PIECE")>] StringPiece = 2

    [<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.EnumConverter<JSType>>)>]
    type JSType =
    /// <summary>Use the default type.</summary>
    | [<FsGrpc.Protobuf.ProtobufName("JS_NORMAL")>] JsNormal = 0
    /// <summary>Use JavaScript strings.</summary>
    | [<FsGrpc.Protobuf.ProtobufName("JS_STRING")>] JsString = 1
    /// <summary>Use JavaScript numbers.</summary>
    | [<FsGrpc.Protobuf.ProtobufName("JS_NUMBER")>] JsNumber = 2

    [<System.Runtime.CompilerServices.IsByRefLike>]
    type Builder =
        struct
            val mutable Ctype: Google.Protobuf.FieldOptions.CType // (1)
            val mutable Packed: bool // (2)
            val mutable Jstype: Google.Protobuf.FieldOptions.JSType // (6)
            val mutable Lazy: bool // (5)
            val mutable Deprecated: bool // (3)
            val mutable Weak: bool // (10)
            val mutable UninterpretedOptions: RepeatedBuilder<Google.Protobuf.UninterpretedOption> // (999)
        end
        with
        member x.Put ((tag, reader): int * Reader) =
            match tag with
            | 1 -> x.Ctype <- ValueCodec.Enum<Google.Protobuf.FieldOptions.CType>.ReadValue reader
            | 2 -> x.Packed <- ValueCodec.Bool.ReadValue reader
            | 6 -> x.Jstype <- ValueCodec.Enum<Google.Protobuf.FieldOptions.JSType>.ReadValue reader
            | 5 -> x.Lazy <- ValueCodec.Bool.ReadValue reader
            | 3 -> x.Deprecated <- ValueCodec.Bool.ReadValue reader
            | 10 -> x.Weak <- ValueCodec.Bool.ReadValue reader
            | 999 -> x.UninterpretedOptions.Add (ValueCodec.Message<Google.Protobuf.UninterpretedOption>.ReadValue reader)
            | _ -> reader.SkipLastField()
        member x.Build : Google.Protobuf.FieldOptions = {
            Ctype = x.Ctype
            Packed = x.Packed
            Jstype = x.Jstype
            Lazy = x.Lazy
            Deprecated = x.Deprecated
            Weak = x.Weak
            UninterpretedOptions = x.UninterpretedOptions.Build
            }

type private _FieldOptions = FieldOptions
[<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.MessageConverter>)>]
[<FsGrpc.Protobuf.Message>]
type FieldOptions = {
    // Field Declarations
    /// <summary>
    /// The ctype option instructs the C++ code generator to use a different
    /// representation of the field than it normally would.  See the specific
    /// options below.  This option is not yet implemented in the open source
    /// release -- sorry, we'll try to include it in a future version!
    /// </summary>
    [<System.Text.Json.Serialization.JsonPropertyName("ctype")>] Ctype: Google.Protobuf.FieldOptions.CType // (1)
    /// <summary>
    /// The packed option can be enabled for repeated primitive fields to enable
    /// a more efficient representation on the wire. Rather than repeatedly
    /// writing the tag and type for each element, the entire array is encoded as
    /// a single length-delimited blob. In proto3, only explicit setting it to
    /// false will avoid using packed encoding.
    /// </summary>
    [<System.Text.Json.Serialization.JsonPropertyName("packed")>] Packed: bool // (2)
    /// <summary>
    /// The jstype option determines the JavaScript type used for values of the
    /// field.  The option is permitted only for 64 bit integral and fixed types
    /// (int64, uint64, sint64, fixed64, sfixed64).  A field with jstype JS_STRING
    /// is represented as JavaScript string, which avoids loss of precision that
    /// can happen when a large value is converted to a floating point JavaScript.
    /// Specifying JS_NUMBER for the jstype causes the generated JavaScript code to
    /// use the JavaScript "number" type.  The behavior of the default option
    /// JS_NORMAL is implementation dependent.
    /// 
    /// This option is an enum to permit additional types to be added, e.g.
    /// goog.math.Integer.
    /// </summary>
    [<System.Text.Json.Serialization.JsonPropertyName("jstype")>] Jstype: Google.Protobuf.FieldOptions.JSType // (6)
    /// <summary>
    /// Should this field be parsed lazily?  Lazy applies only to message-type
    /// fields.  It means that when the outer message is initially parsed, the
    /// inner message's contents will not be parsed but instead stored in encoded
    /// form.  The inner message will actually be parsed when it is first accessed.
    /// 
    /// This is only a hint.  Implementations are free to choose whether to use
    /// eager or lazy parsing regardless of the value of this option.  However,
    /// setting this option true suggests that the protocol author believes that
    /// using lazy parsing on this field is worth the additional bookkeeping
    /// overhead typically needed to implement it.
    /// 
    /// This option does not affect the public interface of any generated code;
    /// all method signatures remain the same.  Furthermore, thread-safety of the
    /// interface is not affected by this option; const methods remain safe to
    /// call from multiple threads concurrently, while non-const methods continue
    /// to require exclusive access.
    /// 
    /// 
    /// Note that implementations may choose not to check required fields within
    /// a lazy sub-message.  That is, calling IsInitialized() on the outer message
    /// may return true even if the inner message has missing required fields.
    /// This is necessary because otherwise the inner message would have to be
    /// parsed in order to perform the check, defeating the purpose of lazy
    /// parsing.  An implementation which chooses not to check required fields
    /// must be consistent about it.  That is, for any particular sub-message, the
    /// implementation must either *always* check its required fields, or *never*
    /// check its required fields, regardless of whether or not the message has
    /// been parsed.
    /// </summary>
    [<System.Text.Json.Serialization.JsonPropertyName("lazy")>] Lazy: bool // (5)
    /// <summary>
    /// Is this field deprecated?
    /// Depending on the target platform, this can emit Deprecated annotations
    /// for accessors, or it will be completely ignored; in the very least, this
    /// is a formalization for deprecating fields.
    /// </summary>
    [<System.Text.Json.Serialization.JsonPropertyName("deprecated")>] Deprecated: bool // (3)
    /// <summary>For Google-internal migration only. Do not use.</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("weak")>] Weak: bool // (10)
    /// <summary>The parser stores options it doesn't recognize here. See above.</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("uninterpretedOptions")>] UninterpretedOptions: Google.Protobuf.UninterpretedOption list // (999)
    }
    with
    static member Proto : Lazy<ProtoDef<FieldOptions>> =
        lazy
        // Field Definitions
        let Ctype = FieldCodec.Primitive ValueCodec.Enum<Google.Protobuf.FieldOptions.CType> (1, "ctype")
        let Packed = FieldCodec.Primitive ValueCodec.Bool (2, "packed")
        let Jstype = FieldCodec.Primitive ValueCodec.Enum<Google.Protobuf.FieldOptions.JSType> (6, "jstype")
        let Lazy = FieldCodec.Primitive ValueCodec.Bool (5, "lazy")
        let Deprecated = FieldCodec.Primitive ValueCodec.Bool (3, "deprecated")
        let Weak = FieldCodec.Primitive ValueCodec.Bool (10, "weak")
        let UninterpretedOptions = FieldCodec.Repeated ValueCodec.Message<Google.Protobuf.UninterpretedOption> (999, "uninterpretedOptions")
        // Proto Definition Implementation
        { // ProtoDef<FieldOptions>
            Name = "FieldOptions"
            Empty = {
                Ctype = Ctype.GetDefault()
                Packed = Packed.GetDefault()
                Jstype = Jstype.GetDefault()
                Lazy = Lazy.GetDefault()
                Deprecated = Deprecated.GetDefault()
                Weak = Weak.GetDefault()
                UninterpretedOptions = UninterpretedOptions.GetDefault()
                }
            Size = fun (m: FieldOptions) ->
                0
                + Ctype.CalcFieldSize m.Ctype
                + Packed.CalcFieldSize m.Packed
                + Jstype.CalcFieldSize m.Jstype
                + Lazy.CalcFieldSize m.Lazy
                + Deprecated.CalcFieldSize m.Deprecated
                + Weak.CalcFieldSize m.Weak
                + UninterpretedOptions.CalcFieldSize m.UninterpretedOptions
            Encode = fun (w: Google.Protobuf.CodedOutputStream) (m: FieldOptions) ->
                Ctype.WriteField w m.Ctype
                Packed.WriteField w m.Packed
                Jstype.WriteField w m.Jstype
                Lazy.WriteField w m.Lazy
                Deprecated.WriteField w m.Deprecated
                Weak.WriteField w m.Weak
                UninterpretedOptions.WriteField w m.UninterpretedOptions
            Decode = fun (r: Google.Protobuf.CodedInputStream) ->
                let mutable builder = new Google.Protobuf.FieldOptions.Builder()
                let mutable tag = 0
                while read r &tag do
                    builder.Put (tag, r)
                builder.Build
            EncodeJson = fun (o: JsonOptions) ->
                let writeCtype = Ctype.WriteJsonField o
                let writePacked = Packed.WriteJsonField o
                let writeJstype = Jstype.WriteJsonField o
                let writeLazy = Lazy.WriteJsonField o
                let writeDeprecated = Deprecated.WriteJsonField o
                let writeWeak = Weak.WriteJsonField o
                let writeUninterpretedOptions = UninterpretedOptions.WriteJsonField o
                let encode (w: System.Text.Json.Utf8JsonWriter) (m: FieldOptions) =
                    writeCtype w m.Ctype
                    writePacked w m.Packed
                    writeJstype w m.Jstype
                    writeLazy w m.Lazy
                    writeDeprecated w m.Deprecated
                    writeWeak w m.Weak
                    writeUninterpretedOptions w m.UninterpretedOptions
                encode
            DecodeJson = fun (node: System.Text.Json.Nodes.JsonNode) ->
                let update value (kvPair: System.Collections.Generic.KeyValuePair<string,System.Text.Json.Nodes.JsonNode>) : FieldOptions =
                    match kvPair.Key with
                    | "ctype" -> { value with Ctype = Ctype.ReadJsonField kvPair.Value }
                    | "packed" -> { value with Packed = Packed.ReadJsonField kvPair.Value }
                    | "jstype" -> { value with Jstype = Jstype.ReadJsonField kvPair.Value }
                    | "lazy" -> { value with Lazy = Lazy.ReadJsonField kvPair.Value }
                    | "deprecated" -> { value with Deprecated = Deprecated.ReadJsonField kvPair.Value }
                    | "weak" -> { value with Weak = Weak.ReadJsonField kvPair.Value }
                    | "uninterpretedOptions" -> { value with UninterpretedOptions = UninterpretedOptions.ReadJsonField kvPair.Value }
                    | _ -> value
                Seq.fold update _FieldOptions.empty (node.AsObject ())
        }
    static member empty
        with get() = Google.Protobuf._FieldOptions.Proto.Value.Empty

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module OneofOptions =

    [<System.Runtime.CompilerServices.IsByRefLike>]
    type Builder =
        struct
            val mutable UninterpretedOptions: RepeatedBuilder<Google.Protobuf.UninterpretedOption> // (999)
        end
        with
        member x.Put ((tag, reader): int * Reader) =
            match tag with
            | 999 -> x.UninterpretedOptions.Add (ValueCodec.Message<Google.Protobuf.UninterpretedOption>.ReadValue reader)
            | _ -> reader.SkipLastField()
        member x.Build : Google.Protobuf.OneofOptions = {
            UninterpretedOptions = x.UninterpretedOptions.Build
            }

type private _OneofOptions = OneofOptions
[<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.MessageConverter>)>]
[<FsGrpc.Protobuf.Message>]
type OneofOptions = {
    // Field Declarations
    /// <summary>The parser stores options it doesn't recognize here. See above.</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("uninterpretedOptions")>] UninterpretedOptions: Google.Protobuf.UninterpretedOption list // (999)
    }
    with
    static member Proto : Lazy<ProtoDef<OneofOptions>> =
        lazy
        // Field Definitions
        let UninterpretedOptions = FieldCodec.Repeated ValueCodec.Message<Google.Protobuf.UninterpretedOption> (999, "uninterpretedOptions")
        // Proto Definition Implementation
        { // ProtoDef<OneofOptions>
            Name = "OneofOptions"
            Empty = {
                UninterpretedOptions = UninterpretedOptions.GetDefault()
                }
            Size = fun (m: OneofOptions) ->
                0
                + UninterpretedOptions.CalcFieldSize m.UninterpretedOptions
            Encode = fun (w: Google.Protobuf.CodedOutputStream) (m: OneofOptions) ->
                UninterpretedOptions.WriteField w m.UninterpretedOptions
            Decode = fun (r: Google.Protobuf.CodedInputStream) ->
                let mutable builder = new Google.Protobuf.OneofOptions.Builder()
                let mutable tag = 0
                while read r &tag do
                    builder.Put (tag, r)
                builder.Build
            EncodeJson = fun (o: JsonOptions) ->
                let writeUninterpretedOptions = UninterpretedOptions.WriteJsonField o
                let encode (w: System.Text.Json.Utf8JsonWriter) (m: OneofOptions) =
                    writeUninterpretedOptions w m.UninterpretedOptions
                encode
            DecodeJson = fun (node: System.Text.Json.Nodes.JsonNode) ->
                let update value (kvPair: System.Collections.Generic.KeyValuePair<string,System.Text.Json.Nodes.JsonNode>) : OneofOptions =
                    match kvPair.Key with
                    | "uninterpretedOptions" -> { value with UninterpretedOptions = UninterpretedOptions.ReadJsonField kvPair.Value }
                    | _ -> value
                Seq.fold update _OneofOptions.empty (node.AsObject ())
        }
    static member empty
        with get() = Google.Protobuf._OneofOptions.Proto.Value.Empty

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module EnumOptions =

    [<System.Runtime.CompilerServices.IsByRefLike>]
    type Builder =
        struct
            val mutable AllowAlias: bool // (2)
            val mutable Deprecated: bool // (3)
            val mutable UninterpretedOptions: RepeatedBuilder<Google.Protobuf.UninterpretedOption> // (999)
        end
        with
        member x.Put ((tag, reader): int * Reader) =
            match tag with
            | 2 -> x.AllowAlias <- ValueCodec.Bool.ReadValue reader
            | 3 -> x.Deprecated <- ValueCodec.Bool.ReadValue reader
            | 999 -> x.UninterpretedOptions.Add (ValueCodec.Message<Google.Protobuf.UninterpretedOption>.ReadValue reader)
            | _ -> reader.SkipLastField()
        member x.Build : Google.Protobuf.EnumOptions = {
            AllowAlias = x.AllowAlias
            Deprecated = x.Deprecated
            UninterpretedOptions = x.UninterpretedOptions.Build
            }

type private _EnumOptions = EnumOptions
[<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.MessageConverter>)>]
[<FsGrpc.Protobuf.Message>]
type EnumOptions = {
    // Field Declarations
    /// <summary>
    /// Set this option to true to allow mapping different tag names to the same
    /// value.
    /// </summary>
    [<System.Text.Json.Serialization.JsonPropertyName("allowAlias")>] AllowAlias: bool // (2)
    /// <summary>
    /// Is this enum deprecated?
    /// Depending on the target platform, this can emit Deprecated annotations
    /// for the enum, or it will be completely ignored; in the very least, this
    /// is a formalization for deprecating enums.
    /// </summary>
    [<System.Text.Json.Serialization.JsonPropertyName("deprecated")>] Deprecated: bool // (3)
    /// <summary>The parser stores options it doesn't recognize here. See above.</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("uninterpretedOptions")>] UninterpretedOptions: Google.Protobuf.UninterpretedOption list // (999)
    }
    with
    static member Proto : Lazy<ProtoDef<EnumOptions>> =
        lazy
        // Field Definitions
        let AllowAlias = FieldCodec.Primitive ValueCodec.Bool (2, "allowAlias")
        let Deprecated = FieldCodec.Primitive ValueCodec.Bool (3, "deprecated")
        let UninterpretedOptions = FieldCodec.Repeated ValueCodec.Message<Google.Protobuf.UninterpretedOption> (999, "uninterpretedOptions")
        // Proto Definition Implementation
        { // ProtoDef<EnumOptions>
            Name = "EnumOptions"
            Empty = {
                AllowAlias = AllowAlias.GetDefault()
                Deprecated = Deprecated.GetDefault()
                UninterpretedOptions = UninterpretedOptions.GetDefault()
                }
            Size = fun (m: EnumOptions) ->
                0
                + AllowAlias.CalcFieldSize m.AllowAlias
                + Deprecated.CalcFieldSize m.Deprecated
                + UninterpretedOptions.CalcFieldSize m.UninterpretedOptions
            Encode = fun (w: Google.Protobuf.CodedOutputStream) (m: EnumOptions) ->
                AllowAlias.WriteField w m.AllowAlias
                Deprecated.WriteField w m.Deprecated
                UninterpretedOptions.WriteField w m.UninterpretedOptions
            Decode = fun (r: Google.Protobuf.CodedInputStream) ->
                let mutable builder = new Google.Protobuf.EnumOptions.Builder()
                let mutable tag = 0
                while read r &tag do
                    builder.Put (tag, r)
                builder.Build
            EncodeJson = fun (o: JsonOptions) ->
                let writeAllowAlias = AllowAlias.WriteJsonField o
                let writeDeprecated = Deprecated.WriteJsonField o
                let writeUninterpretedOptions = UninterpretedOptions.WriteJsonField o
                let encode (w: System.Text.Json.Utf8JsonWriter) (m: EnumOptions) =
                    writeAllowAlias w m.AllowAlias
                    writeDeprecated w m.Deprecated
                    writeUninterpretedOptions w m.UninterpretedOptions
                encode
            DecodeJson = fun (node: System.Text.Json.Nodes.JsonNode) ->
                let update value (kvPair: System.Collections.Generic.KeyValuePair<string,System.Text.Json.Nodes.JsonNode>) : EnumOptions =
                    match kvPair.Key with
                    | "allowAlias" -> { value with AllowAlias = AllowAlias.ReadJsonField kvPair.Value }
                    | "deprecated" -> { value with Deprecated = Deprecated.ReadJsonField kvPair.Value }
                    | "uninterpretedOptions" -> { value with UninterpretedOptions = UninterpretedOptions.ReadJsonField kvPair.Value }
                    | _ -> value
                Seq.fold update _EnumOptions.empty (node.AsObject ())
        }
    static member empty
        with get() = Google.Protobuf._EnumOptions.Proto.Value.Empty

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module EnumValueOptions =

    [<System.Runtime.CompilerServices.IsByRefLike>]
    type Builder =
        struct
            val mutable Deprecated: bool // (1)
            val mutable UninterpretedOptions: RepeatedBuilder<Google.Protobuf.UninterpretedOption> // (999)
        end
        with
        member x.Put ((tag, reader): int * Reader) =
            match tag with
            | 1 -> x.Deprecated <- ValueCodec.Bool.ReadValue reader
            | 999 -> x.UninterpretedOptions.Add (ValueCodec.Message<Google.Protobuf.UninterpretedOption>.ReadValue reader)
            | _ -> reader.SkipLastField()
        member x.Build : Google.Protobuf.EnumValueOptions = {
            Deprecated = x.Deprecated
            UninterpretedOptions = x.UninterpretedOptions.Build
            }

type private _EnumValueOptions = EnumValueOptions
[<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.MessageConverter>)>]
[<FsGrpc.Protobuf.Message>]
type EnumValueOptions = {
    // Field Declarations
    /// <summary>
    /// Is this enum value deprecated?
    /// Depending on the target platform, this can emit Deprecated annotations
    /// for the enum value, or it will be completely ignored; in the very least,
    /// this is a formalization for deprecating enum values.
    /// </summary>
    [<System.Text.Json.Serialization.JsonPropertyName("deprecated")>] Deprecated: bool // (1)
    /// <summary>The parser stores options it doesn't recognize here. See above.</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("uninterpretedOptions")>] UninterpretedOptions: Google.Protobuf.UninterpretedOption list // (999)
    }
    with
    static member Proto : Lazy<ProtoDef<EnumValueOptions>> =
        lazy
        // Field Definitions
        let Deprecated = FieldCodec.Primitive ValueCodec.Bool (1, "deprecated")
        let UninterpretedOptions = FieldCodec.Repeated ValueCodec.Message<Google.Protobuf.UninterpretedOption> (999, "uninterpretedOptions")
        // Proto Definition Implementation
        { // ProtoDef<EnumValueOptions>
            Name = "EnumValueOptions"
            Empty = {
                Deprecated = Deprecated.GetDefault()
                UninterpretedOptions = UninterpretedOptions.GetDefault()
                }
            Size = fun (m: EnumValueOptions) ->
                0
                + Deprecated.CalcFieldSize m.Deprecated
                + UninterpretedOptions.CalcFieldSize m.UninterpretedOptions
            Encode = fun (w: Google.Protobuf.CodedOutputStream) (m: EnumValueOptions) ->
                Deprecated.WriteField w m.Deprecated
                UninterpretedOptions.WriteField w m.UninterpretedOptions
            Decode = fun (r: Google.Protobuf.CodedInputStream) ->
                let mutable builder = new Google.Protobuf.EnumValueOptions.Builder()
                let mutable tag = 0
                while read r &tag do
                    builder.Put (tag, r)
                builder.Build
            EncodeJson = fun (o: JsonOptions) ->
                let writeDeprecated = Deprecated.WriteJsonField o
                let writeUninterpretedOptions = UninterpretedOptions.WriteJsonField o
                let encode (w: System.Text.Json.Utf8JsonWriter) (m: EnumValueOptions) =
                    writeDeprecated w m.Deprecated
                    writeUninterpretedOptions w m.UninterpretedOptions
                encode
            DecodeJson = fun (node: System.Text.Json.Nodes.JsonNode) ->
                let update value (kvPair: System.Collections.Generic.KeyValuePair<string,System.Text.Json.Nodes.JsonNode>) : EnumValueOptions =
                    match kvPair.Key with
                    | "deprecated" -> { value with Deprecated = Deprecated.ReadJsonField kvPair.Value }
                    | "uninterpretedOptions" -> { value with UninterpretedOptions = UninterpretedOptions.ReadJsonField kvPair.Value }
                    | _ -> value
                Seq.fold update _EnumValueOptions.empty (node.AsObject ())
        }
    static member empty
        with get() = Google.Protobuf._EnumValueOptions.Proto.Value.Empty

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module ServiceOptions =

    [<System.Runtime.CompilerServices.IsByRefLike>]
    type Builder =
        struct
            val mutable Deprecated: bool // (33)
            val mutable UninterpretedOptions: RepeatedBuilder<Google.Protobuf.UninterpretedOption> // (999)
        end
        with
        member x.Put ((tag, reader): int * Reader) =
            match tag with
            | 33 -> x.Deprecated <- ValueCodec.Bool.ReadValue reader
            | 999 -> x.UninterpretedOptions.Add (ValueCodec.Message<Google.Protobuf.UninterpretedOption>.ReadValue reader)
            | _ -> reader.SkipLastField()
        member x.Build : Google.Protobuf.ServiceOptions = {
            Deprecated = x.Deprecated
            UninterpretedOptions = x.UninterpretedOptions.Build
            }

type private _ServiceOptions = ServiceOptions
[<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.MessageConverter>)>]
[<FsGrpc.Protobuf.Message>]
type ServiceOptions = {
    // Field Declarations
    /// <summary>
    /// Is this service deprecated?
    /// Depending on the target platform, this can emit Deprecated annotations
    /// for the service, or it will be completely ignored; in the very least,
    /// this is a formalization for deprecating services.
    /// </summary>
    [<System.Text.Json.Serialization.JsonPropertyName("deprecated")>] Deprecated: bool // (33)
    /// <summary>The parser stores options it doesn't recognize here. See above.</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("uninterpretedOptions")>] UninterpretedOptions: Google.Protobuf.UninterpretedOption list // (999)
    }
    with
    static member Proto : Lazy<ProtoDef<ServiceOptions>> =
        lazy
        // Field Definitions
        let Deprecated = FieldCodec.Primitive ValueCodec.Bool (33, "deprecated")
        let UninterpretedOptions = FieldCodec.Repeated ValueCodec.Message<Google.Protobuf.UninterpretedOption> (999, "uninterpretedOptions")
        // Proto Definition Implementation
        { // ProtoDef<ServiceOptions>
            Name = "ServiceOptions"
            Empty = {
                Deprecated = Deprecated.GetDefault()
                UninterpretedOptions = UninterpretedOptions.GetDefault()
                }
            Size = fun (m: ServiceOptions) ->
                0
                + Deprecated.CalcFieldSize m.Deprecated
                + UninterpretedOptions.CalcFieldSize m.UninterpretedOptions
            Encode = fun (w: Google.Protobuf.CodedOutputStream) (m: ServiceOptions) ->
                Deprecated.WriteField w m.Deprecated
                UninterpretedOptions.WriteField w m.UninterpretedOptions
            Decode = fun (r: Google.Protobuf.CodedInputStream) ->
                let mutable builder = new Google.Protobuf.ServiceOptions.Builder()
                let mutable tag = 0
                while read r &tag do
                    builder.Put (tag, r)
                builder.Build
            EncodeJson = fun (o: JsonOptions) ->
                let writeDeprecated = Deprecated.WriteJsonField o
                let writeUninterpretedOptions = UninterpretedOptions.WriteJsonField o
                let encode (w: System.Text.Json.Utf8JsonWriter) (m: ServiceOptions) =
                    writeDeprecated w m.Deprecated
                    writeUninterpretedOptions w m.UninterpretedOptions
                encode
            DecodeJson = fun (node: System.Text.Json.Nodes.JsonNode) ->
                let update value (kvPair: System.Collections.Generic.KeyValuePair<string,System.Text.Json.Nodes.JsonNode>) : ServiceOptions =
                    match kvPair.Key with
                    | "deprecated" -> { value with Deprecated = Deprecated.ReadJsonField kvPair.Value }
                    | "uninterpretedOptions" -> { value with UninterpretedOptions = UninterpretedOptions.ReadJsonField kvPair.Value }
                    | _ -> value
                Seq.fold update _ServiceOptions.empty (node.AsObject ())
        }
    static member empty
        with get() = Google.Protobuf._ServiceOptions.Proto.Value.Empty

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module MethodOptions =

    /// <summary>
    /// Is this method side-effect-free (or safe in HTTP parlance), or idempotent,
    /// or neither? HTTP based RPC implementation may choose GET verb for safe
    /// methods, and PUT verb for idempotent methods instead of the default POST.
    /// </summary>
    [<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.EnumConverter<IdempotencyLevel>>)>]
    type IdempotencyLevel =
    | [<FsGrpc.Protobuf.ProtobufName("IDEMPOTENCY_UNKNOWN")>] IdempotencyUnknown = 0
    | [<FsGrpc.Protobuf.ProtobufName("NO_SIDE_EFFECTS")>] NoSideEffects = 1
    | [<FsGrpc.Protobuf.ProtobufName("IDEMPOTENT")>] Idempotent = 2

    [<System.Runtime.CompilerServices.IsByRefLike>]
    type Builder =
        struct
            val mutable Deprecated: bool // (33)
            val mutable IdempotencyLevel: Google.Protobuf.MethodOptions.IdempotencyLevel // (34)
            val mutable UninterpretedOptions: RepeatedBuilder<Google.Protobuf.UninterpretedOption> // (999)
        end
        with
        member x.Put ((tag, reader): int * Reader) =
            match tag with
            | 33 -> x.Deprecated <- ValueCodec.Bool.ReadValue reader
            | 34 -> x.IdempotencyLevel <- ValueCodec.Enum<Google.Protobuf.MethodOptions.IdempotencyLevel>.ReadValue reader
            | 999 -> x.UninterpretedOptions.Add (ValueCodec.Message<Google.Protobuf.UninterpretedOption>.ReadValue reader)
            | _ -> reader.SkipLastField()
        member x.Build : Google.Protobuf.MethodOptions = {
            Deprecated = x.Deprecated
            IdempotencyLevel = x.IdempotencyLevel
            UninterpretedOptions = x.UninterpretedOptions.Build
            }

type private _MethodOptions = MethodOptions
[<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.MessageConverter>)>]
[<FsGrpc.Protobuf.Message>]
type MethodOptions = {
    // Field Declarations
    /// <summary>
    /// Is this method deprecated?
    /// Depending on the target platform, this can emit Deprecated annotations
    /// for the method, or it will be completely ignored; in the very least,
    /// this is a formalization for deprecating methods.
    /// </summary>
    [<System.Text.Json.Serialization.JsonPropertyName("deprecated")>] Deprecated: bool // (33)
    [<System.Text.Json.Serialization.JsonPropertyName("idempotencyLevel")>] IdempotencyLevel: Google.Protobuf.MethodOptions.IdempotencyLevel // (34)
    /// <summary>The parser stores options it doesn't recognize here. See above.</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("uninterpretedOptions")>] UninterpretedOptions: Google.Protobuf.UninterpretedOption list // (999)
    }
    with
    static member Proto : Lazy<ProtoDef<MethodOptions>> =
        lazy
        // Field Definitions
        let Deprecated = FieldCodec.Primitive ValueCodec.Bool (33, "deprecated")
        let IdempotencyLevel = FieldCodec.Primitive ValueCodec.Enum<Google.Protobuf.MethodOptions.IdempotencyLevel> (34, "idempotencyLevel")
        let UninterpretedOptions = FieldCodec.Repeated ValueCodec.Message<Google.Protobuf.UninterpretedOption> (999, "uninterpretedOptions")
        // Proto Definition Implementation
        { // ProtoDef<MethodOptions>
            Name = "MethodOptions"
            Empty = {
                Deprecated = Deprecated.GetDefault()
                IdempotencyLevel = IdempotencyLevel.GetDefault()
                UninterpretedOptions = UninterpretedOptions.GetDefault()
                }
            Size = fun (m: MethodOptions) ->
                0
                + Deprecated.CalcFieldSize m.Deprecated
                + IdempotencyLevel.CalcFieldSize m.IdempotencyLevel
                + UninterpretedOptions.CalcFieldSize m.UninterpretedOptions
            Encode = fun (w: Google.Protobuf.CodedOutputStream) (m: MethodOptions) ->
                Deprecated.WriteField w m.Deprecated
                IdempotencyLevel.WriteField w m.IdempotencyLevel
                UninterpretedOptions.WriteField w m.UninterpretedOptions
            Decode = fun (r: Google.Protobuf.CodedInputStream) ->
                let mutable builder = new Google.Protobuf.MethodOptions.Builder()
                let mutable tag = 0
                while read r &tag do
                    builder.Put (tag, r)
                builder.Build
            EncodeJson = fun (o: JsonOptions) ->
                let writeDeprecated = Deprecated.WriteJsonField o
                let writeIdempotencyLevel = IdempotencyLevel.WriteJsonField o
                let writeUninterpretedOptions = UninterpretedOptions.WriteJsonField o
                let encode (w: System.Text.Json.Utf8JsonWriter) (m: MethodOptions) =
                    writeDeprecated w m.Deprecated
                    writeIdempotencyLevel w m.IdempotencyLevel
                    writeUninterpretedOptions w m.UninterpretedOptions
                encode
            DecodeJson = fun (node: System.Text.Json.Nodes.JsonNode) ->
                let update value (kvPair: System.Collections.Generic.KeyValuePair<string,System.Text.Json.Nodes.JsonNode>) : MethodOptions =
                    match kvPair.Key with
                    | "deprecated" -> { value with Deprecated = Deprecated.ReadJsonField kvPair.Value }
                    | "idempotencyLevel" -> { value with IdempotencyLevel = IdempotencyLevel.ReadJsonField kvPair.Value }
                    | "uninterpretedOptions" -> { value with UninterpretedOptions = UninterpretedOptions.ReadJsonField kvPair.Value }
                    | _ -> value
                Seq.fold update _MethodOptions.empty (node.AsObject ())
        }
    static member empty
        with get() = Google.Protobuf._MethodOptions.Proto.Value.Empty

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module UninterpretedOption =

    [<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.OneofConverter<ValueCase>>)>]
    [<CompilationRepresentation(CompilationRepresentationFlags.UseNullAsTrueValue)>]
    [<StructuralEquality;NoComparison>]
    [<RequireQualifiedAccess>]
    type ValueCase =
    | None
    | [<System.Text.Json.Serialization.JsonPropertyName("identifierValue")>] IdentifierValue of string
    | [<System.Text.Json.Serialization.JsonPropertyName("positiveIntValue")>] PositiveIntValue of uint64
    | [<System.Text.Json.Serialization.JsonPropertyName("negativeIntValue")>] NegativeIntValue of int64
    | [<System.Text.Json.Serialization.JsonPropertyName("doubleValue")>] DoubleValue of double
    | [<System.Text.Json.Serialization.JsonPropertyName("stringValue")>] StringValue of FsGrpc.Bytes
    | [<System.Text.Json.Serialization.JsonPropertyName("aggregateValue")>] AggregateValue of string
    with
        static member OneofCodec : Lazy<OneofCodec<ValueCase>> = 
            lazy
            let IdentifierValue = FieldCodec.OneofCase "value" ValueCodec.String (3, "identifierValue")
            let PositiveIntValue = FieldCodec.OneofCase "value" ValueCodec.UInt64 (4, "positiveIntValue")
            let NegativeIntValue = FieldCodec.OneofCase "value" ValueCodec.Int64 (5, "negativeIntValue")
            let DoubleValue = FieldCodec.OneofCase "value" ValueCodec.Double (6, "doubleValue")
            let StringValue = FieldCodec.OneofCase "value" ValueCodec.Bytes (7, "stringValue")
            let AggregateValue = FieldCodec.OneofCase "value" ValueCodec.String (8, "aggregateValue")
            let Value = FieldCodec.Oneof "value" (FSharp.Collections.Map [
                ("identifierValue", fun node -> ValueCase.IdentifierValue (IdentifierValue.ReadJsonField node))
                ("positiveIntValue", fun node -> ValueCase.PositiveIntValue (PositiveIntValue.ReadJsonField node))
                ("negativeIntValue", fun node -> ValueCase.NegativeIntValue (NegativeIntValue.ReadJsonField node))
                ("doubleValue", fun node -> ValueCase.DoubleValue (DoubleValue.ReadJsonField node))
                ("stringValue", fun node -> ValueCase.StringValue (StringValue.ReadJsonField node))
                ("aggregateValue", fun node -> ValueCase.AggregateValue (AggregateValue.ReadJsonField node))
                ])
            Value

    [<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    module NamePart =

        [<System.Runtime.CompilerServices.IsByRefLike>]
        type Builder =
            struct
                val mutable NamePart: string // (1)
                val mutable IsExtension: bool // (2)
            end
            with
            member x.Put ((tag, reader): int * Reader) =
                match tag with
                | 1 -> x.NamePart <- ValueCodec.String.ReadValue reader
                | 2 -> x.IsExtension <- ValueCodec.Bool.ReadValue reader
                | _ -> reader.SkipLastField()
            member x.Build : Google.Protobuf.UninterpretedOption.NamePart = {
                NamePart = x.NamePart |> orEmptyString
                IsExtension = x.IsExtension
                }

    /// <summary>
    /// The name of the uninterpreted option.  Each string represents a segment in
    /// a dot-separated name.  is_extension is true iff a segment represents an
    /// extension (denoted with parentheses in options specs in .proto files).
    /// E.g.,{ ["foo", false], ["bar.baz", true], ["qux", false] } represents
    /// "foo.(bar.baz).qux".
    /// </summary>
    type private _NamePart = NamePart
    [<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.MessageConverter>)>]
    [<FsGrpc.Protobuf.Message>]
    type NamePart = {
        // Field Declarations
        [<System.Text.Json.Serialization.JsonPropertyName("namePart")>] NamePart: string // (1)
        [<System.Text.Json.Serialization.JsonPropertyName("isExtension")>] IsExtension: bool // (2)
        }
        with
        static member Proto : Lazy<ProtoDef<NamePart>> =
            lazy
            // Field Definitions
            let NamePart = FieldCodec.Primitive ValueCodec.String (1, "namePart")
            let IsExtension = FieldCodec.Primitive ValueCodec.Bool (2, "isExtension")
            // Proto Definition Implementation
            { // ProtoDef<NamePart>
                Name = "NamePart"
                Empty = {
                    NamePart = NamePart.GetDefault()
                    IsExtension = IsExtension.GetDefault()
                    }
                Size = fun (m: NamePart) ->
                    0
                    + NamePart.CalcFieldSize m.NamePart
                    + IsExtension.CalcFieldSize m.IsExtension
                Encode = fun (w: Google.Protobuf.CodedOutputStream) (m: NamePart) ->
                    NamePart.WriteField w m.NamePart
                    IsExtension.WriteField w m.IsExtension
                Decode = fun (r: Google.Protobuf.CodedInputStream) ->
                    let mutable builder = new Google.Protobuf.UninterpretedOption.NamePart.Builder()
                    let mutable tag = 0
                    while read r &tag do
                        builder.Put (tag, r)
                    builder.Build
                EncodeJson = fun (o: JsonOptions) ->
                    let writeNamePart = NamePart.WriteJsonField o
                    let writeIsExtension = IsExtension.WriteJsonField o
                    let encode (w: System.Text.Json.Utf8JsonWriter) (m: NamePart) =
                        writeNamePart w m.NamePart
                        writeIsExtension w m.IsExtension
                    encode
                DecodeJson = fun (node: System.Text.Json.Nodes.JsonNode) ->
                    let update value (kvPair: System.Collections.Generic.KeyValuePair<string,System.Text.Json.Nodes.JsonNode>) : NamePart =
                        match kvPair.Key with
                        | "namePart" -> { value with NamePart = NamePart.ReadJsonField kvPair.Value }
                        | "isExtension" -> { value with IsExtension = IsExtension.ReadJsonField kvPair.Value }
                        | _ -> value
                    Seq.fold update _NamePart.empty (node.AsObject ())
            }
        static member empty
            with get() = Google.Protobuf.UninterpretedOption._NamePart.Proto.Value.Empty

    [<System.Runtime.CompilerServices.IsByRefLike>]
    type Builder =
        struct
            val mutable Names: RepeatedBuilder<Google.Protobuf.UninterpretedOption.NamePart> // (2)
            val mutable Value: OptionBuilder<Google.Protobuf.UninterpretedOption.ValueCase>
        end
        with
        member x.Put ((tag, reader): int * Reader) =
            match tag with
            | 2 -> x.Names.Add (ValueCodec.Message<Google.Protobuf.UninterpretedOption.NamePart>.ReadValue reader)
            | 3 -> x.Value.Set (ValueCase.IdentifierValue (ValueCodec.String.ReadValue reader))
            | 4 -> x.Value.Set (ValueCase.PositiveIntValue (ValueCodec.UInt64.ReadValue reader))
            | 5 -> x.Value.Set (ValueCase.NegativeIntValue (ValueCodec.Int64.ReadValue reader))
            | 6 -> x.Value.Set (ValueCase.DoubleValue (ValueCodec.Double.ReadValue reader))
            | 7 -> x.Value.Set (ValueCase.StringValue (ValueCodec.Bytes.ReadValue reader))
            | 8 -> x.Value.Set (ValueCase.AggregateValue (ValueCodec.String.ReadValue reader))
            | _ -> reader.SkipLastField()
        member x.Build : Google.Protobuf.UninterpretedOption = {
            Names = x.Names.Build
            Value = x.Value.Build |> (Option.defaultValue ValueCase.None)
            }

/// <summary>
/// A message representing a option the parser does not recognize. This only
/// appears in options protos created by the compiler::Parser class.
/// DescriptorPool resolves these when building Descriptor objects. Therefore,
/// options protos in descriptor objects (e.g. returned by Descriptor::options(),
/// or produced by Descriptor::CopyTo()) will never have UninterpretedOptions
/// in them.
/// </summary>
type private _UninterpretedOption = UninterpretedOption
[<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.MessageConverter>)>]
[<FsGrpc.Protobuf.Message>]
type UninterpretedOption = {
    // Field Declarations
    [<System.Text.Json.Serialization.JsonPropertyName("names")>] Names: Google.Protobuf.UninterpretedOption.NamePart list // (2)
    /// <summary>
    /// The value of the uninterpreted option, in whatever type the tokenizer
    /// identified it as during parsing. Exactly one of these should be set.
    /// </summary>
    Value: Google.Protobuf.UninterpretedOption.ValueCase
    }
    with
    static member Proto : Lazy<ProtoDef<UninterpretedOption>> =
        lazy
        // Field Definitions
        let Names = FieldCodec.Repeated ValueCodec.Message<Google.Protobuf.UninterpretedOption.NamePart> (2, "names")
        let IdentifierValue = FieldCodec.OneofCase "value" ValueCodec.String (3, "identifierValue")
        let PositiveIntValue = FieldCodec.OneofCase "value" ValueCodec.UInt64 (4, "positiveIntValue")
        let NegativeIntValue = FieldCodec.OneofCase "value" ValueCodec.Int64 (5, "negativeIntValue")
        let DoubleValue = FieldCodec.OneofCase "value" ValueCodec.Double (6, "doubleValue")
        let StringValue = FieldCodec.OneofCase "value" ValueCodec.Bytes (7, "stringValue")
        let AggregateValue = FieldCodec.OneofCase "value" ValueCodec.String (8, "aggregateValue")
        let Value = FieldCodec.Oneof "value" (FSharp.Collections.Map [
            ("identifierValue", fun node -> Google.Protobuf.UninterpretedOption.ValueCase.IdentifierValue (IdentifierValue.ReadJsonField node))
            ("positiveIntValue", fun node -> Google.Protobuf.UninterpretedOption.ValueCase.PositiveIntValue (PositiveIntValue.ReadJsonField node))
            ("negativeIntValue", fun node -> Google.Protobuf.UninterpretedOption.ValueCase.NegativeIntValue (NegativeIntValue.ReadJsonField node))
            ("doubleValue", fun node -> Google.Protobuf.UninterpretedOption.ValueCase.DoubleValue (DoubleValue.ReadJsonField node))
            ("stringValue", fun node -> Google.Protobuf.UninterpretedOption.ValueCase.StringValue (StringValue.ReadJsonField node))
            ("aggregateValue", fun node -> Google.Protobuf.UninterpretedOption.ValueCase.AggregateValue (AggregateValue.ReadJsonField node))
            ])
        // Proto Definition Implementation
        { // ProtoDef<UninterpretedOption>
            Name = "UninterpretedOption"
            Empty = {
                Names = Names.GetDefault()
                Value = Google.Protobuf.UninterpretedOption.ValueCase.None
                }
            Size = fun (m: UninterpretedOption) ->
                0
                + Names.CalcFieldSize m.Names
                + match m.Value with
                    | Google.Protobuf.UninterpretedOption.ValueCase.None -> 0
                    | Google.Protobuf.UninterpretedOption.ValueCase.IdentifierValue v -> IdentifierValue.CalcFieldSize v
                    | Google.Protobuf.UninterpretedOption.ValueCase.PositiveIntValue v -> PositiveIntValue.CalcFieldSize v
                    | Google.Protobuf.UninterpretedOption.ValueCase.NegativeIntValue v -> NegativeIntValue.CalcFieldSize v
                    | Google.Protobuf.UninterpretedOption.ValueCase.DoubleValue v -> DoubleValue.CalcFieldSize v
                    | Google.Protobuf.UninterpretedOption.ValueCase.StringValue v -> StringValue.CalcFieldSize v
                    | Google.Protobuf.UninterpretedOption.ValueCase.AggregateValue v -> AggregateValue.CalcFieldSize v
            Encode = fun (w: Google.Protobuf.CodedOutputStream) (m: UninterpretedOption) ->
                Names.WriteField w m.Names
                (match m.Value with
                | Google.Protobuf.UninterpretedOption.ValueCase.None -> ()
                | Google.Protobuf.UninterpretedOption.ValueCase.IdentifierValue v -> IdentifierValue.WriteField w v
                | Google.Protobuf.UninterpretedOption.ValueCase.PositiveIntValue v -> PositiveIntValue.WriteField w v
                | Google.Protobuf.UninterpretedOption.ValueCase.NegativeIntValue v -> NegativeIntValue.WriteField w v
                | Google.Protobuf.UninterpretedOption.ValueCase.DoubleValue v -> DoubleValue.WriteField w v
                | Google.Protobuf.UninterpretedOption.ValueCase.StringValue v -> StringValue.WriteField w v
                | Google.Protobuf.UninterpretedOption.ValueCase.AggregateValue v -> AggregateValue.WriteField w v
                )
            Decode = fun (r: Google.Protobuf.CodedInputStream) ->
                let mutable builder = new Google.Protobuf.UninterpretedOption.Builder()
                let mutable tag = 0
                while read r &tag do
                    builder.Put (tag, r)
                builder.Build
            EncodeJson = fun (o: JsonOptions) ->
                let writeNames = Names.WriteJsonField o
                let writeValueNone = Value.WriteJsonNoneCase o
                let writeIdentifierValue = IdentifierValue.WriteJsonField o
                let writePositiveIntValue = PositiveIntValue.WriteJsonField o
                let writeNegativeIntValue = NegativeIntValue.WriteJsonField o
                let writeDoubleValue = DoubleValue.WriteJsonField o
                let writeStringValue = StringValue.WriteJsonField o
                let writeAggregateValue = AggregateValue.WriteJsonField o
                let encode (w: System.Text.Json.Utf8JsonWriter) (m: UninterpretedOption) =
                    writeNames w m.Names
                    (match m.Value with
                    | Google.Protobuf.UninterpretedOption.ValueCase.None -> writeValueNone w
                    | Google.Protobuf.UninterpretedOption.ValueCase.IdentifierValue v -> writeIdentifierValue w v
                    | Google.Protobuf.UninterpretedOption.ValueCase.PositiveIntValue v -> writePositiveIntValue w v
                    | Google.Protobuf.UninterpretedOption.ValueCase.NegativeIntValue v -> writeNegativeIntValue w v
                    | Google.Protobuf.UninterpretedOption.ValueCase.DoubleValue v -> writeDoubleValue w v
                    | Google.Protobuf.UninterpretedOption.ValueCase.StringValue v -> writeStringValue w v
                    | Google.Protobuf.UninterpretedOption.ValueCase.AggregateValue v -> writeAggregateValue w v
                    )
                encode
            DecodeJson = fun (node: System.Text.Json.Nodes.JsonNode) ->
                let update value (kvPair: System.Collections.Generic.KeyValuePair<string,System.Text.Json.Nodes.JsonNode>) : UninterpretedOption =
                    match kvPair.Key with
                    | "names" -> { value with Names = Names.ReadJsonField kvPair.Value }
                    | "identifierValue" -> { value with Value = Google.Protobuf.UninterpretedOption.ValueCase.IdentifierValue (IdentifierValue.ReadJsonField kvPair.Value) }
                    | "positiveIntValue" -> { value with Value = Google.Protobuf.UninterpretedOption.ValueCase.PositiveIntValue (PositiveIntValue.ReadJsonField kvPair.Value) }
                    | "negativeIntValue" -> { value with Value = Google.Protobuf.UninterpretedOption.ValueCase.NegativeIntValue (NegativeIntValue.ReadJsonField kvPair.Value) }
                    | "doubleValue" -> { value with Value = Google.Protobuf.UninterpretedOption.ValueCase.DoubleValue (DoubleValue.ReadJsonField kvPair.Value) }
                    | "stringValue" -> { value with Value = Google.Protobuf.UninterpretedOption.ValueCase.StringValue (StringValue.ReadJsonField kvPair.Value) }
                    | "aggregateValue" -> { value with Value = Google.Protobuf.UninterpretedOption.ValueCase.AggregateValue (AggregateValue.ReadJsonField kvPair.Value) }
                    | "value" -> { value with Value = Value.ReadJsonField kvPair.Value }
                    | _ -> value
                Seq.fold update _UninterpretedOption.empty (node.AsObject ())
        }
    static member empty
        with get() = Google.Protobuf._UninterpretedOption.Proto.Value.Empty

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module SourceCodeInfo =

    [<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    module Location =

        [<System.Runtime.CompilerServices.IsByRefLike>]
        type Builder =
            struct
                val mutable Paths: RepeatedBuilder<int> // (1)
                val mutable Spans: RepeatedBuilder<int> // (2)
                val mutable LeadingComments: string // (3)
                val mutable TrailingComments: string // (4)
                val mutable LeadingDetachedComments: RepeatedBuilder<string> // (6)
            end
            with
            member x.Put ((tag, reader): int * Reader) =
                match tag with
                | 1 -> x.Paths.AddRange ((ValueCodec.Packed ValueCodec.Int32).ReadValue reader)
                | 2 -> x.Spans.AddRange ((ValueCodec.Packed ValueCodec.Int32).ReadValue reader)
                | 3 -> x.LeadingComments <- ValueCodec.String.ReadValue reader
                | 4 -> x.TrailingComments <- ValueCodec.String.ReadValue reader
                | 6 -> x.LeadingDetachedComments.Add (ValueCodec.String.ReadValue reader)
                | _ -> reader.SkipLastField()
            member x.Build : Google.Protobuf.SourceCodeInfo.Location = {
                Paths = x.Paths.Build
                Spans = x.Spans.Build
                LeadingComments = x.LeadingComments |> orEmptyString
                TrailingComments = x.TrailingComments |> orEmptyString
                LeadingDetachedComments = x.LeadingDetachedComments.Build
                }

    type private _Location = Location
    [<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.MessageConverter>)>]
    [<FsGrpc.Protobuf.Message>]
    type Location = {
        // Field Declarations
        /// <summary>
        /// Identifies which part of the FileDescriptorProto was defined at this
        /// location.
        /// 
        /// Each element is a field number or an index.  They form a path from
        /// the root FileDescriptorProto to the place where the definition.  For
        /// example, this path:
        ///   [ 4, 3, 2, 7, 1 ]
        /// refers to:
        ///   file.message_type(3)  // 4, 3
        ///       .field(7)         // 2, 7
        ///       .name()           // 1
        /// This is because FileDescriptorProto.message_type has field number 4:
        ///   repeated DescriptorProto message_type = 4;
        /// and DescriptorProto.field has field number 2:
        ///   repeated FieldDescriptorProto field = 2;
        /// and FieldDescriptorProto.name has field number 1:
        ///   optional string name = 1;
        /// 
        /// Thus, the above path gives the location of a field name.  If we removed
        /// the last element:
        ///   [ 4, 3, 2, 7 ]
        /// this path refers to the whole field declaration (from the beginning
        /// of the label to the terminating semicolon).
        /// </summary>
        [<System.Text.Json.Serialization.JsonPropertyName("paths")>] Paths: int list // (1)
        /// <summary>
        /// Always has exactly three or four elements: start line, start column,
        /// end line (optional, otherwise assumed same as start line), end column.
        /// These are packed into a single field for efficiency.  Note that line
        /// and column numbers are zero-based -- typically you will want to add
        /// 1 to each before displaying to a user.
        /// </summary>
        [<System.Text.Json.Serialization.JsonPropertyName("spans")>] Spans: int list // (2)
        /// <summary>
        /// If this SourceCodeInfo represents a complete declaration, these are any
        /// comments appearing before and after the declaration which appear to be
        /// attached to the declaration.
        /// 
        /// A series of line comments appearing on consecutive lines, with no other
        /// tokens appearing on those lines, will be treated as a single comment.
        /// 
        /// leading_detached_comments will keep paragraphs of comments that appear
        /// before (but not connected to) the current element. Each paragraph,
        /// separated by empty lines, will be one comment element in the repeated
        /// field.
        /// 
        /// Only the comment content is provided; comment markers (e.g. //) are
        /// stripped out.  For block comments, leading whitespace and an asterisk
        /// will be stripped from the beginning of each line other than the first.
        /// Newlines are included in the output.
        /// 
        /// Examples:
        /// 
        ///   optional int32 foo = 1;  // Comment attached to foo.
        ///   // Comment attached to bar.
        ///   optional int32 bar = 2;
        /// 
        ///   optional string baz = 3;
        ///   // Comment attached to baz.
        ///   // Another line attached to baz.
        /// 
        ///   // Comment attached to qux.
        ///   //
        ///   // Another line attached to qux.
        ///   optional double qux = 4;
        /// 
        ///   // Detached comment for corge. This is not leading or trailing comments
        ///   // to qux or corge because there are blank lines separating it from
        ///   // both.
        /// 
        ///   // Detached comment for corge paragraph 2.
        /// 
        ///   optional string corge = 5;
        ///   /* Block comment attached
        ///    * to corge.  Leading asterisks
        ///    * will be removed. */
        ///   /* Block comment attached to
        ///    * grault. */
        ///   optional int32 grault = 6;
        /// 
        ///   // ignored detached comments.
        /// </summary>
        [<System.Text.Json.Serialization.JsonPropertyName("leadingComments")>] LeadingComments: string // (3)
        [<System.Text.Json.Serialization.JsonPropertyName("trailingComments")>] TrailingComments: string // (4)
        [<System.Text.Json.Serialization.JsonPropertyName("leadingDetachedComments")>] LeadingDetachedComments: string list // (6)
        }
        with
        static member Proto : Lazy<ProtoDef<Location>> =
            lazy
            // Field Definitions
            let Paths = FieldCodec.Primitive (ValueCodec.Packed ValueCodec.Int32) (1, "paths")
            let Spans = FieldCodec.Primitive (ValueCodec.Packed ValueCodec.Int32) (2, "spans")
            let LeadingComments = FieldCodec.Primitive ValueCodec.String (3, "leadingComments")
            let TrailingComments = FieldCodec.Primitive ValueCodec.String (4, "trailingComments")
            let LeadingDetachedComments = FieldCodec.Repeated ValueCodec.String (6, "leadingDetachedComments")
            // Proto Definition Implementation
            { // ProtoDef<Location>
                Name = "Location"
                Empty = {
                    Paths = Paths.GetDefault()
                    Spans = Spans.GetDefault()
                    LeadingComments = LeadingComments.GetDefault()
                    TrailingComments = TrailingComments.GetDefault()
                    LeadingDetachedComments = LeadingDetachedComments.GetDefault()
                    }
                Size = fun (m: Location) ->
                    0
                    + Paths.CalcFieldSize m.Paths
                    + Spans.CalcFieldSize m.Spans
                    + LeadingComments.CalcFieldSize m.LeadingComments
                    + TrailingComments.CalcFieldSize m.TrailingComments
                    + LeadingDetachedComments.CalcFieldSize m.LeadingDetachedComments
                Encode = fun (w: Google.Protobuf.CodedOutputStream) (m: Location) ->
                    Paths.WriteField w m.Paths
                    Spans.WriteField w m.Spans
                    LeadingComments.WriteField w m.LeadingComments
                    TrailingComments.WriteField w m.TrailingComments
                    LeadingDetachedComments.WriteField w m.LeadingDetachedComments
                Decode = fun (r: Google.Protobuf.CodedInputStream) ->
                    let mutable builder = new Google.Protobuf.SourceCodeInfo.Location.Builder()
                    let mutable tag = 0
                    while read r &tag do
                        builder.Put (tag, r)
                    builder.Build
                EncodeJson = fun (o: JsonOptions) ->
                    let writePaths = Paths.WriteJsonField o
                    let writeSpans = Spans.WriteJsonField o
                    let writeLeadingComments = LeadingComments.WriteJsonField o
                    let writeTrailingComments = TrailingComments.WriteJsonField o
                    let writeLeadingDetachedComments = LeadingDetachedComments.WriteJsonField o
                    let encode (w: System.Text.Json.Utf8JsonWriter) (m: Location) =
                        writePaths w m.Paths
                        writeSpans w m.Spans
                        writeLeadingComments w m.LeadingComments
                        writeTrailingComments w m.TrailingComments
                        writeLeadingDetachedComments w m.LeadingDetachedComments
                    encode
                DecodeJson = fun (node: System.Text.Json.Nodes.JsonNode) ->
                    let update value (kvPair: System.Collections.Generic.KeyValuePair<string,System.Text.Json.Nodes.JsonNode>) : Location =
                        match kvPair.Key with
                        | "paths" -> { value with Paths = Paths.ReadJsonField kvPair.Value }
                        | "spans" -> { value with Spans = Spans.ReadJsonField kvPair.Value }
                        | "leadingComments" -> { value with LeadingComments = LeadingComments.ReadJsonField kvPair.Value }
                        | "trailingComments" -> { value with TrailingComments = TrailingComments.ReadJsonField kvPair.Value }
                        | "leadingDetachedComments" -> { value with LeadingDetachedComments = LeadingDetachedComments.ReadJsonField kvPair.Value }
                        | _ -> value
                    Seq.fold update _Location.empty (node.AsObject ())
            }
        static member empty
            with get() = Google.Protobuf.SourceCodeInfo._Location.Proto.Value.Empty

    [<System.Runtime.CompilerServices.IsByRefLike>]
    type Builder =
        struct
            val mutable Location: RepeatedBuilder<Google.Protobuf.SourceCodeInfo.Location> // (1)
        end
        with
        member x.Put ((tag, reader): int * Reader) =
            match tag with
            | 1 -> x.Location.Add (ValueCodec.Message<Google.Protobuf.SourceCodeInfo.Location>.ReadValue reader)
            | _ -> reader.SkipLastField()
        member x.Build : Google.Protobuf.SourceCodeInfo = {
            Location = x.Location.Build
            }

/// <summary>
/// Encapsulates information about the original source file from which a
/// FileDescriptorProto was generated.
/// </summary>
type private _SourceCodeInfo = SourceCodeInfo
[<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.MessageConverter>)>]
[<FsGrpc.Protobuf.Message>]
type SourceCodeInfo = {
    // Field Declarations
    /// <summary>
    /// A Location identifies a piece of source code in a .proto file which
    /// corresponds to a particular definition.  This information is intended
    /// to be useful to IDEs, code indexers, documentation generators, and similar
    /// tools.
    /// 
    /// For example, say we have a file like:
    ///   message Foo {
    ///     optional string foo = 1;
    ///   }
    /// Let's look at just the field definition:
    ///   optional string foo = 1;
    ///   ^       ^^     ^^  ^  ^^^
    ///   a       bc     de  f  ghi
    /// We have the following locations:
    ///   span   path               represents
    ///   [a,i)  [ 4, 0, 2, 0 ]     The whole field definition.
    ///   [a,b)  [ 4, 0, 2, 0, 4 ]  The label (optional).
    ///   [c,d)  [ 4, 0, 2, 0, 5 ]  The type (string).
    ///   [e,f)  [ 4, 0, 2, 0, 1 ]  The name (foo).
    ///   [g,h)  [ 4, 0, 2, 0, 3 ]  The number (1).
    /// 
    /// Notes:
    /// - A location may refer to a repeated field itself (i.e. not to any
    ///   particular index within it).  This is used whenever a set of elements are
    ///   logically enclosed in a single code segment.  For example, an entire
    ///   extend block (possibly containing multiple extension definitions) will
    ///   have an outer location whose path refers to the "extensions" repeated
    ///   field without an index.
    /// - Multiple locations may have the same path.  This happens when a single
    ///   logical declaration is spread out across multiple places.  The most
    ///   obvious example is the "extend" block again -- there may be multiple
    ///   extend blocks in the same scope, each of which will have the same path.
    /// - A location's span is not always a subset of its parent's span.  For
    ///   example, the "extendee" of an extension declaration appears at the
    ///   beginning of the "extend" block and is shared by all extensions within
    ///   the block.
    /// - Just because a location's span is a subset of some other location's span
    ///   does not mean that it is a descendant.  For example, a "group" defines
    ///   both a type and a field in a single declaration.  Thus, the locations
    ///   corresponding to the type and field and their components will overlap.
    /// - Code which tries to interpret locations should probably be designed to
    ///   ignore those that it doesn't understand, as more types of locations could
    ///   be recorded in the future.
    /// </summary>
    [<System.Text.Json.Serialization.JsonPropertyName("location")>] Location: Google.Protobuf.SourceCodeInfo.Location list // (1)
    }
    with
    static member Proto : Lazy<ProtoDef<SourceCodeInfo>> =
        lazy
        // Field Definitions
        let Location = FieldCodec.Repeated ValueCodec.Message<Google.Protobuf.SourceCodeInfo.Location> (1, "location")
        // Proto Definition Implementation
        { // ProtoDef<SourceCodeInfo>
            Name = "SourceCodeInfo"
            Empty = {
                Location = Location.GetDefault()
                }
            Size = fun (m: SourceCodeInfo) ->
                0
                + Location.CalcFieldSize m.Location
            Encode = fun (w: Google.Protobuf.CodedOutputStream) (m: SourceCodeInfo) ->
                Location.WriteField w m.Location
            Decode = fun (r: Google.Protobuf.CodedInputStream) ->
                let mutable builder = new Google.Protobuf.SourceCodeInfo.Builder()
                let mutable tag = 0
                while read r &tag do
                    builder.Put (tag, r)
                builder.Build
            EncodeJson = fun (o: JsonOptions) ->
                let writeLocation = Location.WriteJsonField o
                let encode (w: System.Text.Json.Utf8JsonWriter) (m: SourceCodeInfo) =
                    writeLocation w m.Location
                encode
            DecodeJson = fun (node: System.Text.Json.Nodes.JsonNode) ->
                let update value (kvPair: System.Collections.Generic.KeyValuePair<string,System.Text.Json.Nodes.JsonNode>) : SourceCodeInfo =
                    match kvPair.Key with
                    | "location" -> { value with Location = Location.ReadJsonField kvPair.Value }
                    | _ -> value
                Seq.fold update _SourceCodeInfo.empty (node.AsObject ())
        }
    static member empty
        with get() = Google.Protobuf._SourceCodeInfo.Proto.Value.Empty

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module GeneratedCodeInfo =

    [<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    module Annotation =

        [<System.Runtime.CompilerServices.IsByRefLike>]
        type Builder =
            struct
                val mutable Paths: RepeatedBuilder<int> // (1)
                val mutable SourceFile: string // (2)
                val mutable Begin: int // (3)
                val mutable End: int // (4)
            end
            with
            member x.Put ((tag, reader): int * Reader) =
                match tag with
                | 1 -> x.Paths.AddRange ((ValueCodec.Packed ValueCodec.Int32).ReadValue reader)
                | 2 -> x.SourceFile <- ValueCodec.String.ReadValue reader
                | 3 -> x.Begin <- ValueCodec.Int32.ReadValue reader
                | 4 -> x.End <- ValueCodec.Int32.ReadValue reader
                | _ -> reader.SkipLastField()
            member x.Build : Google.Protobuf.GeneratedCodeInfo.Annotation = {
                Paths = x.Paths.Build
                SourceFile = x.SourceFile |> orEmptyString
                Begin = x.Begin
                End = x.End
                }

    type private _Annotation = Annotation
    [<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.MessageConverter>)>]
    [<FsGrpc.Protobuf.Message>]
    type Annotation = {
        // Field Declarations
        /// <summary>
        /// Identifies the element in the original source .proto file. This field
        /// is formatted the same as SourceCodeInfo.Location.path.
        /// </summary>
        [<System.Text.Json.Serialization.JsonPropertyName("paths")>] Paths: int list // (1)
        /// <summary>Identifies the filesystem path to the original source .proto.</summary>
        [<System.Text.Json.Serialization.JsonPropertyName("sourceFile")>] SourceFile: string // (2)
        /// <summary>
        /// Identifies the starting offset in bytes in the generated code
        /// that relates to the identified object.
        /// </summary>
        [<System.Text.Json.Serialization.JsonPropertyName("begin")>] Begin: int // (3)
        /// <summary>
        /// Identifies the ending offset in bytes in the generated code that
        /// relates to the identified offset. The end offset should be one past
        /// the last relevant byte (so the length of the text = end - begin).
        /// </summary>
        [<System.Text.Json.Serialization.JsonPropertyName("end")>] End: int // (4)
        }
        with
        static member Proto : Lazy<ProtoDef<Annotation>> =
            lazy
            // Field Definitions
            let Paths = FieldCodec.Primitive (ValueCodec.Packed ValueCodec.Int32) (1, "paths")
            let SourceFile = FieldCodec.Primitive ValueCodec.String (2, "sourceFile")
            let Begin = FieldCodec.Primitive ValueCodec.Int32 (3, "begin")
            let End = FieldCodec.Primitive ValueCodec.Int32 (4, "end")
            // Proto Definition Implementation
            { // ProtoDef<Annotation>
                Name = "Annotation"
                Empty = {
                    Paths = Paths.GetDefault()
                    SourceFile = SourceFile.GetDefault()
                    Begin = Begin.GetDefault()
                    End = End.GetDefault()
                    }
                Size = fun (m: Annotation) ->
                    0
                    + Paths.CalcFieldSize m.Paths
                    + SourceFile.CalcFieldSize m.SourceFile
                    + Begin.CalcFieldSize m.Begin
                    + End.CalcFieldSize m.End
                Encode = fun (w: Google.Protobuf.CodedOutputStream) (m: Annotation) ->
                    Paths.WriteField w m.Paths
                    SourceFile.WriteField w m.SourceFile
                    Begin.WriteField w m.Begin
                    End.WriteField w m.End
                Decode = fun (r: Google.Protobuf.CodedInputStream) ->
                    let mutable builder = new Google.Protobuf.GeneratedCodeInfo.Annotation.Builder()
                    let mutable tag = 0
                    while read r &tag do
                        builder.Put (tag, r)
                    builder.Build
                EncodeJson = fun (o: JsonOptions) ->
                    let writePaths = Paths.WriteJsonField o
                    let writeSourceFile = SourceFile.WriteJsonField o
                    let writeBegin = Begin.WriteJsonField o
                    let writeEnd = End.WriteJsonField o
                    let encode (w: System.Text.Json.Utf8JsonWriter) (m: Annotation) =
                        writePaths w m.Paths
                        writeSourceFile w m.SourceFile
                        writeBegin w m.Begin
                        writeEnd w m.End
                    encode
                DecodeJson = fun (node: System.Text.Json.Nodes.JsonNode) ->
                    let update value (kvPair: System.Collections.Generic.KeyValuePair<string,System.Text.Json.Nodes.JsonNode>) : Annotation =
                        match kvPair.Key with
                        | "paths" -> { value with Paths = Paths.ReadJsonField kvPair.Value }
                        | "sourceFile" -> { value with SourceFile = SourceFile.ReadJsonField kvPair.Value }
                        | "begin" -> { value with Begin = Begin.ReadJsonField kvPair.Value }
                        | "end" -> { value with End = End.ReadJsonField kvPair.Value }
                        | _ -> value
                    Seq.fold update _Annotation.empty (node.AsObject ())
            }
        static member empty
            with get() = Google.Protobuf.GeneratedCodeInfo._Annotation.Proto.Value.Empty

    [<System.Runtime.CompilerServices.IsByRefLike>]
    type Builder =
        struct
            val mutable Annotations: RepeatedBuilder<Google.Protobuf.GeneratedCodeInfo.Annotation> // (1)
        end
        with
        member x.Put ((tag, reader): int * Reader) =
            match tag with
            | 1 -> x.Annotations.Add (ValueCodec.Message<Google.Protobuf.GeneratedCodeInfo.Annotation>.ReadValue reader)
            | _ -> reader.SkipLastField()
        member x.Build : Google.Protobuf.GeneratedCodeInfo = {
            Annotations = x.Annotations.Build
            }

/// <summary>
/// Describes the relationship between generated code and its original source
/// file. A GeneratedCodeInfo message is associated with only one generated
/// source file, but may contain references to different source .proto files.
/// </summary>
type private _GeneratedCodeInfo = GeneratedCodeInfo
[<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.MessageConverter>)>]
[<FsGrpc.Protobuf.Message>]
type GeneratedCodeInfo = {
    // Field Declarations
    /// <summary>
    /// An Annotation connects some span of text in generated code to an element
    /// of its generating .proto file.
    /// </summary>
    [<System.Text.Json.Serialization.JsonPropertyName("annotations")>] Annotations: Google.Protobuf.GeneratedCodeInfo.Annotation list // (1)
    }
    with
    static member Proto : Lazy<ProtoDef<GeneratedCodeInfo>> =
        lazy
        // Field Definitions
        let Annotations = FieldCodec.Repeated ValueCodec.Message<Google.Protobuf.GeneratedCodeInfo.Annotation> (1, "annotations")
        // Proto Definition Implementation
        { // ProtoDef<GeneratedCodeInfo>
            Name = "GeneratedCodeInfo"
            Empty = {
                Annotations = Annotations.GetDefault()
                }
            Size = fun (m: GeneratedCodeInfo) ->
                0
                + Annotations.CalcFieldSize m.Annotations
            Encode = fun (w: Google.Protobuf.CodedOutputStream) (m: GeneratedCodeInfo) ->
                Annotations.WriteField w m.Annotations
            Decode = fun (r: Google.Protobuf.CodedInputStream) ->
                let mutable builder = new Google.Protobuf.GeneratedCodeInfo.Builder()
                let mutable tag = 0
                while read r &tag do
                    builder.Put (tag, r)
                builder.Build
            EncodeJson = fun (o: JsonOptions) ->
                let writeAnnotations = Annotations.WriteJsonField o
                let encode (w: System.Text.Json.Utf8JsonWriter) (m: GeneratedCodeInfo) =
                    writeAnnotations w m.Annotations
                encode
            DecodeJson = fun (node: System.Text.Json.Nodes.JsonNode) ->
                let update value (kvPair: System.Collections.Generic.KeyValuePair<string,System.Text.Json.Nodes.JsonNode>) : GeneratedCodeInfo =
                    match kvPair.Key with
                    | "annotations" -> { value with Annotations = Annotations.ReadJsonField kvPair.Value }
                    | _ -> value
                Seq.fold update _GeneratedCodeInfo.empty (node.AsObject ())
        }
    static member empty
        with get() = Google.Protobuf._GeneratedCodeInfo.Proto.Value.Empty

namespace Google.Protobuf.Optics
open Focal.Core
module FileDescriptorSet =
    let _id : ILens'<Google.Protobuf.FileDescriptorSet,Google.Protobuf.FileDescriptorSet> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FileDescriptorSet) -> s }
            _setter = { _over = fun a2b (s: Google.Protobuf.FileDescriptorSet) -> a2b s }
        }
    let ``files`` : ILens'<Google.Protobuf.FileDescriptorSet,Google.Protobuf.FileDescriptorProto list> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FileDescriptorSet) -> s.Files }
            _setter = { _over = fun a2b s -> { s with Files = a2b s.Files } }
        }
module FileDescriptorProto =
    let _id : ILens'<Google.Protobuf.FileDescriptorProto,Google.Protobuf.FileDescriptorProto> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FileDescriptorProto) -> s }
            _setter = { _over = fun a2b (s: Google.Protobuf.FileDescriptorProto) -> a2b s }
        }
    let ``name`` : ILens'<Google.Protobuf.FileDescriptorProto,string> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FileDescriptorProto) -> s.Name }
            _setter = { _over = fun a2b s -> { s with Name = a2b s.Name } }
        }
    let ``package`` : ILens'<Google.Protobuf.FileDescriptorProto,string> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FileDescriptorProto) -> s.Package }
            _setter = { _over = fun a2b s -> { s with Package = a2b s.Package } }
        }
    let ``dependencies`` : ILens'<Google.Protobuf.FileDescriptorProto,string list> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FileDescriptorProto) -> s.Dependencies }
            _setter = { _over = fun a2b s -> { s with Dependencies = a2b s.Dependencies } }
        }
    let ``publicDependencies`` : ILens'<Google.Protobuf.FileDescriptorProto,int list> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FileDescriptorProto) -> s.PublicDependencies }
            _setter = { _over = fun a2b s -> { s with PublicDependencies = a2b s.PublicDependencies } }
        }
    let ``weakDependencies`` : ILens'<Google.Protobuf.FileDescriptorProto,int list> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FileDescriptorProto) -> s.WeakDependencies }
            _setter = { _over = fun a2b s -> { s with WeakDependencies = a2b s.WeakDependencies } }
        }
    let ``messageTypes`` : ILens'<Google.Protobuf.FileDescriptorProto,Google.Protobuf.DescriptorProto list> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FileDescriptorProto) -> s.MessageTypes }
            _setter = { _over = fun a2b s -> { s with MessageTypes = a2b s.MessageTypes } }
        }
    let ``enumTypes`` : ILens'<Google.Protobuf.FileDescriptorProto,Google.Protobuf.EnumDescriptorProto list> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FileDescriptorProto) -> s.EnumTypes }
            _setter = { _over = fun a2b s -> { s with EnumTypes = a2b s.EnumTypes } }
        }
    let ``services`` : ILens'<Google.Protobuf.FileDescriptorProto,Google.Protobuf.ServiceDescriptorProto list> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FileDescriptorProto) -> s.Services }
            _setter = { _over = fun a2b s -> { s with Services = a2b s.Services } }
        }
    let ``extensions`` : ILens'<Google.Protobuf.FileDescriptorProto,Google.Protobuf.FieldDescriptorProto list> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FileDescriptorProto) -> s.Extensions }
            _setter = { _over = fun a2b s -> { s with Extensions = a2b s.Extensions } }
        }
    let ``options`` : ILens'<Google.Protobuf.FileDescriptorProto,Google.Protobuf.FileOptions option> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FileDescriptorProto) -> s.Options }
            _setter = { _over = fun a2b s -> { s with Options = a2b s.Options } }
        }
    let ``sourceCodeInfo`` : ILens'<Google.Protobuf.FileDescriptorProto,Google.Protobuf.SourceCodeInfo option> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FileDescriptorProto) -> s.SourceCodeInfo }
            _setter = { _over = fun a2b s -> { s with SourceCodeInfo = a2b s.SourceCodeInfo } }
        }
    let ``syntax`` : ILens'<Google.Protobuf.FileDescriptorProto,string> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FileDescriptorProto) -> s.Syntax }
            _setter = { _over = fun a2b s -> { s with Syntax = a2b s.Syntax } }
        }
module DescriptorProto =
    let _id : ILens'<Google.Protobuf.DescriptorProto,Google.Protobuf.DescriptorProto> =
        {
            _getter = { _get = fun (s: Google.Protobuf.DescriptorProto) -> s }
            _setter = { _over = fun a2b (s: Google.Protobuf.DescriptorProto) -> a2b s }
        }
    let ``name`` : ILens'<Google.Protobuf.DescriptorProto,string> =
        {
            _getter = { _get = fun (s: Google.Protobuf.DescriptorProto) -> s.Name }
            _setter = { _over = fun a2b s -> { s with Name = a2b s.Name } }
        }
    let ``fields`` : ILens'<Google.Protobuf.DescriptorProto,Google.Protobuf.FieldDescriptorProto list> =
        {
            _getter = { _get = fun (s: Google.Protobuf.DescriptorProto) -> s.Fields }
            _setter = { _over = fun a2b s -> { s with Fields = a2b s.Fields } }
        }
    let ``extensions`` : ILens'<Google.Protobuf.DescriptorProto,Google.Protobuf.FieldDescriptorProto list> =
        {
            _getter = { _get = fun (s: Google.Protobuf.DescriptorProto) -> s.Extensions }
            _setter = { _over = fun a2b s -> { s with Extensions = a2b s.Extensions } }
        }
    let ``nestedTypes`` : ILens'<Google.Protobuf.DescriptorProto,Google.Protobuf.DescriptorProto list> =
        {
            _getter = { _get = fun (s: Google.Protobuf.DescriptorProto) -> s.NestedTypes }
            _setter = { _over = fun a2b s -> { s with NestedTypes = a2b s.NestedTypes } }
        }
    let ``enumTypes`` : ILens'<Google.Protobuf.DescriptorProto,Google.Protobuf.EnumDescriptorProto list> =
        {
            _getter = { _get = fun (s: Google.Protobuf.DescriptorProto) -> s.EnumTypes }
            _setter = { _over = fun a2b s -> { s with EnumTypes = a2b s.EnumTypes } }
        }
    let ``extensionRanges`` : ILens'<Google.Protobuf.DescriptorProto,Google.Protobuf.DescriptorProto.ExtensionRange list> =
        {
            _getter = { _get = fun (s: Google.Protobuf.DescriptorProto) -> s.ExtensionRanges }
            _setter = { _over = fun a2b s -> { s with ExtensionRanges = a2b s.ExtensionRanges } }
        }
    let ``oneofDecls`` : ILens'<Google.Protobuf.DescriptorProto,Google.Protobuf.OneofDescriptorProto list> =
        {
            _getter = { _get = fun (s: Google.Protobuf.DescriptorProto) -> s.OneofDecls }
            _setter = { _over = fun a2b s -> { s with OneofDecls = a2b s.OneofDecls } }
        }
    let ``options`` : ILens'<Google.Protobuf.DescriptorProto,Google.Protobuf.MessageOptions option> =
        {
            _getter = { _get = fun (s: Google.Protobuf.DescriptorProto) -> s.Options }
            _setter = { _over = fun a2b s -> { s with Options = a2b s.Options } }
        }
    let ``reservedRanges`` : ILens'<Google.Protobuf.DescriptorProto,Google.Protobuf.DescriptorProto.ReservedRange list> =
        {
            _getter = { _get = fun (s: Google.Protobuf.DescriptorProto) -> s.ReservedRanges }
            _setter = { _over = fun a2b s -> { s with ReservedRanges = a2b s.ReservedRanges } }
        }
    let ``reservedNames`` : ILens'<Google.Protobuf.DescriptorProto,string list> =
        {
            _getter = { _get = fun (s: Google.Protobuf.DescriptorProto) -> s.ReservedNames }
            _setter = { _over = fun a2b s -> { s with ReservedNames = a2b s.ReservedNames } }
        }
    module ExtensionRange =
        let _id : ILens'<Google.Protobuf.DescriptorProto.ExtensionRange,Google.Protobuf.DescriptorProto.ExtensionRange> =
            {
                _getter = { _get = fun (s: Google.Protobuf.DescriptorProto.ExtensionRange) -> s }
                _setter = { _over = fun a2b (s: Google.Protobuf.DescriptorProto.ExtensionRange) -> a2b s }
            }
        let ``start`` : ILens'<Google.Protobuf.DescriptorProto.ExtensionRange,int> =
            {
                _getter = { _get = fun (s: Google.Protobuf.DescriptorProto.ExtensionRange) -> s.Start }
                _setter = { _over = fun a2b s -> { s with Start = a2b s.Start } }
            }
        let ``end`` : ILens'<Google.Protobuf.DescriptorProto.ExtensionRange,int> =
            {
                _getter = { _get = fun (s: Google.Protobuf.DescriptorProto.ExtensionRange) -> s.End }
                _setter = { _over = fun a2b s -> { s with End = a2b s.End } }
            }
        let ``options`` : ILens'<Google.Protobuf.DescriptorProto.ExtensionRange,Google.Protobuf.ExtensionRangeOptions option> =
            {
                _getter = { _get = fun (s: Google.Protobuf.DescriptorProto.ExtensionRange) -> s.Options }
                _setter = { _over = fun a2b s -> { s with Options = a2b s.Options } }
            }
    module ReservedRange =
        let _id : ILens'<Google.Protobuf.DescriptorProto.ReservedRange,Google.Protobuf.DescriptorProto.ReservedRange> =
            {
                _getter = { _get = fun (s: Google.Protobuf.DescriptorProto.ReservedRange) -> s }
                _setter = { _over = fun a2b (s: Google.Protobuf.DescriptorProto.ReservedRange) -> a2b s }
            }
        let ``start`` : ILens'<Google.Protobuf.DescriptorProto.ReservedRange,int> =
            {
                _getter = { _get = fun (s: Google.Protobuf.DescriptorProto.ReservedRange) -> s.Start }
                _setter = { _over = fun a2b s -> { s with Start = a2b s.Start } }
            }
        let ``end`` : ILens'<Google.Protobuf.DescriptorProto.ReservedRange,int> =
            {
                _getter = { _get = fun (s: Google.Protobuf.DescriptorProto.ReservedRange) -> s.End }
                _setter = { _over = fun a2b s -> { s with End = a2b s.End } }
            }
module ExtensionRangeOptions =
    let _id : ILens'<Google.Protobuf.ExtensionRangeOptions,Google.Protobuf.ExtensionRangeOptions> =
        {
            _getter = { _get = fun (s: Google.Protobuf.ExtensionRangeOptions) -> s }
            _setter = { _over = fun a2b (s: Google.Protobuf.ExtensionRangeOptions) -> a2b s }
        }
    let ``uninterpretedOptions`` : ILens'<Google.Protobuf.ExtensionRangeOptions,Google.Protobuf.UninterpretedOption list> =
        {
            _getter = { _get = fun (s: Google.Protobuf.ExtensionRangeOptions) -> s.UninterpretedOptions }
            _setter = { _over = fun a2b s -> { s with UninterpretedOptions = a2b s.UninterpretedOptions } }
        }
module FieldDescriptorProto =
    let _id : ILens'<Google.Protobuf.FieldDescriptorProto,Google.Protobuf.FieldDescriptorProto> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FieldDescriptorProto) -> s }
            _setter = { _over = fun a2b (s: Google.Protobuf.FieldDescriptorProto) -> a2b s }
        }
    let ``name`` : ILens'<Google.Protobuf.FieldDescriptorProto,string> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FieldDescriptorProto) -> s.Name }
            _setter = { _over = fun a2b s -> { s with Name = a2b s.Name } }
        }
    let ``number`` : ILens'<Google.Protobuf.FieldDescriptorProto,int> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FieldDescriptorProto) -> s.Number }
            _setter = { _over = fun a2b s -> { s with Number = a2b s.Number } }
        }
    let ``label`` : ILens'<Google.Protobuf.FieldDescriptorProto,Google.Protobuf.FieldDescriptorProto.Label> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FieldDescriptorProto) -> s.Label }
            _setter = { _over = fun a2b s -> { s with Label = a2b s.Label } }
        }
    let ``type`` : ILens'<Google.Protobuf.FieldDescriptorProto,Google.Protobuf.FieldDescriptorProto.Type> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FieldDescriptorProto) -> s.Type }
            _setter = { _over = fun a2b s -> { s with Type = a2b s.Type } }
        }
    let ``typeName`` : ILens'<Google.Protobuf.FieldDescriptorProto,string> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FieldDescriptorProto) -> s.TypeName }
            _setter = { _over = fun a2b s -> { s with TypeName = a2b s.TypeName } }
        }
    let ``extendee`` : ILens'<Google.Protobuf.FieldDescriptorProto,string> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FieldDescriptorProto) -> s.Extendee }
            _setter = { _over = fun a2b s -> { s with Extendee = a2b s.Extendee } }
        }
    let ``defaultValue`` : ILens'<Google.Protobuf.FieldDescriptorProto,string> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FieldDescriptorProto) -> s.DefaultValue }
            _setter = { _over = fun a2b s -> { s with DefaultValue = a2b s.DefaultValue } }
        }
    let ``oneofIndex`` : ILens'<Google.Protobuf.FieldDescriptorProto,int option> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FieldDescriptorProto) -> s.OneofIndex }
            _setter = { _over = fun a2b s -> { s with OneofIndex = a2b s.OneofIndex } }
        }
    let ``jsonName`` : ILens'<Google.Protobuf.FieldDescriptorProto,string> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FieldDescriptorProto) -> s.JsonName }
            _setter = { _over = fun a2b s -> { s with JsonName = a2b s.JsonName } }
        }
    let ``options`` : ILens'<Google.Protobuf.FieldDescriptorProto,Google.Protobuf.FieldOptions option> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FieldDescriptorProto) -> s.Options }
            _setter = { _over = fun a2b s -> { s with Options = a2b s.Options } }
        }
    let ``proto3Optional`` : ILens'<Google.Protobuf.FieldDescriptorProto,bool> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FieldDescriptorProto) -> s.Proto3Optional }
            _setter = { _over = fun a2b s -> { s with Proto3Optional = a2b s.Proto3Optional } }
        }
module OneofDescriptorProto =
    let _id : ILens'<Google.Protobuf.OneofDescriptorProto,Google.Protobuf.OneofDescriptorProto> =
        {
            _getter = { _get = fun (s: Google.Protobuf.OneofDescriptorProto) -> s }
            _setter = { _over = fun a2b (s: Google.Protobuf.OneofDescriptorProto) -> a2b s }
        }
    let ``name`` : ILens'<Google.Protobuf.OneofDescriptorProto,string> =
        {
            _getter = { _get = fun (s: Google.Protobuf.OneofDescriptorProto) -> s.Name }
            _setter = { _over = fun a2b s -> { s with Name = a2b s.Name } }
        }
    let ``options`` : ILens'<Google.Protobuf.OneofDescriptorProto,Google.Protobuf.OneofOptions option> =
        {
            _getter = { _get = fun (s: Google.Protobuf.OneofDescriptorProto) -> s.Options }
            _setter = { _over = fun a2b s -> { s with Options = a2b s.Options } }
        }
module EnumDescriptorProto =
    let _id : ILens'<Google.Protobuf.EnumDescriptorProto,Google.Protobuf.EnumDescriptorProto> =
        {
            _getter = { _get = fun (s: Google.Protobuf.EnumDescriptorProto) -> s }
            _setter = { _over = fun a2b (s: Google.Protobuf.EnumDescriptorProto) -> a2b s }
        }
    let ``name`` : ILens'<Google.Protobuf.EnumDescriptorProto,string> =
        {
            _getter = { _get = fun (s: Google.Protobuf.EnumDescriptorProto) -> s.Name }
            _setter = { _over = fun a2b s -> { s with Name = a2b s.Name } }
        }
    let ``values`` : ILens'<Google.Protobuf.EnumDescriptorProto,Google.Protobuf.EnumValueDescriptorProto list> =
        {
            _getter = { _get = fun (s: Google.Protobuf.EnumDescriptorProto) -> s.Values }
            _setter = { _over = fun a2b s -> { s with Values = a2b s.Values } }
        }
    let ``options`` : ILens'<Google.Protobuf.EnumDescriptorProto,Google.Protobuf.EnumOptions option> =
        {
            _getter = { _get = fun (s: Google.Protobuf.EnumDescriptorProto) -> s.Options }
            _setter = { _over = fun a2b s -> { s with Options = a2b s.Options } }
        }
    let ``reservedRanges`` : ILens'<Google.Protobuf.EnumDescriptorProto,Google.Protobuf.EnumDescriptorProto.EnumReservedRange list> =
        {
            _getter = { _get = fun (s: Google.Protobuf.EnumDescriptorProto) -> s.ReservedRanges }
            _setter = { _over = fun a2b s -> { s with ReservedRanges = a2b s.ReservedRanges } }
        }
    let ``reservedNames`` : ILens'<Google.Protobuf.EnumDescriptorProto,string list> =
        {
            _getter = { _get = fun (s: Google.Protobuf.EnumDescriptorProto) -> s.ReservedNames }
            _setter = { _over = fun a2b s -> { s with ReservedNames = a2b s.ReservedNames } }
        }
    module EnumReservedRange =
        let _id : ILens'<Google.Protobuf.EnumDescriptorProto.EnumReservedRange,Google.Protobuf.EnumDescriptorProto.EnumReservedRange> =
            {
                _getter = { _get = fun (s: Google.Protobuf.EnumDescriptorProto.EnumReservedRange) -> s }
                _setter = { _over = fun a2b (s: Google.Protobuf.EnumDescriptorProto.EnumReservedRange) -> a2b s }
            }
        let ``start`` : ILens'<Google.Protobuf.EnumDescriptorProto.EnumReservedRange,int> =
            {
                _getter = { _get = fun (s: Google.Protobuf.EnumDescriptorProto.EnumReservedRange) -> s.Start }
                _setter = { _over = fun a2b s -> { s with Start = a2b s.Start } }
            }
        let ``end`` : ILens'<Google.Protobuf.EnumDescriptorProto.EnumReservedRange,int> =
            {
                _getter = { _get = fun (s: Google.Protobuf.EnumDescriptorProto.EnumReservedRange) -> s.End }
                _setter = { _over = fun a2b s -> { s with End = a2b s.End } }
            }
module EnumValueDescriptorProto =
    let _id : ILens'<Google.Protobuf.EnumValueDescriptorProto,Google.Protobuf.EnumValueDescriptorProto> =
        {
            _getter = { _get = fun (s: Google.Protobuf.EnumValueDescriptorProto) -> s }
            _setter = { _over = fun a2b (s: Google.Protobuf.EnumValueDescriptorProto) -> a2b s }
        }
    let ``name`` : ILens'<Google.Protobuf.EnumValueDescriptorProto,string> =
        {
            _getter = { _get = fun (s: Google.Protobuf.EnumValueDescriptorProto) -> s.Name }
            _setter = { _over = fun a2b s -> { s with Name = a2b s.Name } }
        }
    let ``number`` : ILens'<Google.Protobuf.EnumValueDescriptorProto,int> =
        {
            _getter = { _get = fun (s: Google.Protobuf.EnumValueDescriptorProto) -> s.Number }
            _setter = { _over = fun a2b s -> { s with Number = a2b s.Number } }
        }
    let ``options`` : ILens'<Google.Protobuf.EnumValueDescriptorProto,Google.Protobuf.EnumValueOptions option> =
        {
            _getter = { _get = fun (s: Google.Protobuf.EnumValueDescriptorProto) -> s.Options }
            _setter = { _over = fun a2b s -> { s with Options = a2b s.Options } }
        }
module ServiceDescriptorProto =
    let _id : ILens'<Google.Protobuf.ServiceDescriptorProto,Google.Protobuf.ServiceDescriptorProto> =
        {
            _getter = { _get = fun (s: Google.Protobuf.ServiceDescriptorProto) -> s }
            _setter = { _over = fun a2b (s: Google.Protobuf.ServiceDescriptorProto) -> a2b s }
        }
    let ``name`` : ILens'<Google.Protobuf.ServiceDescriptorProto,string> =
        {
            _getter = { _get = fun (s: Google.Protobuf.ServiceDescriptorProto) -> s.Name }
            _setter = { _over = fun a2b s -> { s with Name = a2b s.Name } }
        }
    let ``methods`` : ILens'<Google.Protobuf.ServiceDescriptorProto,Google.Protobuf.MethodDescriptorProto list> =
        {
            _getter = { _get = fun (s: Google.Protobuf.ServiceDescriptorProto) -> s.Methods }
            _setter = { _over = fun a2b s -> { s with Methods = a2b s.Methods } }
        }
    let ``options`` : ILens'<Google.Protobuf.ServiceDescriptorProto,Google.Protobuf.ServiceOptions option> =
        {
            _getter = { _get = fun (s: Google.Protobuf.ServiceDescriptorProto) -> s.Options }
            _setter = { _over = fun a2b s -> { s with Options = a2b s.Options } }
        }
module MethodDescriptorProto =
    let _id : ILens'<Google.Protobuf.MethodDescriptorProto,Google.Protobuf.MethodDescriptorProto> =
        {
            _getter = { _get = fun (s: Google.Protobuf.MethodDescriptorProto) -> s }
            _setter = { _over = fun a2b (s: Google.Protobuf.MethodDescriptorProto) -> a2b s }
        }
    let ``name`` : ILens'<Google.Protobuf.MethodDescriptorProto,string> =
        {
            _getter = { _get = fun (s: Google.Protobuf.MethodDescriptorProto) -> s.Name }
            _setter = { _over = fun a2b s -> { s with Name = a2b s.Name } }
        }
    let ``inputType`` : ILens'<Google.Protobuf.MethodDescriptorProto,string> =
        {
            _getter = { _get = fun (s: Google.Protobuf.MethodDescriptorProto) -> s.InputType }
            _setter = { _over = fun a2b s -> { s with InputType = a2b s.InputType } }
        }
    let ``outputType`` : ILens'<Google.Protobuf.MethodDescriptorProto,string> =
        {
            _getter = { _get = fun (s: Google.Protobuf.MethodDescriptorProto) -> s.OutputType }
            _setter = { _over = fun a2b s -> { s with OutputType = a2b s.OutputType } }
        }
    let ``options`` : ILens'<Google.Protobuf.MethodDescriptorProto,Google.Protobuf.MethodOptions option> =
        {
            _getter = { _get = fun (s: Google.Protobuf.MethodDescriptorProto) -> s.Options }
            _setter = { _over = fun a2b s -> { s with Options = a2b s.Options } }
        }
    let ``clientStreaming`` : ILens'<Google.Protobuf.MethodDescriptorProto,bool> =
        {
            _getter = { _get = fun (s: Google.Protobuf.MethodDescriptorProto) -> s.ClientStreaming }
            _setter = { _over = fun a2b s -> { s with ClientStreaming = a2b s.ClientStreaming } }
        }
    let ``serverStreaming`` : ILens'<Google.Protobuf.MethodDescriptorProto,bool> =
        {
            _getter = { _get = fun (s: Google.Protobuf.MethodDescriptorProto) -> s.ServerStreaming }
            _setter = { _over = fun a2b s -> { s with ServerStreaming = a2b s.ServerStreaming } }
        }
module FileOptions =
    let _id : ILens'<Google.Protobuf.FileOptions,Google.Protobuf.FileOptions> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FileOptions) -> s }
            _setter = { _over = fun a2b (s: Google.Protobuf.FileOptions) -> a2b s }
        }
    let ``javaPackage`` : ILens'<Google.Protobuf.FileOptions,string> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FileOptions) -> s.JavaPackage }
            _setter = { _over = fun a2b s -> { s with JavaPackage = a2b s.JavaPackage } }
        }
    let ``javaOuterClassname`` : ILens'<Google.Protobuf.FileOptions,string> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FileOptions) -> s.JavaOuterClassname }
            _setter = { _over = fun a2b s -> { s with JavaOuterClassname = a2b s.JavaOuterClassname } }
        }
    let ``javaMultipleFiles`` : ILens'<Google.Protobuf.FileOptions,bool> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FileOptions) -> s.JavaMultipleFiles }
            _setter = { _over = fun a2b s -> { s with JavaMultipleFiles = a2b s.JavaMultipleFiles } }
        }
    let ``javaGenerateEqualsAndHash`` : ILens'<Google.Protobuf.FileOptions,bool> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FileOptions) -> s.JavaGenerateEqualsAndHash }
            _setter = { _over = fun a2b s -> { s with JavaGenerateEqualsAndHash = a2b s.JavaGenerateEqualsAndHash } }
        }
    let ``javaStringCheckUtf8`` : ILens'<Google.Protobuf.FileOptions,bool> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FileOptions) -> s.JavaStringCheckUtf8 }
            _setter = { _over = fun a2b s -> { s with JavaStringCheckUtf8 = a2b s.JavaStringCheckUtf8 } }
        }
    let ``optimizeFor`` : ILens'<Google.Protobuf.FileOptions,Google.Protobuf.FileOptions.OptimizeMode> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FileOptions) -> s.OptimizeFor }
            _setter = { _over = fun a2b s -> { s with OptimizeFor = a2b s.OptimizeFor } }
        }
    let ``goPackage`` : ILens'<Google.Protobuf.FileOptions,string> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FileOptions) -> s.GoPackage }
            _setter = { _over = fun a2b s -> { s with GoPackage = a2b s.GoPackage } }
        }
    let ``ccGenericServices`` : ILens'<Google.Protobuf.FileOptions,bool> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FileOptions) -> s.CcGenericServices }
            _setter = { _over = fun a2b s -> { s with CcGenericServices = a2b s.CcGenericServices } }
        }
    let ``javaGenericServices`` : ILens'<Google.Protobuf.FileOptions,bool> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FileOptions) -> s.JavaGenericServices }
            _setter = { _over = fun a2b s -> { s with JavaGenericServices = a2b s.JavaGenericServices } }
        }
    let ``pyGenericServices`` : ILens'<Google.Protobuf.FileOptions,bool> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FileOptions) -> s.PyGenericServices }
            _setter = { _over = fun a2b s -> { s with PyGenericServices = a2b s.PyGenericServices } }
        }
    let ``phpGenericServices`` : ILens'<Google.Protobuf.FileOptions,bool> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FileOptions) -> s.PhpGenericServices }
            _setter = { _over = fun a2b s -> { s with PhpGenericServices = a2b s.PhpGenericServices } }
        }
    let ``deprecated`` : ILens'<Google.Protobuf.FileOptions,bool> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FileOptions) -> s.Deprecated }
            _setter = { _over = fun a2b s -> { s with Deprecated = a2b s.Deprecated } }
        }
    let ``ccEnableArenas`` : ILens'<Google.Protobuf.FileOptions,bool> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FileOptions) -> s.CcEnableArenas }
            _setter = { _over = fun a2b s -> { s with CcEnableArenas = a2b s.CcEnableArenas } }
        }
    let ``objcClassPrefix`` : ILens'<Google.Protobuf.FileOptions,string> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FileOptions) -> s.ObjcClassPrefix }
            _setter = { _over = fun a2b s -> { s with ObjcClassPrefix = a2b s.ObjcClassPrefix } }
        }
    let ``csharpNamespace`` : ILens'<Google.Protobuf.FileOptions,string> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FileOptions) -> s.CsharpNamespace }
            _setter = { _over = fun a2b s -> { s with CsharpNamespace = a2b s.CsharpNamespace } }
        }
    let ``swiftPrefix`` : ILens'<Google.Protobuf.FileOptions,string> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FileOptions) -> s.SwiftPrefix }
            _setter = { _over = fun a2b s -> { s with SwiftPrefix = a2b s.SwiftPrefix } }
        }
    let ``phpClassPrefix`` : ILens'<Google.Protobuf.FileOptions,string> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FileOptions) -> s.PhpClassPrefix }
            _setter = { _over = fun a2b s -> { s with PhpClassPrefix = a2b s.PhpClassPrefix } }
        }
    let ``phpNamespace`` : ILens'<Google.Protobuf.FileOptions,string> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FileOptions) -> s.PhpNamespace }
            _setter = { _over = fun a2b s -> { s with PhpNamespace = a2b s.PhpNamespace } }
        }
    let ``phpMetadataNamespace`` : ILens'<Google.Protobuf.FileOptions,string> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FileOptions) -> s.PhpMetadataNamespace }
            _setter = { _over = fun a2b s -> { s with PhpMetadataNamespace = a2b s.PhpMetadataNamespace } }
        }
    let ``rubyPackage`` : ILens'<Google.Protobuf.FileOptions,string> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FileOptions) -> s.RubyPackage }
            _setter = { _over = fun a2b s -> { s with RubyPackage = a2b s.RubyPackage } }
        }
    let ``uninterpretedOptions`` : ILens'<Google.Protobuf.FileOptions,Google.Protobuf.UninterpretedOption list> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FileOptions) -> s.UninterpretedOptions }
            _setter = { _over = fun a2b s -> { s with UninterpretedOptions = a2b s.UninterpretedOptions } }
        }
module MessageOptions =
    let _id : ILens'<Google.Protobuf.MessageOptions,Google.Protobuf.MessageOptions> =
        {
            _getter = { _get = fun (s: Google.Protobuf.MessageOptions) -> s }
            _setter = { _over = fun a2b (s: Google.Protobuf.MessageOptions) -> a2b s }
        }
    let ``messageSetWireFormat`` : ILens'<Google.Protobuf.MessageOptions,bool> =
        {
            _getter = { _get = fun (s: Google.Protobuf.MessageOptions) -> s.MessageSetWireFormat }
            _setter = { _over = fun a2b s -> { s with MessageSetWireFormat = a2b s.MessageSetWireFormat } }
        }
    let ``noStandardDescriptorAccessor`` : ILens'<Google.Protobuf.MessageOptions,bool> =
        {
            _getter = { _get = fun (s: Google.Protobuf.MessageOptions) -> s.NoStandardDescriptorAccessor }
            _setter = { _over = fun a2b s -> { s with NoStandardDescriptorAccessor = a2b s.NoStandardDescriptorAccessor } }
        }
    let ``deprecated`` : ILens'<Google.Protobuf.MessageOptions,bool> =
        {
            _getter = { _get = fun (s: Google.Protobuf.MessageOptions) -> s.Deprecated }
            _setter = { _over = fun a2b s -> { s with Deprecated = a2b s.Deprecated } }
        }
    let ``mapEntry`` : ILens'<Google.Protobuf.MessageOptions,bool> =
        {
            _getter = { _get = fun (s: Google.Protobuf.MessageOptions) -> s.MapEntry }
            _setter = { _over = fun a2b s -> { s with MapEntry = a2b s.MapEntry } }
        }
    let ``uninterpretedOptions`` : ILens'<Google.Protobuf.MessageOptions,Google.Protobuf.UninterpretedOption list> =
        {
            _getter = { _get = fun (s: Google.Protobuf.MessageOptions) -> s.UninterpretedOptions }
            _setter = { _over = fun a2b s -> { s with UninterpretedOptions = a2b s.UninterpretedOptions } }
        }
module FieldOptions =
    let _id : ILens'<Google.Protobuf.FieldOptions,Google.Protobuf.FieldOptions> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FieldOptions) -> s }
            _setter = { _over = fun a2b (s: Google.Protobuf.FieldOptions) -> a2b s }
        }
    let ``ctype`` : ILens'<Google.Protobuf.FieldOptions,Google.Protobuf.FieldOptions.CType> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FieldOptions) -> s.Ctype }
            _setter = { _over = fun a2b s -> { s with Ctype = a2b s.Ctype } }
        }
    let ``packed`` : ILens'<Google.Protobuf.FieldOptions,bool> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FieldOptions) -> s.Packed }
            _setter = { _over = fun a2b s -> { s with Packed = a2b s.Packed } }
        }
    let ``jstype`` : ILens'<Google.Protobuf.FieldOptions,Google.Protobuf.FieldOptions.JSType> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FieldOptions) -> s.Jstype }
            _setter = { _over = fun a2b s -> { s with Jstype = a2b s.Jstype } }
        }
    let ``lazy`` : ILens'<Google.Protobuf.FieldOptions,bool> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FieldOptions) -> s.Lazy }
            _setter = { _over = fun a2b s -> { s with Lazy = a2b s.Lazy } }
        }
    let ``deprecated`` : ILens'<Google.Protobuf.FieldOptions,bool> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FieldOptions) -> s.Deprecated }
            _setter = { _over = fun a2b s -> { s with Deprecated = a2b s.Deprecated } }
        }
    let ``weak`` : ILens'<Google.Protobuf.FieldOptions,bool> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FieldOptions) -> s.Weak }
            _setter = { _over = fun a2b s -> { s with Weak = a2b s.Weak } }
        }
    let ``uninterpretedOptions`` : ILens'<Google.Protobuf.FieldOptions,Google.Protobuf.UninterpretedOption list> =
        {
            _getter = { _get = fun (s: Google.Protobuf.FieldOptions) -> s.UninterpretedOptions }
            _setter = { _over = fun a2b s -> { s with UninterpretedOptions = a2b s.UninterpretedOptions } }
        }
module OneofOptions =
    let _id : ILens'<Google.Protobuf.OneofOptions,Google.Protobuf.OneofOptions> =
        {
            _getter = { _get = fun (s: Google.Protobuf.OneofOptions) -> s }
            _setter = { _over = fun a2b (s: Google.Protobuf.OneofOptions) -> a2b s }
        }
    let ``uninterpretedOptions`` : ILens'<Google.Protobuf.OneofOptions,Google.Protobuf.UninterpretedOption list> =
        {
            _getter = { _get = fun (s: Google.Protobuf.OneofOptions) -> s.UninterpretedOptions }
            _setter = { _over = fun a2b s -> { s with UninterpretedOptions = a2b s.UninterpretedOptions } }
        }
module EnumOptions =
    let _id : ILens'<Google.Protobuf.EnumOptions,Google.Protobuf.EnumOptions> =
        {
            _getter = { _get = fun (s: Google.Protobuf.EnumOptions) -> s }
            _setter = { _over = fun a2b (s: Google.Protobuf.EnumOptions) -> a2b s }
        }
    let ``allowAlias`` : ILens'<Google.Protobuf.EnumOptions,bool> =
        {
            _getter = { _get = fun (s: Google.Protobuf.EnumOptions) -> s.AllowAlias }
            _setter = { _over = fun a2b s -> { s with AllowAlias = a2b s.AllowAlias } }
        }
    let ``deprecated`` : ILens'<Google.Protobuf.EnumOptions,bool> =
        {
            _getter = { _get = fun (s: Google.Protobuf.EnumOptions) -> s.Deprecated }
            _setter = { _over = fun a2b s -> { s with Deprecated = a2b s.Deprecated } }
        }
    let ``uninterpretedOptions`` : ILens'<Google.Protobuf.EnumOptions,Google.Protobuf.UninterpretedOption list> =
        {
            _getter = { _get = fun (s: Google.Protobuf.EnumOptions) -> s.UninterpretedOptions }
            _setter = { _over = fun a2b s -> { s with UninterpretedOptions = a2b s.UninterpretedOptions } }
        }
module EnumValueOptions =
    let _id : ILens'<Google.Protobuf.EnumValueOptions,Google.Protobuf.EnumValueOptions> =
        {
            _getter = { _get = fun (s: Google.Protobuf.EnumValueOptions) -> s }
            _setter = { _over = fun a2b (s: Google.Protobuf.EnumValueOptions) -> a2b s }
        }
    let ``deprecated`` : ILens'<Google.Protobuf.EnumValueOptions,bool> =
        {
            _getter = { _get = fun (s: Google.Protobuf.EnumValueOptions) -> s.Deprecated }
            _setter = { _over = fun a2b s -> { s with Deprecated = a2b s.Deprecated } }
        }
    let ``uninterpretedOptions`` : ILens'<Google.Protobuf.EnumValueOptions,Google.Protobuf.UninterpretedOption list> =
        {
            _getter = { _get = fun (s: Google.Protobuf.EnumValueOptions) -> s.UninterpretedOptions }
            _setter = { _over = fun a2b s -> { s with UninterpretedOptions = a2b s.UninterpretedOptions } }
        }
module ServiceOptions =
    let _id : ILens'<Google.Protobuf.ServiceOptions,Google.Protobuf.ServiceOptions> =
        {
            _getter = { _get = fun (s: Google.Protobuf.ServiceOptions) -> s }
            _setter = { _over = fun a2b (s: Google.Protobuf.ServiceOptions) -> a2b s }
        }
    let ``deprecated`` : ILens'<Google.Protobuf.ServiceOptions,bool> =
        {
            _getter = { _get = fun (s: Google.Protobuf.ServiceOptions) -> s.Deprecated }
            _setter = { _over = fun a2b s -> { s with Deprecated = a2b s.Deprecated } }
        }
    let ``uninterpretedOptions`` : ILens'<Google.Protobuf.ServiceOptions,Google.Protobuf.UninterpretedOption list> =
        {
            _getter = { _get = fun (s: Google.Protobuf.ServiceOptions) -> s.UninterpretedOptions }
            _setter = { _over = fun a2b s -> { s with UninterpretedOptions = a2b s.UninterpretedOptions } }
        }
module MethodOptions =
    let _id : ILens'<Google.Protobuf.MethodOptions,Google.Protobuf.MethodOptions> =
        {
            _getter = { _get = fun (s: Google.Protobuf.MethodOptions) -> s }
            _setter = { _over = fun a2b (s: Google.Protobuf.MethodOptions) -> a2b s }
        }
    let ``deprecated`` : ILens'<Google.Protobuf.MethodOptions,bool> =
        {
            _getter = { _get = fun (s: Google.Protobuf.MethodOptions) -> s.Deprecated }
            _setter = { _over = fun a2b s -> { s with Deprecated = a2b s.Deprecated } }
        }
    let ``idempotencyLevel`` : ILens'<Google.Protobuf.MethodOptions,Google.Protobuf.MethodOptions.IdempotencyLevel> =
        {
            _getter = { _get = fun (s: Google.Protobuf.MethodOptions) -> s.IdempotencyLevel }
            _setter = { _over = fun a2b s -> { s with IdempotencyLevel = a2b s.IdempotencyLevel } }
        }
    let ``uninterpretedOptions`` : ILens'<Google.Protobuf.MethodOptions,Google.Protobuf.UninterpretedOption list> =
        {
            _getter = { _get = fun (s: Google.Protobuf.MethodOptions) -> s.UninterpretedOptions }
            _setter = { _over = fun a2b s -> { s with UninterpretedOptions = a2b s.UninterpretedOptions } }
        }
module UninterpretedOption =
    let _id : ILens'<Google.Protobuf.UninterpretedOption,Google.Protobuf.UninterpretedOption> =
        {
            _getter = { _get = fun (s: Google.Protobuf.UninterpretedOption) -> s }
            _setter = { _over = fun a2b (s: Google.Protobuf.UninterpretedOption) -> a2b s }
        }
    module ValuePrisms =
        let ifIdentifierValue : IPrism'<Google.Protobuf.UninterpretedOption.ValueCase,string> =
            {
                _unto = fun a -> Google.Protobuf.UninterpretedOption.ValueCase.IdentifierValue a
                _which = fun s ->
                    match s with
                    | Google.Protobuf.UninterpretedOption.ValueCase.IdentifierValue a -> Ok a
                    | _ -> Error s
            }
        let ifPositiveIntValue : IPrism'<Google.Protobuf.UninterpretedOption.ValueCase,uint64> =
            {
                _unto = fun a -> Google.Protobuf.UninterpretedOption.ValueCase.PositiveIntValue a
                _which = fun s ->
                    match s with
                    | Google.Protobuf.UninterpretedOption.ValueCase.PositiveIntValue a -> Ok a
                    | _ -> Error s
            }
        let ifNegativeIntValue : IPrism'<Google.Protobuf.UninterpretedOption.ValueCase,int64> =
            {
                _unto = fun a -> Google.Protobuf.UninterpretedOption.ValueCase.NegativeIntValue a
                _which = fun s ->
                    match s with
                    | Google.Protobuf.UninterpretedOption.ValueCase.NegativeIntValue a -> Ok a
                    | _ -> Error s
            }
        let ifDoubleValue : IPrism'<Google.Protobuf.UninterpretedOption.ValueCase,double> =
            {
                _unto = fun a -> Google.Protobuf.UninterpretedOption.ValueCase.DoubleValue a
                _which = fun s ->
                    match s with
                    | Google.Protobuf.UninterpretedOption.ValueCase.DoubleValue a -> Ok a
                    | _ -> Error s
            }
        let ifStringValue : IPrism'<Google.Protobuf.UninterpretedOption.ValueCase,FsGrpc.Bytes> =
            {
                _unto = fun a -> Google.Protobuf.UninterpretedOption.ValueCase.StringValue a
                _which = fun s ->
                    match s with
                    | Google.Protobuf.UninterpretedOption.ValueCase.StringValue a -> Ok a
                    | _ -> Error s
            }
        let ifAggregateValue : IPrism'<Google.Protobuf.UninterpretedOption.ValueCase,string> =
            {
                _unto = fun a -> Google.Protobuf.UninterpretedOption.ValueCase.AggregateValue a
                _which = fun s ->
                    match s with
                    | Google.Protobuf.UninterpretedOption.ValueCase.AggregateValue a -> Ok a
                    | _ -> Error s
            }
    let ``names`` : ILens'<Google.Protobuf.UninterpretedOption,Google.Protobuf.UninterpretedOption.NamePart list> =
        {
            _getter = { _get = fun (s: Google.Protobuf.UninterpretedOption) -> s.Names }
            _setter = { _over = fun a2b s -> { s with Names = a2b s.Names } }
        }
    let ``value`` : ILens'<Google.Protobuf.UninterpretedOption,Google.Protobuf.UninterpretedOption.ValueCase> =
        {
            _getter = { _get = fun (s: Google.Protobuf.UninterpretedOption) -> s.Value }
            _setter = { _over = fun a2b s -> { s with Value = a2b s.Value } }
        }
    module NamePart =
        let _id : ILens'<Google.Protobuf.UninterpretedOption.NamePart,Google.Protobuf.UninterpretedOption.NamePart> =
            {
                _getter = { _get = fun (s: Google.Protobuf.UninterpretedOption.NamePart) -> s }
                _setter = { _over = fun a2b (s: Google.Protobuf.UninterpretedOption.NamePart) -> a2b s }
            }
        let ``namePart`` : ILens'<Google.Protobuf.UninterpretedOption.NamePart,string> =
            {
                _getter = { _get = fun (s: Google.Protobuf.UninterpretedOption.NamePart) -> s.NamePart }
                _setter = { _over = fun a2b s -> { s with NamePart = a2b s.NamePart } }
            }
        let ``isExtension`` : ILens'<Google.Protobuf.UninterpretedOption.NamePart,bool> =
            {
                _getter = { _get = fun (s: Google.Protobuf.UninterpretedOption.NamePart) -> s.IsExtension }
                _setter = { _over = fun a2b s -> { s with IsExtension = a2b s.IsExtension } }
            }
module SourceCodeInfo =
    let _id : ILens'<Google.Protobuf.SourceCodeInfo,Google.Protobuf.SourceCodeInfo> =
        {
            _getter = { _get = fun (s: Google.Protobuf.SourceCodeInfo) -> s }
            _setter = { _over = fun a2b (s: Google.Protobuf.SourceCodeInfo) -> a2b s }
        }
    let ``location`` : ILens'<Google.Protobuf.SourceCodeInfo,Google.Protobuf.SourceCodeInfo.Location list> =
        {
            _getter = { _get = fun (s: Google.Protobuf.SourceCodeInfo) -> s.Location }
            _setter = { _over = fun a2b s -> { s with Location = a2b s.Location } }
        }
    module Location =
        let _id : ILens'<Google.Protobuf.SourceCodeInfo.Location,Google.Protobuf.SourceCodeInfo.Location> =
            {
                _getter = { _get = fun (s: Google.Protobuf.SourceCodeInfo.Location) -> s }
                _setter = { _over = fun a2b (s: Google.Protobuf.SourceCodeInfo.Location) -> a2b s }
            }
        let ``paths`` : ILens'<Google.Protobuf.SourceCodeInfo.Location,int list> =
            {
                _getter = { _get = fun (s: Google.Protobuf.SourceCodeInfo.Location) -> s.Paths }
                _setter = { _over = fun a2b s -> { s with Paths = a2b s.Paths } }
            }
        let ``spans`` : ILens'<Google.Protobuf.SourceCodeInfo.Location,int list> =
            {
                _getter = { _get = fun (s: Google.Protobuf.SourceCodeInfo.Location) -> s.Spans }
                _setter = { _over = fun a2b s -> { s with Spans = a2b s.Spans } }
            }
        let ``leadingComments`` : ILens'<Google.Protobuf.SourceCodeInfo.Location,string> =
            {
                _getter = { _get = fun (s: Google.Protobuf.SourceCodeInfo.Location) -> s.LeadingComments }
                _setter = { _over = fun a2b s -> { s with LeadingComments = a2b s.LeadingComments } }
            }
        let ``trailingComments`` : ILens'<Google.Protobuf.SourceCodeInfo.Location,string> =
            {
                _getter = { _get = fun (s: Google.Protobuf.SourceCodeInfo.Location) -> s.TrailingComments }
                _setter = { _over = fun a2b s -> { s with TrailingComments = a2b s.TrailingComments } }
            }
        let ``leadingDetachedComments`` : ILens'<Google.Protobuf.SourceCodeInfo.Location,string list> =
            {
                _getter = { _get = fun (s: Google.Protobuf.SourceCodeInfo.Location) -> s.LeadingDetachedComments }
                _setter = { _over = fun a2b s -> { s with LeadingDetachedComments = a2b s.LeadingDetachedComments } }
            }
module GeneratedCodeInfo =
    let _id : ILens'<Google.Protobuf.GeneratedCodeInfo,Google.Protobuf.GeneratedCodeInfo> =
        {
            _getter = { _get = fun (s: Google.Protobuf.GeneratedCodeInfo) -> s }
            _setter = { _over = fun a2b (s: Google.Protobuf.GeneratedCodeInfo) -> a2b s }
        }
    let ``annotations`` : ILens'<Google.Protobuf.GeneratedCodeInfo,Google.Protobuf.GeneratedCodeInfo.Annotation list> =
        {
            _getter = { _get = fun (s: Google.Protobuf.GeneratedCodeInfo) -> s.Annotations }
            _setter = { _over = fun a2b s -> { s with Annotations = a2b s.Annotations } }
        }
    module Annotation =
        let _id : ILens'<Google.Protobuf.GeneratedCodeInfo.Annotation,Google.Protobuf.GeneratedCodeInfo.Annotation> =
            {
                _getter = { _get = fun (s: Google.Protobuf.GeneratedCodeInfo.Annotation) -> s }
                _setter = { _over = fun a2b (s: Google.Protobuf.GeneratedCodeInfo.Annotation) -> a2b s }
            }
        let ``paths`` : ILens'<Google.Protobuf.GeneratedCodeInfo.Annotation,int list> =
            {
                _getter = { _get = fun (s: Google.Protobuf.GeneratedCodeInfo.Annotation) -> s.Paths }
                _setter = { _over = fun a2b s -> { s with Paths = a2b s.Paths } }
            }
        let ``sourceFile`` : ILens'<Google.Protobuf.GeneratedCodeInfo.Annotation,string> =
            {
                _getter = { _get = fun (s: Google.Protobuf.GeneratedCodeInfo.Annotation) -> s.SourceFile }
                _setter = { _over = fun a2b s -> { s with SourceFile = a2b s.SourceFile } }
            }
        let ``begin`` : ILens'<Google.Protobuf.GeneratedCodeInfo.Annotation,int> =
            {
                _getter = { _get = fun (s: Google.Protobuf.GeneratedCodeInfo.Annotation) -> s.Begin }
                _setter = { _over = fun a2b s -> { s with Begin = a2b s.Begin } }
            }
        let ``end`` : ILens'<Google.Protobuf.GeneratedCodeInfo.Annotation,int> =
            {
                _getter = { _get = fun (s: Google.Protobuf.GeneratedCodeInfo.Annotation) -> s.End }
                _setter = { _over = fun a2b s -> { s with End = a2b s.End } }
            }

namespace Google.Protobuf
open Focal.Core
open System.Runtime.CompilerServices
[<Extension>]
type OpticsExtensionMethods_google_protobuf_descriptor_proto =
    [<Extension>]
    static member inline Files(lens : ILens<'a,'b,Google.Protobuf.FileDescriptorSet,Google.Protobuf.FileDescriptorSet>) : ILens<'a,'b,Google.Protobuf.FileDescriptorProto list,Google.Protobuf.FileDescriptorProto list> =
        lens.ComposeWith(Google.Protobuf.Optics.FileDescriptorSet.``files``)
    [<Extension>]
    static member inline Files(traversal : ITraversal<'a,'b,Google.Protobuf.FileDescriptorSet,Google.Protobuf.FileDescriptorSet>) : ITraversal<'a,'b,Google.Protobuf.FileDescriptorProto list,Google.Protobuf.FileDescriptorProto list> =
        traversal.ComposeWith(Google.Protobuf.Optics.FileDescriptorSet.``files``)
    [<Extension>]
    static member inline Name(lens : ILens<'a,'b,Google.Protobuf.FileDescriptorProto,Google.Protobuf.FileDescriptorProto>) : ILens<'a,'b,string,string> =
        lens.ComposeWith(Google.Protobuf.Optics.FileDescriptorProto.``name``)
    [<Extension>]
    static member inline Name(traversal : ITraversal<'a,'b,Google.Protobuf.FileDescriptorProto,Google.Protobuf.FileDescriptorProto>) : ITraversal<'a,'b,string,string> =
        traversal.ComposeWith(Google.Protobuf.Optics.FileDescriptorProto.``name``)
    [<Extension>]
    static member inline Package(lens : ILens<'a,'b,Google.Protobuf.FileDescriptorProto,Google.Protobuf.FileDescriptorProto>) : ILens<'a,'b,string,string> =
        lens.ComposeWith(Google.Protobuf.Optics.FileDescriptorProto.``package``)
    [<Extension>]
    static member inline Package(traversal : ITraversal<'a,'b,Google.Protobuf.FileDescriptorProto,Google.Protobuf.FileDescriptorProto>) : ITraversal<'a,'b,string,string> =
        traversal.ComposeWith(Google.Protobuf.Optics.FileDescriptorProto.``package``)
    [<Extension>]
    static member inline Dependencies(lens : ILens<'a,'b,Google.Protobuf.FileDescriptorProto,Google.Protobuf.FileDescriptorProto>) : ILens<'a,'b,string list,string list> =
        lens.ComposeWith(Google.Protobuf.Optics.FileDescriptorProto.``dependencies``)
    [<Extension>]
    static member inline Dependencies(traversal : ITraversal<'a,'b,Google.Protobuf.FileDescriptorProto,Google.Protobuf.FileDescriptorProto>) : ITraversal<'a,'b,string list,string list> =
        traversal.ComposeWith(Google.Protobuf.Optics.FileDescriptorProto.``dependencies``)
    [<Extension>]
    static member inline PublicDependencies(lens : ILens<'a,'b,Google.Protobuf.FileDescriptorProto,Google.Protobuf.FileDescriptorProto>) : ILens<'a,'b,int list,int list> =
        lens.ComposeWith(Google.Protobuf.Optics.FileDescriptorProto.``publicDependencies``)
    [<Extension>]
    static member inline PublicDependencies(traversal : ITraversal<'a,'b,Google.Protobuf.FileDescriptorProto,Google.Protobuf.FileDescriptorProto>) : ITraversal<'a,'b,int list,int list> =
        traversal.ComposeWith(Google.Protobuf.Optics.FileDescriptorProto.``publicDependencies``)
    [<Extension>]
    static member inline WeakDependencies(lens : ILens<'a,'b,Google.Protobuf.FileDescriptorProto,Google.Protobuf.FileDescriptorProto>) : ILens<'a,'b,int list,int list> =
        lens.ComposeWith(Google.Protobuf.Optics.FileDescriptorProto.``weakDependencies``)
    [<Extension>]
    static member inline WeakDependencies(traversal : ITraversal<'a,'b,Google.Protobuf.FileDescriptorProto,Google.Protobuf.FileDescriptorProto>) : ITraversal<'a,'b,int list,int list> =
        traversal.ComposeWith(Google.Protobuf.Optics.FileDescriptorProto.``weakDependencies``)
    [<Extension>]
    static member inline MessageTypes(lens : ILens<'a,'b,Google.Protobuf.FileDescriptorProto,Google.Protobuf.FileDescriptorProto>) : ILens<'a,'b,Google.Protobuf.DescriptorProto list,Google.Protobuf.DescriptorProto list> =
        lens.ComposeWith(Google.Protobuf.Optics.FileDescriptorProto.``messageTypes``)
    [<Extension>]
    static member inline MessageTypes(traversal : ITraversal<'a,'b,Google.Protobuf.FileDescriptorProto,Google.Protobuf.FileDescriptorProto>) : ITraversal<'a,'b,Google.Protobuf.DescriptorProto list,Google.Protobuf.DescriptorProto list> =
        traversal.ComposeWith(Google.Protobuf.Optics.FileDescriptorProto.``messageTypes``)
    [<Extension>]
    static member inline EnumTypes(lens : ILens<'a,'b,Google.Protobuf.FileDescriptorProto,Google.Protobuf.FileDescriptorProto>) : ILens<'a,'b,Google.Protobuf.EnumDescriptorProto list,Google.Protobuf.EnumDescriptorProto list> =
        lens.ComposeWith(Google.Protobuf.Optics.FileDescriptorProto.``enumTypes``)
    [<Extension>]
    static member inline EnumTypes(traversal : ITraversal<'a,'b,Google.Protobuf.FileDescriptorProto,Google.Protobuf.FileDescriptorProto>) : ITraversal<'a,'b,Google.Protobuf.EnumDescriptorProto list,Google.Protobuf.EnumDescriptorProto list> =
        traversal.ComposeWith(Google.Protobuf.Optics.FileDescriptorProto.``enumTypes``)
    [<Extension>]
    static member inline Services(lens : ILens<'a,'b,Google.Protobuf.FileDescriptorProto,Google.Protobuf.FileDescriptorProto>) : ILens<'a,'b,Google.Protobuf.ServiceDescriptorProto list,Google.Protobuf.ServiceDescriptorProto list> =
        lens.ComposeWith(Google.Protobuf.Optics.FileDescriptorProto.``services``)
    [<Extension>]
    static member inline Services(traversal : ITraversal<'a,'b,Google.Protobuf.FileDescriptorProto,Google.Protobuf.FileDescriptorProto>) : ITraversal<'a,'b,Google.Protobuf.ServiceDescriptorProto list,Google.Protobuf.ServiceDescriptorProto list> =
        traversal.ComposeWith(Google.Protobuf.Optics.FileDescriptorProto.``services``)
    [<Extension>]
    static member inline Extensions(lens : ILens<'a,'b,Google.Protobuf.FileDescriptorProto,Google.Protobuf.FileDescriptorProto>) : ILens<'a,'b,Google.Protobuf.FieldDescriptorProto list,Google.Protobuf.FieldDescriptorProto list> =
        lens.ComposeWith(Google.Protobuf.Optics.FileDescriptorProto.``extensions``)
    [<Extension>]
    static member inline Extensions(traversal : ITraversal<'a,'b,Google.Protobuf.FileDescriptorProto,Google.Protobuf.FileDescriptorProto>) : ITraversal<'a,'b,Google.Protobuf.FieldDescriptorProto list,Google.Protobuf.FieldDescriptorProto list> =
        traversal.ComposeWith(Google.Protobuf.Optics.FileDescriptorProto.``extensions``)
    [<Extension>]
    static member inline Options(lens : ILens<'a,'b,Google.Protobuf.FileDescriptorProto,Google.Protobuf.FileDescriptorProto>) : ILens<'a,'b,Google.Protobuf.FileOptions option,Google.Protobuf.FileOptions option> =
        lens.ComposeWith(Google.Protobuf.Optics.FileDescriptorProto.``options``)
    [<Extension>]
    static member inline Options(traversal : ITraversal<'a,'b,Google.Protobuf.FileDescriptorProto,Google.Protobuf.FileDescriptorProto>) : ITraversal<'a,'b,Google.Protobuf.FileOptions option,Google.Protobuf.FileOptions option> =
        traversal.ComposeWith(Google.Protobuf.Optics.FileDescriptorProto.``options``)
    [<Extension>]
    static member inline SourceCodeInfo(lens : ILens<'a,'b,Google.Protobuf.FileDescriptorProto,Google.Protobuf.FileDescriptorProto>) : ILens<'a,'b,Google.Protobuf.SourceCodeInfo option,Google.Protobuf.SourceCodeInfo option> =
        lens.ComposeWith(Google.Protobuf.Optics.FileDescriptorProto.``sourceCodeInfo``)
    [<Extension>]
    static member inline SourceCodeInfo(traversal : ITraversal<'a,'b,Google.Protobuf.FileDescriptorProto,Google.Protobuf.FileDescriptorProto>) : ITraversal<'a,'b,Google.Protobuf.SourceCodeInfo option,Google.Protobuf.SourceCodeInfo option> =
        traversal.ComposeWith(Google.Protobuf.Optics.FileDescriptorProto.``sourceCodeInfo``)
    [<Extension>]
    static member inline Syntax(lens : ILens<'a,'b,Google.Protobuf.FileDescriptorProto,Google.Protobuf.FileDescriptorProto>) : ILens<'a,'b,string,string> =
        lens.ComposeWith(Google.Protobuf.Optics.FileDescriptorProto.``syntax``)
    [<Extension>]
    static member inline Syntax(traversal : ITraversal<'a,'b,Google.Protobuf.FileDescriptorProto,Google.Protobuf.FileDescriptorProto>) : ITraversal<'a,'b,string,string> =
        traversal.ComposeWith(Google.Protobuf.Optics.FileDescriptorProto.``syntax``)
    [<Extension>]
    static member inline Name(lens : ILens<'a,'b,Google.Protobuf.DescriptorProto,Google.Protobuf.DescriptorProto>) : ILens<'a,'b,string,string> =
        lens.ComposeWith(Google.Protobuf.Optics.DescriptorProto.``name``)
    [<Extension>]
    static member inline Name(traversal : ITraversal<'a,'b,Google.Protobuf.DescriptorProto,Google.Protobuf.DescriptorProto>) : ITraversal<'a,'b,string,string> =
        traversal.ComposeWith(Google.Protobuf.Optics.DescriptorProto.``name``)
    [<Extension>]
    static member inline Fields(lens : ILens<'a,'b,Google.Protobuf.DescriptorProto,Google.Protobuf.DescriptorProto>) : ILens<'a,'b,Google.Protobuf.FieldDescriptorProto list,Google.Protobuf.FieldDescriptorProto list> =
        lens.ComposeWith(Google.Protobuf.Optics.DescriptorProto.``fields``)
    [<Extension>]
    static member inline Fields(traversal : ITraversal<'a,'b,Google.Protobuf.DescriptorProto,Google.Protobuf.DescriptorProto>) : ITraversal<'a,'b,Google.Protobuf.FieldDescriptorProto list,Google.Protobuf.FieldDescriptorProto list> =
        traversal.ComposeWith(Google.Protobuf.Optics.DescriptorProto.``fields``)
    [<Extension>]
    static member inline Extensions(lens : ILens<'a,'b,Google.Protobuf.DescriptorProto,Google.Protobuf.DescriptorProto>) : ILens<'a,'b,Google.Protobuf.FieldDescriptorProto list,Google.Protobuf.FieldDescriptorProto list> =
        lens.ComposeWith(Google.Protobuf.Optics.DescriptorProto.``extensions``)
    [<Extension>]
    static member inline Extensions(traversal : ITraversal<'a,'b,Google.Protobuf.DescriptorProto,Google.Protobuf.DescriptorProto>) : ITraversal<'a,'b,Google.Protobuf.FieldDescriptorProto list,Google.Protobuf.FieldDescriptorProto list> =
        traversal.ComposeWith(Google.Protobuf.Optics.DescriptorProto.``extensions``)
    [<Extension>]
    static member inline NestedTypes(lens : ILens<'a,'b,Google.Protobuf.DescriptorProto,Google.Protobuf.DescriptorProto>) : ILens<'a,'b,Google.Protobuf.DescriptorProto list,Google.Protobuf.DescriptorProto list> =
        lens.ComposeWith(Google.Protobuf.Optics.DescriptorProto.``nestedTypes``)
    [<Extension>]
    static member inline NestedTypes(traversal : ITraversal<'a,'b,Google.Protobuf.DescriptorProto,Google.Protobuf.DescriptorProto>) : ITraversal<'a,'b,Google.Protobuf.DescriptorProto list,Google.Protobuf.DescriptorProto list> =
        traversal.ComposeWith(Google.Protobuf.Optics.DescriptorProto.``nestedTypes``)
    [<Extension>]
    static member inline EnumTypes(lens : ILens<'a,'b,Google.Protobuf.DescriptorProto,Google.Protobuf.DescriptorProto>) : ILens<'a,'b,Google.Protobuf.EnumDescriptorProto list,Google.Protobuf.EnumDescriptorProto list> =
        lens.ComposeWith(Google.Protobuf.Optics.DescriptorProto.``enumTypes``)
    [<Extension>]
    static member inline EnumTypes(traversal : ITraversal<'a,'b,Google.Protobuf.DescriptorProto,Google.Protobuf.DescriptorProto>) : ITraversal<'a,'b,Google.Protobuf.EnumDescriptorProto list,Google.Protobuf.EnumDescriptorProto list> =
        traversal.ComposeWith(Google.Protobuf.Optics.DescriptorProto.``enumTypes``)
    [<Extension>]
    static member inline ExtensionRanges(lens : ILens<'a,'b,Google.Protobuf.DescriptorProto,Google.Protobuf.DescriptorProto>) : ILens<'a,'b,Google.Protobuf.DescriptorProto.ExtensionRange list,Google.Protobuf.DescriptorProto.ExtensionRange list> =
        lens.ComposeWith(Google.Protobuf.Optics.DescriptorProto.``extensionRanges``)
    [<Extension>]
    static member inline ExtensionRanges(traversal : ITraversal<'a,'b,Google.Protobuf.DescriptorProto,Google.Protobuf.DescriptorProto>) : ITraversal<'a,'b,Google.Protobuf.DescriptorProto.ExtensionRange list,Google.Protobuf.DescriptorProto.ExtensionRange list> =
        traversal.ComposeWith(Google.Protobuf.Optics.DescriptorProto.``extensionRanges``)
    [<Extension>]
    static member inline OneofDecls(lens : ILens<'a,'b,Google.Protobuf.DescriptorProto,Google.Protobuf.DescriptorProto>) : ILens<'a,'b,Google.Protobuf.OneofDescriptorProto list,Google.Protobuf.OneofDescriptorProto list> =
        lens.ComposeWith(Google.Protobuf.Optics.DescriptorProto.``oneofDecls``)
    [<Extension>]
    static member inline OneofDecls(traversal : ITraversal<'a,'b,Google.Protobuf.DescriptorProto,Google.Protobuf.DescriptorProto>) : ITraversal<'a,'b,Google.Protobuf.OneofDescriptorProto list,Google.Protobuf.OneofDescriptorProto list> =
        traversal.ComposeWith(Google.Protobuf.Optics.DescriptorProto.``oneofDecls``)
    [<Extension>]
    static member inline Options(lens : ILens<'a,'b,Google.Protobuf.DescriptorProto,Google.Protobuf.DescriptorProto>) : ILens<'a,'b,Google.Protobuf.MessageOptions option,Google.Protobuf.MessageOptions option> =
        lens.ComposeWith(Google.Protobuf.Optics.DescriptorProto.``options``)
    [<Extension>]
    static member inline Options(traversal : ITraversal<'a,'b,Google.Protobuf.DescriptorProto,Google.Protobuf.DescriptorProto>) : ITraversal<'a,'b,Google.Protobuf.MessageOptions option,Google.Protobuf.MessageOptions option> =
        traversal.ComposeWith(Google.Protobuf.Optics.DescriptorProto.``options``)
    [<Extension>]
    static member inline ReservedRanges(lens : ILens<'a,'b,Google.Protobuf.DescriptorProto,Google.Protobuf.DescriptorProto>) : ILens<'a,'b,Google.Protobuf.DescriptorProto.ReservedRange list,Google.Protobuf.DescriptorProto.ReservedRange list> =
        lens.ComposeWith(Google.Protobuf.Optics.DescriptorProto.``reservedRanges``)
    [<Extension>]
    static member inline ReservedRanges(traversal : ITraversal<'a,'b,Google.Protobuf.DescriptorProto,Google.Protobuf.DescriptorProto>) : ITraversal<'a,'b,Google.Protobuf.DescriptorProto.ReservedRange list,Google.Protobuf.DescriptorProto.ReservedRange list> =
        traversal.ComposeWith(Google.Protobuf.Optics.DescriptorProto.``reservedRanges``)
    [<Extension>]
    static member inline ReservedNames(lens : ILens<'a,'b,Google.Protobuf.DescriptorProto,Google.Protobuf.DescriptorProto>) : ILens<'a,'b,string list,string list> =
        lens.ComposeWith(Google.Protobuf.Optics.DescriptorProto.``reservedNames``)
    [<Extension>]
    static member inline ReservedNames(traversal : ITraversal<'a,'b,Google.Protobuf.DescriptorProto,Google.Protobuf.DescriptorProto>) : ITraversal<'a,'b,string list,string list> =
        traversal.ComposeWith(Google.Protobuf.Optics.DescriptorProto.``reservedNames``)
    [<Extension>]
    static member inline Start(lens : ILens<'a,'b,Google.Protobuf.DescriptorProto.ExtensionRange,Google.Protobuf.DescriptorProto.ExtensionRange>) : ILens<'a,'b,int,int> =
        lens.ComposeWith(Google.Protobuf.Optics.DescriptorProto.ExtensionRange.``start``)
    [<Extension>]
    static member inline Start(traversal : ITraversal<'a,'b,Google.Protobuf.DescriptorProto.ExtensionRange,Google.Protobuf.DescriptorProto.ExtensionRange>) : ITraversal<'a,'b,int,int> =
        traversal.ComposeWith(Google.Protobuf.Optics.DescriptorProto.ExtensionRange.``start``)
    [<Extension>]
    static member inline End(lens : ILens<'a,'b,Google.Protobuf.DescriptorProto.ExtensionRange,Google.Protobuf.DescriptorProto.ExtensionRange>) : ILens<'a,'b,int,int> =
        lens.ComposeWith(Google.Protobuf.Optics.DescriptorProto.ExtensionRange.``end``)
    [<Extension>]
    static member inline End(traversal : ITraversal<'a,'b,Google.Protobuf.DescriptorProto.ExtensionRange,Google.Protobuf.DescriptorProto.ExtensionRange>) : ITraversal<'a,'b,int,int> =
        traversal.ComposeWith(Google.Protobuf.Optics.DescriptorProto.ExtensionRange.``end``)
    [<Extension>]
    static member inline Options(lens : ILens<'a,'b,Google.Protobuf.DescriptorProto.ExtensionRange,Google.Protobuf.DescriptorProto.ExtensionRange>) : ILens<'a,'b,Google.Protobuf.ExtensionRangeOptions option,Google.Protobuf.ExtensionRangeOptions option> =
        lens.ComposeWith(Google.Protobuf.Optics.DescriptorProto.ExtensionRange.``options``)
    [<Extension>]
    static member inline Options(traversal : ITraversal<'a,'b,Google.Protobuf.DescriptorProto.ExtensionRange,Google.Protobuf.DescriptorProto.ExtensionRange>) : ITraversal<'a,'b,Google.Protobuf.ExtensionRangeOptions option,Google.Protobuf.ExtensionRangeOptions option> =
        traversal.ComposeWith(Google.Protobuf.Optics.DescriptorProto.ExtensionRange.``options``)
    [<Extension>]
    static member inline Start(lens : ILens<'a,'b,Google.Protobuf.DescriptorProto.ReservedRange,Google.Protobuf.DescriptorProto.ReservedRange>) : ILens<'a,'b,int,int> =
        lens.ComposeWith(Google.Protobuf.Optics.DescriptorProto.ReservedRange.``start``)
    [<Extension>]
    static member inline Start(traversal : ITraversal<'a,'b,Google.Protobuf.DescriptorProto.ReservedRange,Google.Protobuf.DescriptorProto.ReservedRange>) : ITraversal<'a,'b,int,int> =
        traversal.ComposeWith(Google.Protobuf.Optics.DescriptorProto.ReservedRange.``start``)
    [<Extension>]
    static member inline End(lens : ILens<'a,'b,Google.Protobuf.DescriptorProto.ReservedRange,Google.Protobuf.DescriptorProto.ReservedRange>) : ILens<'a,'b,int,int> =
        lens.ComposeWith(Google.Protobuf.Optics.DescriptorProto.ReservedRange.``end``)
    [<Extension>]
    static member inline End(traversal : ITraversal<'a,'b,Google.Protobuf.DescriptorProto.ReservedRange,Google.Protobuf.DescriptorProto.ReservedRange>) : ITraversal<'a,'b,int,int> =
        traversal.ComposeWith(Google.Protobuf.Optics.DescriptorProto.ReservedRange.``end``)
    [<Extension>]
    static member inline UninterpretedOptions(lens : ILens<'a,'b,Google.Protobuf.ExtensionRangeOptions,Google.Protobuf.ExtensionRangeOptions>) : ILens<'a,'b,Google.Protobuf.UninterpretedOption list,Google.Protobuf.UninterpretedOption list> =
        lens.ComposeWith(Google.Protobuf.Optics.ExtensionRangeOptions.``uninterpretedOptions``)
    [<Extension>]
    static member inline UninterpretedOptions(traversal : ITraversal<'a,'b,Google.Protobuf.ExtensionRangeOptions,Google.Protobuf.ExtensionRangeOptions>) : ITraversal<'a,'b,Google.Protobuf.UninterpretedOption list,Google.Protobuf.UninterpretedOption list> =
        traversal.ComposeWith(Google.Protobuf.Optics.ExtensionRangeOptions.``uninterpretedOptions``)
    [<Extension>]
    static member inline Name(lens : ILens<'a,'b,Google.Protobuf.FieldDescriptorProto,Google.Protobuf.FieldDescriptorProto>) : ILens<'a,'b,string,string> =
        lens.ComposeWith(Google.Protobuf.Optics.FieldDescriptorProto.``name``)
    [<Extension>]
    static member inline Name(traversal : ITraversal<'a,'b,Google.Protobuf.FieldDescriptorProto,Google.Protobuf.FieldDescriptorProto>) : ITraversal<'a,'b,string,string> =
        traversal.ComposeWith(Google.Protobuf.Optics.FieldDescriptorProto.``name``)
    [<Extension>]
    static member inline Number(lens : ILens<'a,'b,Google.Protobuf.FieldDescriptorProto,Google.Protobuf.FieldDescriptorProto>) : ILens<'a,'b,int,int> =
        lens.ComposeWith(Google.Protobuf.Optics.FieldDescriptorProto.``number``)
    [<Extension>]
    static member inline Number(traversal : ITraversal<'a,'b,Google.Protobuf.FieldDescriptorProto,Google.Protobuf.FieldDescriptorProto>) : ITraversal<'a,'b,int,int> =
        traversal.ComposeWith(Google.Protobuf.Optics.FieldDescriptorProto.``number``)
    [<Extension>]
    static member inline Label(lens : ILens<'a,'b,Google.Protobuf.FieldDescriptorProto,Google.Protobuf.FieldDescriptorProto>) : ILens<'a,'b,Google.Protobuf.FieldDescriptorProto.Label,Google.Protobuf.FieldDescriptorProto.Label> =
        lens.ComposeWith(Google.Protobuf.Optics.FieldDescriptorProto.``label``)
    [<Extension>]
    static member inline Label(traversal : ITraversal<'a,'b,Google.Protobuf.FieldDescriptorProto,Google.Protobuf.FieldDescriptorProto>) : ITraversal<'a,'b,Google.Protobuf.FieldDescriptorProto.Label,Google.Protobuf.FieldDescriptorProto.Label> =
        traversal.ComposeWith(Google.Protobuf.Optics.FieldDescriptorProto.``label``)
    [<Extension>]
    static member inline Type(lens : ILens<'a,'b,Google.Protobuf.FieldDescriptorProto,Google.Protobuf.FieldDescriptorProto>) : ILens<'a,'b,Google.Protobuf.FieldDescriptorProto.Type,Google.Protobuf.FieldDescriptorProto.Type> =
        lens.ComposeWith(Google.Protobuf.Optics.FieldDescriptorProto.``type``)
    [<Extension>]
    static member inline Type(traversal : ITraversal<'a,'b,Google.Protobuf.FieldDescriptorProto,Google.Protobuf.FieldDescriptorProto>) : ITraversal<'a,'b,Google.Protobuf.FieldDescriptorProto.Type,Google.Protobuf.FieldDescriptorProto.Type> =
        traversal.ComposeWith(Google.Protobuf.Optics.FieldDescriptorProto.``type``)
    [<Extension>]
    static member inline TypeName(lens : ILens<'a,'b,Google.Protobuf.FieldDescriptorProto,Google.Protobuf.FieldDescriptorProto>) : ILens<'a,'b,string,string> =
        lens.ComposeWith(Google.Protobuf.Optics.FieldDescriptorProto.``typeName``)
    [<Extension>]
    static member inline TypeName(traversal : ITraversal<'a,'b,Google.Protobuf.FieldDescriptorProto,Google.Protobuf.FieldDescriptorProto>) : ITraversal<'a,'b,string,string> =
        traversal.ComposeWith(Google.Protobuf.Optics.FieldDescriptorProto.``typeName``)
    [<Extension>]
    static member inline Extendee(lens : ILens<'a,'b,Google.Protobuf.FieldDescriptorProto,Google.Protobuf.FieldDescriptorProto>) : ILens<'a,'b,string,string> =
        lens.ComposeWith(Google.Protobuf.Optics.FieldDescriptorProto.``extendee``)
    [<Extension>]
    static member inline Extendee(traversal : ITraversal<'a,'b,Google.Protobuf.FieldDescriptorProto,Google.Protobuf.FieldDescriptorProto>) : ITraversal<'a,'b,string,string> =
        traversal.ComposeWith(Google.Protobuf.Optics.FieldDescriptorProto.``extendee``)
    [<Extension>]
    static member inline DefaultValue(lens : ILens<'a,'b,Google.Protobuf.FieldDescriptorProto,Google.Protobuf.FieldDescriptorProto>) : ILens<'a,'b,string,string> =
        lens.ComposeWith(Google.Protobuf.Optics.FieldDescriptorProto.``defaultValue``)
    [<Extension>]
    static member inline DefaultValue(traversal : ITraversal<'a,'b,Google.Protobuf.FieldDescriptorProto,Google.Protobuf.FieldDescriptorProto>) : ITraversal<'a,'b,string,string> =
        traversal.ComposeWith(Google.Protobuf.Optics.FieldDescriptorProto.``defaultValue``)
    [<Extension>]
    static member inline OneofIndex(lens : ILens<'a,'b,Google.Protobuf.FieldDescriptorProto,Google.Protobuf.FieldDescriptorProto>) : ILens<'a,'b,int option,int option> =
        lens.ComposeWith(Google.Protobuf.Optics.FieldDescriptorProto.``oneofIndex``)
    [<Extension>]
    static member inline OneofIndex(traversal : ITraversal<'a,'b,Google.Protobuf.FieldDescriptorProto,Google.Protobuf.FieldDescriptorProto>) : ITraversal<'a,'b,int option,int option> =
        traversal.ComposeWith(Google.Protobuf.Optics.FieldDescriptorProto.``oneofIndex``)
    [<Extension>]
    static member inline JsonName(lens : ILens<'a,'b,Google.Protobuf.FieldDescriptorProto,Google.Protobuf.FieldDescriptorProto>) : ILens<'a,'b,string,string> =
        lens.ComposeWith(Google.Protobuf.Optics.FieldDescriptorProto.``jsonName``)
    [<Extension>]
    static member inline JsonName(traversal : ITraversal<'a,'b,Google.Protobuf.FieldDescriptorProto,Google.Protobuf.FieldDescriptorProto>) : ITraversal<'a,'b,string,string> =
        traversal.ComposeWith(Google.Protobuf.Optics.FieldDescriptorProto.``jsonName``)
    [<Extension>]
    static member inline Options(lens : ILens<'a,'b,Google.Protobuf.FieldDescriptorProto,Google.Protobuf.FieldDescriptorProto>) : ILens<'a,'b,Google.Protobuf.FieldOptions option,Google.Protobuf.FieldOptions option> =
        lens.ComposeWith(Google.Protobuf.Optics.FieldDescriptorProto.``options``)
    [<Extension>]
    static member inline Options(traversal : ITraversal<'a,'b,Google.Protobuf.FieldDescriptorProto,Google.Protobuf.FieldDescriptorProto>) : ITraversal<'a,'b,Google.Protobuf.FieldOptions option,Google.Protobuf.FieldOptions option> =
        traversal.ComposeWith(Google.Protobuf.Optics.FieldDescriptorProto.``options``)
    [<Extension>]
    static member inline Proto3Optional(lens : ILens<'a,'b,Google.Protobuf.FieldDescriptorProto,Google.Protobuf.FieldDescriptorProto>) : ILens<'a,'b,bool,bool> =
        lens.ComposeWith(Google.Protobuf.Optics.FieldDescriptorProto.``proto3Optional``)
    [<Extension>]
    static member inline Proto3Optional(traversal : ITraversal<'a,'b,Google.Protobuf.FieldDescriptorProto,Google.Protobuf.FieldDescriptorProto>) : ITraversal<'a,'b,bool,bool> =
        traversal.ComposeWith(Google.Protobuf.Optics.FieldDescriptorProto.``proto3Optional``)
    [<Extension>]
    static member inline Name(lens : ILens<'a,'b,Google.Protobuf.OneofDescriptorProto,Google.Protobuf.OneofDescriptorProto>) : ILens<'a,'b,string,string> =
        lens.ComposeWith(Google.Protobuf.Optics.OneofDescriptorProto.``name``)
    [<Extension>]
    static member inline Name(traversal : ITraversal<'a,'b,Google.Protobuf.OneofDescriptorProto,Google.Protobuf.OneofDescriptorProto>) : ITraversal<'a,'b,string,string> =
        traversal.ComposeWith(Google.Protobuf.Optics.OneofDescriptorProto.``name``)
    [<Extension>]
    static member inline Options(lens : ILens<'a,'b,Google.Protobuf.OneofDescriptorProto,Google.Protobuf.OneofDescriptorProto>) : ILens<'a,'b,Google.Protobuf.OneofOptions option,Google.Protobuf.OneofOptions option> =
        lens.ComposeWith(Google.Protobuf.Optics.OneofDescriptorProto.``options``)
    [<Extension>]
    static member inline Options(traversal : ITraversal<'a,'b,Google.Protobuf.OneofDescriptorProto,Google.Protobuf.OneofDescriptorProto>) : ITraversal<'a,'b,Google.Protobuf.OneofOptions option,Google.Protobuf.OneofOptions option> =
        traversal.ComposeWith(Google.Protobuf.Optics.OneofDescriptorProto.``options``)
    [<Extension>]
    static member inline Name(lens : ILens<'a,'b,Google.Protobuf.EnumDescriptorProto,Google.Protobuf.EnumDescriptorProto>) : ILens<'a,'b,string,string> =
        lens.ComposeWith(Google.Protobuf.Optics.EnumDescriptorProto.``name``)
    [<Extension>]
    static member inline Name(traversal : ITraversal<'a,'b,Google.Protobuf.EnumDescriptorProto,Google.Protobuf.EnumDescriptorProto>) : ITraversal<'a,'b,string,string> =
        traversal.ComposeWith(Google.Protobuf.Optics.EnumDescriptorProto.``name``)
    [<Extension>]
    static member inline Values(lens : ILens<'a,'b,Google.Protobuf.EnumDescriptorProto,Google.Protobuf.EnumDescriptorProto>) : ILens<'a,'b,Google.Protobuf.EnumValueDescriptorProto list,Google.Protobuf.EnumValueDescriptorProto list> =
        lens.ComposeWith(Google.Protobuf.Optics.EnumDescriptorProto.``values``)
    [<Extension>]
    static member inline Values(traversal : ITraversal<'a,'b,Google.Protobuf.EnumDescriptorProto,Google.Protobuf.EnumDescriptorProto>) : ITraversal<'a,'b,Google.Protobuf.EnumValueDescriptorProto list,Google.Protobuf.EnumValueDescriptorProto list> =
        traversal.ComposeWith(Google.Protobuf.Optics.EnumDescriptorProto.``values``)
    [<Extension>]
    static member inline Options(lens : ILens<'a,'b,Google.Protobuf.EnumDescriptorProto,Google.Protobuf.EnumDescriptorProto>) : ILens<'a,'b,Google.Protobuf.EnumOptions option,Google.Protobuf.EnumOptions option> =
        lens.ComposeWith(Google.Protobuf.Optics.EnumDescriptorProto.``options``)
    [<Extension>]
    static member inline Options(traversal : ITraversal<'a,'b,Google.Protobuf.EnumDescriptorProto,Google.Protobuf.EnumDescriptorProto>) : ITraversal<'a,'b,Google.Protobuf.EnumOptions option,Google.Protobuf.EnumOptions option> =
        traversal.ComposeWith(Google.Protobuf.Optics.EnumDescriptorProto.``options``)
    [<Extension>]
    static member inline ReservedRanges(lens : ILens<'a,'b,Google.Protobuf.EnumDescriptorProto,Google.Protobuf.EnumDescriptorProto>) : ILens<'a,'b,Google.Protobuf.EnumDescriptorProto.EnumReservedRange list,Google.Protobuf.EnumDescriptorProto.EnumReservedRange list> =
        lens.ComposeWith(Google.Protobuf.Optics.EnumDescriptorProto.``reservedRanges``)
    [<Extension>]
    static member inline ReservedRanges(traversal : ITraversal<'a,'b,Google.Protobuf.EnumDescriptorProto,Google.Protobuf.EnumDescriptorProto>) : ITraversal<'a,'b,Google.Protobuf.EnumDescriptorProto.EnumReservedRange list,Google.Protobuf.EnumDescriptorProto.EnumReservedRange list> =
        traversal.ComposeWith(Google.Protobuf.Optics.EnumDescriptorProto.``reservedRanges``)
    [<Extension>]
    static member inline ReservedNames(lens : ILens<'a,'b,Google.Protobuf.EnumDescriptorProto,Google.Protobuf.EnumDescriptorProto>) : ILens<'a,'b,string list,string list> =
        lens.ComposeWith(Google.Protobuf.Optics.EnumDescriptorProto.``reservedNames``)
    [<Extension>]
    static member inline ReservedNames(traversal : ITraversal<'a,'b,Google.Protobuf.EnumDescriptorProto,Google.Protobuf.EnumDescriptorProto>) : ITraversal<'a,'b,string list,string list> =
        traversal.ComposeWith(Google.Protobuf.Optics.EnumDescriptorProto.``reservedNames``)
    [<Extension>]
    static member inline Start(lens : ILens<'a,'b,Google.Protobuf.EnumDescriptorProto.EnumReservedRange,Google.Protobuf.EnumDescriptorProto.EnumReservedRange>) : ILens<'a,'b,int,int> =
        lens.ComposeWith(Google.Protobuf.Optics.EnumDescriptorProto.EnumReservedRange.``start``)
    [<Extension>]
    static member inline Start(traversal : ITraversal<'a,'b,Google.Protobuf.EnumDescriptorProto.EnumReservedRange,Google.Protobuf.EnumDescriptorProto.EnumReservedRange>) : ITraversal<'a,'b,int,int> =
        traversal.ComposeWith(Google.Protobuf.Optics.EnumDescriptorProto.EnumReservedRange.``start``)
    [<Extension>]
    static member inline End(lens : ILens<'a,'b,Google.Protobuf.EnumDescriptorProto.EnumReservedRange,Google.Protobuf.EnumDescriptorProto.EnumReservedRange>) : ILens<'a,'b,int,int> =
        lens.ComposeWith(Google.Protobuf.Optics.EnumDescriptorProto.EnumReservedRange.``end``)
    [<Extension>]
    static member inline End(traversal : ITraversal<'a,'b,Google.Protobuf.EnumDescriptorProto.EnumReservedRange,Google.Protobuf.EnumDescriptorProto.EnumReservedRange>) : ITraversal<'a,'b,int,int> =
        traversal.ComposeWith(Google.Protobuf.Optics.EnumDescriptorProto.EnumReservedRange.``end``)
    [<Extension>]
    static member inline Name(lens : ILens<'a,'b,Google.Protobuf.EnumValueDescriptorProto,Google.Protobuf.EnumValueDescriptorProto>) : ILens<'a,'b,string,string> =
        lens.ComposeWith(Google.Protobuf.Optics.EnumValueDescriptorProto.``name``)
    [<Extension>]
    static member inline Name(traversal : ITraversal<'a,'b,Google.Protobuf.EnumValueDescriptorProto,Google.Protobuf.EnumValueDescriptorProto>) : ITraversal<'a,'b,string,string> =
        traversal.ComposeWith(Google.Protobuf.Optics.EnumValueDescriptorProto.``name``)
    [<Extension>]
    static member inline Number(lens : ILens<'a,'b,Google.Protobuf.EnumValueDescriptorProto,Google.Protobuf.EnumValueDescriptorProto>) : ILens<'a,'b,int,int> =
        lens.ComposeWith(Google.Protobuf.Optics.EnumValueDescriptorProto.``number``)
    [<Extension>]
    static member inline Number(traversal : ITraversal<'a,'b,Google.Protobuf.EnumValueDescriptorProto,Google.Protobuf.EnumValueDescriptorProto>) : ITraversal<'a,'b,int,int> =
        traversal.ComposeWith(Google.Protobuf.Optics.EnumValueDescriptorProto.``number``)
    [<Extension>]
    static member inline Options(lens : ILens<'a,'b,Google.Protobuf.EnumValueDescriptorProto,Google.Protobuf.EnumValueDescriptorProto>) : ILens<'a,'b,Google.Protobuf.EnumValueOptions option,Google.Protobuf.EnumValueOptions option> =
        lens.ComposeWith(Google.Protobuf.Optics.EnumValueDescriptorProto.``options``)
    [<Extension>]
    static member inline Options(traversal : ITraversal<'a,'b,Google.Protobuf.EnumValueDescriptorProto,Google.Protobuf.EnumValueDescriptorProto>) : ITraversal<'a,'b,Google.Protobuf.EnumValueOptions option,Google.Protobuf.EnumValueOptions option> =
        traversal.ComposeWith(Google.Protobuf.Optics.EnumValueDescriptorProto.``options``)
    [<Extension>]
    static member inline Name(lens : ILens<'a,'b,Google.Protobuf.ServiceDescriptorProto,Google.Protobuf.ServiceDescriptorProto>) : ILens<'a,'b,string,string> =
        lens.ComposeWith(Google.Protobuf.Optics.ServiceDescriptorProto.``name``)
    [<Extension>]
    static member inline Name(traversal : ITraversal<'a,'b,Google.Protobuf.ServiceDescriptorProto,Google.Protobuf.ServiceDescriptorProto>) : ITraversal<'a,'b,string,string> =
        traversal.ComposeWith(Google.Protobuf.Optics.ServiceDescriptorProto.``name``)
    [<Extension>]
    static member inline Methods(lens : ILens<'a,'b,Google.Protobuf.ServiceDescriptorProto,Google.Protobuf.ServiceDescriptorProto>) : ILens<'a,'b,Google.Protobuf.MethodDescriptorProto list,Google.Protobuf.MethodDescriptorProto list> =
        lens.ComposeWith(Google.Protobuf.Optics.ServiceDescriptorProto.``methods``)
    [<Extension>]
    static member inline Methods(traversal : ITraversal<'a,'b,Google.Protobuf.ServiceDescriptorProto,Google.Protobuf.ServiceDescriptorProto>) : ITraversal<'a,'b,Google.Protobuf.MethodDescriptorProto list,Google.Protobuf.MethodDescriptorProto list> =
        traversal.ComposeWith(Google.Protobuf.Optics.ServiceDescriptorProto.``methods``)
    [<Extension>]
    static member inline Options(lens : ILens<'a,'b,Google.Protobuf.ServiceDescriptorProto,Google.Protobuf.ServiceDescriptorProto>) : ILens<'a,'b,Google.Protobuf.ServiceOptions option,Google.Protobuf.ServiceOptions option> =
        lens.ComposeWith(Google.Protobuf.Optics.ServiceDescriptorProto.``options``)
    [<Extension>]
    static member inline Options(traversal : ITraversal<'a,'b,Google.Protobuf.ServiceDescriptorProto,Google.Protobuf.ServiceDescriptorProto>) : ITraversal<'a,'b,Google.Protobuf.ServiceOptions option,Google.Protobuf.ServiceOptions option> =
        traversal.ComposeWith(Google.Protobuf.Optics.ServiceDescriptorProto.``options``)
    [<Extension>]
    static member inline Name(lens : ILens<'a,'b,Google.Protobuf.MethodDescriptorProto,Google.Protobuf.MethodDescriptorProto>) : ILens<'a,'b,string,string> =
        lens.ComposeWith(Google.Protobuf.Optics.MethodDescriptorProto.``name``)
    [<Extension>]
    static member inline Name(traversal : ITraversal<'a,'b,Google.Protobuf.MethodDescriptorProto,Google.Protobuf.MethodDescriptorProto>) : ITraversal<'a,'b,string,string> =
        traversal.ComposeWith(Google.Protobuf.Optics.MethodDescriptorProto.``name``)
    [<Extension>]
    static member inline InputType(lens : ILens<'a,'b,Google.Protobuf.MethodDescriptorProto,Google.Protobuf.MethodDescriptorProto>) : ILens<'a,'b,string,string> =
        lens.ComposeWith(Google.Protobuf.Optics.MethodDescriptorProto.``inputType``)
    [<Extension>]
    static member inline InputType(traversal : ITraversal<'a,'b,Google.Protobuf.MethodDescriptorProto,Google.Protobuf.MethodDescriptorProto>) : ITraversal<'a,'b,string,string> =
        traversal.ComposeWith(Google.Protobuf.Optics.MethodDescriptorProto.``inputType``)
    [<Extension>]
    static member inline OutputType(lens : ILens<'a,'b,Google.Protobuf.MethodDescriptorProto,Google.Protobuf.MethodDescriptorProto>) : ILens<'a,'b,string,string> =
        lens.ComposeWith(Google.Protobuf.Optics.MethodDescriptorProto.``outputType``)
    [<Extension>]
    static member inline OutputType(traversal : ITraversal<'a,'b,Google.Protobuf.MethodDescriptorProto,Google.Protobuf.MethodDescriptorProto>) : ITraversal<'a,'b,string,string> =
        traversal.ComposeWith(Google.Protobuf.Optics.MethodDescriptorProto.``outputType``)
    [<Extension>]
    static member inline Options(lens : ILens<'a,'b,Google.Protobuf.MethodDescriptorProto,Google.Protobuf.MethodDescriptorProto>) : ILens<'a,'b,Google.Protobuf.MethodOptions option,Google.Protobuf.MethodOptions option> =
        lens.ComposeWith(Google.Protobuf.Optics.MethodDescriptorProto.``options``)
    [<Extension>]
    static member inline Options(traversal : ITraversal<'a,'b,Google.Protobuf.MethodDescriptorProto,Google.Protobuf.MethodDescriptorProto>) : ITraversal<'a,'b,Google.Protobuf.MethodOptions option,Google.Protobuf.MethodOptions option> =
        traversal.ComposeWith(Google.Protobuf.Optics.MethodDescriptorProto.``options``)
    [<Extension>]
    static member inline ClientStreaming(lens : ILens<'a,'b,Google.Protobuf.MethodDescriptorProto,Google.Protobuf.MethodDescriptorProto>) : ILens<'a,'b,bool,bool> =
        lens.ComposeWith(Google.Protobuf.Optics.MethodDescriptorProto.``clientStreaming``)
    [<Extension>]
    static member inline ClientStreaming(traversal : ITraversal<'a,'b,Google.Protobuf.MethodDescriptorProto,Google.Protobuf.MethodDescriptorProto>) : ITraversal<'a,'b,bool,bool> =
        traversal.ComposeWith(Google.Protobuf.Optics.MethodDescriptorProto.``clientStreaming``)
    [<Extension>]
    static member inline ServerStreaming(lens : ILens<'a,'b,Google.Protobuf.MethodDescriptorProto,Google.Protobuf.MethodDescriptorProto>) : ILens<'a,'b,bool,bool> =
        lens.ComposeWith(Google.Protobuf.Optics.MethodDescriptorProto.``serverStreaming``)
    [<Extension>]
    static member inline ServerStreaming(traversal : ITraversal<'a,'b,Google.Protobuf.MethodDescriptorProto,Google.Protobuf.MethodDescriptorProto>) : ITraversal<'a,'b,bool,bool> =
        traversal.ComposeWith(Google.Protobuf.Optics.MethodDescriptorProto.``serverStreaming``)
    [<Extension>]
    static member inline JavaPackage(lens : ILens<'a,'b,Google.Protobuf.FileOptions,Google.Protobuf.FileOptions>) : ILens<'a,'b,string,string> =
        lens.ComposeWith(Google.Protobuf.Optics.FileOptions.``javaPackage``)
    [<Extension>]
    static member inline JavaPackage(traversal : ITraversal<'a,'b,Google.Protobuf.FileOptions,Google.Protobuf.FileOptions>) : ITraversal<'a,'b,string,string> =
        traversal.ComposeWith(Google.Protobuf.Optics.FileOptions.``javaPackage``)
    [<Extension>]
    static member inline JavaOuterClassname(lens : ILens<'a,'b,Google.Protobuf.FileOptions,Google.Protobuf.FileOptions>) : ILens<'a,'b,string,string> =
        lens.ComposeWith(Google.Protobuf.Optics.FileOptions.``javaOuterClassname``)
    [<Extension>]
    static member inline JavaOuterClassname(traversal : ITraversal<'a,'b,Google.Protobuf.FileOptions,Google.Protobuf.FileOptions>) : ITraversal<'a,'b,string,string> =
        traversal.ComposeWith(Google.Protobuf.Optics.FileOptions.``javaOuterClassname``)
    [<Extension>]
    static member inline JavaMultipleFiles(lens : ILens<'a,'b,Google.Protobuf.FileOptions,Google.Protobuf.FileOptions>) : ILens<'a,'b,bool,bool> =
        lens.ComposeWith(Google.Protobuf.Optics.FileOptions.``javaMultipleFiles``)
    [<Extension>]
    static member inline JavaMultipleFiles(traversal : ITraversal<'a,'b,Google.Protobuf.FileOptions,Google.Protobuf.FileOptions>) : ITraversal<'a,'b,bool,bool> =
        traversal.ComposeWith(Google.Protobuf.Optics.FileOptions.``javaMultipleFiles``)
    [<Extension>]
    static member inline JavaGenerateEqualsAndHash(lens : ILens<'a,'b,Google.Protobuf.FileOptions,Google.Protobuf.FileOptions>) : ILens<'a,'b,bool,bool> =
        lens.ComposeWith(Google.Protobuf.Optics.FileOptions.``javaGenerateEqualsAndHash``)
    [<Extension>]
    static member inline JavaGenerateEqualsAndHash(traversal : ITraversal<'a,'b,Google.Protobuf.FileOptions,Google.Protobuf.FileOptions>) : ITraversal<'a,'b,bool,bool> =
        traversal.ComposeWith(Google.Protobuf.Optics.FileOptions.``javaGenerateEqualsAndHash``)
    [<Extension>]
    static member inline JavaStringCheckUtf8(lens : ILens<'a,'b,Google.Protobuf.FileOptions,Google.Protobuf.FileOptions>) : ILens<'a,'b,bool,bool> =
        lens.ComposeWith(Google.Protobuf.Optics.FileOptions.``javaStringCheckUtf8``)
    [<Extension>]
    static member inline JavaStringCheckUtf8(traversal : ITraversal<'a,'b,Google.Protobuf.FileOptions,Google.Protobuf.FileOptions>) : ITraversal<'a,'b,bool,bool> =
        traversal.ComposeWith(Google.Protobuf.Optics.FileOptions.``javaStringCheckUtf8``)
    [<Extension>]
    static member inline OptimizeFor(lens : ILens<'a,'b,Google.Protobuf.FileOptions,Google.Protobuf.FileOptions>) : ILens<'a,'b,Google.Protobuf.FileOptions.OptimizeMode,Google.Protobuf.FileOptions.OptimizeMode> =
        lens.ComposeWith(Google.Protobuf.Optics.FileOptions.``optimizeFor``)
    [<Extension>]
    static member inline OptimizeFor(traversal : ITraversal<'a,'b,Google.Protobuf.FileOptions,Google.Protobuf.FileOptions>) : ITraversal<'a,'b,Google.Protobuf.FileOptions.OptimizeMode,Google.Protobuf.FileOptions.OptimizeMode> =
        traversal.ComposeWith(Google.Protobuf.Optics.FileOptions.``optimizeFor``)
    [<Extension>]
    static member inline GoPackage(lens : ILens<'a,'b,Google.Protobuf.FileOptions,Google.Protobuf.FileOptions>) : ILens<'a,'b,string,string> =
        lens.ComposeWith(Google.Protobuf.Optics.FileOptions.``goPackage``)
    [<Extension>]
    static member inline GoPackage(traversal : ITraversal<'a,'b,Google.Protobuf.FileOptions,Google.Protobuf.FileOptions>) : ITraversal<'a,'b,string,string> =
        traversal.ComposeWith(Google.Protobuf.Optics.FileOptions.``goPackage``)
    [<Extension>]
    static member inline CcGenericServices(lens : ILens<'a,'b,Google.Protobuf.FileOptions,Google.Protobuf.FileOptions>) : ILens<'a,'b,bool,bool> =
        lens.ComposeWith(Google.Protobuf.Optics.FileOptions.``ccGenericServices``)
    [<Extension>]
    static member inline CcGenericServices(traversal : ITraversal<'a,'b,Google.Protobuf.FileOptions,Google.Protobuf.FileOptions>) : ITraversal<'a,'b,bool,bool> =
        traversal.ComposeWith(Google.Protobuf.Optics.FileOptions.``ccGenericServices``)
    [<Extension>]
    static member inline JavaGenericServices(lens : ILens<'a,'b,Google.Protobuf.FileOptions,Google.Protobuf.FileOptions>) : ILens<'a,'b,bool,bool> =
        lens.ComposeWith(Google.Protobuf.Optics.FileOptions.``javaGenericServices``)
    [<Extension>]
    static member inline JavaGenericServices(traversal : ITraversal<'a,'b,Google.Protobuf.FileOptions,Google.Protobuf.FileOptions>) : ITraversal<'a,'b,bool,bool> =
        traversal.ComposeWith(Google.Protobuf.Optics.FileOptions.``javaGenericServices``)
    [<Extension>]
    static member inline PyGenericServices(lens : ILens<'a,'b,Google.Protobuf.FileOptions,Google.Protobuf.FileOptions>) : ILens<'a,'b,bool,bool> =
        lens.ComposeWith(Google.Protobuf.Optics.FileOptions.``pyGenericServices``)
    [<Extension>]
    static member inline PyGenericServices(traversal : ITraversal<'a,'b,Google.Protobuf.FileOptions,Google.Protobuf.FileOptions>) : ITraversal<'a,'b,bool,bool> =
        traversal.ComposeWith(Google.Protobuf.Optics.FileOptions.``pyGenericServices``)
    [<Extension>]
    static member inline PhpGenericServices(lens : ILens<'a,'b,Google.Protobuf.FileOptions,Google.Protobuf.FileOptions>) : ILens<'a,'b,bool,bool> =
        lens.ComposeWith(Google.Protobuf.Optics.FileOptions.``phpGenericServices``)
    [<Extension>]
    static member inline PhpGenericServices(traversal : ITraversal<'a,'b,Google.Protobuf.FileOptions,Google.Protobuf.FileOptions>) : ITraversal<'a,'b,bool,bool> =
        traversal.ComposeWith(Google.Protobuf.Optics.FileOptions.``phpGenericServices``)
    [<Extension>]
    static member inline Deprecated(lens : ILens<'a,'b,Google.Protobuf.FileOptions,Google.Protobuf.FileOptions>) : ILens<'a,'b,bool,bool> =
        lens.ComposeWith(Google.Protobuf.Optics.FileOptions.``deprecated``)
    [<Extension>]
    static member inline Deprecated(traversal : ITraversal<'a,'b,Google.Protobuf.FileOptions,Google.Protobuf.FileOptions>) : ITraversal<'a,'b,bool,bool> =
        traversal.ComposeWith(Google.Protobuf.Optics.FileOptions.``deprecated``)
    [<Extension>]
    static member inline CcEnableArenas(lens : ILens<'a,'b,Google.Protobuf.FileOptions,Google.Protobuf.FileOptions>) : ILens<'a,'b,bool,bool> =
        lens.ComposeWith(Google.Protobuf.Optics.FileOptions.``ccEnableArenas``)
    [<Extension>]
    static member inline CcEnableArenas(traversal : ITraversal<'a,'b,Google.Protobuf.FileOptions,Google.Protobuf.FileOptions>) : ITraversal<'a,'b,bool,bool> =
        traversal.ComposeWith(Google.Protobuf.Optics.FileOptions.``ccEnableArenas``)
    [<Extension>]
    static member inline ObjcClassPrefix(lens : ILens<'a,'b,Google.Protobuf.FileOptions,Google.Protobuf.FileOptions>) : ILens<'a,'b,string,string> =
        lens.ComposeWith(Google.Protobuf.Optics.FileOptions.``objcClassPrefix``)
    [<Extension>]
    static member inline ObjcClassPrefix(traversal : ITraversal<'a,'b,Google.Protobuf.FileOptions,Google.Protobuf.FileOptions>) : ITraversal<'a,'b,string,string> =
        traversal.ComposeWith(Google.Protobuf.Optics.FileOptions.``objcClassPrefix``)
    [<Extension>]
    static member inline CsharpNamespace(lens : ILens<'a,'b,Google.Protobuf.FileOptions,Google.Protobuf.FileOptions>) : ILens<'a,'b,string,string> =
        lens.ComposeWith(Google.Protobuf.Optics.FileOptions.``csharpNamespace``)
    [<Extension>]
    static member inline CsharpNamespace(traversal : ITraversal<'a,'b,Google.Protobuf.FileOptions,Google.Protobuf.FileOptions>) : ITraversal<'a,'b,string,string> =
        traversal.ComposeWith(Google.Protobuf.Optics.FileOptions.``csharpNamespace``)
    [<Extension>]
    static member inline SwiftPrefix(lens : ILens<'a,'b,Google.Protobuf.FileOptions,Google.Protobuf.FileOptions>) : ILens<'a,'b,string,string> =
        lens.ComposeWith(Google.Protobuf.Optics.FileOptions.``swiftPrefix``)
    [<Extension>]
    static member inline SwiftPrefix(traversal : ITraversal<'a,'b,Google.Protobuf.FileOptions,Google.Protobuf.FileOptions>) : ITraversal<'a,'b,string,string> =
        traversal.ComposeWith(Google.Protobuf.Optics.FileOptions.``swiftPrefix``)
    [<Extension>]
    static member inline PhpClassPrefix(lens : ILens<'a,'b,Google.Protobuf.FileOptions,Google.Protobuf.FileOptions>) : ILens<'a,'b,string,string> =
        lens.ComposeWith(Google.Protobuf.Optics.FileOptions.``phpClassPrefix``)
    [<Extension>]
    static member inline PhpClassPrefix(traversal : ITraversal<'a,'b,Google.Protobuf.FileOptions,Google.Protobuf.FileOptions>) : ITraversal<'a,'b,string,string> =
        traversal.ComposeWith(Google.Protobuf.Optics.FileOptions.``phpClassPrefix``)
    [<Extension>]
    static member inline PhpNamespace(lens : ILens<'a,'b,Google.Protobuf.FileOptions,Google.Protobuf.FileOptions>) : ILens<'a,'b,string,string> =
        lens.ComposeWith(Google.Protobuf.Optics.FileOptions.``phpNamespace``)
    [<Extension>]
    static member inline PhpNamespace(traversal : ITraversal<'a,'b,Google.Protobuf.FileOptions,Google.Protobuf.FileOptions>) : ITraversal<'a,'b,string,string> =
        traversal.ComposeWith(Google.Protobuf.Optics.FileOptions.``phpNamespace``)
    [<Extension>]
    static member inline PhpMetadataNamespace(lens : ILens<'a,'b,Google.Protobuf.FileOptions,Google.Protobuf.FileOptions>) : ILens<'a,'b,string,string> =
        lens.ComposeWith(Google.Protobuf.Optics.FileOptions.``phpMetadataNamespace``)
    [<Extension>]
    static member inline PhpMetadataNamespace(traversal : ITraversal<'a,'b,Google.Protobuf.FileOptions,Google.Protobuf.FileOptions>) : ITraversal<'a,'b,string,string> =
        traversal.ComposeWith(Google.Protobuf.Optics.FileOptions.``phpMetadataNamespace``)
    [<Extension>]
    static member inline RubyPackage(lens : ILens<'a,'b,Google.Protobuf.FileOptions,Google.Protobuf.FileOptions>) : ILens<'a,'b,string,string> =
        lens.ComposeWith(Google.Protobuf.Optics.FileOptions.``rubyPackage``)
    [<Extension>]
    static member inline RubyPackage(traversal : ITraversal<'a,'b,Google.Protobuf.FileOptions,Google.Protobuf.FileOptions>) : ITraversal<'a,'b,string,string> =
        traversal.ComposeWith(Google.Protobuf.Optics.FileOptions.``rubyPackage``)
    [<Extension>]
    static member inline UninterpretedOptions(lens : ILens<'a,'b,Google.Protobuf.FileOptions,Google.Protobuf.FileOptions>) : ILens<'a,'b,Google.Protobuf.UninterpretedOption list,Google.Protobuf.UninterpretedOption list> =
        lens.ComposeWith(Google.Protobuf.Optics.FileOptions.``uninterpretedOptions``)
    [<Extension>]
    static member inline UninterpretedOptions(traversal : ITraversal<'a,'b,Google.Protobuf.FileOptions,Google.Protobuf.FileOptions>) : ITraversal<'a,'b,Google.Protobuf.UninterpretedOption list,Google.Protobuf.UninterpretedOption list> =
        traversal.ComposeWith(Google.Protobuf.Optics.FileOptions.``uninterpretedOptions``)
    [<Extension>]
    static member inline MessageSetWireFormat(lens : ILens<'a,'b,Google.Protobuf.MessageOptions,Google.Protobuf.MessageOptions>) : ILens<'a,'b,bool,bool> =
        lens.ComposeWith(Google.Protobuf.Optics.MessageOptions.``messageSetWireFormat``)
    [<Extension>]
    static member inline MessageSetWireFormat(traversal : ITraversal<'a,'b,Google.Protobuf.MessageOptions,Google.Protobuf.MessageOptions>) : ITraversal<'a,'b,bool,bool> =
        traversal.ComposeWith(Google.Protobuf.Optics.MessageOptions.``messageSetWireFormat``)
    [<Extension>]
    static member inline NoStandardDescriptorAccessor(lens : ILens<'a,'b,Google.Protobuf.MessageOptions,Google.Protobuf.MessageOptions>) : ILens<'a,'b,bool,bool> =
        lens.ComposeWith(Google.Protobuf.Optics.MessageOptions.``noStandardDescriptorAccessor``)
    [<Extension>]
    static member inline NoStandardDescriptorAccessor(traversal : ITraversal<'a,'b,Google.Protobuf.MessageOptions,Google.Protobuf.MessageOptions>) : ITraversal<'a,'b,bool,bool> =
        traversal.ComposeWith(Google.Protobuf.Optics.MessageOptions.``noStandardDescriptorAccessor``)
    [<Extension>]
    static member inline Deprecated(lens : ILens<'a,'b,Google.Protobuf.MessageOptions,Google.Protobuf.MessageOptions>) : ILens<'a,'b,bool,bool> =
        lens.ComposeWith(Google.Protobuf.Optics.MessageOptions.``deprecated``)
    [<Extension>]
    static member inline Deprecated(traversal : ITraversal<'a,'b,Google.Protobuf.MessageOptions,Google.Protobuf.MessageOptions>) : ITraversal<'a,'b,bool,bool> =
        traversal.ComposeWith(Google.Protobuf.Optics.MessageOptions.``deprecated``)
    [<Extension>]
    static member inline MapEntry(lens : ILens<'a,'b,Google.Protobuf.MessageOptions,Google.Protobuf.MessageOptions>) : ILens<'a,'b,bool,bool> =
        lens.ComposeWith(Google.Protobuf.Optics.MessageOptions.``mapEntry``)
    [<Extension>]
    static member inline MapEntry(traversal : ITraversal<'a,'b,Google.Protobuf.MessageOptions,Google.Protobuf.MessageOptions>) : ITraversal<'a,'b,bool,bool> =
        traversal.ComposeWith(Google.Protobuf.Optics.MessageOptions.``mapEntry``)
    [<Extension>]
    static member inline UninterpretedOptions(lens : ILens<'a,'b,Google.Protobuf.MessageOptions,Google.Protobuf.MessageOptions>) : ILens<'a,'b,Google.Protobuf.UninterpretedOption list,Google.Protobuf.UninterpretedOption list> =
        lens.ComposeWith(Google.Protobuf.Optics.MessageOptions.``uninterpretedOptions``)
    [<Extension>]
    static member inline UninterpretedOptions(traversal : ITraversal<'a,'b,Google.Protobuf.MessageOptions,Google.Protobuf.MessageOptions>) : ITraversal<'a,'b,Google.Protobuf.UninterpretedOption list,Google.Protobuf.UninterpretedOption list> =
        traversal.ComposeWith(Google.Protobuf.Optics.MessageOptions.``uninterpretedOptions``)
    [<Extension>]
    static member inline Ctype(lens : ILens<'a,'b,Google.Protobuf.FieldOptions,Google.Protobuf.FieldOptions>) : ILens<'a,'b,Google.Protobuf.FieldOptions.CType,Google.Protobuf.FieldOptions.CType> =
        lens.ComposeWith(Google.Protobuf.Optics.FieldOptions.``ctype``)
    [<Extension>]
    static member inline Ctype(traversal : ITraversal<'a,'b,Google.Protobuf.FieldOptions,Google.Protobuf.FieldOptions>) : ITraversal<'a,'b,Google.Protobuf.FieldOptions.CType,Google.Protobuf.FieldOptions.CType> =
        traversal.ComposeWith(Google.Protobuf.Optics.FieldOptions.``ctype``)
    [<Extension>]
    static member inline Packed(lens : ILens<'a,'b,Google.Protobuf.FieldOptions,Google.Protobuf.FieldOptions>) : ILens<'a,'b,bool,bool> =
        lens.ComposeWith(Google.Protobuf.Optics.FieldOptions.``packed``)
    [<Extension>]
    static member inline Packed(traversal : ITraversal<'a,'b,Google.Protobuf.FieldOptions,Google.Protobuf.FieldOptions>) : ITraversal<'a,'b,bool,bool> =
        traversal.ComposeWith(Google.Protobuf.Optics.FieldOptions.``packed``)
    [<Extension>]
    static member inline Jstype(lens : ILens<'a,'b,Google.Protobuf.FieldOptions,Google.Protobuf.FieldOptions>) : ILens<'a,'b,Google.Protobuf.FieldOptions.JSType,Google.Protobuf.FieldOptions.JSType> =
        lens.ComposeWith(Google.Protobuf.Optics.FieldOptions.``jstype``)
    [<Extension>]
    static member inline Jstype(traversal : ITraversal<'a,'b,Google.Protobuf.FieldOptions,Google.Protobuf.FieldOptions>) : ITraversal<'a,'b,Google.Protobuf.FieldOptions.JSType,Google.Protobuf.FieldOptions.JSType> =
        traversal.ComposeWith(Google.Protobuf.Optics.FieldOptions.``jstype``)
    [<Extension>]
    static member inline Lazy(lens : ILens<'a,'b,Google.Protobuf.FieldOptions,Google.Protobuf.FieldOptions>) : ILens<'a,'b,bool,bool> =
        lens.ComposeWith(Google.Protobuf.Optics.FieldOptions.``lazy``)
    [<Extension>]
    static member inline Lazy(traversal : ITraversal<'a,'b,Google.Protobuf.FieldOptions,Google.Protobuf.FieldOptions>) : ITraversal<'a,'b,bool,bool> =
        traversal.ComposeWith(Google.Protobuf.Optics.FieldOptions.``lazy``)
    [<Extension>]
    static member inline Deprecated(lens : ILens<'a,'b,Google.Protobuf.FieldOptions,Google.Protobuf.FieldOptions>) : ILens<'a,'b,bool,bool> =
        lens.ComposeWith(Google.Protobuf.Optics.FieldOptions.``deprecated``)
    [<Extension>]
    static member inline Deprecated(traversal : ITraversal<'a,'b,Google.Protobuf.FieldOptions,Google.Protobuf.FieldOptions>) : ITraversal<'a,'b,bool,bool> =
        traversal.ComposeWith(Google.Protobuf.Optics.FieldOptions.``deprecated``)
    [<Extension>]
    static member inline Weak(lens : ILens<'a,'b,Google.Protobuf.FieldOptions,Google.Protobuf.FieldOptions>) : ILens<'a,'b,bool,bool> =
        lens.ComposeWith(Google.Protobuf.Optics.FieldOptions.``weak``)
    [<Extension>]
    static member inline Weak(traversal : ITraversal<'a,'b,Google.Protobuf.FieldOptions,Google.Protobuf.FieldOptions>) : ITraversal<'a,'b,bool,bool> =
        traversal.ComposeWith(Google.Protobuf.Optics.FieldOptions.``weak``)
    [<Extension>]
    static member inline UninterpretedOptions(lens : ILens<'a,'b,Google.Protobuf.FieldOptions,Google.Protobuf.FieldOptions>) : ILens<'a,'b,Google.Protobuf.UninterpretedOption list,Google.Protobuf.UninterpretedOption list> =
        lens.ComposeWith(Google.Protobuf.Optics.FieldOptions.``uninterpretedOptions``)
    [<Extension>]
    static member inline UninterpretedOptions(traversal : ITraversal<'a,'b,Google.Protobuf.FieldOptions,Google.Protobuf.FieldOptions>) : ITraversal<'a,'b,Google.Protobuf.UninterpretedOption list,Google.Protobuf.UninterpretedOption list> =
        traversal.ComposeWith(Google.Protobuf.Optics.FieldOptions.``uninterpretedOptions``)
    [<Extension>]
    static member inline UninterpretedOptions(lens : ILens<'a,'b,Google.Protobuf.OneofOptions,Google.Protobuf.OneofOptions>) : ILens<'a,'b,Google.Protobuf.UninterpretedOption list,Google.Protobuf.UninterpretedOption list> =
        lens.ComposeWith(Google.Protobuf.Optics.OneofOptions.``uninterpretedOptions``)
    [<Extension>]
    static member inline UninterpretedOptions(traversal : ITraversal<'a,'b,Google.Protobuf.OneofOptions,Google.Protobuf.OneofOptions>) : ITraversal<'a,'b,Google.Protobuf.UninterpretedOption list,Google.Protobuf.UninterpretedOption list> =
        traversal.ComposeWith(Google.Protobuf.Optics.OneofOptions.``uninterpretedOptions``)
    [<Extension>]
    static member inline AllowAlias(lens : ILens<'a,'b,Google.Protobuf.EnumOptions,Google.Protobuf.EnumOptions>) : ILens<'a,'b,bool,bool> =
        lens.ComposeWith(Google.Protobuf.Optics.EnumOptions.``allowAlias``)
    [<Extension>]
    static member inline AllowAlias(traversal : ITraversal<'a,'b,Google.Protobuf.EnumOptions,Google.Protobuf.EnumOptions>) : ITraversal<'a,'b,bool,bool> =
        traversal.ComposeWith(Google.Protobuf.Optics.EnumOptions.``allowAlias``)
    [<Extension>]
    static member inline Deprecated(lens : ILens<'a,'b,Google.Protobuf.EnumOptions,Google.Protobuf.EnumOptions>) : ILens<'a,'b,bool,bool> =
        lens.ComposeWith(Google.Protobuf.Optics.EnumOptions.``deprecated``)
    [<Extension>]
    static member inline Deprecated(traversal : ITraversal<'a,'b,Google.Protobuf.EnumOptions,Google.Protobuf.EnumOptions>) : ITraversal<'a,'b,bool,bool> =
        traversal.ComposeWith(Google.Protobuf.Optics.EnumOptions.``deprecated``)
    [<Extension>]
    static member inline UninterpretedOptions(lens : ILens<'a,'b,Google.Protobuf.EnumOptions,Google.Protobuf.EnumOptions>) : ILens<'a,'b,Google.Protobuf.UninterpretedOption list,Google.Protobuf.UninterpretedOption list> =
        lens.ComposeWith(Google.Protobuf.Optics.EnumOptions.``uninterpretedOptions``)
    [<Extension>]
    static member inline UninterpretedOptions(traversal : ITraversal<'a,'b,Google.Protobuf.EnumOptions,Google.Protobuf.EnumOptions>) : ITraversal<'a,'b,Google.Protobuf.UninterpretedOption list,Google.Protobuf.UninterpretedOption list> =
        traversal.ComposeWith(Google.Protobuf.Optics.EnumOptions.``uninterpretedOptions``)
    [<Extension>]
    static member inline Deprecated(lens : ILens<'a,'b,Google.Protobuf.EnumValueOptions,Google.Protobuf.EnumValueOptions>) : ILens<'a,'b,bool,bool> =
        lens.ComposeWith(Google.Protobuf.Optics.EnumValueOptions.``deprecated``)
    [<Extension>]
    static member inline Deprecated(traversal : ITraversal<'a,'b,Google.Protobuf.EnumValueOptions,Google.Protobuf.EnumValueOptions>) : ITraversal<'a,'b,bool,bool> =
        traversal.ComposeWith(Google.Protobuf.Optics.EnumValueOptions.``deprecated``)
    [<Extension>]
    static member inline UninterpretedOptions(lens : ILens<'a,'b,Google.Protobuf.EnumValueOptions,Google.Protobuf.EnumValueOptions>) : ILens<'a,'b,Google.Protobuf.UninterpretedOption list,Google.Protobuf.UninterpretedOption list> =
        lens.ComposeWith(Google.Protobuf.Optics.EnumValueOptions.``uninterpretedOptions``)
    [<Extension>]
    static member inline UninterpretedOptions(traversal : ITraversal<'a,'b,Google.Protobuf.EnumValueOptions,Google.Protobuf.EnumValueOptions>) : ITraversal<'a,'b,Google.Protobuf.UninterpretedOption list,Google.Protobuf.UninterpretedOption list> =
        traversal.ComposeWith(Google.Protobuf.Optics.EnumValueOptions.``uninterpretedOptions``)
    [<Extension>]
    static member inline Deprecated(lens : ILens<'a,'b,Google.Protobuf.ServiceOptions,Google.Protobuf.ServiceOptions>) : ILens<'a,'b,bool,bool> =
        lens.ComposeWith(Google.Protobuf.Optics.ServiceOptions.``deprecated``)
    [<Extension>]
    static member inline Deprecated(traversal : ITraversal<'a,'b,Google.Protobuf.ServiceOptions,Google.Protobuf.ServiceOptions>) : ITraversal<'a,'b,bool,bool> =
        traversal.ComposeWith(Google.Protobuf.Optics.ServiceOptions.``deprecated``)
    [<Extension>]
    static member inline UninterpretedOptions(lens : ILens<'a,'b,Google.Protobuf.ServiceOptions,Google.Protobuf.ServiceOptions>) : ILens<'a,'b,Google.Protobuf.UninterpretedOption list,Google.Protobuf.UninterpretedOption list> =
        lens.ComposeWith(Google.Protobuf.Optics.ServiceOptions.``uninterpretedOptions``)
    [<Extension>]
    static member inline UninterpretedOptions(traversal : ITraversal<'a,'b,Google.Protobuf.ServiceOptions,Google.Protobuf.ServiceOptions>) : ITraversal<'a,'b,Google.Protobuf.UninterpretedOption list,Google.Protobuf.UninterpretedOption list> =
        traversal.ComposeWith(Google.Protobuf.Optics.ServiceOptions.``uninterpretedOptions``)
    [<Extension>]
    static member inline Deprecated(lens : ILens<'a,'b,Google.Protobuf.MethodOptions,Google.Protobuf.MethodOptions>) : ILens<'a,'b,bool,bool> =
        lens.ComposeWith(Google.Protobuf.Optics.MethodOptions.``deprecated``)
    [<Extension>]
    static member inline Deprecated(traversal : ITraversal<'a,'b,Google.Protobuf.MethodOptions,Google.Protobuf.MethodOptions>) : ITraversal<'a,'b,bool,bool> =
        traversal.ComposeWith(Google.Protobuf.Optics.MethodOptions.``deprecated``)
    [<Extension>]
    static member inline IdempotencyLevel(lens : ILens<'a,'b,Google.Protobuf.MethodOptions,Google.Protobuf.MethodOptions>) : ILens<'a,'b,Google.Protobuf.MethodOptions.IdempotencyLevel,Google.Protobuf.MethodOptions.IdempotencyLevel> =
        lens.ComposeWith(Google.Protobuf.Optics.MethodOptions.``idempotencyLevel``)
    [<Extension>]
    static member inline IdempotencyLevel(traversal : ITraversal<'a,'b,Google.Protobuf.MethodOptions,Google.Protobuf.MethodOptions>) : ITraversal<'a,'b,Google.Protobuf.MethodOptions.IdempotencyLevel,Google.Protobuf.MethodOptions.IdempotencyLevel> =
        traversal.ComposeWith(Google.Protobuf.Optics.MethodOptions.``idempotencyLevel``)
    [<Extension>]
    static member inline UninterpretedOptions(lens : ILens<'a,'b,Google.Protobuf.MethodOptions,Google.Protobuf.MethodOptions>) : ILens<'a,'b,Google.Protobuf.UninterpretedOption list,Google.Protobuf.UninterpretedOption list> =
        lens.ComposeWith(Google.Protobuf.Optics.MethodOptions.``uninterpretedOptions``)
    [<Extension>]
    static member inline UninterpretedOptions(traversal : ITraversal<'a,'b,Google.Protobuf.MethodOptions,Google.Protobuf.MethodOptions>) : ITraversal<'a,'b,Google.Protobuf.UninterpretedOption list,Google.Protobuf.UninterpretedOption list> =
        traversal.ComposeWith(Google.Protobuf.Optics.MethodOptions.``uninterpretedOptions``)
    [<Extension>]
    static member inline Names(lens : ILens<'a,'b,Google.Protobuf.UninterpretedOption,Google.Protobuf.UninterpretedOption>) : ILens<'a,'b,Google.Protobuf.UninterpretedOption.NamePart list,Google.Protobuf.UninterpretedOption.NamePart list> =
        lens.ComposeWith(Google.Protobuf.Optics.UninterpretedOption.``names``)
    [<Extension>]
    static member inline Names(traversal : ITraversal<'a,'b,Google.Protobuf.UninterpretedOption,Google.Protobuf.UninterpretedOption>) : ITraversal<'a,'b,Google.Protobuf.UninterpretedOption.NamePart list,Google.Protobuf.UninterpretedOption.NamePart list> =
        traversal.ComposeWith(Google.Protobuf.Optics.UninterpretedOption.``names``)
    [<Extension>]
    static member inline Value(lens : ILens<'a,'b,Google.Protobuf.UninterpretedOption,Google.Protobuf.UninterpretedOption>) : ILens<'a,'b,Google.Protobuf.UninterpretedOption.ValueCase,Google.Protobuf.UninterpretedOption.ValueCase> =
        lens.ComposeWith(Google.Protobuf.Optics.UninterpretedOption.``value``)
    [<Extension>]
    static member inline Value(traversal : ITraversal<'a,'b,Google.Protobuf.UninterpretedOption,Google.Protobuf.UninterpretedOption>) : ITraversal<'a,'b,Google.Protobuf.UninterpretedOption.ValueCase,Google.Protobuf.UninterpretedOption.ValueCase> =
        traversal.ComposeWith(Google.Protobuf.Optics.UninterpretedOption.``value``)
    [<Extension>]
    static member inline IfIdentifierValue(prism : IPrism<'s,'t,Google.Protobuf.UninterpretedOption.ValueCase,Google.Protobuf.UninterpretedOption.ValueCase>) : IPrism<'s,'t,string,string> = 
        prism.ComposeWith(Google.Protobuf.Optics.UninterpretedOption.ValuePrisms.ifIdentifierValue)
    [<Extension>]
    static member inline IfIdentifierValue(traversal : ITraversal<'s,'t,Google.Protobuf.UninterpretedOption.ValueCase,Google.Protobuf.UninterpretedOption.ValueCase>) : ITraversal<'s,'t,string,string> = 
        traversal.ComposeWith(Google.Protobuf.Optics.UninterpretedOption.ValuePrisms.ifIdentifierValue)
    [<Extension>]
    static member inline IfPositiveIntValue(prism : IPrism<'s,'t,Google.Protobuf.UninterpretedOption.ValueCase,Google.Protobuf.UninterpretedOption.ValueCase>) : IPrism<'s,'t,uint64,uint64> = 
        prism.ComposeWith(Google.Protobuf.Optics.UninterpretedOption.ValuePrisms.ifPositiveIntValue)
    [<Extension>]
    static member inline IfPositiveIntValue(traversal : ITraversal<'s,'t,Google.Protobuf.UninterpretedOption.ValueCase,Google.Protobuf.UninterpretedOption.ValueCase>) : ITraversal<'s,'t,uint64,uint64> = 
        traversal.ComposeWith(Google.Protobuf.Optics.UninterpretedOption.ValuePrisms.ifPositiveIntValue)
    [<Extension>]
    static member inline IfNegativeIntValue(prism : IPrism<'s,'t,Google.Protobuf.UninterpretedOption.ValueCase,Google.Protobuf.UninterpretedOption.ValueCase>) : IPrism<'s,'t,int64,int64> = 
        prism.ComposeWith(Google.Protobuf.Optics.UninterpretedOption.ValuePrisms.ifNegativeIntValue)
    [<Extension>]
    static member inline IfNegativeIntValue(traversal : ITraversal<'s,'t,Google.Protobuf.UninterpretedOption.ValueCase,Google.Protobuf.UninterpretedOption.ValueCase>) : ITraversal<'s,'t,int64,int64> = 
        traversal.ComposeWith(Google.Protobuf.Optics.UninterpretedOption.ValuePrisms.ifNegativeIntValue)
    [<Extension>]
    static member inline IfDoubleValue(prism : IPrism<'s,'t,Google.Protobuf.UninterpretedOption.ValueCase,Google.Protobuf.UninterpretedOption.ValueCase>) : IPrism<'s,'t,double,double> = 
        prism.ComposeWith(Google.Protobuf.Optics.UninterpretedOption.ValuePrisms.ifDoubleValue)
    [<Extension>]
    static member inline IfDoubleValue(traversal : ITraversal<'s,'t,Google.Protobuf.UninterpretedOption.ValueCase,Google.Protobuf.UninterpretedOption.ValueCase>) : ITraversal<'s,'t,double,double> = 
        traversal.ComposeWith(Google.Protobuf.Optics.UninterpretedOption.ValuePrisms.ifDoubleValue)
    [<Extension>]
    static member inline IfStringValue(prism : IPrism<'s,'t,Google.Protobuf.UninterpretedOption.ValueCase,Google.Protobuf.UninterpretedOption.ValueCase>) : IPrism<'s,'t,FsGrpc.Bytes,FsGrpc.Bytes> = 
        prism.ComposeWith(Google.Protobuf.Optics.UninterpretedOption.ValuePrisms.ifStringValue)
    [<Extension>]
    static member inline IfStringValue(traversal : ITraversal<'s,'t,Google.Protobuf.UninterpretedOption.ValueCase,Google.Protobuf.UninterpretedOption.ValueCase>) : ITraversal<'s,'t,FsGrpc.Bytes,FsGrpc.Bytes> = 
        traversal.ComposeWith(Google.Protobuf.Optics.UninterpretedOption.ValuePrisms.ifStringValue)
    [<Extension>]
    static member inline IfAggregateValue(prism : IPrism<'s,'t,Google.Protobuf.UninterpretedOption.ValueCase,Google.Protobuf.UninterpretedOption.ValueCase>) : IPrism<'s,'t,string,string> = 
        prism.ComposeWith(Google.Protobuf.Optics.UninterpretedOption.ValuePrisms.ifAggregateValue)
    [<Extension>]
    static member inline IfAggregateValue(traversal : ITraversal<'s,'t,Google.Protobuf.UninterpretedOption.ValueCase,Google.Protobuf.UninterpretedOption.ValueCase>) : ITraversal<'s,'t,string,string> = 
        traversal.ComposeWith(Google.Protobuf.Optics.UninterpretedOption.ValuePrisms.ifAggregateValue)
    [<Extension>]
    static member inline NamePart(lens : ILens<'a,'b,Google.Protobuf.UninterpretedOption.NamePart,Google.Protobuf.UninterpretedOption.NamePart>) : ILens<'a,'b,string,string> =
        lens.ComposeWith(Google.Protobuf.Optics.UninterpretedOption.NamePart.``namePart``)
    [<Extension>]
    static member inline NamePart(traversal : ITraversal<'a,'b,Google.Protobuf.UninterpretedOption.NamePart,Google.Protobuf.UninterpretedOption.NamePart>) : ITraversal<'a,'b,string,string> =
        traversal.ComposeWith(Google.Protobuf.Optics.UninterpretedOption.NamePart.``namePart``)
    [<Extension>]
    static member inline IsExtension(lens : ILens<'a,'b,Google.Protobuf.UninterpretedOption.NamePart,Google.Protobuf.UninterpretedOption.NamePart>) : ILens<'a,'b,bool,bool> =
        lens.ComposeWith(Google.Protobuf.Optics.UninterpretedOption.NamePart.``isExtension``)
    [<Extension>]
    static member inline IsExtension(traversal : ITraversal<'a,'b,Google.Protobuf.UninterpretedOption.NamePart,Google.Protobuf.UninterpretedOption.NamePart>) : ITraversal<'a,'b,bool,bool> =
        traversal.ComposeWith(Google.Protobuf.Optics.UninterpretedOption.NamePart.``isExtension``)
    [<Extension>]
    static member inline Location(lens : ILens<'a,'b,Google.Protobuf.SourceCodeInfo,Google.Protobuf.SourceCodeInfo>) : ILens<'a,'b,Google.Protobuf.SourceCodeInfo.Location list,Google.Protobuf.SourceCodeInfo.Location list> =
        lens.ComposeWith(Google.Protobuf.Optics.SourceCodeInfo.``location``)
    [<Extension>]
    static member inline Location(traversal : ITraversal<'a,'b,Google.Protobuf.SourceCodeInfo,Google.Protobuf.SourceCodeInfo>) : ITraversal<'a,'b,Google.Protobuf.SourceCodeInfo.Location list,Google.Protobuf.SourceCodeInfo.Location list> =
        traversal.ComposeWith(Google.Protobuf.Optics.SourceCodeInfo.``location``)
    [<Extension>]
    static member inline Paths(lens : ILens<'a,'b,Google.Protobuf.SourceCodeInfo.Location,Google.Protobuf.SourceCodeInfo.Location>) : ILens<'a,'b,int list,int list> =
        lens.ComposeWith(Google.Protobuf.Optics.SourceCodeInfo.Location.``paths``)
    [<Extension>]
    static member inline Paths(traversal : ITraversal<'a,'b,Google.Protobuf.SourceCodeInfo.Location,Google.Protobuf.SourceCodeInfo.Location>) : ITraversal<'a,'b,int list,int list> =
        traversal.ComposeWith(Google.Protobuf.Optics.SourceCodeInfo.Location.``paths``)
    [<Extension>]
    static member inline Spans(lens : ILens<'a,'b,Google.Protobuf.SourceCodeInfo.Location,Google.Protobuf.SourceCodeInfo.Location>) : ILens<'a,'b,int list,int list> =
        lens.ComposeWith(Google.Protobuf.Optics.SourceCodeInfo.Location.``spans``)
    [<Extension>]
    static member inline Spans(traversal : ITraversal<'a,'b,Google.Protobuf.SourceCodeInfo.Location,Google.Protobuf.SourceCodeInfo.Location>) : ITraversal<'a,'b,int list,int list> =
        traversal.ComposeWith(Google.Protobuf.Optics.SourceCodeInfo.Location.``spans``)
    [<Extension>]
    static member inline LeadingComments(lens : ILens<'a,'b,Google.Protobuf.SourceCodeInfo.Location,Google.Protobuf.SourceCodeInfo.Location>) : ILens<'a,'b,string,string> =
        lens.ComposeWith(Google.Protobuf.Optics.SourceCodeInfo.Location.``leadingComments``)
    [<Extension>]
    static member inline LeadingComments(traversal : ITraversal<'a,'b,Google.Protobuf.SourceCodeInfo.Location,Google.Protobuf.SourceCodeInfo.Location>) : ITraversal<'a,'b,string,string> =
        traversal.ComposeWith(Google.Protobuf.Optics.SourceCodeInfo.Location.``leadingComments``)
    [<Extension>]
    static member inline TrailingComments(lens : ILens<'a,'b,Google.Protobuf.SourceCodeInfo.Location,Google.Protobuf.SourceCodeInfo.Location>) : ILens<'a,'b,string,string> =
        lens.ComposeWith(Google.Protobuf.Optics.SourceCodeInfo.Location.``trailingComments``)
    [<Extension>]
    static member inline TrailingComments(traversal : ITraversal<'a,'b,Google.Protobuf.SourceCodeInfo.Location,Google.Protobuf.SourceCodeInfo.Location>) : ITraversal<'a,'b,string,string> =
        traversal.ComposeWith(Google.Protobuf.Optics.SourceCodeInfo.Location.``trailingComments``)
    [<Extension>]
    static member inline LeadingDetachedComments(lens : ILens<'a,'b,Google.Protobuf.SourceCodeInfo.Location,Google.Protobuf.SourceCodeInfo.Location>) : ILens<'a,'b,string list,string list> =
        lens.ComposeWith(Google.Protobuf.Optics.SourceCodeInfo.Location.``leadingDetachedComments``)
    [<Extension>]
    static member inline LeadingDetachedComments(traversal : ITraversal<'a,'b,Google.Protobuf.SourceCodeInfo.Location,Google.Protobuf.SourceCodeInfo.Location>) : ITraversal<'a,'b,string list,string list> =
        traversal.ComposeWith(Google.Protobuf.Optics.SourceCodeInfo.Location.``leadingDetachedComments``)
    [<Extension>]
    static member inline Annotations(lens : ILens<'a,'b,Google.Protobuf.GeneratedCodeInfo,Google.Protobuf.GeneratedCodeInfo>) : ILens<'a,'b,Google.Protobuf.GeneratedCodeInfo.Annotation list,Google.Protobuf.GeneratedCodeInfo.Annotation list> =
        lens.ComposeWith(Google.Protobuf.Optics.GeneratedCodeInfo.``annotations``)
    [<Extension>]
    static member inline Annotations(traversal : ITraversal<'a,'b,Google.Protobuf.GeneratedCodeInfo,Google.Protobuf.GeneratedCodeInfo>) : ITraversal<'a,'b,Google.Protobuf.GeneratedCodeInfo.Annotation list,Google.Protobuf.GeneratedCodeInfo.Annotation list> =
        traversal.ComposeWith(Google.Protobuf.Optics.GeneratedCodeInfo.``annotations``)
    [<Extension>]
    static member inline Paths(lens : ILens<'a,'b,Google.Protobuf.GeneratedCodeInfo.Annotation,Google.Protobuf.GeneratedCodeInfo.Annotation>) : ILens<'a,'b,int list,int list> =
        lens.ComposeWith(Google.Protobuf.Optics.GeneratedCodeInfo.Annotation.``paths``)
    [<Extension>]
    static member inline Paths(traversal : ITraversal<'a,'b,Google.Protobuf.GeneratedCodeInfo.Annotation,Google.Protobuf.GeneratedCodeInfo.Annotation>) : ITraversal<'a,'b,int list,int list> =
        traversal.ComposeWith(Google.Protobuf.Optics.GeneratedCodeInfo.Annotation.``paths``)
    [<Extension>]
    static member inline SourceFile(lens : ILens<'a,'b,Google.Protobuf.GeneratedCodeInfo.Annotation,Google.Protobuf.GeneratedCodeInfo.Annotation>) : ILens<'a,'b,string,string> =
        lens.ComposeWith(Google.Protobuf.Optics.GeneratedCodeInfo.Annotation.``sourceFile``)
    [<Extension>]
    static member inline SourceFile(traversal : ITraversal<'a,'b,Google.Protobuf.GeneratedCodeInfo.Annotation,Google.Protobuf.GeneratedCodeInfo.Annotation>) : ITraversal<'a,'b,string,string> =
        traversal.ComposeWith(Google.Protobuf.Optics.GeneratedCodeInfo.Annotation.``sourceFile``)
    [<Extension>]
    static member inline Begin(lens : ILens<'a,'b,Google.Protobuf.GeneratedCodeInfo.Annotation,Google.Protobuf.GeneratedCodeInfo.Annotation>) : ILens<'a,'b,int,int> =
        lens.ComposeWith(Google.Protobuf.Optics.GeneratedCodeInfo.Annotation.``begin``)
    [<Extension>]
    static member inline Begin(traversal : ITraversal<'a,'b,Google.Protobuf.GeneratedCodeInfo.Annotation,Google.Protobuf.GeneratedCodeInfo.Annotation>) : ITraversal<'a,'b,int,int> =
        traversal.ComposeWith(Google.Protobuf.Optics.GeneratedCodeInfo.Annotation.``begin``)
    [<Extension>]
    static member inline End(lens : ILens<'a,'b,Google.Protobuf.GeneratedCodeInfo.Annotation,Google.Protobuf.GeneratedCodeInfo.Annotation>) : ILens<'a,'b,int,int> =
        lens.ComposeWith(Google.Protobuf.Optics.GeneratedCodeInfo.Annotation.``end``)
    [<Extension>]
    static member inline End(traversal : ITraversal<'a,'b,Google.Protobuf.GeneratedCodeInfo.Annotation,Google.Protobuf.GeneratedCodeInfo.Annotation>) : ITraversal<'a,'b,int,int> =
        traversal.ComposeWith(Google.Protobuf.Optics.GeneratedCodeInfo.Annotation.``end``)

