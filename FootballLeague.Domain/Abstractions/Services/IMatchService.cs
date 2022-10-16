using FootballLeague.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Domain.Abstractions.Services
{
    public interface IMatchService:IBaseService<MatchDto>
    {
        public Task<List<MatchDto>> GetPlayedMatches();
    }
}
