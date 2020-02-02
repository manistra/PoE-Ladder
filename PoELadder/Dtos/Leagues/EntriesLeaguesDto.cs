using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace PoELadder.Dtos.Leagues
{
    public class EntriesLeaguesDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}

