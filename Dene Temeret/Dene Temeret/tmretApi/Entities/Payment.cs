using System.ComponentModel.DataAnnotations.Schema;

namespace tmretApi.Entities
{
    public class Payment :Common
    {

        public Guid DegafiId { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        [NotMapped]

        public int month { get; set; }

        public float MoneyPayed { get; set; }


        public float Penality { get; set; }

    }


}
