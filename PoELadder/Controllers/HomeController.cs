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
using PoELadder.ViewModels;
using AutoMapper;
using System.Linq;
using System.Web.Services.Protocols;

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
            ViewBag.League = Leagues.getList();

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> LadderView(string League)  //FIX THIS 1 ++
        {
            //List<EntryDto> entries = new List<EntryDto> { };
            //CurrentLeagueSSFPlayer entry = new CurrentLeagueSSFPlayer();

            //for (int i = 0; i < 1; i++) { // i * 200 = number of shown players

            //    string link = "http://api.pathofexile.com/ladders/" + League + "?offset=" + i*200 + "&limit=200";  //FIX THIS 1 

            //    var res = await link.GetStringAsync();

            //    RootobjectDto data = JsonConvert.DeserializeObject<RootobjectDto>(res);

            //    entries.AddRange(data.Entries.ToList());
            //}
            //    _context.CurrentLeagueSSFPlayers.RemoveRange(_context.CurrentLeagueSSFPlayers);
            //    _context.SaveChanges();

            //foreach (var item in entries) {

            //    entry.Rank = item.Rank;
            //    entry.Dead = item.Dead;
            //    entry.Online = item.Online;
            //    entry.AccountName = item.Account.Name;
            //    entry.TotalChallenges = item.Account.Challenges.Total;
            //    entry.CharacterName = item.Character.Name;
            //    entry.CharacterLevel = item.Character.Level;
            //    entry.CharacterClass = item.Character.Class;
            //    if (item.Character.Depth != null)
            //    {
            //        entry.CharacterDepthSolo = item.Character.Depth.Solo;
            //    }
            //    else
            //    {
            //        entry.CharacterDepthSolo = 0;
            //    }

            //    _context.CurrentLeagueSSFPlayers.Add(entry);
            //    _context.SaveChanges();
            //};

            IEnumerable<PlayersViewModel> playersViewModel;

            switch (League)
            {
                case "StandardPlayer":
                    IEnumerable<StandardPlayer> standardPlayers = _context.StandardPlayers;
                    playersViewModel = Mapper.Map<IEnumerable<StandardPlayer>, IEnumerable<PlayersViewModel>>(standardPlayers);
                    break;
                case "StandardHCPlayer":
                    IEnumerable<StandardHCPlayer> standardHCPlayers = _context.StandardHCPlayers;
                    playersViewModel = Mapper.Map<IEnumerable<StandardHCPlayer>, IEnumerable<PlayersViewModel>>(standardHCPlayers);
                    break;
                case "StandardSSFPlayer":
                    IEnumerable<StandardSSFPlayer> standardSSFPlayers = _context.StandardSSFPlayers;
                    playersViewModel = Mapper.Map<IEnumerable<StandardSSFPlayer>, IEnumerable<PlayersViewModel>>(standardSSFPlayers);
                    break;
                case "StandardHCSSFPlayer":
                    IEnumerable<StandardHCSSFPlayer> standardHCSSFPlayers = _context.StandardHCSSFPlayers;
                    playersViewModel = Mapper.Map<IEnumerable<StandardHCSSFPlayer>, IEnumerable<PlayersViewModel>>(standardHCSSFPlayers);
                    break;
                case "CurrentLeaguePlayer":
                    IEnumerable<CurrentLeaguePlayer> currentLeaguePlayers = _context.CurrentLeaguePlayers;
                    playersViewModel = Mapper.Map<IEnumerable<CurrentLeaguePlayer>, IEnumerable<PlayersViewModel>>(currentLeaguePlayers);
                    break;
                case "CurrentLeagueHCPlayer":
                    IEnumerable<CurrentLeagueHCPlayer> currentLeagueHCPlayers = _context.CurrentLeagueHCPlayers;
                    playersViewModel = Mapper.Map<IEnumerable<CurrentLeagueHCPlayer>, IEnumerable<PlayersViewModel>>(currentLeagueHCPlayers);
                    break;
                case "CurrentLeagueSSFPlayer":
                    IEnumerable<CurrentLeagueSSFPlayer> currentLeagueSSFPlayers = _context.CurrentLeagueSSFPlayers;
                    playersViewModel = Mapper.Map<IEnumerable<CurrentLeagueSSFPlayer>, IEnumerable<PlayersViewModel>>(currentLeagueSSFPlayers);
                    break;
                case "CurrentLeagueHCSSFPlayer":
                    IEnumerable<CurrentLeagueHCSSFPlayer> currentLeagueHCSSFPlayers = _context.CurrentLeagueHCSSFPlayers;
                    playersViewModel = Mapper.Map<IEnumerable<CurrentLeagueHCSSFPlayer>, IEnumerable<PlayersViewModel>>(currentLeagueHCSSFPlayers);
                    break;
                default:
                    IEnumerable<CurrentLeaguePlayer> currentLeaguePlayersDefault = _context.CurrentLeaguePlayers;
                    playersViewModel = Mapper.Map<IEnumerable<CurrentLeaguePlayer>, IEnumerable<PlayersViewModel>>(currentLeaguePlayersDefault);
                    break;
            }
            LadderViewModel model = new LadderViewModel();
            model.Players = playersViewModel;
            model.SelectedLeague = League;
            model.Filter = new FilterViewModel();

            return View(model);
        }

        public async Task<ActionResult> FilterView (LadderViewModel filterModel)
        {
            IEnumerable<PlayersViewModel> playersViewModel;

            switch (filterModel.SelectedLeague)
            {
                case "StandardPlayer":
                    IEnumerable<StandardPlayer> standardPlayers = _context.StandardPlayers
                        .Where(m => m.CharacterLevel >= filterModel.Filter.LevelBottom)
                        .Where(m => m.CharacterLevel <= filterModel.Filter.LevelTop)
                        .Where(m => m.Rank >= filterModel.Filter.RankBottom)
                        .Where(m => m.Rank <= filterModel.Filter.RankTop)
                        .Where(m => m.CharacterDepthSolo >= filterModel.Filter.Depth);
                    if (filterModel.Filter.Online == true)
                        standardPlayers = standardPlayers.Where(m => m.Online == true);
                    if (filterModel.Filter.Class != "All")
                        standardPlayers = standardPlayers.Where(m => m.CharacterClass == filterModel.Filter.Class);
                    playersViewModel = Mapper.Map<IEnumerable<StandardPlayer>, IEnumerable<PlayersViewModel>>(standardPlayers);
                    break;
                case "StandardHCPlayer":
                    IEnumerable<StandardHCPlayer> standardHCPlayers = _context.StandardHCPlayers
                        .Where(m => m.CharacterLevel >= filterModel.Filter.LevelBottom)
                        .Where(m => m.CharacterLevel <= filterModel.Filter.LevelTop)
                        .Where(m => m.Rank >= filterModel.Filter.RankBottom)
                        .Where(m => m.Rank <= filterModel.Filter.RankTop)
                        .Where(m => m.CharacterDepthSolo >= filterModel.Filter.Depth);
                    if (filterModel.Filter.Online == true)
                        standardHCPlayers = standardHCPlayers.Where(m => m.Online == true);
                    if (filterModel.Filter.Class != "All")
                        standardHCPlayers = standardHCPlayers.Where(m => m.CharacterClass == filterModel.Filter.Class);
                    playersViewModel = Mapper.Map<IEnumerable<StandardHCPlayer>, IEnumerable<PlayersViewModel>>(standardHCPlayers);
                    break;
                case "StandardSSFPlayer":
                    IEnumerable<StandardSSFPlayer> standardSSFPlayers = _context.StandardSSFPlayers
                        .Where(m => m.CharacterLevel >= filterModel.Filter.LevelBottom)
                        .Where(m => m.CharacterLevel <= filterModel.Filter.LevelTop)
                        .Where(m => m.Rank >= filterModel.Filter.RankBottom)
                        .Where(m => m.Rank <= filterModel.Filter.RankTop)
                        .Where(m => m.CharacterDepthSolo >= filterModel.Filter.Depth);
                    if (filterModel.Filter.Online == true)
                        standardSSFPlayers = standardSSFPlayers.Where(m => m.Online == true);
                    if (filterModel.Filter.Class != "All")
                        standardSSFPlayers = standardSSFPlayers.Where(m => m.CharacterClass == filterModel.Filter.Class);
                    playersViewModel = Mapper.Map<IEnumerable<StandardSSFPlayer>, IEnumerable<PlayersViewModel>>(standardSSFPlayers);
                    break;
                case "StandardHCSSFPlayer":
                    IEnumerable<StandardHCSSFPlayer> standardHCSSFPlayers = _context.StandardHCSSFPlayers
                        .Where(m => m.CharacterLevel >= filterModel.Filter.LevelBottom)
                        .Where(m => m.CharacterLevel <= filterModel.Filter.LevelTop)
                        .Where(m => m.Rank >= filterModel.Filter.RankBottom)
                        .Where(m => m.Rank <= filterModel.Filter.RankTop)
                        .Where(m => m.CharacterDepthSolo >= filterModel.Filter.Depth);
                    if (filterModel.Filter.Online == true)
                        standardHCSSFPlayers = standardHCSSFPlayers.Where(m => m.Online == true);
                    if (filterModel.Filter.Class != "All")
                        standardHCSSFPlayers = standardHCSSFPlayers.Where(m => m.CharacterClass == filterModel.Filter.Class);
                    playersViewModel = Mapper.Map<IEnumerable<StandardHCSSFPlayer>, IEnumerable<PlayersViewModel>>(standardHCSSFPlayers);
                    break;
                case "CurrentLeaguePlayer":
                    IEnumerable<CurrentLeaguePlayer> currentLeaguePlayers = _context.CurrentLeaguePlayers
                        .Where(m => m.CharacterLevel >= filterModel.Filter.LevelBottom)
                        .Where(m => m.CharacterLevel <= filterModel.Filter.LevelTop)
                        .Where(m => m.Rank >= filterModel.Filter.RankBottom)
                        .Where(m => m.Rank <= filterModel.Filter.RankTop)
                        .Where(m => m.CharacterDepthSolo >= filterModel.Filter.Depth);
                    if (filterModel.Filter.Online == true)
                        currentLeaguePlayers = currentLeaguePlayers.Where(m => m.Online == true);
                    if (filterModel.Filter.Class != "All")
                        currentLeaguePlayers = currentLeaguePlayers.Where(m => m.CharacterClass == filterModel.Filter.Class);
                    playersViewModel = Mapper.Map<IEnumerable<CurrentLeaguePlayer>, IEnumerable<PlayersViewModel>>(currentLeaguePlayers);
                    break;
                case "CurrentLeagueHCPlayer":
                    IEnumerable<CurrentLeagueHCPlayer> currentLeagueHCPlayers = _context.CurrentLeagueHCPlayers
                        .Where(m => m.CharacterLevel >= filterModel.Filter.LevelBottom)
                        .Where(m => m.CharacterLevel <= filterModel.Filter.LevelTop)
                        .Where(m => m.Rank >= filterModel.Filter.RankBottom)
                        .Where(m => m.Rank <= filterModel.Filter.RankTop)
                        .Where(m => m.CharacterDepthSolo >= filterModel.Filter.Depth);
                    if (filterModel.Filter.Online == true)
                        currentLeagueHCPlayers = currentLeagueHCPlayers.Where(m => m.Online == true);
                    if (filterModel.Filter.Class != "All")
                        currentLeagueHCPlayers = currentLeagueHCPlayers.Where(m => m.CharacterClass == filterModel.Filter.Class);
                    playersViewModel = Mapper.Map<IEnumerable<CurrentLeagueHCPlayer>, IEnumerable<PlayersViewModel>>(currentLeagueHCPlayers);
                    break;
                case "CurrentLeagueSSFPlayer":
                    IEnumerable<CurrentLeagueSSFPlayer> currentLeagueSSFPlayers = _context.CurrentLeagueSSFPlayers
                        .Where(m => m.CharacterLevel >= filterModel.Filter.LevelBottom)
                        .Where(m => m.CharacterLevel <= filterModel.Filter.LevelTop)
                        .Where(m => m.Rank >= filterModel.Filter.RankBottom)
                        .Where(m => m.Rank <= filterModel.Filter.RankTop)
                        .Where(m => m.CharacterDepthSolo >= filterModel.Filter.Depth);
                    if (filterModel.Filter.Online == true)
                        currentLeagueSSFPlayers = currentLeagueSSFPlayers.Where(m => m.Online == true);
                    if (filterModel.Filter.Class != "All")
                        currentLeagueSSFPlayers = currentLeagueSSFPlayers.Where(m => m.CharacterClass == filterModel.Filter.Class);
                    playersViewModel = Mapper.Map<IEnumerable<CurrentLeagueSSFPlayer>, IEnumerable<PlayersViewModel>>(currentLeagueSSFPlayers);
                    break;
                case "CurrentLeagueHCSSFPlayer":
                    IEnumerable<CurrentLeagueHCSSFPlayer> currentLeagueHCSSFPlayers = _context.CurrentLeagueHCSSFPlayers
                        .Where(m => m.CharacterLevel >= filterModel.Filter.LevelBottom)
                        .Where(m => m.CharacterLevel <= filterModel.Filter.LevelTop)
                        .Where(m => m.Rank >= filterModel.Filter.RankBottom)
                        .Where(m => m.Rank <= filterModel.Filter.RankTop)
                        .Where(m => m.CharacterDepthSolo >= filterModel.Filter.Depth);
                    if (filterModel.Filter.Online == true)
                        currentLeagueHCSSFPlayers = currentLeagueHCSSFPlayers.Where(m => m.Online == true);
                    if (filterModel.Filter.Class != "All")
                        currentLeagueHCSSFPlayers = currentLeagueHCSSFPlayers.Where(m => m.CharacterClass == filterModel.Filter.Class);
                    playersViewModel = Mapper.Map<IEnumerable<CurrentLeagueHCSSFPlayer>, IEnumerable<PlayersViewModel>>(currentLeagueHCSSFPlayers);
                    break;
                default:
                    IEnumerable<CurrentLeaguePlayer> currentLeaguePlayersDefault = _context.CurrentLeaguePlayers
                        .Where(m => m.CharacterLevel >= filterModel.Filter.LevelBottom)
                        .Where(m => m.CharacterLevel <= filterModel.Filter.LevelTop)
                        .Where(m => m.Rank >= filterModel.Filter.RankBottom)
                        .Where(m => m.Rank <= filterModel.Filter.RankTop)
                        .Where(m => m.CharacterDepthSolo >= filterModel.Filter.Depth);
                    if (filterModel.Filter.Online == true)
                        currentLeaguePlayersDefault = currentLeaguePlayersDefault.Where(m => m.Online == true);
                    if (filterModel.Filter.Class != "All")
                        currentLeaguePlayersDefault = currentLeaguePlayersDefault.Where(m => m.CharacterClass == filterModel.Filter.Class);
                    playersViewModel = Mapper.Map<IEnumerable<CurrentLeaguePlayer>, IEnumerable<PlayersViewModel>>(currentLeaguePlayersDefault);
                    break;
            }
            filterModel.Players = playersViewModel;

            return View("LadderView", filterModel);
        }
    }
}