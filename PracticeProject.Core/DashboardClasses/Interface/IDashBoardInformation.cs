using PracticeProject.Model.CustomerAndProducts;

namespace PracticeProject.Core.DashboardClasses.Interface
{
    public interface IDashBoardInformation
    {
        DashboardResponseModel GetDashBoardDetails(int year);
    }
}