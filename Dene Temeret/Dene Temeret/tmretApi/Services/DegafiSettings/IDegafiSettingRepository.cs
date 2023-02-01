
using tmretApi.Entities;
namespace tmretApi.Services{


    public interface IDegafiSettingRepository {


        Task Create(DegafiSetting desetting);
        Task Create(IdTemplate idTemplate);
        Task Update(IdTemplate idTemplate);
        Task Update(DegafiSetting desetting);
        
        IdTemplate getTemplateById(Guid mahberId);
        List<DegafiSetting> GetAll(Guid userId);
        Task Delete(Guid advertId);
    }
}