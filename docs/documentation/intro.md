# BlinkBuildIndicator

The project consists of two solutions:

* BlinkBuildIndicator.sln - this is where the main projects resides - means, the service, the code required to control the blink(1) device and the corresponding test cases
* BlinkBuildIndicatorPlugins.sln - this is where all plugins and their unit tests are located at

The plugins in this repository will all be implemented with C# and DotNET Core but it's also possible to implement custom plugins in other languages as long as they are able to communicate through [gRPC](https://grpc.io).