set sourceDirectory=%~dp0

cd .. 

set parentDirectory=%~dp0
set csharpDirectory=%parentDirectory%\HashGrpcClient\Generated

cd %sourceDirectory%

if not exist %csharpDirectory% mkdir %csharpDirectory%

.\HashGrpcClient\packages\Grpc.Tools.1.10.0\tools\windows_x86\protoc.exe -I . --csharp_out %csharpDirectory% proto\hashGrpc.proto --grpc_out %csharpDirectory% --plugin=protoc-gen-grpc=HashGrpcClient\packages\Grpc.Tools.1.10.0\tools\windows_x86\grpc_csharp_plugin.exe