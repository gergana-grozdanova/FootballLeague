using AutoMapper;
using FootballLeague.Data.Entities;
using FootballLeague.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Services
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Team,TeamDto>().ReverseMap();
            CreateMap<Match,MatchDto>().ReverseMap();
        }
    }
}
