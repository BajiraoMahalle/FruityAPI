using FruityAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Threading.Tasks;

namespace FruityAPI.Controllers
{
    [ApiController]
    
    public class FruityAPIController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<FruityAPIController> _logger;

        public FruityAPIController(ILogger<FruityAPIController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("FruityAPI/GetAllFruits")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<List<FruityResponse>> GetAllFruits()
        {
            List<FruityResponse> fruityResponse = new List<FruityResponse>();
            HttpClient client = new HttpClient();
            string uri = "https://www.fruityvice.com";

            string requestParameter = $"/api/fruit/all";
            string uriBase = uri + requestParameter;
            HttpResponseMessage httpResponse;
            httpResponse = await client.GetAsync(uriBase);
            var contentString = await httpResponse.Content.ReadAsStringAsync();            
            fruityResponse = JsonConvert.DeserializeObject<List<FruityResponse>>(contentString);
            //return newContent;
            return fruityResponse;
        }

        [HttpPost]
        [Route("FruityAPI/AllFruits")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<List<FruityResponse>> AllFruits([FromBody] FruityBody fruityBody)
        {
            List<FruityResponse> fruityResponse = new List<FruityResponse>();
            HttpClient client = new HttpClient();
            string uri = "https://www.fruityvice.com";

            string requestParameter = $"/api/fruit/all";
            string uriBase = uri + requestParameter;
            HttpResponseMessage httpResponse;
            httpResponse = await client.GetAsync(uriBase);
            var contentString = await httpResponse.Content.ReadAsStringAsync();            
            fruityResponse = JsonConvert.DeserializeObject<List<FruityResponse>>(contentString);
            fruityResponse = fruityResponse.Where(x=>x.family == fruityBody.fruitFamily).ToList();
            //return newContent;
            return fruityResponse;
            
        }
    }
}
