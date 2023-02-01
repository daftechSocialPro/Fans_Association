

namespace tmretApi.Entities
{


    public class DegafiSetting : Common
    {

        public Guid IDtemplateId { get; set; }

        public string Name { get; set; }

        public string AmharicName { get; set; }

        public float Payment { get; set; } //change to payment 

        public bool HasPenality { get; set; }

        public float PenalityAmount { get; set; }

        public int IncreasesEvery { get; set; }

        public float MultiplyAmount { get; set; }

        public string Description { get; set; }

        public string Color { get; set; }

        public string IdInitial { get; set; }

        public string StartFrom { get; set; }

        public virtual DegafiMahber Mahber { get; set; }
        public Guid MahberId { get; set; }


    }


   

}