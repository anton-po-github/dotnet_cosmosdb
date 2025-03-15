using System.Text.Json;

public static class SeedData
{
    public static async Task<List<T>> GetDataSample<T>(ICosmosService<T> _service)
    {

        //var file = $"{Startup.PATH}/Statics/{typeof(T).Name}_SEED.json";

        var file = File.ReadAllText("../../../DOT_NET/dotnet_cosmosdb/Statics/Movie_SEED.json");

        if (File.Exists(file))
        {
            try
            {
                var data = JsonSerializer.Deserialize<List<T>>(File.ReadAllText(file));
                foreach (T item in data)
                {
                    await _service.AddItemAsync(item);
                }
                return data;
            }
            catch (Exception ex)
            {

            }
        }
        return new List<T>();
    }
}

