using AutoMapper;
using FootballLeague.Domain.Dtos;
using FootballLeague.Models;

namespace FootballLeague
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<CreateMatchModel, MatchDto>();
            CreateMap<CreateTeamModel, TeamDto>();
            CreateMap<TeamDto,TeamModel>();
            CreateMap<MatchDto,MatchModel>();
        }
    }
}
