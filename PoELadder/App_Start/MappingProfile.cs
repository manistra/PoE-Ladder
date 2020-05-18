using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using PoELadder.Dtos;
using PoELadder.Models;
using PoELadder.ViewModels;

namespace PoELadder.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {

            Mapper.CreateMap<StandardPlayer,PlayersViewModel>();
            Mapper.CreateMap<StandardHCPlayer, PlayersViewModel>();
            Mapper.CreateMap<StandardSSFPlayer, PlayersViewModel>();
            Mapper.CreateMap<StandardHCSSFPlayer, PlayersViewModel>();
            Mapper.CreateMap<CurrentLeaguePlayer, PlayersViewModel>();
            Mapper.CreateMap<CurrentLeagueHCPlayer, PlayersViewModel>();
            Mapper.CreateMap<CurrentLeagueSSFPlayer, PlayersViewModel>();
            Mapper.CreateMap<CurrentLeagueHCSSFPlayer, PlayersViewModel>();

        }
    }
}