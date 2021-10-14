using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace APInet5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CepController : ControllerBase
    {
        private readonly ILogger<CepController> _logger;

        public CepController(ILogger<CepController> logger, ApiContext context)
        {
            _logger = logger;
        }
        
        [HttpGet("{cep}")]
        public async Task<string> GetByCepAsync(string cep)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri ("https://viacep.com.br/ws/");
                HttpResponseMessage response = await httpClient.GetAsync($"{cep}/json/");

                return await response.Content.ReadAsStringAsync();
            }

        }

    }
}
