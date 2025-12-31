module WellKnownTypesTests

open Xunit

let run cmd args : Result<int, string> =
    try
        let psi = new System.Diagnostics.ProcessStartInfo(FileName=cmd, Arguments=args, UseShellExecute=false)
        use p = new System.Diagnostics.Process(StartInfo=psi)
        if p.Start() then
            p.WaitForExit()
            Ok p.ExitCode
        else Error "failed to start"
    with ex -> Error ex.Message

let protocPath =
    if System.OperatingSystem.IsWindows() then "windows_x64/protoc.exe"
    elif System.OperatingSystem.IsLinux() then "linux_x64/protoc"
    else "macosx_x64/protoc"

[<Fact>]
let ``WellKnownTypes emit under Google.Protobuf.WellKnownTypes`` () =
    // Generate to temp and read emitted code
    let assembly = System.Reflection.Assembly.GetAssembly (typeof<ProtocGenFsgrpc.ProtoCodeGen.TypeInfo>)
    let pluginBase = System.IO.Path.Combine (System.IO.Path.GetDirectoryName assembly.Location, "protoc-gen-fsgrpc")
    let plugin = if System.OperatingSystem.IsWindows() then pluginBase + ".exe" else pluginBase
    let outFolder = System.IO.Path.Combine (System.IO.Path.GetTempPath (),  "wkt-actual")
    if System.IO.Directory.Exists outFolder then System.IO.Directory.Delete(outFolder, true)
    System.IO.Directory.CreateDirectory(outFolder) |> ignore
    let args = $"--plugin=protoc-gen-fsgrpc={plugin} -Iinclude -Iinputs/proto --fsgrpc_out={outFolder} wkt.proto"
    match run protocPath args with
    | Ok 0 -> ()
    | Ok code -> failwithf "protoc failed: %d" code
    | Error e -> failwith e
    // Read generated file
    let genPath = System.IO.Path.Combine(outFolder, "wkt.proto.gen.fs")
    Assert.True(System.IO.File.Exists genPath)
    let text = System.IO.File.ReadAllText(genPath)
    // Assert namespace and well-known types usage
    Assert.Contains("namespace Ex.Amplewkt", text)
    Assert.Contains("Google.Protobuf.WellKnownTypes.Struct", text)
    Assert.Contains("Google.Protobuf.WellKnownTypes.Value", text)
    // No direct Google.Protobuf.Struct/Value
    Assert.DoesNotContain("Google.Protobuf.Struct", text)
    Assert.DoesNotContain("Google.Protobuf.Value", text)
