using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private static readonly HttpClient _client = new HttpClient();

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            var requestUri = $"{Environment.GetEnvironmentVariable("EXTERNAL_SERVICE_URL")}/api/values";
            var json = await _client.GetStringAsync(requestUri);
            
            return JsonConvert.DeserializeObject<string[]>(json);
        }
    }
}
