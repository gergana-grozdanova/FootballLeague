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
    public class MatchService : BaseService<MatchDto, Match>, IMatchService
    {
        public MatchService(FootballLeagueContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<List<MatchDto>> GetPlayedMatches()
        {
            var played = entities.Where(m => m.IsPlayed).ToListAsync();
            return played.GetAwaiter().GetResult().Select(m=>_mapper.Map<MatchDto>(m)).ToList();
        }
    }
}
