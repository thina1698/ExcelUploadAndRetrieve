using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject.Model.CustomerAndProducts
{
    public class DashboardResponseModel
    {
        public List<CustomerCountResponseModel> CustomerCountResponseModel { get; set; }
        public List<OrderCountResponseModel> OrderCountResponseModel { get; set; }
        public List<TopSellingProductResponseModel> TopSellingProductResponseModel { get; set; }
        public List<TopProductByRatingResponseModel> TopProductByRatingResponseModel { get; set; }
    }
    public class CustomerCountResponseModel
    {
        public int Month { get; set; }
        public int Count { get; set; }
    }
    public class OrderCountResponseModel
    {
        public int Month { get; set; }
        public int Count { get; set; }
    }

    public class TopSellingProductResponseModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int TotalQuantitySold { get; set; }
    }

    public class TopProductByRatingResponseModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductRating {  get; set; }
    }
}
