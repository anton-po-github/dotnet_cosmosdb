using Microsoft.Azure.Cosmos;

public static class MovieDBInit
{
    /// <summary>
    /// Creates a Cosmos database and a container with the specified partition key. 
    /// </summary>
    public static async Task<CosmosService<T>> Initialize<T>(IConfiguration configuration)
    {
        var settings = configuration.GetSection("MovieCosmosDb").Get<CosmosSettings>();
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

