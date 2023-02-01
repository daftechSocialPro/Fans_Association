using tmretApi.Entities;

namespace tmretApi.Services
{
    public interface IMatchWeekRepository
    {
        Task Create(MatchWeek matchWeek); 
        
        List<MatchWeek> GetAll();

        Task Update(MatchWeek matchWeek);

        Task Delete(Guid matchWeekId);
    }
}
