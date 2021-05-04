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

    ```
        dapr run --app-id schema-registry-api --app-port 5000 -- dotnet run
    ```

2. Browse to http://localhost:5000/swagger/index.html.
   - Execute Get, Post, Put, Delete
   - Use `v1.person-schema.json` in **json** folder.