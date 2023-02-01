using Microsoft.EntityFrameworkCore;
using tmretApi.Entities;
using tmretApi.Helpers;
using System.Globalization;
using tmretApi.Data;

namespace tmretApi.Services
{
    public class MemberRepository : IMemberRepository
    {
        private readonly ApplicationDbContext _db;


        public MemberRepository(ApplicationDbContext db)
        {
            _db = db;
        }


            public async Task Create(DegafiMahberExecutive Member)
        {
            try
            {

               



                if (Member.Photo != null)
                {
                    var image = Member.Photo;
                    var photoinfo = new FileInfo(Path.GetFileName(image.FileName));
                    var fileExtension = photoinfo.Extension;
                    var savingPath =Path.Combine(Path.GetDirectoryName("./Assets/Member_upload_photo/"), Member.ID.ToString() + fileExtension);


                    
                    await image.SaveAsAsync(savingPath);
                    Member.photo = "Assets/Member_upload_photo/"+ Member.ID + fileExtension;
                }



                await _db.AddAsync(Member);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       public async Task<List<DegafiMahberExecutive>> getAll(Guid DegafiMahberId)
        {

            List<DegafiMahberExecutive> members = await _db.DegafiMahberMembers.Where(x=>x.DegafiMahberId==DegafiMahberId).ToListAsync();
            return members;
        }
    }

}