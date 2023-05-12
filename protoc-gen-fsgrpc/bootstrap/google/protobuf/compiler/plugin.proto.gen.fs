namespace rec Google.Protobuf.Compiler
open FsGrpc.Protobuf
#nowarn "40"


[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module Version =

    [<System.Runtime.CompilerServices.IsByRefLike>]
    type Builder =
        struct
            val mutable Major: int // (1)
            val mutable Minor: int // (2)
            val mutable Patch: int // (3)
            val mutable Suffix: string // (4)
        end
        with
        member x.Put ((tag, reader): int * Reader) =
            match tag with
            | 1 -> x.Major <- ValueCodec.Int32.ReadValue reader
            | 2 -> x.Minor <- ValueCodec.Int32.ReadValue reader
            | 3 -> x.Patch <- ValueCodec.Int32.ReadValue reader
            | 4 -> x.Suffix <- ValueCodec.String.ReadValue reader
            | _ -> reader.SkipLastField()
        member x.Build : Google.Protobuf.Compiler.Version = {
            Major = x.Major
            Minor = x.Minor
            Patch = x.Patch
            Suffix = x.Suffix |> orEmptyString
            }

/// <summary>The version number of protocol compiler.</summary>
type private _Version = Version
[<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.MessageConverter>)>]
[<FsGrpc.Protobuf.Message>]
type Version = {
    // Field Declarations
    [<System.Text.Json.Serialization.JsonPropertyName("major")>] Major: int // (1)
    [<System.Text.Json.Serialization.JsonPropertyName("minor")>] Minor: int // (2)
    [<System.Text.Json.Serialization.JsonPropertyName("patch")>] Patch: int // (3)
    /// <summary>
    /// A suffix for alpha, beta or rc release, e.g., "alpha-1", "rc2". It should
    /// be empty for mainline stable releases.
    /// </summary>
    [<System.Text.Json.Serialization.JsonPropertyName("suffix")>] Suffix: string // (4)
    }
    with
    static member Proto : Lazy<ProtoDef<Version>> =
        lazy
        // Field Definitions
        let Major = FieldCodec.Primitive ValueCodec.Int32 (1, "major")
        let Minor = FieldCodec.Primitive ValueCodec.Int32 (2, "minor")
        let Patch = FieldCodec.Primitive ValueCodec.Int32 (3, "patch")
        let Suffix = FieldCodec.Primitive ValueCodec.String (4, "suffix")
        // Proto Definition Implementation
        { // ProtoDef<Version>
            Name = "Version"
            Empty = {
                Major = Major.GetDefault()
                Minor = Minor.GetDefault()
                Patch = Patch.GetDefault()
                Suffix = Suffix.GetDefault()
                }
            Size = fun (m: Version) ->
                0
                + Major.CalcFieldSize m.Major
                + Minor.CalcFieldSize m.Minor
                + Patch.CalcFieldSize m.Patch
                + Suffix.CalcFieldSize m.Suffix
            Encode = fun (w: Google.Protobuf.CodedOutputStream) (m: Version) ->
                Major.WriteField w m.Major
                Minor.WriteField w m.Minor
                Patch.WriteField w m.Patch
                Suffix.WriteField w m.Suffix
            Decode = fun (r: Google.Protobuf.CodedInputStream) ->
                let mutable builder = new Google.Protobuf.Compiler.Version.Builder()
                let mutable tag = 0
                while read r &tag do
                    builder.Put (tag, r)
                builder.Build
            EncodeJson = fun (o: JsonOptions) ->
                let writeMajor = Major.WriteJsonField o
                let writeMinor = Minor.WriteJsonField o
                let writePatch = Patch.WriteJsonField o
                let writeSuffix = Suffix.WriteJsonField o
                let encode (w: System.Text.Json.Utf8JsonWriter) (m: Version) =
                    writeMajor w m.Major
                    writeMinor w m.Minor
                    writePatch w m.Patch
                    writeSuffix w m.Suffix
                encode
            DecodeJson = fun (node: System.Text.Json.Nodes.JsonNode) ->
                let update value (kvPair: System.Collections.Generic.KeyValuePair<string,System.Text.Json.Nodes.JsonNode>) : Version =
                    match kvPair.Key with
                    | "major" -> { value with Major = Major.ReadJsonField kvPair.Value }
                    | "minor" -> { value with Minor = Minor.ReadJsonField kvPair.Value }
                    | "patch" -> { value with Patch = Patch.ReadJsonField kvPair.Value }
                    | "suffix" -> { value with Suffix = Suffix.ReadJsonField kvPair.Value }
                    | _ -> value
                Seq.fold update _Version.empty (node.AsObject ())
        }
    static member empty
        with get() = Google.Protobuf.Compiler._Version.Proto.Value.Empty

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module CodeGeneratorRequest =

    [<System.Runtime.CompilerServices.IsByRefLike>]
    type Builder =
        struct
            val mutable FilesToGenerate: RepeatedBuilder<string> // (1)
            val mutable Parameter: string // (2)
            val mutable ProtoFiles: RepeatedBuilder<Google.Protobuf.FileDescriptorProto> // (15)
            val mutable CompilerVersion: OptionBuilder<Google.Protobuf.Compiler.Version> // (3)
        end
        with
        member x.Put ((tag, reader): int * Reader) =
            match tag with
            | 1 -> x.FilesToGenerate.Add (ValueCodec.String.ReadValue reader)
            | 2 -> x.Parameter <- ValueCodec.String.ReadValue reader
            | 15 -> x.ProtoFiles.Add (ValueCodec.Message<Google.Protobuf.FileDescriptorProto>.ReadValue reader)
            | 3 -> x.CompilerVersion.Set (ValueCodec.Message<Google.Protobuf.Compiler.Version>.ReadValue reader)
            | _ -> reader.SkipLastField()
        member x.Build : Google.Protobuf.Compiler.CodeGeneratorRequest = {
            FilesToGenerate = x.FilesToGenerate.Build
            Parameter = x.Parameter |> orEmptyString
            ProtoFiles = x.ProtoFiles.Build
            CompilerVersion = x.CompilerVersion.Build
            }

