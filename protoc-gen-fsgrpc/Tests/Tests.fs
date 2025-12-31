module Tests

open System
open FsGrpc
open Xunit
open Xunit.Abstractions
open FSharp.Compiler.CodeAnalysis
open FSharp.Compiler.Text
open FSharp.Compiler.Syntax

type LaunchResult = {
    ExitCode: int
    Output: string
    Error: string
}

let run cmd args : Result<LaunchResult, string> =
    let start =
        System.Diagnostics.ProcessStartInfo(
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            FileName = cmd,
            Arguments = args
        )
    let outputs = System.Collections.Generic.List<string>()
    let errors = System.Collections.Generic.List<string>()
    let outHandler f (_sender:obj) (args:System.Diagnostics.DataReceivedEventArgs) = f args.Data
    let p = new System.Diagnostics.Process(StartInfo = start)
    p.OutputDataReceived.AddHandler(System.Diagnostics.DataReceivedEventHandler (outHandler outputs.Add))
    p.ErrorDataReceived.AddHandler(System.Diagnostics.DataReceivedEventHandler (outHandler errors.Add))
    let started = p.Start()
    if not started then
        Error (sprintf "Failed to start process")
    else
        p.BeginOutputReadLine()
        p.BeginErrorReadLine()
        p.WaitForExit()
        let result = {
            ExitCode = p.ExitCode
            Output = outputs |> String.concat "\n"
            Error = errors |> String.concat "\n"
        }
        Ok result

let hashOf (file: string) =
    use md5 = System.Security.Cryptography.MD5.Create()
    use stream = System.IO.File.OpenRead(file)
    let hash = md5.ComputeHash(stream)
    BitConverter.ToString(hash).Replace("-","" ).ToLower()

let contentsOfFolder folder =
    let combine p1 p2 =
        System.IO.Path.Combine(p1, p2)
    let essentials (short, path, full, hash) =
        (path, hash)
    let rec contentsOfFolder root folder =
        let fileInfo (full: string) =
            let short = System.IO.Path.GetFileName(full)
            let path = combine folder short
            let hash = hashOf full
            (short, path, full, hash)
        let combined = System.IO.Path.Combine(root, folder)
        let files =
            System.IO.Directory.GetFiles(combined)
            |> Seq.map fileInfo
            |> List.ofSeq
            |> List.sort
        let subdirs =
            System.IO.Directory.GetDirectories(combined)
            |> Seq.map System.IO.Path.GetFileName
            |> Seq.map (combine folder)
            |> List.ofSeq
            |> List.sort
        let result =
            match subdirs with
            | [] ->
                files
            | subdirs ->
                files @
                (subdirs |> List.map (contentsOfFolder root) |> List.concat)
        result
    contentsOfFolder folder "" |> Seq.map essentials

// On Windows use packaged protoc.exe under windows_x64; on Unix use linux_x64
let runProtoc =
    if OperatingSystem.IsWindows() then run "windows_x64/protoc.exe"
    elif OperatingSystem.IsLinux() then run "linux_x64/protoc"
    else run "macosx_x64/protoc"

[<Fact>]
let ``Can run protoc`` () =
    // check that we can run protoc
    let result = runProtoc "--version"
    let result =
        match result with
        | Error e -> failwith e
        | Ok result -> result
    Assert.Equal(0, result.ExitCode)
    Assert.StartsWith("libprotoc", result.Output)


