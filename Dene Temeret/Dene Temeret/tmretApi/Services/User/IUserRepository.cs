using tmretApi.Entities;

namespace tmretApi.Services{



    public interface IUserRepository {


        User Create (User user );
        User GetByEmail (string email );

        User GetById (Guid id );

        List<MahberView> GetMahber ();
    }
}