using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace tmretApi.Entities
{
    public class TmretExecutives: Common
    {

        public virtual User  Temret  { get; set; }
        public Guid TemretId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }

        public string UserPhoto  { get; set; }

        [NotMapped]
        [JsonIgnore] public IFormFile Photo { get; set; }
        public string Description { get; set; }

        public string BirthDate { get; set; }

        public bool IsActive { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public string InActiveDescription { get; set; }



    }
}
