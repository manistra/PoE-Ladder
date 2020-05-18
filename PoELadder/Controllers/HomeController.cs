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
using AutoMapper;

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
        public async Task<ActionResult> LadderView(string League)  //FIX THIS 1 ++
        {
            List<EntryDto> entries = new List<EntryDto> { };
            CurrentLeagueSSFPlayer entry = new CurrentLeagueSSFPlayer();

            for (int i = 0; i < 1; i++) { // i * 200 = number of shown players

                string link = "http://api.pathofexile.com/ladders/" + League + "?offset=" + i*200 + "&limit=200";  //FIX THIS 1 

                var res = await link.GetStringAsync();

                RootobjectDto data = JsonConvert.DeserializeObject<RootobjectDto>(res);

                entries.AddRange(data.Entries.ToList());
            }
                _context.CurrentLeagueSSFPlayers.RemoveRange(_context.CurrentLeagueSSFPlayers);
                _context.SaveChanges();

            foreach (var item in entries) {

                entry.Rank = item.Rank;
                entry.Dead = item.Dead;
                entry.Online = item.Online;
                entry.AccountName = item.Account.Name;
                entry.TotalChallenges = item.Account.Challenges.Total;
                entry.CharacterName = item.Character.Name;
                entry.CharacterLevel = item.Character.Level;
                entry.CharacterClass = item.Character.Class;
                if (item.Character.Depth != null)
                {
                    entry.CharacterDepthSolo = item.Character.Depth.Solo;
                }
                else
                {
                    entry.CharacterDepthSolo = 0;
                }

                _context.CurrentLeagueSSFPlayers.Add(entry);
                _context.SaveChanges();
            };

            IEnumerable<CurrentLeagueSSFPlayer> viewList = _context.CurrentLeagueSSFPlayers;      

            return View(viewList);
        }
    }
}