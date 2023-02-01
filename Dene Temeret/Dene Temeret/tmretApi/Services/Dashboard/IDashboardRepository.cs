namespace tmretApi.Services.Dashboard
{
    public interface IDashboardRepository
    {

        DashboardWidget GetAll(Guid userId);
        List<DashboardTable> GetTable();
    }
}