/// <summary>An encoded CodeGeneratorRequest is written to the plugin's stdin.</summary>
type private _CodeGeneratorRequest = CodeGeneratorRequest
[<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.MessageConverter>)>]
[<FsGrpc.Protobuf.Message>]
type CodeGeneratorRequest = {
    // Field Declarations
    /// <summary>
    /// The .proto files that were explicitly listed on the command-line.  The
    /// code generator should generate code only for these files.  Each file's
    /// descriptor will be included in proto_file, below.
    /// </summary>
    [<System.Text.Json.Serialization.JsonPropertyName("filesToGenerate")>] FilesToGenerate: string list // (1)
    /// <summary>The generator parameter passed on the command-line.</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("parameter")>] Parameter: string // (2)
    /// <summary>
    /// FileDescriptorProtos for all files in files_to_generate and everything
    /// they import.  The files will appear in topological order, so each file
    /// appears before any file that imports it.
    /// 
    /// protoc guarantees that all proto_files will be written after
    /// the fields above, even though this is not technically guaranteed by the
    /// protobuf wire format.  This theoretically could allow a plugin to stream
    /// in the FileDescriptorProtos and handle them one by one rather than read
    /// the entire set into memory at once.  However, as of this writing, this
    /// is not similarly optimized on protoc's end -- it will store all fields in
    /// memory at once before sending them to the plugin.
    /// 
    /// Type names of fields and extensions in the FileDescriptorProto are always
    /// fully qualified.
    /// </summary>
    [<System.Text.Json.Serialization.JsonPropertyName("protoFiles")>] ProtoFiles: Google.Protobuf.FileDescriptorProto list // (15)
    /// <summary>The version number of protocol compiler.</summary>
    [<System.Text.Json.Serialization.JsonPropertyName("compilerVersion")>] CompilerVersion: Google.Protobuf.Compiler.Version option // (3)
    }
    with
    static member Proto : Lazy<ProtoDef<CodeGeneratorRequest>> =
        lazy
        // Field Definitions
        let FilesToGenerate = FieldCodec.Repeated ValueCodec.String (1, "filesToGenerate")
        let Parameter = FieldCodec.Primitive ValueCodec.String (2, "parameter")
        let ProtoFiles = FieldCodec.Repeated ValueCodec.Message<Google.Protobuf.FileDescriptorProto> (15, "protoFiles")
        let CompilerVersion = FieldCodec.Optional ValueCodec.Message<Google.Protobuf.Compiler.Version> (3, "compilerVersion")
        // Proto Definition Implementation
        { // ProtoDef<CodeGeneratorRequest>
            Name = "CodeGeneratorRequest"
            Empty = {
                FilesToGenerate = FilesToGenerate.GetDefault()
                Parameter = Parameter.GetDefault()
                ProtoFiles = ProtoFiles.GetDefault()
                CompilerVersion = CompilerVersion.GetDefault()
                }
            Size = fun (m: CodeGeneratorRequest) ->
                0
                + FilesToGenerate.CalcFieldSize m.FilesToGenerate
                + Parameter.CalcFieldSize m.Parameter
                + ProtoFiles.CalcFieldSize m.ProtoFiles
                + CompilerVersion.CalcFieldSize m.CompilerVersion
            Encode = fun (w: Google.Protobuf.CodedOutputStream) (m: CodeGeneratorRequest) ->
                FilesToGenerate.WriteField w m.FilesToGenerate
                Parameter.WriteField w m.Parameter
                ProtoFiles.WriteField w m.ProtoFiles
                CompilerVersion.WriteField w m.CompilerVersion
            Decode = fun (r: Google.Protobuf.CodedInputStream) ->
                let mutable builder = new Google.Protobuf.Compiler.CodeGeneratorRequest.Builder()
                let mutable tag = 0
                while read r &tag do
                    builder.Put (tag, r)
                builder.Build
            EncodeJson = fun (o: JsonOptions) ->
                let writeFilesToGenerate = FilesToGenerate.WriteJsonField o
                let writeParameter = Parameter.WriteJsonField o
                let writeProtoFiles = ProtoFiles.WriteJsonField o
                let writeCompilerVersion = CompilerVersion.WriteJsonField o
                let encode (w: System.Text.Json.Utf8JsonWriter) (m: CodeGeneratorRequest) =
                    writeFilesToGenerate w m.FilesToGenerate
                    writeParameter w m.Parameter
                    writeProtoFiles w m.ProtoFiles
                    writeCompilerVersion w m.CompilerVersion
                encode
            DecodeJson = fun (node: System.Text.Json.Nodes.JsonNode) ->
                let update value (kvPair: System.Collections.Generic.KeyValuePair<string,System.Text.Json.Nodes.JsonNode>) : CodeGeneratorRequest =
                    match kvPair.Key with
                    | "filesToGenerate" -> { value with FilesToGenerate = FilesToGenerate.ReadJsonField kvPair.Value }
                    | "parameter" -> { value with Parameter = Parameter.ReadJsonField kvPair.Value }
                    | "protoFiles" -> { value with ProtoFiles = ProtoFiles.ReadJsonField kvPair.Value }
                    | "compilerVersion" -> { value with CompilerVersion = CompilerVersion.ReadJsonField kvPair.Value }
                    | _ -> value
                Seq.fold update _CodeGeneratorRequest.empty (node.AsObject ())
        }
    static member empty
        with get() = Google.Protobuf.Compiler._CodeGeneratorRequest.Proto.Value.Empty

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module CodeGeneratorResponse =

    [<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    module File =

        [<System.Runtime.CompilerServices.IsByRefLike>]
        type Builder =
            struct
                val mutable Name: string // (1)
                val mutable InsertionPoint: string // (2)
                val mutable Content: string // (15)
            end
            with
            member x.Put ((tag, reader): int * Reader) =
                match tag with
                | 1 -> x.Name <- ValueCodec.String.ReadValue reader
                | 2 -> x.InsertionPoint <- ValueCodec.String.ReadValue reader
                | 15 -> x.Content <- ValueCodec.String.ReadValue reader
                | _ -> reader.SkipLastField()
            member x.Build : Google.Protobuf.Compiler.CodeGeneratorResponse.File = {
                Name = x.Name |> orEmptyString
                InsertionPoint = x.InsertionPoint |> orEmptyString
                Content = x.Content |> orEmptyString
                }

    /// <summary>Represents a single generated file.</summary>
    type private _File = File
    [<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.MessageConverter>)>]
    [<FsGrpc.Protobuf.Message>]
    type File = {
        // Field Declarations
        /// <summary>
        /// The file name, relative to the output directory.  The name must not
        /// contain "." or ".." components and must be relative, not be absolute (so,
        /// the file cannot lie outside the output directory).  "/" must be used as
        /// the path separator, not "\".
        /// 
        /// If the name is omitted, the content will be appended to the previous
        /// file.  This allows the generator to break large files into small chunks,
        /// and allows the generated text to be streamed back to protoc so that large
        /// files need not reside completely in memory at one time.  Note that as of
        /// this writing protoc does not optimize for this -- it will read the entire
        /// CodeGeneratorResponse before writing files to disk.
        /// </summary>
        [<System.Text.Json.Serialization.JsonPropertyName("name")>] Name: string // (1)
        /// <summary>
        /// If non-empty, indicates that the named file should already exist, and the
        /// content here is to be inserted into that file at a defined insertion
        /// point.  This feature allows a code generator to extend the output
        /// produced by another code generator.  The original generator may provide
        /// insertion points by placing special annotations in the file that look
        /// like:
        ///   @@protoc_insertion_point(NAME)
        /// The annotation can have arbitrary text before and after it on the line,
        /// which allows it to be placed in a comment.  NAME should be replaced with
        /// an identifier naming the point -- this is what other generators will use
        /// as the insertion_point.  Code inserted at this point will be placed
        /// immediately above the line containing the insertion point (thus multiple
        /// insertions to the same point will come out in the order they were added).
        /// The double-@ is intended to make it unlikely that the generated code
        /// could contain things that look like insertion points by accident.
        /// 
        /// For example, the C++ code generator places the following line in the
        /// .pb.h files that it generates:
        ///   // @@protoc_insertion_point(namespace_scope)
        /// This line appears within the scope of the file's package namespace, but
        /// outside of any particular class.  Another plugin can then specify the
        /// insertion_point "namespace_scope" to generate additional classes or
        /// other declarations that should be placed in this scope.
        /// 
        /// Note that if the line containing the insertion point begins with
        /// whitespace, the same whitespace will be added to every line of the
        /// inserted text.  This is useful for languages like Python, where
        /// indentation matters.  In these languages, the insertion point comment
        /// should be indented the same amount as any inserted code will need to be
        /// in order to work correctly in that context.
        /// 
        /// The code generator that generates the initial file and the one which
        /// inserts into it must both run as part of a single invocation of protoc.
        /// Code generators are executed in the order in which they appear on the
        /// command line.
        /// 
        /// If |insertion_point| is present, |name| must also be present.
        /// </summary>
        [<System.Text.Json.Serialization.JsonPropertyName("insertionPoint")>] InsertionPoint: string // (2)
        /// <summary>The file contents.</summary>
        [<System.Text.Json.Serialization.JsonPropertyName("content")>] Content: string // (15)
        }
        with
        static member Proto : Lazy<ProtoDef<File>> =
            lazy
            // Field Definitions
            let Name = FieldCodec.Primitive ValueCodec.String (1, "name")
            let InsertionPoint = FieldCodec.Primitive ValueCodec.String (2, "insertionPoint")
            let Content = FieldCodec.Primitive ValueCodec.String (15, "content")
            // Proto Definition Implementation
            { // ProtoDef<File>
                Name = "File"
                Empty = {
                    Name = Name.GetDefault()
                    InsertionPoint = InsertionPoint.GetDefault()
                    Content = Content.GetDefault()
                    }
                Size = fun (m: File) ->
                    0
                    + Name.CalcFieldSize m.Name
                    + InsertionPoint.CalcFieldSize m.InsertionPoint
                    + Content.CalcFieldSize m.Content
                Encode = fun (w: Google.Protobuf.CodedOutputStream) (m: File) ->
                    Name.WriteField w m.Name
                    InsertionPoint.WriteField w m.InsertionPoint
                    Content.WriteField w m.Content
                Decode = fun (r: Google.Protobuf.CodedInputStream) ->
                    let mutable builder = new Google.Protobuf.Compiler.CodeGeneratorResponse.File.Builder()
                    let mutable tag = 0
                    while read r &tag do
                        builder.Put (tag, r)
                    builder.Build
                EncodeJson = fun (o: JsonOptions) ->
                    let writeName = Name.WriteJsonField o
                    let writeInsertionPoint = InsertionPoint.WriteJsonField o
                    let writeContent = Content.WriteJsonField o
                    let encode (w: System.Text.Json.Utf8JsonWriter) (m: File) =
                        writeName w m.Name
                        writeInsertionPoint w m.InsertionPoint
                        writeContent w m.Content
                    encode
                DecodeJson = fun (node: System.Text.Json.Nodes.JsonNode) ->
                    let update value (kvPair: System.Collections.Generic.KeyValuePair<string,System.Text.Json.Nodes.JsonNode>) : File =
                        match kvPair.Key with
                        | "name" -> { value with Name = Name.ReadJsonField kvPair.Value }
                        | "insertionPoint" -> { value with InsertionPoint = InsertionPoint.ReadJsonField kvPair.Value }
                        | "content" -> { value with Content = Content.ReadJsonField kvPair.Value }
                        | _ -> value
                    Seq.fold update _File.empty (node.AsObject ())
            }
        static member empty
            with get() = Google.Protobuf.Compiler.CodeGeneratorResponse._File.Proto.Value.Empty

    /// <summary>Sync with code_generator.h.</summary>
    [<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.EnumConverter<Feature>>)>]
    type Feature =
    | [<FsGrpc.Protobuf.ProtobufName("FEATURE_NONE")>] None = 0
    | [<FsGrpc.Protobuf.ProtobufName("FEATURE_PROTO3_OPTIONAL")>] Proto3Optional = 1

    [<System.Runtime.CompilerServices.IsByRefLike>]
    type Builder =
        struct
            val mutable Error: string // (1)
            val mutable SupportedFeatures: uint64 // (2)
            val mutable Files: RepeatedBuilder<Google.Protobuf.Compiler.CodeGeneratorResponse.File> // (15)
        end
        with
        member x.Put ((tag, reader): int * Reader) =
            match tag with
            | 1 -> x.Error <- ValueCodec.String.ReadValue reader
            | 2 -> x.SupportedFeatures <- ValueCodec.UInt64.ReadValue reader
            | 15 -> x.Files.Add (ValueCodec.Message<Google.Protobuf.Compiler.CodeGeneratorResponse.File>.ReadValue reader)
            | _ -> reader.SkipLastField()
        member x.Build : Google.Protobuf.Compiler.CodeGeneratorResponse = {
            Error = x.Error |> orEmptyString
            SupportedFeatures = x.SupportedFeatures
            Files = x.Files.Build
            }

