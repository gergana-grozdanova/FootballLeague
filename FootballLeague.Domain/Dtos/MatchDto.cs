using System;
using System.Collections.Generic;
using System.Text;

namespace FootballLeague.Domain.Dtos
{
    public class MatchDto:BaseDto
    {
        public string Team1Id { get; set; }
        public string Team2Id { get; set; }
        public TeamDto Team1 { get; set; }
        public TeamDto Team2 { get; set; }
        public bool IsPlayed { get; set; }
        public int Team1Result { get; set; }
        public int Team2Result { get; set; }
    }
}
