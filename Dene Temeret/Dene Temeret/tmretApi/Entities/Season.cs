namespace tmretApi.Entities
{
    public class Season : Common
    {

        public string Name { get; set; }

        public int Year { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public bool IsActive { get; set; }


    }
}
