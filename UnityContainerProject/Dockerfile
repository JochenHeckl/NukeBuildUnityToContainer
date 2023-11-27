FROM ubuntu:22.04

WORKDIR /app

COPY bin/UnityContainerProject/Server_Data /app/Server_Data
COPY bin/UnityContainerProject/Server /app/Server

COPY bin/UnityContainerProject/GameAssembly.so /app/GameAssembly.so
COPY bin/UnityContainerProject/libdecor-0.so.0 /app/libdecor-0.so.0
COPY bin/UnityContainerProject/libdecor-cairo.so /app/libdecor-cairo.so
COPY bin/UnityContainerProject/UnityPlayer.so /app/UnityPlayer.so

EXPOSE 1337

# Set the entry point for the Docker container
CMD ["./Server"]
