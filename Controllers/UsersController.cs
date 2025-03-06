using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    readonly ICosmosService<Users> _cosmos;

    public UsersController(ICosmosService<Users> cosmosDbService)
    {
        _cosmos = cosmosDbService;
    }

    // GET: api/<Books>
    [HttpGet]
    public async Task<IEnumerable<Users>> Get()
    {
        return await _cosmos.GetItemsAsync("SELECT * FROM c");
    }

    // GET api/<Books>/ISBN/Partition
    [HttpGet("{id}/{partition}")]
    public async Task<Users> Get(string id, string partition = Utils.DEFAULT_PARTITION)
    {
        return await _cosmos.GetItemAsync(id, partition);
    }

    // POST api/<Books>
    [HttpPost]
    public async Task<bool> Post([FromBody] Users item)
    {
        return await _cosmos.AddItemAsync(item);
    }

    // PUT api/<Books>/5
    [HttpPut("{id}")]
    public async Task<bool> Put(string id, [FromBody] Users item)
    {
        return await _cosmos.UpdateItemAsync(id, item);
    }

    // DELETE api/<Books>/id/partition
    [HttpDelete("{id}")]
    [HttpDelete("{id}/{partition}")]
    public async Task<bool> Delete(string id, string partition = Utils.DEFAULT_PARTITION)
    {
        return await _cosmos.DeleteItemAsync(id, partition);
    }
}