/// <summary>The plugin writes an encoded CodeGeneratorResponse to stdout.</summary>
type private _CodeGeneratorResponse = CodeGeneratorResponse
[<System.Text.Json.Serialization.JsonConverter(typeof<FsGrpc.Json.MessageConverter>)>]
[<FsGrpc.Protobuf.Message>]
type CodeGeneratorResponse = {
    // Field Declarations
    /// <summary>
    /// Error message.  If non-empty, code generation failed.  The plugin process
    /// should exit with status code zero even if it reports an error in this way.
    /// 
    /// This should be used to indicate errors in .proto files which prevent the
    /// code generator from generating correct code.  Errors which indicate a
    /// problem in protoc itself -- such as the input CodeGeneratorRequest being
    /// unparseable -- should be reported by writing a message to stderr and
    /// exiting with a non-zero status code.
    /// </summary>
    [<System.Text.Json.Serialization.JsonPropertyName("error")>] Error: string // (1)
    /// <summary>
    /// A bitmask of supported features that the code generator supports.
    /// This is a bitwise "or" of values from the Feature enum.
    /// </summary>
    [<System.Text.Json.Serialization.JsonPropertyName("supportedFeatures")>] SupportedFeatures: uint64 // (2)
    [<System.Text.Json.Serialization.JsonPropertyName("files")>] Files: Google.Protobuf.Compiler.CodeGeneratorResponse.File list // (15)
    }
    with
    static member Proto : Lazy<ProtoDef<CodeGeneratorResponse>> =
        lazy
        // Field Definitions
        let Error = FieldCodec.Primitive ValueCodec.String (1, "error")
        let SupportedFeatures = FieldCodec.Primitive ValueCodec.UInt64 (2, "supportedFeatures")
        let Files = FieldCodec.Repeated ValueCodec.Message<Google.Protobuf.Compiler.CodeGeneratorResponse.File> (15, "files")
        // Proto Definition Implementation
        { // ProtoDef<CodeGeneratorResponse>
            Name = "CodeGeneratorResponse"
            Empty = {
                Error = Error.GetDefault()
                SupportedFeatures = SupportedFeatures.GetDefault()
                Files = Files.GetDefault()
                }
            Size = fun (m: CodeGeneratorResponse) ->
                0
                + Error.CalcFieldSize m.Error
                + SupportedFeatures.CalcFieldSize m.SupportedFeatures
                + Files.CalcFieldSize m.Files
            Encode = fun (w: Google.Protobuf.CodedOutputStream) (m: CodeGeneratorResponse) ->
                Error.WriteField w m.Error
                SupportedFeatures.WriteField w m.SupportedFeatures
                Files.WriteField w m.Files
            Decode = fun (r: Google.Protobuf.CodedInputStream) ->
                let mutable builder = new Google.Protobuf.Compiler.CodeGeneratorResponse.Builder()
                let mutable tag = 0
                while read r &tag do
                    builder.Put (tag, r)
                builder.Build
            EncodeJson = fun (o: JsonOptions) ->
                let writeError = Error.WriteJsonField o
                let writeSupportedFeatures = SupportedFeatures.WriteJsonField o
                let writeFiles = Files.WriteJsonField o
                let encode (w: System.Text.Json.Utf8JsonWriter) (m: CodeGeneratorResponse) =
                    writeError w m.Error
                    writeSupportedFeatures w m.SupportedFeatures
                    writeFiles w m.Files
                encode
            DecodeJson = fun (node: System.Text.Json.Nodes.JsonNode) ->
                let update value (kvPair: System.Collections.Generic.KeyValuePair<string,System.Text.Json.Nodes.JsonNode>) : CodeGeneratorResponse =
                    match kvPair.Key with
                    | "error" -> { value with Error = Error.ReadJsonField kvPair.Value }
                    | "supportedFeatures" -> { value with SupportedFeatures = SupportedFeatures.ReadJsonField kvPair.Value }
                    | "files" -> { value with Files = Files.ReadJsonField kvPair.Value }
                    | _ -> value
                Seq.fold update _CodeGeneratorResponse.empty (node.AsObject ())
        }
    static member empty
        with get() = Google.Protobuf.Compiler._CodeGeneratorResponse.Proto.Value.Empty

