dotnet restore

dotnet build -p:TargetFramework=net6.0 --no-self-contained --configuration Release --no-restore -r linux-arm64 
dotnet build -p:TargetFramework=net6.0 --no-self-contained --configuration Release --no-restore -r linux-x64
dotnet build -p:TargetFramework=net6.0 --no-self-contained --configuration Release --no-restore -r osx-x64
dotnet build -p:TargetFramework=net6.0 --no-self-contained --configuration Release --no-restore -r osx-arm64
dotnet build -p:TargetFramework=net6.0 --no-self-contained --configuration Release --no-restore -r win-x86
dotnet build -p:TargetFramework=net6.0 --no-self-contained --configuration Release --no-restore -r win-x64

dotnet pack -p:PROTOCGENFSGRPC_VERSION=0.5.4-prerelease --configuration=Release -o=artifacts --no-restore --no-build