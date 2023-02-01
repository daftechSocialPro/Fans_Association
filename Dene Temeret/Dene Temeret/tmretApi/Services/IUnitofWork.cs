

using MahberApi.Services.TemretExecutive;
using tmretApi.Services.Advert;
using tmretApi.Services.Dashboard;

using tmretApi.Services.TemretExecutive;

namespace tmretApi.Services
{
    public interface IUnitOfWork
    {
        INewsRepository newsRepository { get; }
        IUserRepository userRepository { get; }

        IMahberRepository mahberRepository { get; }

        IMemberRepository memberRepository { get; }

        IMatchRepository matchRepository { get; }

        ITemretExecutiveRepostiory temretExecutiveRepostiory { get; }
        IMahberExecutiveRepostiory mahberExecutiveRepostiory { get; }
        IAdvertRepository advertRepository { get; }

        IDegafiSettingRepository degafiSettingRepository { get; }

        IDegafiRepostiory degafiRepostiory { get; }


        IDashboardRepository dashboardRepository { get; }

        ISeasonRepository seasonRepository { get; }

        ITeamRepository teamRepository { get; }

        IMatchWeekRepository matchWeekRepository { get; }

        IPlayerRepository playerRepository { get; }


        Task SaveChanges();
    }
}
