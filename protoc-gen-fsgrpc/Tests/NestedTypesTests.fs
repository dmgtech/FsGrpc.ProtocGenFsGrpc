module NestedTypesTests

open Xunit
open Xunit.Abstractions
open System.IO

type NestedTypesTests(output: ITestOutputHelper) =
    
    let protocPath =
        if System.OperatingSystem.IsWindows() then "windows_x64/protoc.exe"
        elif System.OperatingSystem.IsLinux() then "linux_x64/protoc"
        else "macosx_x64/protoc"
    
    let run cmd args =
        try
            let psi = new System.Diagnostics.ProcessStartInfo(
                FileName=cmd, 
                Arguments=args, 
                UseShellExecute=false,
                RedirectStandardOutput=true,
                RedirectStandardError=true)
            use p = new System.Diagnostics.Process(StartInfo=psi)
            if p.Start() then
                let stdout = p.StandardOutput.ReadToEnd()
                let stderr = p.StandardError.ReadToEnd()
                p.WaitForExit()
                Ok (p.ExitCode, stdout, stderr)
            else Error "failed to start"
        with ex -> Error ex.Message
    
    [<Fact>]
    member _.``Nested types are fully qualified in generated code`` () =
        let assembly = System.Reflection.Assembly.GetAssembly(typeof<ProtocGenFsgrpc.ProtoCodeGen.TypeInfo>)
        let pluginBase = Path.Combine(Path.GetDirectoryName(assembly.Location), "protoc-gen-fsgrpc")
        let plugin = if System.OperatingSystem.IsWindows() then pluginBase + ".exe" else pluginBase
        
        let outFolder = Path.Combine(Path.GetTempPath(), "nested-types-test")
        if Directory.Exists(outFolder) then Directory.Delete(outFolder, true)
        Directory.CreateDirectory(outFolder) |> ignore
        
        let args = sprintf "--plugin=protoc-gen-fsgrpc=%s -Iinclude -Iinputs/proto --fsgrpc_out=%s nested_types_test.proto" plugin outFolder
        
        match run protocPath args with
        | Ok (0, _, _) ->
            let genFile = Path.Combine(outFolder, "nested_types_test.proto.gen.fs")
            Assert.True(File.Exists(genFile), "Generated file should exist")
            
            let content = File.ReadAllText(genFile)
            output.WriteLine("=== Generated Code ===")
            output.WriteLine(content)
            output.WriteLine("=== End Generated Code ===")
            
            // Check that nested types are properly qualified
            
            // 1. In field declarations, nested types should be Nested.Test.OuterMessage.NestedMessage
            Assert.Contains("NestedField: Nested.Test.OuterMessage.NestedMessage", content)
            Assert.Contains("DoublyNestedField: Nested.Test.OuterMessage.NestedMessage.DoublyNested", content)
            
            // 2. In optics extension methods, nested types must be fully qualified
            // Looking for patterns like:
            // static member inline NestedField(lens : ILens<'a,'b,Nested.Test.OuterMessage,Nested.Test.OuterMessage>) : ILens<'a,'b,Nested.Test.OuterMessage.NestedMessage,Nested.Test.OuterMessage.NestedMessage>
            let opticsPattern = "ILens<'a,'b,Nested.Test.OuterMessage.NestedMessage,Nested.Test.OuterMessage.NestedMessage>"
            if not (content.Contains(opticsPattern)) then
                output.WriteLine("FAILED: Expected fully qualified nested type in optics:")
                output.WriteLine(sprintf "  Expected pattern: %s" opticsPattern)
                
                // Show what was actually generated
                let lines = content.Split('\n') |> Array.filter (fun l -> l.Contains("NestedField") && l.Contains("ILens"))
                output.WriteLine("  Actual ILens declarations for NestedField:")
                for line in lines do
                    output.WriteLine(sprintf "    %s" line)
            
            Assert.Contains(opticsPattern, content)
            
            // 3. Check cross-references are also fully qualified
            Assert.Contains("CrossReference: Nested.Test.OuterMessage.NestedMessage", content)
            
            // 4. Check doubly nested types
            let doublyNestedPattern = "Nested.Test.OuterMessage.NestedMessage.DoublyNested"
            Assert.Contains(doublyNestedPattern, content)
            
            // 5. Verify optics for doubly nested
            let doublyNestedOpticsPattern = sprintf "ILens<'a,'b,%s,%s>" doublyNestedPattern doublyNestedPattern
            if not (content.Contains(doublyNestedOpticsPattern)) then
                output.WriteLine("FAILED: Expected fully qualified doubly nested type in optics:")
                output.WriteLine(sprintf "  Expected pattern: %s" doublyNestedOpticsPattern)
            Assert.Contains(doublyNestedOpticsPattern, content)
            
            Directory.Delete(outFolder, true)
            
        | Ok (code, stdout, stderr) ->
            output.WriteLine(sprintf "protoc failed with code %d" code)
            output.WriteLine(sprintf "stdout: %s" stdout)
            output.WriteLine(sprintf "stderr: %s" stderr)
            Assert.True(false, sprintf "protoc failed: %s" stderr)
            
        | Error e ->
            Assert.True(false, sprintf "Failed to run protoc: %s" e)
