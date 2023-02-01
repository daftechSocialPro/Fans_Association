using tmretApi.Data;
using tmretApi.Entities;
using tmretApi.Helpers;
using tmretApi.Migrations;

namespace tmretApi.Services
{
    public class MatchWeekRepository : IMatchWeekRepository
    {
        private readonly ApplicationDbContext _context;
        public MatchWeekRepository(ApplicationDbContext context)
        {
            _context = context;

        }


        public async Task Create(MatchWeek matchWeek)
        {
            try
            {

                if (matchWeek.isMatchWeek)
                {
                    var machweeks = _context.MatchWeeks.ToList();

                    foreach (var ma in machweeks)
                    {
                        ma.isMatchWeek = false;
                    }

                    _context.MatchWeeks.UpdateRange(machweeks);
                }

                await _context.MatchWeeks.AddAsync(matchWeek);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }

        }


        public List<MatchWeek> GetAll()
        {
            return _context.MatchWeeks.OrderBy(x=>x.matchWeek).ToList();
        }

        public async Task Update(MatchWeek matchWeek)
        {
            try
            {

                if (matchWeek.isMatchWeek)
                {
                    var machweeks = _context.MatchWeeks.ToList();

                    foreach (var ma in machweeks)
                    {
                        ma.isMatchWeek = false;
                    }

                    _context.MatchWeeks.UpdateRange(machweeks);
                }




                var match = _context.MatchWeeks.Find(matchWeek.ID);

                match.isMatchWeek = matchWeek.isMatchWeek;
    

               

                 _context.MatchWeeks.Update(match);
                await _context.SaveChangesAsync();


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }




        }


        public async Task Delete(Guid matchweekId)
        {
            try
            {
                var match = await _context.MatchWeeks.FindAsync(matchweekId);
                _context.MatchWeeks.Remove(match);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
