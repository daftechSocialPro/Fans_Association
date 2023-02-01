using MlkPwgen;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace tmretApi.Entities
{
    public class Player :Common
    {

        public string FullName { get; set; }

        public string PlayerImage { get; set; }

        [NotMapped]
       [JsonIgnore] public IFormFile Photo { get; set; }

        public float Height { get; set; }
        public float Weight { get; set; }

        public virtual Team CurrentTeam { get; set; }
        public Guid CurrentTeamId { get; set; }

        public Postition Postition { get; set; }

        public DateTime BirthDate { get; set; }

        public string Description { get; set; }

        public string Nationality { get; set; }


        public List<PlayerStats> PlayerStats { get; set; }
        public List<MacthStats> MacthStats { get; set; }

        public List <PlayerHistory> PlayerHistory { get; set; }

    }

    public enum Postition {
        GK,
        RB,
        LB,
        CB,
        DMF,
        RMF,
        LMF,
        CM,
        CF,
        RW,
        LW,
        AMF
    }
}
