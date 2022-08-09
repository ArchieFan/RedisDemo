using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RedisDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CacheController : ControllerBase
    {
        private readonly IDatabase _database;

        public CacheController(IDatabase database)
        {
            _database = database;
        }

        // GET api/<CacheController>/5
        [HttpGet]
        public string Get([FromQuery] string key)
        {
            return _database.StringGet(key);
        }

        // POST api/<CacheController>
        [HttpPost]
        public void Post([FromBody] KeyValuePair<string, string> KeyValue)
        {
            _database.StringSet(KeyValue.Key, KeyValue.Value);
        }




    }
}