namespace Google.Protobuf.Compiler.Optics
open Focal.Core
module Version =
    let _id : ILens'<Google.Protobuf.Compiler.Version,Google.Protobuf.Compiler.Version> =
        {
            _getter = { _get = fun (s: Google.Protobuf.Compiler.Version) -> s }
            _setter = { _over = fun a2b (s: Google.Protobuf.Compiler.Version) -> a2b s }
        }
    let ``major`` : ILens'<Google.Protobuf.Compiler.Version,int> =
        {
            _getter = { _get = fun (s: Google.Protobuf.Compiler.Version) -> s.Major }
            _setter = { _over = fun a2b s -> { s with Major = a2b s.Major } }
        }
    let ``minor`` : ILens'<Google.Protobuf.Compiler.Version,int> =
        {
            _getter = { _get = fun (s: Google.Protobuf.Compiler.Version) -> s.Minor }
            _setter = { _over = fun a2b s -> { s with Minor = a2b s.Minor } }
        }
    let ``patch`` : ILens'<Google.Protobuf.Compiler.Version,int> =
        {
            _getter = { _get = fun (s: Google.Protobuf.Compiler.Version) -> s.Patch }
            _setter = { _over = fun a2b s -> { s with Patch = a2b s.Patch } }
        }
    let ``suffix`` : ILens'<Google.Protobuf.Compiler.Version,string> =
        {
            _getter = { _get = fun (s: Google.Protobuf.Compiler.Version) -> s.Suffix }
            _setter = { _over = fun a2b s -> { s with Suffix = a2b s.Suffix } }
        }
