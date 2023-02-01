using tmretApi.Entities;
namespace tmretApi.Services
{
    public interface INewsRepository 
    {
         Task Create(News News);
        //Task Update(News entity);

        Task<List<News>> getAll(NewsType newsType);
        Task<FileResponse> GetNewsPhoto(string newsId);
        Task<FileResponse> GetNewsPhotoBytes(string newsId);
        Task Update(News news);


    }
}
