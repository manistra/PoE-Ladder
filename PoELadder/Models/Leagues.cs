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
                        Value = "Standard"
                    },
                new SelectListItem
                    {
                        Text = "Hardcore",
                        Value = "Hardcore"
                    },
                new SelectListItem
                    {
                        Text = "SSF Standard",
                        Value = "SSF Standard"
                    },
                new SelectListItem
                    {
                        Text = "SSF Hardcore",
                        Value = "SSF Hardcore"
                    },
                new SelectListItem
                    {
                        Text = "Delirium",
                        Value = "Delirium"
                    },
                new SelectListItem
                    {
                        Text = "Hardcore Delirium",
                        Value = "Hardcore Delirium"
                    },
                new SelectListItem
                    {
                        Text = "SSF Delirium",
                        Value = "SSF Delirium"
                    },
                new SelectListItem
                    {
                        Text = "SSF Delirium HC",
                        Value = "SSF Delirium HC"
                    },
            };
            return leagues;
        }

    }
}