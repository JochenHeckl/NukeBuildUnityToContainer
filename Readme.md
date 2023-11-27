# NukeBuildUnityToContainer

Basic repository that automates building a Unity linux server and packaging it to a docker image.

## Prerequisites

- [Nuke](https://nuke.build/)
  
  You can get nuke by simply running:
  ```
  dotnet tool install -g nuke.globaltool
  ```

- [Docker](https://www.docker.com/get-started/)

## How to use

To get help run:
```
nuke --help
```

To just build the image run:
```
nuke CreateUnityServerContainerImage
```