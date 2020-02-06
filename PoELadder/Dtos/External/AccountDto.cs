using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using PoELadder.Models;
using PoELadder.Dtos;

namespace PoELadder.Models
{
    public class AccountDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("challenges")]
        public ChallengesDto Challenges {get; set;}

    }
}