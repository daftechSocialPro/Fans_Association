
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using tmretApi.Data;
using tmretApi.Entities;

namespace tmretApi.Services.Dashboard
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly ApplicationDbContext _context;
        public DashboardRepository(ApplicationDbContext context)
        {
            _context = context;

        }


        public DashboardWidget GetAll(Guid userId)
        {

            var user = _context.Users.Find(userId);

            if (user.userRole == Entities.UserRole.Tmret)
            {

                DashboardWidget u = new DashboardWidget
                {
                    numberOfNews = _context.News.Count(),
                    numberOfMahber = _context.DefafiMahbers.Count(),
                    numberOfExecutives = _context.TmretExecutives.Count(),
                    numberofdegafi = _context.Degafi.Count()
                };

                return u;
            }
            DashboardWidget k = new DashboardWidget
            {
                numberOfNews = _context.News.Count(),
                numberOfMahber = _context.DefafiMahbers.Count(),
                numberOfExecutives = _context.TmretExecutives.Count(),
                numberofdegafi = _context.Degafi.Count()
            };

            return k;


        }

        public List<DashboardTable> GetTable()
        {
            List<DashboardTable> tables = new List<DashboardTable>();

            var mahbers = _context.DefafiMahbers.Include(x => x.User).ToList();


            foreach (var mahber in mahbers)
            {
                var membersExecutives = _context.MahberExecutives.Include(x=>x.Mahber).Where(x => x.MahberId == mahber.ID).ToList();
                int numberOfDegafi = _context.Degafi.Where(x => x.MahberId == mahber.ID).Count();
                var user = _context.Users.Where(x => x.ID == mahber.UserId).FirstOrDefault();
                DashboardTable table = new DashboardTable
                {
                    Image = mahber.logo,
                    MahberName = user.fullName,
                    MahberAltName = mahber.name,
                    MahberExecutives = membersExecutives,
                    numberOfDegafi = numberOfDegafi,
                    establishedDate = mahber.establishedDate,
                    Website= mahber.websiteAdress

                };
                tables.Add(table);

            }



            return tables.OrderByDescending(x=>x.numberOfDegafi).ToList();

        }
    }


    public class DashboardWidget
    {
        public int numberOfNews { get; set; }
        public int numberOfMahber { get; set; }

        public int numberOfExecutives { get; set; }

        public int numberofdegafi { get; set; }
    }





    public class DashboardTable
    {

        public string Image { get; set; }
        public string MahberName { get; set; }
        public string MahberAltName { get; set; }

        public string Website { get; set; }

        public List<MahberExecutives> MahberExecutives { get; set; }

        public int numberOfDegafi { get; set; }

        public string establishedDate { get; set; }


    }
}
