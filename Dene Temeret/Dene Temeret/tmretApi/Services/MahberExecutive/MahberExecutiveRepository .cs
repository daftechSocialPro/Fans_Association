using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using tmretApi.Data;
using tmretApi.Entities;
using tmretApi.Helpers;

namespace MahberApi.Services.TemretExecutive
{
    public class MahberExecutiveRepository : IMahberExecutiveRepostiory
    {

        private readonly ApplicationDbContext _context;
        public MahberExecutiveRepository(ApplicationDbContext context)
        {
            _context = context;


        }


        public async Task Create(MahberExecutives executives)
        {
            try
            {

                if (executives.Photo != null)
                {
                    var image = executives.Photo;
                    var photoinfo = new FileInfo(Path.GetFileName(image.FileName));
                    var fileExtension = photoinfo.Extension;
                    var savingPath = Path.Combine(Path.GetDirectoryName("./Assets/Executives_upload_photo/"), executives.ID.ToString() + fileExtension);



                    await image.SaveAsAsync(savingPath);
                    executives.UserPhoto = "Assets/Executives_upload_photo/" + executives.ID + fileExtension;
                }


                await _context.MahberExecutives.AddAsync(executives);
               await _context.SaveChangesAsync();


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        public async Task<List<MahberExecutives>> GetAll(Guid mahberId)
        {
            


            return await _context.MahberExecutives.Include(x => x.Mahber).Where(x=>x.MahberId==mahberId).ToListAsync();
        }

        public async Task Update(MahberExecutives executives)
        {
            try
            {

                var Mahberexec = _context.MahberExecutives.Find(executives.ID);

                Mahberexec.Name = executives.Name;
                Mahberexec.Position = executives.Position;
                Mahberexec.BirthDate =executives.BirthDate;
                Mahberexec.FromDate = executives.FromDate;
                Mahberexec.ToDate = executives.ToDate;
                Mahberexec.Description = executives.Description;
                Mahberexec.IsActive = executives.IsActive;


                if (executives.Photo != null)
                {
                    var image = executives.Photo;
                    var photoinfo = new FileInfo(Path.GetFileName(image.FileName));
                    var fileExtension = photoinfo.Extension;
                    var savingPath = Path.Combine(Path.GetDirectoryName("./Assets/Executives_upload_photo/"), executives.ID.ToString() + fileExtension);

                    if (File.Exists(savingPath))
                    {
                        File.Delete(savingPath);
                    }

                    await image.SaveAsAsync(savingPath);
                    Mahberexec.UserPhoto = "Assets/Executives_upload_photo/" + executives.ID + fileExtension;
                }


                _context.MahberExecutives.Update(Mahberexec);
                _context.SaveChanges();


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }




        }




    }
}
