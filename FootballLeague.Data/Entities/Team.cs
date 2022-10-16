using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FootballLeague.Data.Entities
{
    public class Team:BaseEntity
    {
        public Team()
        {
            this.WonMatches = new HashSet<Match>();
            this.LostMatches = new HashSet<Match>();
            this.DrawMatches = new HashSet<Match>();
        }
        [MinLength(1)]
        public string Name { get; set; }
        public ICollection<Match>? WonMatches { get; set; }
        public ICollection<Match>? LostMatches { get; set; }
        public ICollection<Match>? DrawMatches { get; set; }
    }
}
