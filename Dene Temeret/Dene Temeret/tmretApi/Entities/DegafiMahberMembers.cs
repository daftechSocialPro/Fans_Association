using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace tmretApi.Entities
{


    public class DegafiMahberExecutive : Common

    {
        public virtual DegafiMahber DegafiMahber { get; set; }
        public Guid DegafiMahberId { get; set; }
        public string name { get; set; }
        public string position { get; set; }

        public string photo { get; set; }

        [NotMapped]
        [JsonIgnore] public IFormFile Photo { get; set; }
        public string Description { get; set; }

        public string birthDate { get; set; }

        public bool isActive { get; set; }

        public string fromDate { get; set; }

        public string toDate { get; set; }

        public string inActiveDescription { get; set; }


    }
}