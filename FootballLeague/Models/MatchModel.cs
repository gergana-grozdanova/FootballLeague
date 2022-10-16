namespace FootballLeague.Models
{
    public class MatchModel
    {
        public string Team1Name { get; set; }
        public string Team2Name { get; set; }
        public bool IsPlayed { get; set; }
        public int? Team1Result { get; set; }
        public int? Team2Result { get; set; }
    }
}
