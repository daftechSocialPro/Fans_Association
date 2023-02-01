using tmretApi.Entities;

namespace tmretApi.Services.TemretExecutive
{
    public interface ITemretExecutiveRepostiory 
    {

        Task Create(TmretExecutives executives);

        Task Update(TmretExecutives executives);

        Task<List<TmretExecutives>> GetAll();
    }
}
