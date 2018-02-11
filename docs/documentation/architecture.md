# Architecture

The architecture is quite simple.
There's the supervisor process which acts as a service and starts the plugins and there are the plugin processes.
The supervisor (or PluginHost) has a gRPC API to enable the plugins to register them at the host (with a name and a port where their gRPC API is located at).
Every plugin starts its own gRPC server based on a protobuf spec which contains two methods:

* `GetCurrentState`
* `Shutdown`

## `GetCurrentState`

This method is called periodically by the supervisor and returns the state of the CI pipeline the plugin watches.
The interval how often the method is called is configurable at the supervisor.

## `Shutdown`

This method should initiate a clean shutdown of the plugin before the supervisor exits.