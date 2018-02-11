$target_Path = "packages/Grpc.Tools/"
$temp_dir = "$($target_Path)tmp"
$temp_file = "$($temp_dir)/tmp.zip"
$curl_url = "https://www.nuget.org/api/v2/package/Grpc.Tools/"
$protobuf_out = "protobuf_out"

If(!(Test-Path -Path "packages\Grpc.Tools\tools\windows_x64\protoc.exe")) {
    $client = new-object System.Net.WebClient 
    New-Item -ItemType Directory -Force -Path $temp_dir
    $client.DownloadFile($curl_url, $temp_file)
    Expand-Archive $temp_file -DestinationPath $temp_dir
    Move-Item -Path "$temp_dir/tools" -Destination $target_Path
    Remove-Item -Force -Recurse $temp_dir
}

# generate PluginMessages
New-Item -ItemType Directory -Force -Path $protobuf_out
packages\Grpc.Tools\tools\windows_x64\protoc.exe --proto_path=protobuf --csharp_out "protobuf_out" "PluginMessages.proto" --plugin="packages\Grpc.Tools\tools\windows_x64\grpc_csharp_plugin.exe"
Move-Item -Force -Path .\protobuf_out\PluginMessages.cs -Destination .\lib\BBI.Common\Protobuf
Remove-Item -Force -Recurse "$protobuf_out/*"

packages\Grpc.Tools\tools\windows_x64\protoc.exe -Iprotobuf --csharp_out "protobuf_out" --grpc_out "protobuf_out" "CIPluginHost.proto" --plugin="protoc-gen-grpc=packages\Grpc.Tools\tools\windows_x64\grpc_csharp_plugin.exe"
Move-Item -Force -Path .\protobuf_out\CIPluginHost* -Destination .\bin\BBI.Service\gRPC
Remove-Item -Force -Recurse $protobuf_out