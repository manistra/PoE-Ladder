using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using PoELadder.Dtos;

namespace PoELadder.Models
{
    public class CharacterDto
    {   
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("level")]
        public int Level { get; set; }

        [JsonProperty("class")]
        public string Class { get; set; }

        [JsonProperty("experience")]
        public string Experience { get; set; }

        [JsonProperty("depth")]
        public DepthDto Depth { get; set; }
    }
}