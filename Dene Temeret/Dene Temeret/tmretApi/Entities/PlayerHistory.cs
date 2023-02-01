namespace tmretApi.Entities
{
    public class PlayerHistory :Common
    {

        public virtual Player Player { get; set; }
        public Guid PlayerId { get; set; }

        public virtual Team FromTeam { get; set; }

        public Guid FromTeamId { get; set; }

        public virtual Team ToTeam { get; set; }
        public Guid ToTeamId { get; set; }


        public DateTime Date { get; set; }

        public int ContractLength { get; set; }

        
        


    }
}
