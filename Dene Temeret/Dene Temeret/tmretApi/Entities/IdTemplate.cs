using System.ComponentModel.DataAnnotations.Schema;

namespace tmretApi.Entities
{
    public class IdTemplate : Common
    {

        public Guid MahberId { get; set; }

        public string HeaderAmharic { get; set; }

        public string HeaderEnglish { get; set; }

        public string Subtitle1 { get; set; }

        public string Subtitle2 { get; set; }

        public string Logo { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }

        public string BackgroundImage { get; set; }

        [NotMapped]
        public IFormFile Photo2 { get; set; }




        public string BackImage { get; set; }

        [NotMapped]
        public IFormFile Photo3 { get; set; }


        public string Address { get; set; }
        public string AddressAmharic { get; set; }


        [ForeignKey("IDtemplateId")]

        public ICollection<DegafiSetting> DegafiSettings { get; set; }





    }
}
