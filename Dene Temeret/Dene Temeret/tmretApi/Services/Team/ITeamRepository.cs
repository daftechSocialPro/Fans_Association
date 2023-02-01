using tmretApi.Entities;

namespace tmretApi.Services
{
    public interface ITeamRepository
    {

        Task Create(Team team);
        Task Update(Team team);
        List<Team> GetBySeason(Guid SeasonId);
        List<TeamView> GetAllTable();
        List<Team> GetAll();

    }
}
