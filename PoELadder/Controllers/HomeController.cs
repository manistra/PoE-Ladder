using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Flurl;
using Flurl.Http;
using PoELadder.Models;
using PoELadder.Dtos.Leagues;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace PoELadder.Controllers
{
    public class HomeController : Controller
    {
        
        public async Task<ActionResult> Index()
        {
            var res = await "http://api.pathofexile.com/leagues".GetStringAsync();

            List<EntriesLeaguesDto> data = JsonConvert.DeserializeObject<List<EntriesLeaguesDto>>(res);

            
            List<SelectListItem> leagues = new List<SelectListItem>() { };

            for (int i = 0; i < data.Count(); i++)
                {
                    SelectListItem item = new SelectListItem
                    {
                        Text = data[i].Id,  //FIX THIS 1 
                        Value = data[i].Id  //FIX THIS 1 
                    };
                leagues.Add(item);
                };

            ViewBag.Leagues = leagues;           


            return View();
        }

        [HttpPost]
        public async Task<ActionResult> LadderView(string Leagues)  //FIX THIS 1 
        {            
            string link = "http://api.pathofexile.com/ladders/" + Leagues + "/?limit=200";  //FIX THIS 1 

            var res = await link.GetStringAsync();

            RootobjectDto data = JsonConvert.DeserializeObject<RootobjectDto>(res);

            IEnumerable<EntryDto> entries = data.Entries.ToList();





            return View(entries);
        }
    }
}