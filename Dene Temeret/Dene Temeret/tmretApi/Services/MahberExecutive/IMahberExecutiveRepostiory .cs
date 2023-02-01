using tmretApi.Entities;

namespace MahberApi.Services.TemretExecutive
{
    public interface IMahberExecutiveRepostiory 
    {

        Task Create(MahberExecutives executives);

        Task Update(MahberExecutives executives);

        Task<List<MahberExecutives>> GetAll(Guid mahberId);
    }
}
