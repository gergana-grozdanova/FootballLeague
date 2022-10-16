using System.Collections.Generic;

namespace FootballLeague.Models
{
    public class TeamModel
    {
        public string Name { get; set; }
        public ICollection<MatchModel> WonMatches { get; set; }
        public ICollection<MatchModel> LostMatches { get; set; }
        public ICollection<MatchModel> DrawMatches { get; set; }
    }
}
