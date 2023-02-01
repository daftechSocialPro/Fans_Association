

using Microsoft.EntityFrameworkCore;
using tmretApi.Data;
using tmretApi.Entities;
using tmretApi.Helpers;

namespace tmretApi.Services.Player
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly ApplicationDbContext _context;
        public PlayerRepository(ApplicationDbContext context)
        {
            _context = context;


        }


        public List<tmretApi.Entities.Player> GetById(Guid teamId)
        {


            return _context.Players.Where(x => x.CurrentTeamId == teamId).ToList();
        }


        public string getPlayerName (Guid playerId)
        {

            var player = _context.Players.Find(playerId);

            if (player != null)
            {
                return player.FullName;
            }
            return "";
        }

        public List<GoalView> getGolasAndAssist()
        {



            var player = from p in _context.Players.Include(x => x.MacthStats)
                         join
                         t in _context.Teams on p.CurrentTeamId equals t.ID
                         select new { p, t };

            var goalViews = new List<GoalView>();

           

            foreach (var goal in player)
            {

                var goalview = new GoalView

                {
                    UserPhoto = goal.p.PlayerImage,
                    Name = goal.p.FullName,
                    Club = goal.t.Name,
                    ClubLogo= goal.t.Logo,
                    Position = goal.p.Postition.ToString(),
                    Goals = goal.p.MacthStats.Count(x => x.PlayerDid == PlayerDid.Goal),
                    Assist = goal.p.MacthStats.Count(x => x.PlayerDid == PlayerDid.Assist),
                    Nationality= goal.p.Nationality
                    

                };
                goalViews.Add(goalview);

            }



            return goalViews;

        }



        public async Task Create(tmretApi.Entities.Player player)
        {
            try
            {

                if (player.Photo != null)
                {
                    var image = player.Photo;
                    var photoinfo = new FileInfo(Path.GetFileName(image.FileName));
                    var fileExtension = photoinfo.Extension;
                    var savingPath = Path.Combine(Path.GetDirectoryName("./Assets/Player_upload_photo/"), player.ID.ToString() + fileExtension);



                    await image.SaveAsAsync(savingPath);
                    player.PlayerImage = "Assets/Player_upload_photo/" + player.ID + fileExtension;
                }


                await _context.Players.AddAsync(player);
                await _context.SaveChangesAsync();


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }



        public async Task Update(tmretApi.Entities.Player player)
        {
            try
            {

                var players = _context.Players.Find(player.ID);

                players.FullName = player.FullName;
                players.Postition = player.Postition;
                players.BirthDate = player.BirthDate;
                players.Description = player.Description;
                players.Height = player.Height;
                players.Weight = player.Weight;




                if (player.Photo != null)
                {
                    var image = player.Photo;
                    var photoinfo = new FileInfo(Path.GetFileName(image.FileName));
                    var fileExtension = photoinfo.Extension;
                    var savingPath = Path.Combine(Path.GetDirectoryName("./Assets/Player_upload_photo/"), player.ID.ToString() + fileExtension);

                    if (File.Exists(savingPath))
                    {
                        File.Delete(savingPath);
                    }

                    await image.SaveAsAsync(savingPath);
                    players.PlayerImage = "Assets/Player_upload_photo/" + player.ID + fileExtension;
                }


                _context.Players.Update(players);
                _context.SaveChanges();


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }




        }


        public class GoalView
        {
            public string UserPhoto { get; set; }
            public string Name { get; set; }
            public string Position { get; set; }

            public string Club { get; set; }
            public string ClubLogo { get; set; }
            public int Goals { get; set; }

            public int Assist { get; set; }

            public string Nationality { get; set; }


        }

    }
}
