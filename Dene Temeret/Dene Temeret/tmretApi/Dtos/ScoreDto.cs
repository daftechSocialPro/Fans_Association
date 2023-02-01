using Org.BouncyCastle.Bcpg.OpenPgp;
using tmretApi.Entities;

namespace tmretApi.Dtos
{
    public class ScoreDto
    {
              
        public Guid matchId { get;set;}
        public Guid playerId { get; set; }

        public Guid teamId      { get; set; }   
        public PlayerDid playerDid { get; set; }
        public int minute { get; set; }
        public Game Game { get; set; }

        public Guid playerAssistId { get; set; }


    }
}
