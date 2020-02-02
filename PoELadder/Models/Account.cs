using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace PoELadder.Models
{
    public class Account
    {
        public int Id { get; set; }        
        public string Name { get; set; }
        public Twitch Twitch { get; set; }
    }
}