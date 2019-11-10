# BoilerPlate.Core.API
This is a project for a boiler plate .net Core 3 API with a Mongo DB database that is self documenting via Swagger / SwaggerUI

Mongo DB can be accessed through the `ICollectionRepository` Interface and the `GetCollection<T>` method within that. 

A default Query class and repository have been included for a very basic `Products` collection.
The same logic used in those could be implemented for any collection to provide basic CRUD functionality.

# Patterns

The design pattern used in this boiler plate is `Repository` due to the simplicity. It could be modified to use CQRS and event based design for a data layer.


# Settings

The `app.settings.json` file provided in the repo will provide the correct format and default values for running MongoDb locally. 
If you are hosting Mongo via Atlas this connection string should be updated. 

# Auto Mapper

The project uses `AutoMapper` to handle all object mapping, the configuration for this can be found in `WebAPI -> Configs -> AutoMapperConfig.cs` 
