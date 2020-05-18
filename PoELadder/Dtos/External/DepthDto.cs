using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace PoELadder.Dtos
{
    public class DepthDto
    {
        [JsonProperty("solo")]
        public int? Solo { get; set; }
        
        [JsonProperty("default")]
        public int? Default { get; set; }
    }
}