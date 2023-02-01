using tmretApi.Dtos;
using tmretApi.Data;
using tmretApi.Entities;
using tmretApi.Helpers;
using Microsoft.EntityFrameworkCore;

namespace tmretApi.Services
{


    public class MahberRepository : IMahberRepository
    {

        private readonly ApplicationDbContext _context;
        public MahberRepository(ApplicationDbContext context)
        {
            _context = context;

        }


        public User Create (MahberDto mahber){


                User user = new User ();


                return user ;


        }

          public async Task<DegafiMahber> CreateMahber(DegafiMahber mahber)
        {
            try
            {

               



                if (mahber.Photo != null)
                {
                    var image = mahber.Photo;
                    var photoinfo = new FileInfo(Path.GetFileName(image.FileName));
                    var fileExtension = photoinfo.Extension;
                    var savingPath =Path.Combine(Path.GetDirectoryName("./Assets/Mahber_Logo/"), mahber.ID.ToString() + fileExtension);


                    
                    await image.SaveAsAsync(savingPath);
                    mahber.logo = "Assets/Mahber_Logo/"+ mahber.ID + fileExtension;
                }



                await _context.AddAsync(mahber);
                return mahber;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



          public DegafiMahber GetById(Guid mahberId){


            return _context.DefafiMahbers.Where(dm=>dm.UserId==mahberId).FirstOrDefault();
          }
          
          public List<DegafiMahber> GetAll(){

              

            return _context.DefafiMahbers.Include(x=>x.MahberExecutives).ToList();
          }

        public async Task Update(DegafiMahber mahber2)
        {
            try
            {

                var mahber = _context.DefafiMahbers.Find(mahber2.ID);

                if (mahber != null)
                {
                    mahber.name = mahber2.name;
                    mahber.websiteAdress = mahber2.websiteAdress;
                    mahber.establishedDate = mahber2.establishedDate;
                    mahber.description = mahber2.description;
                    mahber.updatedAt = DateTime.UtcNow;



                    if (mahber2.Photo != null)
                    {
                        var image = mahber2.Photo;
                        var photoinfo = new FileInfo(Path.GetFileName(image.FileName));
                        var fileExtension = photoinfo.Extension;
                        var savingPath = Path.Combine(Path.GetDirectoryName("./Assets/Mahber_Logo/"), mahber.ID.ToString() + fileExtension);

                        if (File.Exists(savingPath))
                        {
                            File.Delete(savingPath);
                        }

                        await image.SaveAsAsync(savingPath);
                        mahber.logo = "Assets/Mahber_Logo/" + mahber.ID + fileExtension;
                    }


                    _context.DefafiMahbers.Update(mahber);
                    _context.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }




        }



    }
}