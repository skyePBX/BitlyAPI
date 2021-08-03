using System.Collections.Generic;

namespace BitlyAPI
{
    public class BitlyMetrics
    {
        public List<LinkClick> LinkClicks { get; set; }

        public string TotalClicks { get; set; }

        public string Units { get; set; }

        public string Unit { get; set; }

        public string UnitReference { get; set; }
    }

    public class LinkClick
    {
        public string Clicks { get; set; }

        public string Date { get; set; }
    }
}