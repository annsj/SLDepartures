using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SLWebApp.Models.Stop
{
    public class Stops
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public long ExecutionTime { get; set; }
        public ResponseData[] ResponseData { get; set; }
    }

    public class ResponseData
    {
        public string Name { get; set; }
        public string SiteId { get; set; }
        public string Type { get; set; }
        public string X { get; set; }
        public string Y { get; set; }
        public string Products { get; set; }
    }    
}
