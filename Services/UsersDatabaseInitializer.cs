using Microsoft.Azure.Cosmos;

public class UsersDatabaseInitializer
{

    public static async Task<CosmosService<T>> Initialize<T>(IConfiguration configuration)
    {
        var settings = configuration.GetSection("UsersCosmosDb").Get<CosmosSettings>();
        var containerId = typeof(T).Name;

        var client = new CosmosClient(settings.EndPoint, settings.Key);

        var database = await client.CreateDatabaseIfNotExistsAsync(settings.DatabaseId);
        var container = await database
            .Database
            .CreateContainerIfNotExistsAsync(containerId, "/" + settings.PartitionName);

        // OBJECT FOR DI
        return new CosmosService<T>(container, settings.PartitionName); ;
    }
}