
using Microsoft.EntityFrameworkCore;
using tmretApi.Data;
using tmretApi.Entities;
using tmretApi.Helpers;

namespace tmretApi.Services
{


    public class DegafiSettingRepository : IDegafiSettingRepository
    {

        private readonly ApplicationDbContext _context;
        public DegafiSettingRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task Create(DegafiSetting desetting)
        {
            try
            {




                await _context.DegafiSettings.AddAsync(desetting);
                _context.SaveChanges();


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public async Task Create(IdTemplate idTemplate)
        {
            try
            {
                var user = await _context.Users.FindAsync(idTemplate.createdBy);

                if (user != null)
                {

                    var mahber =  _context.DefafiMahbers.Where(x => x.UserId == user.ID).FirstOrDefault();
                    idTemplate.MahberId = mahber.ID;

                    if (idTemplate.Photo != null)
                    {
                        var image = idTemplate.Photo;
                        var photoinfo = new FileInfo(Path.GetFileName(image.FileName));
                        var fileExtension = photoinfo.Extension;
                        var savingPath = Path.Combine(Path.GetDirectoryName("./Assets/Id_upload_photo/"), idTemplate.ID.ToString() + fileExtension);



                        await image.SaveAsAsync(savingPath);
                        idTemplate.BackgroundImage = "Assets/Id_upload_photo/" + idTemplate.ID + fileExtension;
                    }


                    if (idTemplate.Photo2 != null)
                    {
                        var image = idTemplate.Photo2;
                        var photoinfo = new FileInfo(Path.GetFileName(image.FileName));
                        var fileExtension = photoinfo.Extension;
                        var savingPath = Path.Combine(Path.GetDirectoryName("./Assets/Id_upload_photo/"), idTemplate.ID.ToString() + fileExtension);



                        await image.SaveAsAsync(savingPath);
                        idTemplate.Logo = "Assets/Id_upload_photo/" + idTemplate.ID+"bg" + fileExtension;
                    }


                    if (idTemplate.Photo3 != null)
                    {
                        var image = idTemplate.Photo3;
                        var photoinfo = new FileInfo(Path.GetFileName(image.FileName));
                        var fileExtension = photoinfo.Extension;
                        var savingPath = Path.Combine(Path.GetDirectoryName("./Assets/Id_upload_photo/"), idTemplate.ID.ToString() + "back" + fileExtension);



                        await image.SaveAsAsync(savingPath);
                        idTemplate.BackImage = "Assets/Id_upload_photo/" + idTemplate.ID + "back" + fileExtension;
                    }




                }

                await _context.IdTemplates.AddAsync(idTemplate);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public async Task Update (IdTemplate idTemplate)
        {


            try
            {

                var template = _context.IdTemplates.Find(idTemplate.ID);

                template.HeaderAmharic = idTemplate.HeaderAmharic;
                template.HeaderEnglish = idTemplate.HeaderEnglish;
                template.Subtitle1 = idTemplate.Subtitle1;
                template.Subtitle2 = idTemplate.Subtitle2;
                template.Address = idTemplate.Address;
                template.AddressAmharic = idTemplate.AddressAmharic;

                if (idTemplate.Photo != null)
                {
                    var image = idTemplate.Photo;
                    var photoinfo = new FileInfo(Path.GetFileName(image.FileName));
                    var fileExtension = photoinfo.Extension;
                    var savingPath = Path.Combine(Path.GetDirectoryName("./Assets/Id_upload_photo/"), idTemplate.ID.ToString() + "bg"  + fileExtension);



                    await image.SaveAsAsync(savingPath);
                    template.BackgroundImage = "Assets/Id_upload_photo/" + idTemplate.ID +"bg"+ fileExtension;
                }

                if (idTemplate.Photo2 != null)
                {
                    var image = idTemplate.Photo2;
                    var photoinfo = new FileInfo(Path.GetFileName(image.FileName));
                    var fileExtension = photoinfo.Extension;
                    var savingPath = Path.Combine(Path.GetDirectoryName("./Assets/Id_upload_photo/"), idTemplate.ID.ToString() + fileExtension);



                    await image.SaveAsAsync(savingPath);
                    template.Logo = "Assets/Id_upload_photo/" + idTemplate.ID  + fileExtension;
                }

                if (idTemplate.Photo3 != null)
                {
                    var image = idTemplate.Photo3;
                    var photoinfo = new FileInfo(Path.GetFileName(image.FileName));
                    var fileExtension = photoinfo.Extension;
                    var savingPath = Path.Combine(Path.GetDirectoryName("./Assets/Id_upload_photo/"), idTemplate.ID.ToString()  +"back"+ fileExtension);



                    await image.SaveAsAsync(savingPath);
                    template.BackImage = "Assets/Id_upload_photo/" + idTemplate.ID+"back" + fileExtension;
                }



               _context.IdTemplates.Update(template);
               await  _context.SaveChangesAsync();


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }




        }
        public IdTemplate getTemplateById(Guid mahberId)
        {

            return _context.IdTemplates.Include(x=>x.DegafiSettings).Where(x => x.MahberId == mahberId).FirstOrDefault();
        }
        public List<DegafiSetting> GetAll(Guid userId)
        {
           
            return _context.DegafiSettings.Where(x=>x.MahberId==userId).ToList();
        }
        public async Task Update(DegafiSetting desetting)
        {
            try
            {

                var dese = _context.DegafiSettings.Find(desetting.ID);

                dese.Name = desetting.Name;
                dese.AmharicName = desetting.AmharicName;               
                dese.Payment = desetting.Payment;
                dese.Description = desetting.Description;

                dese.HasPenality=  desetting.HasPenality;
                dese.PenalityAmount= desetting.PenalityAmount;
                dese.IncreasesEvery =   desetting.IncreasesEvery;
                dese.MultiplyAmount= desetting.MultiplyAmount;




                _context.DegafiSettings.Update(dese);
                await _context.SaveChangesAsync();


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }




        }
        public async Task Delete(Guid desettingId)
        {
            try
            {
                var dsetting = await _context.DegafiSettings.FindAsync(desettingId);
                _context.DegafiSettings.Remove(dsetting);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }

}
