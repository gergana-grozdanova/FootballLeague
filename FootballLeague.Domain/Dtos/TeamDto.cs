using System;
using System.Collections.Generic;
using System.Text;

namespace FootballLeague.Domain.Dtos
{
    public class TeamDto:BaseDto
    {
        public TeamDto()
        {
            this.WonMatches=new HashSet<MatchDto>();
            this.LostMatches=new HashSet<MatchDto>();
            this.DrawMatches=new HashSet<MatchDto>();
        }
        public string Name { get; set; }
        public ICollection<MatchDto> WonMatches { get; set; }
        public ICollection<MatchDto> LostMatches { get; set; }
        public ICollection<MatchDto> DrawMatches { get; set; }

    }
}
