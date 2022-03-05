using SLWebApp.Models.Stop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SLWebApp.Gateways
{
    public interface IStopGateway
    {
        Task<Stops> GetStopsAsync(string searchString);
    }
}
