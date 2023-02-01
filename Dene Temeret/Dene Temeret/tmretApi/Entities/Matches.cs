namespace tmretApi.Entities
{

    public class Matches : Common
    {


        public virtual Team Team1 { get; set; }
        public Guid Team1Id { get; set; }

        public virtual Team Team2 { get; set; }
        public Guid Team2Id { get; set; }

        public Game Game { get; set; }

        public int Team1Score { get; set; }

        public int Team2Score { get; set; }

        public virtual Season Seasons { get; set; }

        public Guid SeasonsId { get; set; }

        public virtual MatchWeek MatchWeek { get; set; }
        public Guid MatchWeekId { get; set; }

        public DateTime MatchDate { get; set; }

        public List<MacthStats> MacthStats { get; set; }


    }


    public enum Game
    {

        NotStarted,
        OnGoing,
        FullTime

    }

}