namespace tmretApi.Entities
{
    public class PlayerStats:Common
    {

        public virtual Player Player { get; set; }
        public Guid PlayerId { get; set; }      
        

        public virtual Team Team { get; set; }
        public Guid TeamId { get; set; }

        public virtual Matches Match { get; set; }
        public Guid MatchId { get; set; }

        public int Goals { get; set; }  

        public int Assists { get;set ; }

        public int YellowCard { get;set; }

        public int Minute { get; set; }

        

        public int RedCard { get;set; } 


        
    }
}
