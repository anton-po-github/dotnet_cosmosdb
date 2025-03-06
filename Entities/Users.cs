using System.Text.Json.Serialization;
using Newtonsoft.Json;

public class Users
{
    [JsonPropertyName("id")]
    [JsonProperty("id")]
    public string ISBN { get; set; }

    [JsonPropertyName("UserEmail")]
    public string UserEmail { get; set; }

    [JsonPropertyName("UserName")]
    public string UserName { get; set; }

    public string Partition { get; set; }

    // public override string ToString() => $"{UserEmail}, {UserName}";
}