# EventDriven.SchemaRegistry.Api

Web API for a Dapr state store for validating messages against schemas that are stored in a registry by topic name.

## Prerequisites
- [.NET Core SDK](https://dotnet.microsoft.com/download) (5.0 or greater)
- [Docker Desktop](https://www.docker.com/products/docker-desktop)
- [MongoDB Docker](https://hub.docker.com/_/mongo): `docker run --name mongo -d -p 27017:27017 -v /tmp/mongo/data:/data/db mongo`
- [MongoDB Client](https://robomongo.org/download):
  - Download Robo 3T only.
  - Add connection to localhost on port 27017.

## Usage

1. Browse to http://localhost:5100/swagger.
   - Execute Get, Post, Put, Delete
   - Use `v1.person-schema.json` in **json** folder.
    
2. To view all the registered schemas, you can use a MongoDB Client.