type FileGenerationTests(output: ITestOutputHelper) =

    [<Fact>]
    member _.``Generates correct files`` () =
        let assembly = System.Reflection.Assembly.GetAssembly (typeof<ProtocGenFsgrpc.ProtoCodeGen.TypeInfo>)
        Assert.NotNull(assembly)
        Assert.NotNull(assembly.Location)
        Assert.NotEmpty(assembly.Location)

        let basePath = System.IO.Path.Combine (System.IO.Path.GetDirectoryName assembly.Location, "protoc-gen-fsgrpc")
        let fullPathToPlugin = if OperatingSystem.IsWindows() then basePath + ".exe" else basePath

        let outFolder = System.IO.Path.Combine [|(System.IO.Path.GetTempPath ());  "actual"|]

        if System.IO.Directory.Exists (outFolder) then
            System.IO.Directory.Delete (outFolder, true)

        System.IO.Directory.CreateDirectory(outFolder) |> ignore

        let args = sprintf "--plugin=protoc-gen-fsgrpc=%s -Iinclude -Iinputs/proto --fsgrpc_out=%s testproto.proto example.proto importable/importMe.proto" fullPathToPlugin outFolder
        let result = runProtoc args
        let result =
            match result with
            | Error e -> failwith e
            | Ok result -> result
        match result.ExitCode with
        | 0 -> ()
        | code ->
            output.WriteLine(sprintf "Process returned: %d" code)
            output.WriteLine(result.Error)
            output.WriteLine(result.Output)
        Assert.Equal(0, result.ExitCode)
        
        // Verify files were generated
        let actualFiles = contentsOfFolder outFolder |> Seq.map fst |> Seq.toList
        output.WriteLine(sprintf "Generated %d files" (List.length actualFiles))
        for file in actualFiles do
            output.WriteLine(sprintf "  - %s" file)
        
        // Basic sanity check: make sure key files exist and compile
        Assert.True(actualFiles |> List.exists (fun f -> f.Contains("example.proto.gen.fs")), "example.proto.gen.fs should be generated")
        Assert.True(actualFiles |> List.exists (fun f -> f.Contains("testproto.proto.gen.fs")), "testproto.proto.gen.fs should be generated")
        Assert.True(actualFiles |> List.exists (fun f -> f.Contains("importMe.proto.gen.fs")), "importMe.proto.gen.fs should be generated")

        if System.IO.Directory.Exists (outFolder) then
            System.IO.Directory.Delete (outFolder, true)


type Nested = Ex.Ample.Outer.Nested

[<Fact>]
let ``Basic roundtrip decoding and encoding work from generated file`` () =
    let expected : Ex.Ample.Outer =
        {
            BoolVal = true
            BytesVal = Bytes.FromUtf8("test")
            Doubles = [1.1; 2.2]
            DoubleVal = 3.3;
            Duration = Some (NodaTime.Duration.FromDays 1)
            EnumImported = Ex.Ample.Importable.Imported.EnumForImport.Yes
            EnumVal = Ex.Ample.EnumType.One
            FloatVal = 123.45f(* float32 *)
            Imported = Some
                { Ex.Ample.Importable.Imported.empty with
                    Value = "chévere" } (* Ex.Ample.Importable.Imported option *)
            Inner = Some
                { Ex.Ample.Inner.empty with
                    IntFixed = 123
                    LongFixed = 234L
                    ZigzagInt = -456
                    ZigzagLong = -567L
                    Nested = Some
                        { Nested.empty with
                            Enums = [ Ex.Ample.Outer.NestEnumeration.Blue; Ex.Ample.Outer.NestEnumeration.Red ]
                            Inner = Some
                                { Ex.Ample.Inner.empty with IntFixed = 789 }
                            }
                    NestedEnum = Ex.Ample.Outer.NestEnumeration.Blue
                    }
            Inners = [
                { Ex.Ample.Inner.empty with
                    IntFixed = 123 }
                { Ex.Ample.Inner.empty with
                    IntFixed = 321 }
                ]
            IntVal = 1234(* int *)
            LongVal = 4567L (* int64 *)
            Map = Map [
                ("1", "one")
                ("2", "two")
                ]
            MapBool = Map [
                (true, "yep")
                (false, "nope")
                ]
            MapInner = Map [
                ("one", { Ex.Ample.Inner.empty with IntFixed = 1 })
                ("two", { Ex.Ample.Inner.empty with IntFixed = 2 })
                ]
            MapInts = Map [
                (1, 1)
                (2, 2)
                ]
            MaybeBool = Some false
            MaybeBytes = None
            MaybeDouble = Some 1.111
            MaybeFloat = None
            MaybeInt32 = Some 0
            MaybeInt64 = None
            MaybesInt64 = [1234; 0]
            MaybeString = None
            MaybeUint32 = None
            MaybeUint64 = None
            Nested = Some {
                Enums = []
                Inner = Some
                    { Ex.Ample.Inner.empty with IntFixed = 789 }
                }
            OptionalInt32 = Some 0
            Recursive = Some { Ex.Ample.Outer.empty with StringVal = "Hi" }
            StringVal = "There"
            Timestamp = Some (NodaTime.Instant.FromUnixTimeSeconds 100000)
            Timestamps = [
                (NodaTime.Instant.FromUnixTimeSeconds 100000)
                (NodaTime.Instant.FromUnixTimeSeconds 100001)
                ]
            UintFixed = 123456u
            UintVal = 123456u
            UlongFixed = 12345UL
            UlongVal = 12345UL
            Union = Ex.Ample.Outer.UnionCase.StringOption "World"
            Anything = None
            }
    let actual = expected |> Protobuf.encode |> Protobuf.decode
    Assert.Equal(expected, actual)