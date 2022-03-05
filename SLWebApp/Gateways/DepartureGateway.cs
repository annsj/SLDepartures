using Microsoft.Extensions.Configuration;
using SLWebApp.Models.Departure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SLWebApp.Gateways
{
    public class DepartureGateway : IDepartureGateway
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _client;

        public DepartureGateway(IConfiguration configuration,
            HttpClient client)
        {
            _configuration = configuration;
            _client = client;
        }

        public async Task<Departures> GetDeparturesAsync(string siteId)
        {
            HttpResponseMessage respons = new HttpResponseMessage();

            if (siteId == _configuration["MyStopId1"] || siteId == _configuration["MyStopId2"])
            {
                respons = await _client.GetAsync(String.Format(_configuration["Departure30API"], siteId));
            }
            else
            {
                respons = await _client.GetAsync(String.Format(_configuration["Departure15API"], siteId));
            }

            string responsString = await respons.Content.ReadAsStringAsync();
            Departures result = JsonSerializer.Deserialize<Departures>(responsString);

            return result;

        }
    }
}
