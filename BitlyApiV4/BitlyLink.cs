﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace BitlyAPI
{
    public class BitlyLink
    {
        public bool Archived { get; set; }

        public List<string> Tags { get; set; }

        [JsonProperty("created_at")] public string CreatedAt { get; set; }

        public string Title { get; set; }

        public List<BitlyDeepLink> Deeplinks { get; set; }

        public string CreatedBy { get; set; }

        [JsonProperty("long_url")] public string LongUrl { get; set; }

        [JsonProperty("client_id")] public string ClientId { get; set; }

        [JsonProperty("custom_bitlinks")] public List<string> CustomBitlinks { get; set; }

        public string Link { get; set; }

        public string Id { get; set; }

        public Dictionary<string, string> References { get; set; }
    }
}