module CodeGeneratorRequest =
    let _id : ILens'<Google.Protobuf.Compiler.CodeGeneratorRequest,Google.Protobuf.Compiler.CodeGeneratorRequest> =
        {
            _getter = { _get = fun (s: Google.Protobuf.Compiler.CodeGeneratorRequest) -> s }
            _setter = { _over = fun a2b (s: Google.Protobuf.Compiler.CodeGeneratorRequest) -> a2b s }
        }
    let ``filesToGenerate`` : ILens'<Google.Protobuf.Compiler.CodeGeneratorRequest,string list> =
        {
            _getter = { _get = fun (s: Google.Protobuf.Compiler.CodeGeneratorRequest) -> s.FilesToGenerate }
            _setter = { _over = fun a2b s -> { s with FilesToGenerate = a2b s.FilesToGenerate } }
        }
    let ``parameter`` : ILens'<Google.Protobuf.Compiler.CodeGeneratorRequest,string> =
        {
            _getter = { _get = fun (s: Google.Protobuf.Compiler.CodeGeneratorRequest) -> s.Parameter }
            _setter = { _over = fun a2b s -> { s with Parameter = a2b s.Parameter } }
        }
    let ``protoFiles`` : ILens'<Google.Protobuf.Compiler.CodeGeneratorRequest,Google.Protobuf.FileDescriptorProto list> =
        {
            _getter = { _get = fun (s: Google.Protobuf.Compiler.CodeGeneratorRequest) -> s.ProtoFiles }
            _setter = { _over = fun a2b s -> { s with ProtoFiles = a2b s.ProtoFiles } }
        }
    let ``compilerVersion`` : ILens'<Google.Protobuf.Compiler.CodeGeneratorRequest,Google.Protobuf.Compiler.Version option> =
        {
            _getter = { _get = fun (s: Google.Protobuf.Compiler.CodeGeneratorRequest) -> s.CompilerVersion }
            _setter = { _over = fun a2b s -> { s with CompilerVersion = a2b s.CompilerVersion } }
        }
