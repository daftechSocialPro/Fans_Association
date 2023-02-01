namespace tmretApi.Entities
{
    public class MacthStats:Common
    {
        public virtual Matches Match { get; set; }    
        public Guid MatchId { get; set; }

        public virtual Player Player { get; set; }
        public Guid PlayerId { get; set; }


        public virtual Team Team { get; set; }
        public Guid TeamId { get; set; }


        public PlayerDid PlayerDid { get; set; }
        public string Minute { get; set; }


    }

    public enum PlayerDid{
        Goal,
        Assist,
        YellowCard,
        RedCard
    }
}
