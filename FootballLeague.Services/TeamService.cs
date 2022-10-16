using AutoMapper;
using FootballLeague.Data;
using FootballLeague.Data.Entities;
using FootballLeague.Domain.Abstractions.Services;
using FootballLeague.Domain.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Services
{
    public class TeamService : BaseService<TeamDto, Team>, ITeamService
    {
        private readonly IMatchService _matchService;
        public TeamService(FootballLeagueContext dbContext, IMapper mapper,IMatchService matchService) : base(dbContext, mapper)
        {
        }

        public async Task<List<TeamDto>> RankedTeams()
        {
            var ranked = entities.OrderByDescending(t => (t.WonMatches.Count * 3 + t.DrawMatches.Count)).ToListAsync();
            return  ranked.GetAwaiter().GetResult().Select(t=>_mapper.Map<TeamDto>(t)).ToList();
        }
    }
}
