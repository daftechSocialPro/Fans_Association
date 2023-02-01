using tmretApi.Entities;

namespace tmretApi.Services
{
    public interface ISeasonRepository
    {
       Task  Create(tmretApi.Entities.Season seasons);
        Task Update(tmretApi.Entities.Season season);
        List<tmretApi.Entities.Season> GetAll();

    }
}
