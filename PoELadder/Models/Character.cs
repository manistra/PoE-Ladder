using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace PoELadder.Models
{
    public class Character
    {
        public int Id { get; set; }        
        public string Name { get; set; }        
        public int Level { get; set; }       
        public string Class { get; set; }        
        public string Experience { get; set; }
    }
}