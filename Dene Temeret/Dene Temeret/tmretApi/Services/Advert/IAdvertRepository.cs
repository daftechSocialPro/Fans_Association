using Microsoft.AspNetCore.Mvc;
using tmretApi.Entities;

namespace tmretApi.Services.Advert
{
    public interface IAdvertRepository
    {

        Task Create(Advertisement advert);

        Task Update(Advertisement advert);

        List<Advertisement> GetAll();
        Task Delete(Guid advertId);

    }
}
