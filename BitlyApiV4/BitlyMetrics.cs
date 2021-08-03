using System.Collections.Generic;
using Newtonsoft.Json;

namespace BitlyAPI
{
    public class BitlyMetrics
    {
        [JsonProperty("link_clicks", NullValueHandling = NullValueHandling.Ignore)]
        public List<LinkClick> LinkClicks { get; set; }

        [JsonProperty("total_clicks", NullValueHandling = NullValueHandling.Ignore)]
        public string TotalClicks { get; set; }

        [JsonProperty("units", NullValueHandling = NullValueHandling.Ignore)]
        public string Units { get; set; }

        [JsonProperty("unit", NullValueHandling = NullValueHandling.Ignore)]
        public string Unit { get; set; }

        [JsonProperty("unit_reference", NullValueHandling = NullValueHandling.Ignore)]
        public string UnitReference { get; set; }
    }

    public class LinkClick
    {
        [JsonProperty("clicks", NullValueHandling = NullValueHandling.Ignore)]
        public string Clicks { get; set; }

        [JsonProperty("date", NullValueHandling = NullValueHandling.Ignore)]
        public string Date { get; set; }
    }
}