module CodeGeneratorResponse =
    let _id : ILens'<Google.Protobuf.Compiler.CodeGeneratorResponse,Google.Protobuf.Compiler.CodeGeneratorResponse> =
        {
            _getter = { _get = fun (s: Google.Protobuf.Compiler.CodeGeneratorResponse) -> s }
            _setter = { _over = fun a2b (s: Google.Protobuf.Compiler.CodeGeneratorResponse) -> a2b s }
        }
    let ``error`` : ILens'<Google.Protobuf.Compiler.CodeGeneratorResponse,string> =
        {
            _getter = { _get = fun (s: Google.Protobuf.Compiler.CodeGeneratorResponse) -> s.Error }
            _setter = { _over = fun a2b s -> { s with Error = a2b s.Error } }
        }
    let ``supportedFeatures`` : ILens'<Google.Protobuf.Compiler.CodeGeneratorResponse,uint64> =
        {
            _getter = { _get = fun (s: Google.Protobuf.Compiler.CodeGeneratorResponse) -> s.SupportedFeatures }
            _setter = { _over = fun a2b s -> { s with SupportedFeatures = a2b s.SupportedFeatures } }
        }
    let ``files`` : ILens'<Google.Protobuf.Compiler.CodeGeneratorResponse,Google.Protobuf.Compiler.CodeGeneratorResponse.File list> =
        {
            _getter = { _get = fun (s: Google.Protobuf.Compiler.CodeGeneratorResponse) -> s.Files }
            _setter = { _over = fun a2b s -> { s with Files = a2b s.Files } }
        }
    module File =
        let _id : ILens'<Google.Protobuf.Compiler.CodeGeneratorResponse.File,Google.Protobuf.Compiler.CodeGeneratorResponse.File> =
            {
                _getter = { _get = fun (s: Google.Protobuf.Compiler.CodeGeneratorResponse.File) -> s }
                _setter = { _over = fun a2b (s: Google.Protobuf.Compiler.CodeGeneratorResponse.File) -> a2b s }
            }
        let ``name`` : ILens'<Google.Protobuf.Compiler.CodeGeneratorResponse.File,string> =
            {
                _getter = { _get = fun (s: Google.Protobuf.Compiler.CodeGeneratorResponse.File) -> s.Name }
                _setter = { _over = fun a2b s -> { s with Name = a2b s.Name } }
            }
        let ``insertionPoint`` : ILens'<Google.Protobuf.Compiler.CodeGeneratorResponse.File,string> =
            {
                _getter = { _get = fun (s: Google.Protobuf.Compiler.CodeGeneratorResponse.File) -> s.InsertionPoint }
                _setter = { _over = fun a2b s -> { s with InsertionPoint = a2b s.InsertionPoint } }
            }
        let ``content`` : ILens'<Google.Protobuf.Compiler.CodeGeneratorResponse.File,string> =
            {
                _getter = { _get = fun (s: Google.Protobuf.Compiler.CodeGeneratorResponse.File) -> s.Content }
                _setter = { _over = fun a2b s -> { s with Content = a2b s.Content } }
            }

