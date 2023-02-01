using tmretApi.Entities;
using tmretApi.Data;
using tmretApi.Helpers;
using Microsoft.EntityFrameworkCore;

namespace tmretApi.Services
{



    public class UserRepository : IUserRepository
    {

        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {

            _context = context;
        }

        public User Create(User user)
        {


            _context.Users.Add(user);
            _context.SaveChanges();

            return user;

        }

        public User GetByEmail(string email)
        {


            return _context.Users.FirstOrDefault(u => u.email == email);
        }

        public User GetById(Guid id)
        {

            return _context.Users.Find(id);
        }

        public List<MahberView> GetMahber()
        {


            var mahber = from ma in  _context.Users.Where(m=>m.userRole ==UserRole.Mahber)
            join dm in  _context.DefafiMahbers on ma.ID equals dm.UserId into Details
            from m in Details.DefaultIfEmpty()
            select new MahberView
            {
                ID = ma.ID,
                fullName = ma.fullName,
                email = ma.email,
                createdAt = ma.createdAt,
                isActive = ma.isActive,
                name = m.name,
                description = m.description,
                establishedDate = m.establishedDate,
                websiteAdress = m.websiteAdress,
                logo = m.logo,
            };     

            return  mahber.ToList();
        }



    }

    public class MahberView
    {

        public Guid ID { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }

        public DateTime createdAt { get; set; }
        public bool isActive { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string establishedDate { get; set; }

        public string logo { get; set; }

        public string websiteAdress { get; set; }
    }
}