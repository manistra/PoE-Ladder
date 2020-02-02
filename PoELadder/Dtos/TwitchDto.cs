using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace PoELadder.Dtos
{
    public class TwitchDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}