using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using tmretApi.Data;
using tmretApi.Entities;
using tmretApi.Helpers;

namespace tmretApi.Services.TemretExecutive
{
    public class TmretExecutiveRepository : ITemretExecutiveRepostiory
    {

        private readonly ApplicationDbContext _context;
        public TmretExecutiveRepository(ApplicationDbContext context)
        {
            _context = context;


        }


        public async Task Create(TmretExecutives executives)
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


                await _context.AddAsync(executives);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        public async Task<List<TmretExecutives>> GetAll()
        {
            


            return await _context.TmretExecutives.Include(x => x.Temret).ToListAsync();
        }

        public async Task Update(TmretExecutives executives)
        {
            try
            {

                var tmretexec = _context.TmretExecutives.Find(executives.ID);

                tmretexec.Name = executives.Name;
                tmretexec.Position = executives.Position;
                tmretexec.BirthDate =executives.BirthDate;
                tmretexec.FromDate = executives.FromDate;
                tmretexec.ToDate = executives.ToDate;
                tmretexec.Description = executives.Description;
                tmretexec.IsActive = executives.IsActive;


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
                    tmretexec.UserPhoto = "Assets/Executives_upload_photo/" + executives.ID + fileExtension;
                }


                _context.TmretExecutives.Update(tmretexec);
                _context.SaveChanges();


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }




        }




    }
}
