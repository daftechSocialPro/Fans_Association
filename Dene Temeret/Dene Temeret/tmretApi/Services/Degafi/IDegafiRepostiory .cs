using tmretApi.Dtos;
using tmretApi.Entities;

namespace MahberApi.Services.TemretExecutive
{
    public interface IDegafiRepostiory 
    {

        Task Create(Degafi degafi);

        Task CreateFromExcel(FansFromExcel fansFromExcel);

        Task Update(Degafi degafi);

        Task<List<Degafi>> GetAll(Guid mahberId);

        Task CreatePayment(Payment Payment);
        Task<List<Payment>> GetAllPaymentsByid(Guid fanId);
      
        string getDate();
        double getPenality(string startDate, Guid degafiId);


    }
}
