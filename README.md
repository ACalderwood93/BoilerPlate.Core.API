# BoilerPlate.Core.API
This is a project for a boiler plate .net Core 3 API with a Mongo DB database that is self documenting via Swagger / SwaggerUI

Mongo DB can be accessed through the `ICollectionRepository` Interface and the `GetCollection<T>` method within that. 

# Settings

The `app.settings.json` file provided in the repo will provide the correct format and default values for running MongoDb locally. 
If you are hosting Mongo via Atlas this connection string should be updated. 
