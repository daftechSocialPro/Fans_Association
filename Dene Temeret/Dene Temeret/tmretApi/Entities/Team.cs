using System.ComponentModel.DataAnnotations.Schema;

namespace tmretApi.Entities
{
    public class Team :Common
    {

        public string Name { get; set; }    

        public string ShortName { get; set; }

        public string Logo { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }


        public virtual Season Season { get; set; }
        public  Guid SeasonId { get; set; }

        public int Played { get; set; }

        public int Win { get; set; }

        public int Draw { get; set; }

        public int Lost { get; set; }

        public int GoalForward { get; set; }

        public int GoalAgainst { get; set; }

        public int Point { get; set;}

        public List<Player> Players { get; set; }


    }
}
