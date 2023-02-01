using tmretApi.Entities;
using tmretApi.Dtos;

namespace tmretApi.Services
{
    public interface IMahberRepository
    {

        User Create (MahberDto mahber);

        Task<DegafiMahber>  CreateMahber (DegafiMahber mahber);


        DegafiMahber  GetById (Guid mahberId);


        List<DegafiMahber> GetAll ();

        Task Update(DegafiMahber mahber2);

    }
}