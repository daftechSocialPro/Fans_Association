using System.ComponentModel.DataAnnotations.Schema;

namespace tmretApi.Entities{


    public class News :Common {

        
        public string title { get; set; }
        public string  subTitle {get;set;}
        public string img { get; set; }
         [NotMapped]
        public IFormFile Photo { get; set; }

        public string description { get; set; }
        public bool isHeadLine { get; set; }

        public bool isApproved {get;set ;}

        public virtual User user { get; set; }

        public Guid userId { get; set; }

       

        public NewsType NewsType {get;set;}
    }

    public enum NewsType{
        News,
        Videos
    }
}