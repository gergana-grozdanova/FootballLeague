namespace FootballLeague.Models
{
    public class CreateMatchModel
    {
        public string Team1Id { get; set; }
        public string Team2Id { get; set; }
        public bool IsPlayed { get; set; }
        public int? Team1Result { get; set; }
        public int? Team2Result { get; set; }
    }
}
