# EventDriven.SchemaRegistry.Api

Web API for a Dapr state store for validating messages against schemas that are stored in a registry by topic name.

## Prerequisites
- [.NET Core SDK](https://dotnet.microsoft.com/download) (5.0 or greater)
- [Docker Desktop](https://www.docker.com/products/docker-desktop)
- [Dapr](https://dapr.io/) (Distributed Application Runtime)
  - [Install Dapr CLI](https://docs.dapr.io/getting-started/install-dapr-cli/)
  - [Initialize Dapr](https://docs.dapr.io/getting-started/install-dapr-selfhost/)

## Usage

1. Run using Dapr.

   > **Note**: `--app-id` value must match the app id used with `dapr run` for the publisher.

    ```
        dapr run --app-id publisher --app-port 5100 -- dotnet run --urls "http://localhost:5100"
    ```

2. Browse to http://localhost:5100/swagger/index.html.
   - Execute Get, Post, Put, Delete
   - Use `v1.person-schema.json` in **json** folder.
    
3. To view all the registered topics for the publisher, you can connect to the Redis container directly and use the redis-cli.

    ```
    docker run --rm -it --link dapr_redis redis redis-cli -h dapr_redis
    KEYS publisher*
    ```