using MahberApi.Services.TemretExecutive;
using tmretApi.Data;
using tmretApi.Services.Advert;
using tmretApi.Services.Dashboard;
using tmretApi.Services.Player;
using tmretApi.Services.Season;
using tmretApi.Services.TemretExecutive;

namespace tmretApi.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            newsRepository = new NewsRepository(db);
            userRepository = new UserRepository(db);
            mahberRepository = new MahberRepository(db);
            memberRepository = new MemberRepository(db);
            matchRepository =new MatchRepository(db);
            temretExecutiveRepostiory = new TmretExecutiveRepository(db);
            advertRepository = new AdvertRepository(db);
            degafiSettingRepository= new DegafiSettingRepository(db);
            mahberExecutiveRepostiory = new MahberExecutiveRepository(db);
            degafiRepostiory =new DegafiRepository(db);
            dashboardRepository = new DashboardRepository(db);
            seasonRepository = new SeasonRepository(db);
            teamRepository = new TeamRepository(db);
            matchWeekRepository = new MatchWeekRepository(db);
            playerRepository = new PlayerRepository(db);

        }
        public INewsRepository newsRepository { get; private set; }
        public IUserRepository userRepository {get;set;}

        public IMahberRepository mahberRepository {get;set;}

        public IMemberRepository memberRepository {get;set;}
        public IMatchRepository matchRepository{get;set;}

        public ITemretExecutiveRepostiory temretExecutiveRepostiory { get; set; }

        public IAdvertRepository advertRepository {get;set;}
    
        public IDegafiSettingRepository degafiSettingRepository{ get;set; }

        public IMahberExecutiveRepostiory mahberExecutiveRepostiory  { get; set; }

        public IDegafiRepostiory degafiRepostiory { get; set; }

        public IDashboardRepository dashboardRepository { get; set; }

        public ISeasonRepository seasonRepository { get; set; }


        public ITeamRepository teamRepository { get; set; }


        public IMatchWeekRepository matchWeekRepository { get; set; }


        public IPlayerRepository playerRepository { get; set; } 
        public async Task SaveChanges()
        {
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

