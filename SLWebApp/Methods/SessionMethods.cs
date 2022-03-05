using Microsoft.AspNetCore.Http;
using SLWebApp.Models;
using SLWebApp.Models.Stop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SLWebApp.Methods
{
    public static class SessionMethods
    {
        static readonly JsonSerializerOptions Options = new JsonSerializerOptions
        {
            DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(System.Text.Unicode.UnicodeRanges.All)
        };

        public static void SetStopSelects(this ISession session, string key, List<StopSelect> stopSelects)
        {
            session.SetString(key, JsonSerializer.Serialize(stopSelects));
        }

        public static void SetTransportModes(this ISession session, string key, List<TransportMode> transportModes)
        {
            session.SetString(key, JsonSerializer.Serialize(transportModes));
        }

        public static List<StopSelect> GetStopSelects(this ISession session, string key)
        {
            string sessionValue = session.GetString(key);
            return sessionValue == null ? default : JsonSerializer.Deserialize<List<StopSelect>>(sessionValue);
        }

        public static List<TransportMode> GetTransportModes(this ISession session, string key)
        {
            string sessionValue = session.GetString(key);
            return sessionValue == null ? default : JsonSerializer.Deserialize<List<TransportMode>>(sessionValue);
        }       
    }
}
