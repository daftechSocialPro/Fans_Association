using tmretApi.Data;
using tmretApi.Entities;

namespace tmretApi.Services.Season
{
    public class SeasonRepository : ISeasonRepository
    {

        private readonly ApplicationDbContext _context;
        public SeasonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(tmretApi.Entities.Season season)
        {
            try
            {

                await _context.AddAsync(season);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        public List<tmretApi.Entities.Season> GetAll()
        {



            return _context.Seasons.ToList();
        }

        public async Task Update(tmretApi.Entities.Season season)
        {
            try
            {

                if (season.IsActive == true)
                {
                    var seas = _context.Seasons.ToList();

                    foreach (var se in seas)
                    {
                        se.IsActive = false; ;
                    }
                    _context.Seasons.UpdateRange(seas);
                    _context.SaveChanges();
                }

                var seasons = _context.Seasons.Find(season.ID);


                seasons.Name = season.Name;
                seasons.Year = season.Year;
                seasons.FromDate = season.FromDate;
                seasons.ToDate = season.ToDate;
                seasons.IsActive = season.IsActive;

                _context.Seasons.Update(seasons);
                await _context.SaveChangesAsync();


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }




        }



    }
}
