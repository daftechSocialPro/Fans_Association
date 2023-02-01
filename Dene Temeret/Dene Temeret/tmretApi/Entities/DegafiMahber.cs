using System.ComponentModel.DataAnnotations.Schema;

namespace tmretApi.Entities
{


    public class DegafiMahber :Common
    {
        public string name { get; set; }
        public string websiteAdress { get; set; }
        public string establishedDate { get; set; }
        public string logo { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public string description { get; set; }
        public virtual User User { get; set; }
        public Guid UserId { get; set; }
        public List<MahberExecutives> MahberExecutives { get; set; }

    }
}