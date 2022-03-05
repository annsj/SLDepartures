using SLWebApp.Models.Departure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SLWebApp.Gateways
{
    public interface IDepartureGateway
    {
        Task<Departures> GetDeparturesAsync(string siteId);
    }
}
