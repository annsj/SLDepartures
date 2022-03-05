using Microsoft.Extensions.Configuration;
using SLWebApp.Models.Stop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SLWebApp.Gateways
{
    public class StopGateway : IStopGateway
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _client;

        public StopGateway(IConfiguration configuration,
            HttpClient client)
        {
            _configuration = configuration;
            _client = client;
        }      

        public async Task<Stops> GetStopsAsync(string searchString)
        {
            HttpResponseMessage respons = await _client.GetAsync(String.Format(_configuration["StopAPI"], searchString));
            string responsString = await respons.Content.ReadAsStringAsync();
            Stops result = JsonSerializer.Deserialize<Stops>(responsString);

            return result;
        }
    }
}
