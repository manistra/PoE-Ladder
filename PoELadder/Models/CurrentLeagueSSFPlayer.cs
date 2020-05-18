using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoELadder.Models
{
    public class CurrentLeagueSSFPlayer
    {
        public int Id { get; set; }
        public int Rank { get; set; }
        public bool Dead { get; set; }
        public bool Online { get; set; }
        public string AccountName { get; set; }
        public int TotalChallenges { get; set; }
        public string CharacterName { get; set; }
        public int CharacterLevel { get; set; }
        public string CharacterClass { get; set; }
        public int? CharacterDepthSolo { get; set; }
    }
}