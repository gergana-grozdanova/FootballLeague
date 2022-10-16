using FootballLeague.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Domain.Abstractions.Services
{
    public interface ITeamService:IBaseService<TeamDto>
    {
        public Task<List<TeamDto>> RankedTeams();
    }
}
