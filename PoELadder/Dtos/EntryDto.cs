using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using PoELadder.Dtos;

namespace PoELadder.Models
{
    public class EntryDto
    {  
        [JsonProperty("rank")]
        public int Rank { get; set; }

        [JsonProperty("dead")]
        public bool Dead { get; set; }

        [JsonProperty("online")]
        public bool Online { get; set; }

        [JsonProperty("character")]
        public CharacterDto Character { get; set; }

        [JsonProperty("account")]
        public AccountDto Account { get; set; }
    }
}