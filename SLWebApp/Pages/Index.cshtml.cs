using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using SLWebApp.Gateways;
using SLWebApp.Methods;
using SLWebApp.Models;
using SLWebApp.Models.Departure;
using SLWebApp.Models.Stop;

namespace SLWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly IDepartureGateway _departureGateway;
        private readonly IStopGateway _stopGateway;

        public IndexModel(IConfiguration configuration,
            IDepartureGateway departureGateway,
            IStopGateway stopGateway)
        {
            _configuration = configuration;
            _departureGateway = departureGateway;
            _stopGateway = stopGateway;
        }

        [BindProperty]
        public Departures MyDepartures1 { get; set; }

        [BindProperty]
        public Departures MyDepartures2 { get; set; }

        [BindProperty]
        public string SearchString { get; set; }

        [BindProperty]
        public List<StopSelect> StopSelects { get; set; }

        [BindProperty]
        public string SelectedStopId { get; set; }

        [BindProperty]
        public List<TransportMode> TransportModes { get; set; }

        [BindProperty]
        public Departures Departures { get; set; }



        public async Task<IActionResult> OnGetAsync()
        {
            string myStopId1 = _configuration["MyStopId1"];
            MyDepartures1 = await _departureGateway.GetDeparturesAsync(myStopId1);
            string myStopId2 = _configuration["MyStopId2"];
            MyDepartures2 = await _departureGateway.GetDeparturesAsync(myStopId2);

            StopSelects = HttpContext.Session.GetStopSelects("StopSelects");
            TransportModes = HttpContext.Session.GetTransportModes("TransportModes");
            SelectedStopId = HttpContext.Session.GetString("SelectedStopId");

            if (SelectedStopId != null)
            {
                Departures = await _departureGateway.GetDeparturesAsync(SelectedStopId);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (SearchString != null)
            {
                Stops suggestedStops = await _stopGateway.GetStopsAsync(SearchString);
                StopSelects = new List<StopSelect>();
                foreach (var stop in suggestedStops.ResponseData)
                {
                    StopSelects.Add(new StopSelect
                    {
                        Name = stop.Name,
                        SiteId = stop.SiteId
                    });
                }
                HttpContext.Session.SetStopSelects("StopSelects", StopSelects);
            }

            if (TransportModes.Count == 0)
            {
                TransportModes = HttpContext.Session.GetTransportModes("TransportModes");
                List<string> transportModesString = _configuration.GetSection("Transports").Get<string[]>().ToList();
                TransportModes = new List<TransportMode>();

                foreach (var name in transportModesString)
                {
                    TransportModes.Add(new TransportMode
                    {
                        Name = name
                    });
                }
            }
            HttpContext.Session.SetTransportModes("TransportModes", TransportModes);

            if (SelectedStopId != null)
            {
                HttpContext.Session.SetString("SelectedStopId", SelectedStopId);
            }

            return Redirect("/Index");
        }
    }
}
