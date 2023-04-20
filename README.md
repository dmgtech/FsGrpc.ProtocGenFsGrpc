
# FsGrpc
Idiomatic F# code generation for Protocol Buffers and gRPC

> *⚠️ this is currently a work in progress.  See the "Status" section
> for more info*

Generate idiomatic F# records from proto3 message definitions, complete with oneofs as discriminated unions, and serialize/deserialize to and from protocol buffer wire format.

# Usage System Diagram

```mermaid

C4Context
  Container_Boundary(workstation, "Developer Workstation", $link="https://github.com/plantuml-stdlib/C4-PlantUML") {
      Container_Boundary(fsgrpc_repository, "FsGrpc Repository"){
          Component(protoc_fsgrpc_plugin_local, "Protoc FsGrpc Plugin", "local protoc-gen-fsgrpc")
      }
      Container_Boundary(your_fsharp_project, "Your F# project"){
          Component(projectfile, "Web Application fsproj")
          Component(generatedcode, "Generated F# Protobuf Code", "F# representations of your protobuf schema")
      }
  }

  Boundary(nuget, "Nuget"){
      Component(fsgrpc_nuget, "FsGrpc Package", "FsGrpc as a nuget package")
  }

  Boundary(buf, "buf.build"){
      Component(protoc_fsgrpc_plugin, "Protoc FsGrpc Plugin", "Hosted protoc-gen-fsgrpc as a service")
  }

  UpdateElementStyle(workstation, $fontColor="blue", $borderColor="blue", $legendTest=" ")
  UpdateElementStyle(your_fsharp_project, $fontColor="blue", $borderColor="blue", $legendTest=" ")

  UpdateElementStyle(protoc_component, $fontColor="blue", $borderColor="blue", $legendTest=" ")
  UpdateElementStyle(fsgrpc_component, $fontColor="blue", $borderColor="blue", $legendTest=" ")

  UpdateElementStyle(buf, $fontColor="blue", $borderColor="blue", $legendTest=" ")
  UpdateElementStyle(nuget, $fontColor="blue", $borderColor="blue", $legendTest=" ")

  Rel(protoc_fsgrpc_plugin, generatedcode, "generates (Buf)")
  UpdateRelStyle(protoc_fsgrpc_plugin, generatedcode, $textColor="red", $lineColor="red")
  Rel(projectfile, fsgrpc_nuget, "references")
  UpdateRelStyle(projectfile, fsgrpc_nuget, $textColor="red", $lineColor="red")
  Rel(protoc_fsgrpc_plugin_local, generatedcode, "generates (offline)")
  UpdateRelStyle(protoc_fsgrpc_plugin_local, generatedcode, $textColor="red", $lineColor="red")

```

# Getting Started

There are a couple of approaches you can use to generate code from your protos.

## Option 1: Use the buf cli

1. If using buf (or if you just want to use the buf cli), start by installing the buf cli from https://docs.buf.build/installation.

