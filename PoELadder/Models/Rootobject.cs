using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace PoELadder.Models
{
    public class Rootobject
    {
        public int Id { get; set; }        
        public Entry[] Entries { get; set; }
    }
}