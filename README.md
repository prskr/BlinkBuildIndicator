# BlinkBuildIndicator

X-Plattform build indicator service which uses a [blink(1) USB device](https://blink1.thingm.com) to indicate if all CI builds are running without errors.

Currently work is in progress - stay tuned for first releases.

## Docs

[DocFX pages](https://baez90.github.io/BlinkBuildIndicator)

## Architecture

The main project is implemented in C# with DotNET Core but the plugins can be implemented in any language with any framework as long as it supports gRPC.

The main project acts as a supervisor and starts the plugins as seperate processes.
The supervisor only needs to know how the process can be spawned and how it can pass the port the plugin should listen to to the plugin.
Anything else is accomplished through gRPC.

A guide how to implement custom plugins will be added to docs as the project proceeds.