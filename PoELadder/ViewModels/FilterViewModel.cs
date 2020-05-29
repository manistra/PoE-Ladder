using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PoELadder.ViewModels
{
    public class FilterViewModel
    {
        public FilterViewModel()
        {
            this.RankTop = 200;
            this.RankBottom = 1;
            this.LevelBottom = 1;
            this.LevelTop = 100;
            this.Class = "All";
        }

        public string Class { get; set; }
        public bool Dead { get; set; }
        public bool Online { get; set; }
        public int RankTop { get; set; }
        public int RankBottom { get; set; }
        public int LevelTop { get; set; }
        public int LevelBottom { get; set; }
        public int Depth { get; set; }
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