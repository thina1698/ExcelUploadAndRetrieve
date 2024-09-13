using PracticeProject.Model.CustomerAndProducts;

namespace PracticeProject.Core.DashboardClasses.Interface
{
    public interface IOrdersCountByMonth
    {
        List<OrderCountResponseModel> GetOrderCount(int year);
    }
}