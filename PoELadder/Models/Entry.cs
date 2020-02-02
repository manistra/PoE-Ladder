using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace PoELadder.Models
{
    public class Entry
    {
        public int Id { get; set; }      
        public int Rank { get; set; }        
        public bool Dead { get; set; }        
        public bool Online { get; set; }        
        public Character Character { get; set; }       
        public Account Account { get; set; }
    }
}