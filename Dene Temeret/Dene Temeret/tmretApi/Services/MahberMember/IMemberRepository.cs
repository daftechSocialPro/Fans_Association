using tmretApi.Entities;
namespace tmretApi.Services
{
    public interface IMemberRepository 
    {
         Task Create(DegafiMahberExecutive Member);
         Task<List<DegafiMahberExecutive>> getAll(Guid DegafiMahberId);
        //Task Update(Member entity);

        // Task<List<Member>> getAll(MemberType MemberType);
        // Task<FileResponse> GetMemberPhoto(string MemberId);
        // Task<FileResponse> GetMemberPhotoBytes(string MemberId);
        
    }
}