namespace Google.Protobuf.Compiler
open Focal.Core
open System.Runtime.CompilerServices
[<Extension>]
type OpticsExtensionMethods_google_protobuf_compiler_plugin_proto =
    [<Extension>]
    static member inline Major(lens : ILens<'a,'b,Google.Protobuf.Compiler.Version,Google.Protobuf.Compiler.Version>) : ILens<'a,'b,int,int> =
        lens.ComposeWith(Google.Protobuf.Compiler.Optics.Version.``major``)
    [<Extension>]
    static member inline Major(traversal : ITraversal<'a,'b,Google.Protobuf.Compiler.Version,Google.Protobuf.Compiler.Version>) : ITraversal<'a,'b,int,int> =
        traversal.ComposeWith(Google.Protobuf.Compiler.Optics.Version.``major``)
    [<Extension>]
    static member inline Minor(lens : ILens<'a,'b,Google.Protobuf.Compiler.Version,Google.Protobuf.Compiler.Version>) : ILens<'a,'b,int,int> =
        lens.ComposeWith(Google.Protobuf.Compiler.Optics.Version.``minor``)
    [<Extension>]
    static member inline Minor(traversal : ITraversal<'a,'b,Google.Protobuf.Compiler.Version,Google.Protobuf.Compiler.Version>) : ITraversal<'a,'b,int,int> =
        traversal.ComposeWith(Google.Protobuf.Compiler.Optics.Version.``minor``)
    [<Extension>]
    static member inline Patch(lens : ILens<'a,'b,Google.Protobuf.Compiler.Version,Google.Protobuf.Compiler.Version>) : ILens<'a,'b,int,int> =
        lens.ComposeWith(Google.Protobuf.Compiler.Optics.Version.``patch``)
    [<Extension>]
    static member inline Patch(traversal : ITraversal<'a,'b,Google.Protobuf.Compiler.Version,Google.Protobuf.Compiler.Version>) : ITraversal<'a,'b,int,int> =
        traversal.ComposeWith(Google.Protobuf.Compiler.Optics.Version.``patch``)
    [<Extension>]
    static member inline Suffix(lens : ILens<'a,'b,Google.Protobuf.Compiler.Version,Google.Protobuf.Compiler.Version>) : ILens<'a,'b,string,string> =
        lens.ComposeWith(Google.Protobuf.Compiler.Optics.Version.``suffix``)
    [<Extension>]
    static member inline Suffix(traversal : ITraversal<'a,'b,Google.Protobuf.Compiler.Version,Google.Protobuf.Compiler.Version>) : ITraversal<'a,'b,string,string> =
        traversal.ComposeWith(Google.Protobuf.Compiler.Optics.Version.``suffix``)
    [<Extension>]
    static member inline FilesToGenerate(lens : ILens<'a,'b,Google.Protobuf.Compiler.CodeGeneratorRequest,Google.Protobuf.Compiler.CodeGeneratorRequest>) : ILens<'a,'b,string list,string list> =
        lens.ComposeWith(Google.Protobuf.Compiler.Optics.CodeGeneratorRequest.``filesToGenerate``)
    [<Extension>]
    static member inline FilesToGenerate(traversal : ITraversal<'a,'b,Google.Protobuf.Compiler.CodeGeneratorRequest,Google.Protobuf.Compiler.CodeGeneratorRequest>) : ITraversal<'a,'b,string list,string list> =
        traversal.ComposeWith(Google.Protobuf.Compiler.Optics.CodeGeneratorRequest.``filesToGenerate``)
    [<Extension>]
    static member inline Parameter(lens : ILens<'a,'b,Google.Protobuf.Compiler.CodeGeneratorRequest,Google.Protobuf.Compiler.CodeGeneratorRequest>) : ILens<'a,'b,string,string> =
        lens.ComposeWith(Google.Protobuf.Compiler.Optics.CodeGeneratorRequest.``parameter``)
    [<Extension>]
    static member inline Parameter(traversal : ITraversal<'a,'b,Google.Protobuf.Compiler.CodeGeneratorRequest,Google.Protobuf.Compiler.CodeGeneratorRequest>) : ITraversal<'a,'b,string,string> =
        traversal.ComposeWith(Google.Protobuf.Compiler.Optics.CodeGeneratorRequest.``parameter``)
    [<Extension>]
    static member inline ProtoFiles(lens : ILens<'a,'b,Google.Protobuf.Compiler.CodeGeneratorRequest,Google.Protobuf.Compiler.CodeGeneratorRequest>) : ILens<'a,'b,Google.Protobuf.FileDescriptorProto list,Google.Protobuf.FileDescriptorProto list> =
        lens.ComposeWith(Google.Protobuf.Compiler.Optics.CodeGeneratorRequest.``protoFiles``)
    [<Extension>]
    static member inline ProtoFiles(traversal : ITraversal<'a,'b,Google.Protobuf.Compiler.CodeGeneratorRequest,Google.Protobuf.Compiler.CodeGeneratorRequest>) : ITraversal<'a,'b,Google.Protobuf.FileDescriptorProto list,Google.Protobuf.FileDescriptorProto list> =
        traversal.ComposeWith(Google.Protobuf.Compiler.Optics.CodeGeneratorRequest.``protoFiles``)
    [<Extension>]
    static member inline CompilerVersion(lens : ILens<'a,'b,Google.Protobuf.Compiler.CodeGeneratorRequest,Google.Protobuf.Compiler.CodeGeneratorRequest>) : ILens<'a,'b,Google.Protobuf.Compiler.Version option,Google.Protobuf.Compiler.Version option> =
        lens.ComposeWith(Google.Protobuf.Compiler.Optics.CodeGeneratorRequest.``compilerVersion``)
    [<Extension>]
    static member inline CompilerVersion(traversal : ITraversal<'a,'b,Google.Protobuf.Compiler.CodeGeneratorRequest,Google.Protobuf.Compiler.CodeGeneratorRequest>) : ITraversal<'a,'b,Google.Protobuf.Compiler.Version option,Google.Protobuf.Compiler.Version option> =
        traversal.ComposeWith(Google.Protobuf.Compiler.Optics.CodeGeneratorRequest.``compilerVersion``)
    [<Extension>]
    static member inline Error(lens : ILens<'a,'b,Google.Protobuf.Compiler.CodeGeneratorResponse,Google.Protobuf.Compiler.CodeGeneratorResponse>) : ILens<'a,'b,string,string> =
        lens.ComposeWith(Google.Protobuf.Compiler.Optics.CodeGeneratorResponse.``error``)
    [<Extension>]
    static member inline Error(traversal : ITraversal<'a,'b,Google.Protobuf.Compiler.CodeGeneratorResponse,Google.Protobuf.Compiler.CodeGeneratorResponse>) : ITraversal<'a,'b,string,string> =
        traversal.ComposeWith(Google.Protobuf.Compiler.Optics.CodeGeneratorResponse.``error``)
    [<Extension>]
    static member inline SupportedFeatures(lens : ILens<'a,'b,Google.Protobuf.Compiler.CodeGeneratorResponse,Google.Protobuf.Compiler.CodeGeneratorResponse>) : ILens<'a,'b,uint64,uint64> =
        lens.ComposeWith(Google.Protobuf.Compiler.Optics.CodeGeneratorResponse.``supportedFeatures``)
    [<Extension>]
    static member inline SupportedFeatures(traversal : ITraversal<'a,'b,Google.Protobuf.Compiler.CodeGeneratorResponse,Google.Protobuf.Compiler.CodeGeneratorResponse>) : ITraversal<'a,'b,uint64,uint64> =
        traversal.ComposeWith(Google.Protobuf.Compiler.Optics.CodeGeneratorResponse.``supportedFeatures``)
    [<Extension>]
    static member inline Files(lens : ILens<'a,'b,Google.Protobuf.Compiler.CodeGeneratorResponse,Google.Protobuf.Compiler.CodeGeneratorResponse>) : ILens<'a,'b,Google.Protobuf.Compiler.CodeGeneratorResponse.File list,Google.Protobuf.Compiler.CodeGeneratorResponse.File list> =
        lens.ComposeWith(Google.Protobuf.Compiler.Optics.CodeGeneratorResponse.``files``)
    [<Extension>]
    static member inline Files(traversal : ITraversal<'a,'b,Google.Protobuf.Compiler.CodeGeneratorResponse,Google.Protobuf.Compiler.CodeGeneratorResponse>) : ITraversal<'a,'b,Google.Protobuf.Compiler.CodeGeneratorResponse.File list,Google.Protobuf.Compiler.CodeGeneratorResponse.File list> =
        traversal.ComposeWith(Google.Protobuf.Compiler.Optics.CodeGeneratorResponse.``files``)
    [<Extension>]
    static member inline Name(lens : ILens<'a,'b,Google.Protobuf.Compiler.CodeGeneratorResponse.File,Google.Protobuf.Compiler.CodeGeneratorResponse.File>) : ILens<'a,'b,string,string> =
        lens.ComposeWith(Google.Protobuf.Compiler.Optics.CodeGeneratorResponse.File.``name``)
    [<Extension>]
    static member inline Name(traversal : ITraversal<'a,'b,Google.Protobuf.Compiler.CodeGeneratorResponse.File,Google.Protobuf.Compiler.CodeGeneratorResponse.File>) : ITraversal<'a,'b,string,string> =
        traversal.ComposeWith(Google.Protobuf.Compiler.Optics.CodeGeneratorResponse.File.``name``)
    [<Extension>]
    static member inline InsertionPoint(lens : ILens<'a,'b,Google.Protobuf.Compiler.CodeGeneratorResponse.File,Google.Protobuf.Compiler.CodeGeneratorResponse.File>) : ILens<'a,'b,string,string> =
        lens.ComposeWith(Google.Protobuf.Compiler.Optics.CodeGeneratorResponse.File.``insertionPoint``)
    [<Extension>]
    static member inline InsertionPoint(traversal : ITraversal<'a,'b,Google.Protobuf.Compiler.CodeGeneratorResponse.File,Google.Protobuf.Compiler.CodeGeneratorResponse.File>) : ITraversal<'a,'b,string,string> =
        traversal.ComposeWith(Google.Protobuf.Compiler.Optics.CodeGeneratorResponse.File.``insertionPoint``)
    [<Extension>]
    static member inline Content(lens : ILens<'a,'b,Google.Protobuf.Compiler.CodeGeneratorResponse.File,Google.Protobuf.Compiler.CodeGeneratorResponse.File>) : ILens<'a,'b,string,string> =
        lens.ComposeWith(Google.Protobuf.Compiler.Optics.CodeGeneratorResponse.File.``content``)
    [<Extension>]
    static member inline Content(traversal : ITraversal<'a,'b,Google.Protobuf.Compiler.CodeGeneratorResponse.File,Google.Protobuf.Compiler.CodeGeneratorResponse.File>) : ITraversal<'a,'b,string,string> =
        traversal.ComposeWith(Google.Protobuf.Compiler.Optics.CodeGeneratorResponse.File.``content``)