2. Add the following "remote" section to your buf.gen.yaml (or create a new buf.gen.yaml if one doesn't already exist):
A.
```yaml
version: v1
plugins:
- remote: buf.build/divisions-maintenance-group/plugins/fsharp
    out: gen
    strategy: all
```
B. If you need to run the plugin offline:
1. Pull the fsgrpc repo locally
2. Build the protoc-gen-fsgrpc project in that repo
3. Change your buf.gen.yaml file to look like this:
    ```yaml
    version: v1
    plugins:
    - plugin: fsgrpc.exe 'fsgrpc for non-windows operating systems and fsgrpc.exe for windows
        out: gen
        path: <path to the fsgrpc repo>/fsgrpc/protoc-gen-fsgrpc/bin/Debug/net6.0/protoc-gen-fsgrpc
        strategy: all
    ```

3. Generate the code

- Option 1:
    1. Place your protos in a folder named "protos" in the same folder as your buf.gen.yaml file.

    2. If your protos are in buf, you can export them into that folder by running:
    `buf export buf.build/path/to/your/protos -o protos`

    e.g. `buf export buf.build/googleapis/googleapis -o protos` will place the proto defintions for the google apis into the protos folder

    3. Run `buf generate protos --include-imports --include-wkt` in the folder where your buf.gen.yaml file is located.

- Option 2:
    1. Run buf generate command directly referencing protos in buf
    `buf generate buf.build/googleapis/googleapis`

4. Add the generated code to your F# project

    Using `buf generate` with the above example will generate .fs files in the "gen" directory, and also a Protobuf.targets file in that directory which includes those files in correct dependency order.

    You then add the following line to your .fsproj inside the top-level "project" element:
    ```xml
    <Import Project="gen/Protobuf.targets" />
    ```

    And run

    ```bash
    dotnet add package fsgrpc
    ```

    or

    ```powershell
    Install-Package FsGrpc
    ```

## Usage in F#

You can create a record by specifying all of the fields or using `with` syntax as follows:

```fsharp
let message =
	{ MyMessage.empty with
	    Name = "a name value"
	    Description = "some string here" }
```

    You can serialize/deserialize from various formats:

### Serializing to/from bytes

```fsharp
let encodedMessage = FsGrpc.Protobuf.encode message 

let decodedMessage: MyMessage = FsGrpc.Protobuf.decode encodedMessage
```

### Serializing to/from a CodedOutputStream

```fsharp
let decodedMessage = MyMessage.Proto.Value.Decode cis

MyMessage.Proto.Value.Encode cos decodedMessage
```

### Serializing to/from json

```fsharp
let serializedMessage = FsGrpc.Json.serialize message

let deserializedMessage : Http = FsGrpc.Json.deserialize serializedMessage
```

### Implementing a GRPC service
Starting from a protobuf service defined like the following:

```protobuf
message HelloRequest {
    string name = 1;
}
  
  message HelloReply {
    string message = 1;
}

service Greeter {
    rpc SayHello (HelloRequest) returns (HelloReply);
    rpc SayHelloServerStreaming (HelloRequest) returns (stream HelloReply);
    rpc SayHelloClientStreaming (stream HelloRequest) returns (HelloReply);
    rpc SayHelloDuplexStreaming (stream HelloRequest) returns (stream HelloReply);
}
```

The implementation can then look like:
```fsharp
    open FSharp.Control //from the FSharp.Control.AsyncSeq package

    type GRPCService () =
        inherit Greeter.ServiceBase()

        override _.SayHello (request: HelloRequest) (context: ServerCallContext) =
            task { return { Message = "Hello " + request.Name } }

        override _.SayHelloServerStreaming (request: HelloRequest) (writer: IServerStreamWriter<HelloReply>) (context: ServerCallContext) =
            task {
                for i in [1..5] do
                    do! writer.WriteAsync { Message = "Hello " + request.Name }
            }

        override _.SayHelloClientStreaming (requestStream: IAsyncStreamReader<HelloRequest>) (context: ServerCallContext) =
            task {
                let! names =
                    AsyncSeq.ofAsyncEnum (requestStream.ReadAllAsync())
                    |> AsyncSeq.toListAsync

                let names = List.map (fun x -> x.Name) names
                return { Message = $"""Hello {String.concat ", " names}""" }
            }

        override _.SayHelloDuplexStreaming
            (requestStream: IAsyncStreamReader<HelloRequest>)
            (writer: IServerStreamWriter<HelloReply>)
            (context: ServerCallContext)
            =
            AsyncSeq.ofAsyncEnum (requestStream.ReadAllAsync())
            |> AsyncSeq.iterAsync (fun x ->
                writer.WriteAsync { Message = "Hello " + x.Name }
                |> Async.AwaitTask)
            |> fun x -> task { do! x }

        let builder = WebApplication.CreateBuilder()
        do
            builder.Services.AddGrpc() |> ignore
            builder.WebHost
                .ConfigureKestrel(fun serverOptions ->
                    serverOptions.ConfigureEndpointDefaults(fun listenOptions ->
                        listenOptions.Protocols <- Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http2))
                .UseShutdownTimeout(TimeSpan.FromSeconds(60))
                |> ignore

            let mutable app = Unchecked.defaultof<WebApplication>
            app <- builder.Build()
            app.MapGrpcService<GRPCService>() |> ignore
            app.StartAsync().Wait()
```

## Status
Note: This is currently a work in progress.  Code generation for protocol buffers is currently working but considered an alpha version.  gRPC and other features (such as code comments and reflection) are not complete.

The major features intended are:
- [x] Protobuf Messages as immutable F# record types
- [x] Oneofs as Discriminated Unions
- [x] proto3 optional keyword support
- [x] Support for optional wrapper types (e.g. google.protobuf.UInt32Val)
- [x] Support for well-known types Duration and Timestamp (represented using NodaTime types)
- [x] Automatic dependency-sorted inclusion of generated .fs files
- [x] Buf.build integration
- [x] Comment pass-through
- [ ] Protocol Buffer reflection
- [x] Idiomatic functional implementation for gRPC endpoints

# Contributing

## Development System Diagram
```mermaid

C4Context
  Container_Boundary(workstation, "Developer Workstation", $link="https://github.com/plantuml-stdlib/C4-PlantUML") {
      Container_Boundary(your_fsharp_project, "Your F# project"){
          Component(generatedcode, "Generated F# Protobuf Code", "F# representations of your protobuf schema")
          Component(projectfile, "Web Application fsproj")
      }
      Component(protoc_fsgrpc_plugin_local, "Protoc FsGrpc Plugin", "local protoc-gen-fsgrpc")
  }

  Boundary(fsgrpc_repository, "FsGrpc Repository"){
     Boundary(protoc_component, "protoc FsGrpc Plugin"){
         Component(protoc_gen_fsgrpc,"protoc-gen-fsgrpc", "Generates F# representations of your protobuf schema")
         Component(protoc_gen_fsgrpc_tests, "Tests")
     }
     Boundary(fsgrpc_component, "FsGrpc"){
         Component(fsgrpc, "FsGrpc", "Support Library for generated code")
         Component(fsgrpc_tests, "FsGrpc.Tests")
     }
  }

  Boundary(buf, "buf.build"){
      Component(protoc_fsgrpc_plugin, "Protoc FsGrpc Plugin", "Hosted protoc-gen-fsgrpc as a service")
  }

  Boundary(nuget, "Nuget"){
      Component(fsgrpc_nuget, "FsGrpc Package", "FsGrpc as a nuget package")
  }


  UpdateElementStyle(workstation, $fontColor="blue", $borderColor="blue", $legendTest=" ")
  UpdateElementStyle(your_fsharp_project, $fontColor="blue", $borderColor="blue", $legendTest=" ")
  
  UpdateElementStyle(fsgrpc_repository, $fontColor="blue", $borderColor="blue", $legendTest=" ")
  UpdateElementStyle(protoc_component, $fontColor="blue", $borderColor="blue", $legendTest=" ")
  UpdateElementStyle(fsgrpc_component, $fontColor="blue", $borderColor="blue", $legendTest=" ")
  
  UpdateElementStyle(buf, $fontColor="blue", $borderColor="blue", $legendTest=" ")
  UpdateElementStyle(nuget, $fontColor="blue", $borderColor="blue", $legendTest=" ")
  Rel(generatedcode, fsgrpc, "depends on")
  UpdateRelStyle(generatedcode, fsgrpc, $textColor="red", $lineColor="red")
  Rel(fsgrpc, fsgrpc_nuget, "publishes")
  UpdateRelStyle(fsgrpc, fsgrpc_nuget, $textColor="red", $lineColor="red")
  Rel(protoc_gen_fsgrpc, protoc_fsgrpc_plugin, "Publishes")
  UpdateRelStyle(protoc_gen_fsgrpc, protoc_fsgrpc_plugin, $textColor="red", $lineColor="red")
  Rel(protoc_gen_fsgrpc, protoc_fsgrpc_plugin_local, "publishes (for local-only builds)")
  UpdateRelStyle(protoc_gen_fsgrpc, protoc_fsgrpc_plugin_local, $textColor="red", $lineColor="red")
  Rel(protoc_fsgrpc_plugin, generatedcode, "generates (Buf)")
  UpdateRelStyle(protoc_fsgrpc_plugin, generatedcode, $textColor="red", $lineColor="red")
  Rel(projectfile, fsgrpc_nuget, "references")
  UpdateRelStyle(projectfile, fsgrpc_nuget, $textColor="red", $lineColor="red")
  Rel(protoc_fsgrpc_plugin_local, generatedcode, "generates (offline)")
  UpdateRelStyle(protoc_fsgrpc_plugin_local, generatedcode, $textColor="red", $lineColor="red")
  Rel(protoc_gen_fsgrpc, fsgrpc, "references")
  UpdateRelStyle(protoc_gen_fsgrpc, fsgrpc, $textColor="red", $lineColor="red")
  Rel(fsgrpc_tests, fsgrpc, "references")
  UpdateRelStyle(fsgrpc_tests, fsgrpc, $textColor="red", $lineColor="red")
  Rel(protoc_gen_fsgrpc_tests, protoc_gen_fsgrpc, "references")
  UpdateRelStyle(protoc_gen_fsgrpc_tests, protoc_gen_fsgrpc, $textColor="red", $lineColor="red")
```