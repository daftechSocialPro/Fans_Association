using tmretApi.Dtos;
using tmretApi.Data;
using tmretApi.Entities;
using tmretApi.Helpers;
using Microsoft.EntityFrameworkCore;
using tmretApi.Migrations;

namespace tmretApi.Services
{


    public class MatchRepository : IMatchRepository
    {

        private readonly ApplicationDbContext _context;
        public MatchRepository(ApplicationDbContext context)
        {
            _context = context;

        }




        public async Task Create(Matches Match)
        {
            try
            {
                _context.Add(Match);
                await _context.SaveChangesAsync();


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }



        public async Task<List<Matches>> GetMatches()
        {

            return await _context.Matches.Include(x => x.Team1).Include(x => x.Team2).Include(x => x.MatchWeek).Include(x => x.Seasons).Include(x => x.MacthStats).Where(x => x.MatchWeek.isMatchWeek && x.Seasons.IsActive).ToListAsync();
        }

      
        public List<Matches> GetByWeek(int gameWeek)
        {
            return _context.Matches.Where(m => m.MatchWeek.matchWeek == gameWeek).ToList();
        }

        public List<Matches> GetAll()
        {
            return _context.Matches.Include(x => x.Team1).Include(x=>x.MacthStats).Include(x => x.Team2).Include(x => x.MatchWeek).Include(x => x.Seasons).ToList();
        }


        public async Task ScoreUpdate(ScoreDto score)
        {
            try
            {
                var matches = _context.Matches.Find(score.matchId);

                if (matches != null)
                {
                    
                    if (Guid.Empty != score.playerId)
                    {
                        var matchStat = new MacthStats
                        {
                            ID = Guid.NewGuid(),
                            TeamId = score.teamId,
                            MatchId = score.matchId,
                            PlayerId = score.playerId,
                            PlayerDid = score.playerDid,
                            Minute = score.minute.ToString(),
                            createdAt = DateTime.UtcNow
                        };



                        var playerStat = new PlayerStats
                        {
                            ID = Guid.NewGuid(),
                            PlayerId = score.playerId,
                            TeamId = score.teamId,
                            createdAt = DateTime.UtcNow,
                            Minute = score.minute,
                            MatchId = score.matchId
                        };
                        _context.MacthStats.Add(matchStat);
                        switch (score.playerDid)
                        {
                            case PlayerDid.Goal:
                                playerStat.Goals += 1;
                                break;
                            case PlayerDid.Assist:
                                playerStat.Assists += 1;
                                break;
                            case PlayerDid.YellowCard:
                                playerStat.YellowCard += 1;                               
                                break;
                            case PlayerDid.RedCard:
                                playerStat.Goals += 1;
                                break;
                        }

                      
                        if (Guid.Empty != score.playerAssistId)
                        {
                            var matchStat2 = new MacthStats
                            {
                                ID = Guid.NewGuid(),
                                MatchId = score.matchId,
                                PlayerId = score.playerAssistId,
                                PlayerDid = PlayerDid.Assist,
                                Minute = score.minute.ToString(),
                                TeamId = score.teamId,
                                createdAt = DateTime.UtcNow
                            };
                            var playerStat2 = new PlayerStats
                            {
                                ID = Guid.NewGuid(),
                                PlayerId = score.playerAssistId,
                                TeamId = score.teamId,
                                createdAt = DateTime.UtcNow,
                                Minute = score.minute,
                                MatchId = score.matchId,
                                Assists =1
                            };


                           
                            _context.MacthStats.Add(matchStat2);
                            _context.PlayerStats.Add(playerStat2);

                        }


                        
                        _context.PlayerStats.Add(playerStat);
                    }

                    if (score.playerDid == PlayerDid.Goal)
                    {
                        if (matches.Team1Id == score.teamId)
                        {
                            matches.Team1Score += 1;
                        }
                        if (matches.Team2Id == score.teamId)
                        {
                            matches.Team2Score += 1;
                        }

                    }

                    matches.Game = score.Game;
                    _context.Matches.Update(matches);
                    await _context.SaveChangesAsync();

                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.InnerException.Message);
            }
        }


        public async Task Update(Matches match)
        {
            try
            {
                var meaches = _context.Matches.Find(match.ID);


                meaches.Team1Id = match.Team1Id;
                meaches.Team2Id = match.Team2Id;
                meaches.MatchDate = match.MatchDate;
                meaches.MatchWeekId = match.MatchWeekId;
                meaches.SeasonsId = match.SeasonsId;

                _context.Matches.Update(meaches);
                await _context.SaveChangesAsync();


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }



        public async Task Delete(Guid matchId)
        {
            try
            {
                var match = await _context.Matches.FindAsync(matchId);
                _context.Matches.Remove(match);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}