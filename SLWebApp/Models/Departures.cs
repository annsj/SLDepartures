using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace SLWebApp.Models.Departure
{

    public class Departures
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public int ExecutionTime { get; set; }
        public ResponseData ResponseData { get; set; }
    }

    public class ResponseData
    {
        public DateTime LatestUpdate { get; set; }
        public int DataAge { get; set; }
        public Metro[] Metros { get; set; }
        public Bus[] Buses { get; set; }
        public Train[] Trains { get; set; }
        public Tram[] Trams { get; set; }
        public Ship[] Ships { get; set; }
        public Stoppointdeviation[] StopPointDeviations { get; set; }
    }

    public class Metro
    {
        public string GroupOfLine { get; set; }
        public string DisplayTime { get; set; }
        public string TransportMode { get; set; }
        public string LineNumber { get; set; }
        public string Destination { get; set; }
        public int JourneyDirection { get; set; }
        public string StopAreaName { get; set; }
        public int StopAreaNumber { get; set; }
        public int StopPointNumber { get; set; }
        public string StopPointDesignation { get; set; }
        public DateTime TimeTabledDateTime { get; set; }
        public DateTime? ExpectedDateTime { get; set; }
        public int JourneyNumber { get; set; }
    }

    public class Bus
    {
        public string GroupOfLine { get; set; }
        public string TransportMode { get; set; }
        public string LineNumber { get; set; }
        public string Destination { get; set; }
        public int JourneyDirection { get; set; }
        public string StopAreaName { get; set; }
        public int StopAreaNumber { get; set; }
        public int StopPointNumber { get; set; }
        public string StopPointDesignation { get; set; }
        public DateTime TimeTabledDateTime { get; set; }
        public DateTime? ExpectedDateTime { get; set; }
        public string DisplayTime { get; set; }
        public int JourneyNumber { get; set; }
    }

    

    public class Train
    {
        public string SecondaryDestinationName { get; set; }
        public string GroupOfLine { get; set; }
        public string TransportMode { get; set; }
        public string LineNumber { get; set; }
        public string Destination { get; set; }
        public int JourneyDirection { get; set; }
        public string StopAreaName { get; set; }
        public int StopAreaNumber { get; set; }
        public int StopPointNumber { get; set; }
        public string StopPointDesignation { get; set; }
        public DateTime TimeTabledDateTime { get; set; }
        public DateTime? ExpectedDateTime { get; set; }
        public string DisplayTime { get; set; }
        public int JourneyNumber { get; set; }
    }

    public class Tram
    {
        public string TransportMode { get; set; }
        public string LineNumber { get; set; }
        public string Destination { get; set; }
        public int JourneyDirection { get; set; }
        public string GroupOfLine { get; set; }
        public string StopAreaName { get; set; }
        public int StopAreaNumber { get; set; }
        public int StopPointNumber { get; set; }
        public string StopPointDesignation { get; set; }
        public DateTime TimeTabledDateTime { get; set; }
        public DateTime? ExpectedDateTime { get; set; }
        public string DisplayTime { get; set; }
        public int JourneyNumber { get; set; }
    }

    public class Ship
    {
        public string TransportMode { get; set; }
        public string LineNumber { get; set; }
        public string Destination { get; set; }
        public int JourneyDirection { get; set; }
        public string GroupOfLine { get; set; }
        public string StopAreaName { get; set; }
        public int StopAreaNumber { get; set; }
        public int StopPointNumber { get; set; }
        public string StopPointDesignation { get; set; }
        public DateTime TimeTabledDateTime { get; set; }
        public DateTime? ExpectedDateTime { get; set; }
        public string DisplayTime { get; set; }
        public int JourneyNumber { get; set; }
    }
    
    public class Stoppointdeviation
    {
        public Stopinfo StopInfo { get; set; }
    }

    public class Stopinfo
    {
        public int StopAreaNumber { get; set; }
        public string StopAreaName { get; set; }
        public string TransportMode { get; set; }
        public string GroupOfLine { get; set; }
    }
}
