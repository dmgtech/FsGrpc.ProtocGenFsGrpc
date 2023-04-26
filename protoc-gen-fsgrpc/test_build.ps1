dotnet build -r linux-arm64 -p:TargetFramework=net6.0 --no-self-contained -c=release
dotnet build -r linux-x64 -p:TargetFramework=net6.0 --no-self-contained -c=release
dotnet build -r osx-x64 -p:TargetFramework=net6.0 --no-self-contained -c=release
dotnet build -r win-x86 -p:TargetFramework=net6.0 --no-self-contained -c=release
dotnet build -r win-x64 -p:TargetFramework=net6.0 --no-self-contained -c=release

dotnet pack -p:PROTOCGENFSGRPC_VERSION=0.5.4-prerelease --configuration=Release -o=artifacts