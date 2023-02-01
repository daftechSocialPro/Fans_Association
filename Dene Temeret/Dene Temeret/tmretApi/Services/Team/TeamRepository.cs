using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations.Schema;

using tmretApi.Data;
using tmretApi.Entities;
using tmretApi.Helpers;

namespace tmretApi.Services
{
    public class TeamRepository : ITeamRepository
    {
        private readonly ApplicationDbContext _context;
        public TeamRepository(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task Create(Team team)
        {
            try
            {
                team.ID= Guid.NewGuid();
                if (team.Photo != null)
                {
                    var image = team.Photo;
                    var photoinfo = new FileInfo(Path.GetFileName(image.FileName));
                    var fileExtension = photoinfo.Extension;
                    var savingPath = Path.Combine(Path.GetDirectoryName("./Assets/Team_upload_photo/"), team.ID.ToString() + fileExtension);
                  


                    await image.SaveAsAsync(savingPath);
                    team.Logo = "Assets/Team_upload_photo/" + team.ID + fileExtension;
                }



                await _context.AddAsync(team);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


     public   List<Team> GetAll()
        {
            return _context.Teams.Include(x => x.Season).ToList();
        }


        public List<TeamView> GetAllTable()
        {


            var teams = _context.Teams.Include(x => x.Season);
            var matches = _context.Matches.Where(x=>x.Game!=Game.NotStarted).ToList();


            var Teams = new List<TeamView>();

            foreach (var te in teams)
            {

                int Win = matches.Count(y => y.Team1Score > y.Team2Score && y.Team1Id ==te.ID) + matches.Count(y => y.Team2Score > y.Team1Score && y.Team2Id == te.ID);
                int Draw = matches.Count(y => y.Team1Score == y.Team2Score && y.Team1Id == te.ID) + matches.Count(y => y.Team2Score == y.Team1Score && y.Team2Id == te.ID);
                int Lost = matches.Count(y => y.Team1Score < y.Team2Score && y.Team1Id == te.ID) + matches.Count(y => y.Team2Score < y.Team1Score&& y.Team2Id == te.ID);
                int GF = matches.Where(x => x.Team1Id == te.ID).Sum(y => y.Team1Score) + matches.Where(x => x.Team2Id == te.ID).Sum(y => y.Team2Score);
                int GA = matches.Where(x => x.Team1Id == te.ID).Sum(y => y.Team2Score) + matches.Where(x => x.Team2Id == te.ID).Sum(y => y.Team1Score);


                var team = new TeamView
                {
                    ID = te.ID,
                    Logo = te.Logo,
                    Name = te.Name,
                    Shortname = te.ShortName,
                    SeasonName = te.Season.Name,
                    Mp=Win+Draw+Lost,
                    Win= Win,
                    Draw= Draw,
                    Lost= Lost,
                    GF=GF,
                    GA=GA,
                    GD=GF-GA,
                    pts= 3*Win + Draw                   

                };

                Teams.Add(team);
            }








            return Teams.OrderByDescending(x=>x.pts).ThenByDescending(x=>x.GD).ToList();
        }
        public List<Team> GetBySeason(Guid seasonId)
        {
            return _context.Teams.Where(x => x.SeasonId == seasonId).ToList();
        }

        public async Task Update(Team team)
        {
            try
            {
                var teams = _context.Teams.Find(team.ID);
                if (teams != null)
                {
                    teams.Name = team.Name;
                    teams.ShortName = team.ShortName;
                    teams.SeasonId = team.SeasonId;

                    if (team.Photo != null)
                    {
                        var image = team.Photo;
                        var photoinfo = new FileInfo(Path.GetFileName(image.FileName));
                        var fileExtension = photoinfo.Extension;
                        var savingPath = Path.Combine(Path.GetDirectoryName("./Assets/Team_upload_photo/"), team.ID.ToString() + fileExtension);

                        if (File.Exists(savingPath))
                        {
                            File.Delete(savingPath);
                        }

                        await image.SaveAsAsync(savingPath);
                        teams.Logo = "Assets/Team_upload_photo/" + team.ID + fileExtension;
                    }
                    _context.Teams.Update(teams);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }

    public class TeamView
    {
        public Guid ID { get; set; }
        public string Logo { get; set; }

        public string Name { get; set; }

        public string Shortname { get; set; }

        public string SeasonName { get; set; }

        public int Mp { get; set; }

        public int Win { get; set; }

        public int Draw { get; set; }

        public int Lost { get; set; }

        public int GF { get; set; }

        public int GA { get; set; }

        public int GD { get; set; }

        public int pts { get; set; }

    }
}
