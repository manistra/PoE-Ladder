using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace PoELadder.Models
{
    public class RootobjectDto
    {   
        [JsonProperty("entries")]
        public EntryDto[] Entries { get; set; }
    }
}