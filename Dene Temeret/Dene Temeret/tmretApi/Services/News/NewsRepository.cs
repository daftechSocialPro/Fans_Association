
using Microsoft.EntityFrameworkCore;
using tmretApi.Entities;
using tmretApi.Helpers;
using System.Globalization;
using tmretApi.Data;

namespace tmretApi.Services
{
    public class NewsRepository : INewsRepository
    {
        private readonly ApplicationDbContext _db;


        public NewsRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public Task<FileResponse> GetNewsPhoto(string newsId)
        {
            try
            {

                string pathName = Path.Combine(Path.GetDirectoryName("./Assets/News_upload_photo/"), newsId);
                string dirName = Path.GetDirectoryName("./Assets/News_upload_photo/");
                string[] match = Directory.GetFiles(dirName);
                string ext = "";
                string type;
                foreach (string file in match)
                {
                    if (file.Contains(newsId))
                    {
                        ext = Path.GetExtension(file);
                        break;
                    }
                }
                FileInfo fi = new FileInfo(string.Concat(pathName, ext));
                type = FileHelpers.GetMimeType(ext);
                byte[] photoBytes = File.ReadAllBytes(fi.FullName);
                FileResponse res = new()
                {
                    File = photoBytes,
                    Type = type
                };

                return Task.FromResult(res);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<List<News>> getAll(NewsType newsType)
        {

            List<News> news = await _db.News.Include(x=>x.user).Where(n=>n.NewsType ==newsType).OrderByDescending(x=>x.createdAt).ToListAsync();




            return news;
        }
        public async Task Create(News news)
        {
            try
            {

               



                if (news.Photo != null)
                {

                    var image = news.Photo;
                    var photoinfo = new FileInfo(Path.GetFileName(image.FileName));
                    var fileExtension = photoinfo.Extension;
                    var savingPath =Path.Combine(Path.GetDirectoryName("./Assets/News_upload_photo/"), news.ID.ToString() + fileExtension);                    
                    await image.SaveAsAsync(savingPath);
                    news.img = "Assets/News_upload_photo/"+ news.ID + fileExtension;

                }



                await _db.AddAsync(news);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<FileResponse> GetNewsPhotoBytes(string newsId)
        {
            try
            {
                News news = await _db.News.FindAsync(newsId);
                string file = news.img;
                string ext = Path.GetExtension(file);
                string type;
                type = FileHelpers.GetMimeType(ext);
                byte[] fileBytes = File.ReadAllBytes(news.img);
                FileResponse res = new()
                {
                    File = fileBytes,
                    Type = type
                };

                return res;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public async Task Update(News news)
        {
            try
            {
                var newss = _db.News.Find(news.ID);

                if (newss != null)
                {
                    newss.title = news.title;
                    newss.subTitle = news.subTitle;
                    newss.description = news.description;
                    newss.description = news.description;
                    newss.updatedAt = DateTime.UtcNow;
                    newss.isHeadLine = news.isHeadLine;

                    if (news.isHeadLine)
                    {
                        var nes = _db.News.Where(x=>x.isHeadLine && x.ID!=news.ID).ToList();

                        foreach(var ne in nes){
                            ne.isHeadLine =  false;

                        }

                        _db.News.UpdateRange(nes);
                        _db.SaveChanges();

                    }



                    if (news.Photo != null)
                    {
                        var image = news.Photo;
                        var photoinfo = new FileInfo(Path.GetFileName(image.FileName));
                        var fileExtension = photoinfo.Extension;
                        var savingPath = Path.Combine(Path.GetDirectoryName("./Assets/News_upload_photo/"), news.ID.ToString() + fileExtension);

                        if (File.Exists(savingPath))
                        {
                            File.Delete(savingPath);
                        }

                        await image.SaveAsAsync(savingPath);
                        newss.img = "Assets/News_upload_photo/" + news.ID + fileExtension;
                    }


                    _db.News.Update(newss);
                    _db.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }




        }



    }
}

