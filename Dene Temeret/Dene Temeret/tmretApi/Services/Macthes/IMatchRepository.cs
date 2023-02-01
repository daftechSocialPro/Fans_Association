using tmretApi.Dtos;
using tmretApi.Entities;


namespace tmretApi.Services
{
    public interface IMatchRepository
    {
        Task Create (Matches matches);
        List<Matches>  GetByWeek (int gameWeek);
        Task<List<Matches>> GetMatches();
        Task ScoreUpdate(ScoreDto score);
        Task Update(Matches match);
        Task Delete(Guid matchId);
        List<Matches> GetAll ();

    }
}