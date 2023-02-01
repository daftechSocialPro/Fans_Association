namespace tmretApi.Entities
{
    public class SeasonTeams:Common
    {

        public virtual Team Team { get; set; }
        public Guid TeamId { get; set; }


        public virtual Season Season {get;set;}
        public Guid SeasonId { get; set; }
    }
}
