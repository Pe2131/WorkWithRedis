using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WorkWithRedis.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RedisController : ControllerBase
    {
        private readonly ICacheService _cacheService;

        public RedisController(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        // GET: api/<RedisController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<RedisController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _cacheService.GetCacheValue(id));
        }

        // POST api/<RedisController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromForm]string key)
        {
            await _cacheService.SetCacheValue(key, "hi");
            return Ok();

        }

        // PUT api/<RedisController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RedisController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
