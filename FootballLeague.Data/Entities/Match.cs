using System;
using System.Collections.Generic;
using System.Text;

namespace FootballLeague.Data.Entities
{
    public class Match:BaseEntity
    {
        public string Team1Id { get; set; }
        public string Team2Id { get; set; }
        public Team Team1 { get; set; }
        public Team Team2 { get; set; }
        public bool IsPlayed { get; set; }
        public int? Team1Result { get; set; }
        public int? Team2Result { get; set; }
    }
}
