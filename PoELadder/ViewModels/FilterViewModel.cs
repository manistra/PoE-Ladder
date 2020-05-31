using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;


namespace PoELadder.ViewModels
{
    public class FilterViewModel
    {
        public FilterViewModel()
        {
            this.RankTop = 100;
            this.RankBottom = 1;
            this.LevelBottom = 1;
            this.LevelTop = 100;
            this.Class = "All";
            this.Challenges = 0;
            this.Dead = false;
            this.Online = false;
        }

        public string Class { get; set; }
        [Range(0, 40)]
        [Display(Name = "Challenges")]
        public int Challenges { get; set; }
        [Range(2, 15000)]
        [Display(Name = "Max Rank")]
        public int RankTop { get; set; }
        [Range(1, 14999)]
        [Display(Name = "Min Rank")]
        public int RankBottom { get; set; }
        [Range(2, 100)]
        [Display(Name = "Max Level")]
        public int LevelTop { get; set; }
        [Range(1, 99)]
        [Display(Name = "Min Level")]
        public int LevelBottom { get; set; }
        [Range(0, 15000)]
        [Display(Name = "Depth")]
        public int Depth { get; set; }
        public bool Dead { get; set; }
        public bool Online { get; set; }
        public enum Classes
        {
            All,
            Marauder,
            Juggernaut,
            Berserker,
            Chieftain,
            Duelist,
            Slayer,
            Gladiator,
            Champion,
            Ranger,
            Deadeye,
            Raider,
            Pathfinder,
            Shadow,
            Assassin,
            Saboteur,
            Trickster,
            Witch,
            Necromancer,
            Occultist,
            Elementalist,
            Templar,
            Inquisitor,
            Hierophant,
            Guardian,
            Scion
        }
    }
}