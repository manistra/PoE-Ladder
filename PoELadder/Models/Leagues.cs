using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PoELadder.Models
{
    public static class Leagues
    {

        public static List<SelectListItem> getList()
        {
            List<SelectListItem> leagues = new List<SelectListItem>()
            {
                new SelectListItem
                    {
                        Text ="Standard" ,
                        Value = "StandardPlayer"
                    },
                new SelectListItem
                    {
                        Text = "Hardcore",
                        Value = "StandardHCPlayer"
                    },
                new SelectListItem
                    {
                        Text = "SSF Standard",
                        Value = "StandardSSFPlayer"
                    },
                new SelectListItem
                    {
                        Text = "SSF Hardcore",
                        Value = "StandardHCSSFPlayer"
                    },
                new SelectListItem
                    {
                        Text = "Delirium",
                        Value = "CurrentLeaguePlayer"
                    },
                new SelectListItem
                    {
                        Text = "Hardcore Delirium",
                        Value = "CurrentLeagueHCPlayer"
                    },
                new SelectListItem
                    {
                        Text = "SSF Delirium",
                        Value = "CurrentLeagueSSFPlayer"
                    },
                new SelectListItem
                    {
                        Text = "SSF Delirium HC",
                        Value = "CurrentLeagueHCSSFPlayer"
                    },
            };
            return leagues;
        }

    }
}