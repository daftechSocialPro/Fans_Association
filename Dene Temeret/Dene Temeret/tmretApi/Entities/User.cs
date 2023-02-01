using System.ComponentModel;
using System.Text.Json.Serialization;

namespace tmretApi.Entities
{


    public class User :Common
    {
         

    
        public string fullName { get; set; }

        public string email { get; set; }

        [DefaultValue(true)]
        public bool isActive { get; set; }

        public UserRole userRole { get; set; }

        [JsonIgnore] public string password { get; set; }



    }

    public enum UserRole
    {
        Tmret,
        Mahber,
        Encoder
    }
}