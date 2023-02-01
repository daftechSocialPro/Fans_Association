using tmretApi.Entities;


namespace tmretApi.Services
{
    public interface IPlayerRepository
    {

        List<Player.PlayerRepository.GoalView> getGolasAndAssist();
        Task Create( tmretApi.Entities.Player player);

        List<tmretApi.Entities.Player> GetById(Guid teamId ); 

        Task Update( tmretApi.Entities.Player player);
        string getPlayerName(Guid playerId);




    }
}
