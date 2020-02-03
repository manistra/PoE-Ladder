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
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public async Task<ActionResult> Index()
        {
            var res = await "http://api.pathofexile.com/leagues".GetStringAsync();

            List<EntriesLeaguesDto> data = JsonConvert.DeserializeObject<List<EntriesLeaguesDto>>(res);

            
            List<SelectListItem> league = new List<SelectListItem>() { };

            for (int i = 0; i < data.Count(); i++)
                {
                    SelectListItem item = new SelectListItem
                    {
                        Text = data[i].Id,  //FIX THIS 1 
                        Value = data[i].Id  //FIX THIS 1 
                    };
                league.Add(item);
                };

            ViewBag.League = league;           


            return View();
        }

        [HttpPost]
        public async Task<ActionResult> LadderView(string League)  //FIX THIS 1 
        {
            List<EntryDto> lista = new List<EntryDto> { };

            for (int i = 0; i < 75; i++) { // i * 200 = number of shown players

                string link = "http://api.pathofexile.com/ladders/" + League + "?offset=" + i*200 + "&limit=200";  //FIX THIS 1 

                var res = await link.GetStringAsync();

                RootobjectDto data = JsonConvert.DeserializeObject<RootobjectDto>(res);

                lista.AddRange(data.Entries.ToList());
            }

            IEnumerable<EntryDto> entries = lista;

            return View(entries);
        }
    }
}