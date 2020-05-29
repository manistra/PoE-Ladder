using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PoELadder.ViewModels;

namespace PoELadder.ViewModels
{
    public class LadderViewModel
    {
        public string SelectedLeague { get; set; }
        public IEnumerable<PlayersViewModel> Players { get; set; }
        public  FilterViewModel Filter { get; set; }

    }
}