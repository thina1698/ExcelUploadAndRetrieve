using PracticeProject.Model.CustomerAndProducts;

namespace PracticeProject.Core.DashboardClasses.Interface
{
    public interface ICustomerCountByMonth
    {
        List<CustomerCountResponseModel> GetCustomerCount(int year);
    }
}