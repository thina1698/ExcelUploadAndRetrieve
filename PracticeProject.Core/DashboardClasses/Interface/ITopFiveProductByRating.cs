using PracticeProject.Model.CustomerAndProducts;

namespace PracticeProject.Core.DashboardClasses.Interface
{
    public interface ITopFiveProductByRating
    {
        List<TopProductByRatingResponseModel> GetTopFiveRatedProduct(int year);
    }
}