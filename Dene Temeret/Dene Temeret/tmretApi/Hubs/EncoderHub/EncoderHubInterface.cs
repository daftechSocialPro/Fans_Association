using tmretApi.Entities;
using tmretApi.Services;
using static tmretApi.Services.Player.PlayerRepository;

namespace tmretApi.Hubs.EncoderHub{

    public interface IEncoderHubInterface {

        Task getMatch (List<Matches> matches);

        Task getNews (List<News> news );

        Task getTeams(homeUpdate result);

    }
}