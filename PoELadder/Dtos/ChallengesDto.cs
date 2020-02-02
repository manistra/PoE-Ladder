using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;


namespace PoELadder.Dtos
{
    public class ChallengesDto
    {
        [JsonProperty("total")]
        public int Total { get; set; }
    }
}