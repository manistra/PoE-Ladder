using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Flurl;
using Flurl.Http;
using PoELadder.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace PoELadder.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var res = await "http://api.pathofexile.com/ladders/metamorph/?limit=100".GetStringAsync();

            RootobjectDto data = JsonConvert.DeserializeObject<RootobjectDto>(res);

            IEnumerable<EntryDto> entries = data.Entries.ToList();

              



            return View(entries);
        }
    }
}