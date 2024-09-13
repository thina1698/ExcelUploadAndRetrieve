using Microsoft.EntityFrameworkCore;
using PracticeProject.Core.DashboardClasses.Interface;
using PracticeProject.Infra;
using PracticeProject.Model.CustomerAndProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject.Core.CustomerAndProducts.Implementation
{
    public class DashBoardInformation(ICustomerCountByMonth _customerCountByMonth,
                                      IOrdersCountByMonth _ordersCountByMonth,
                                      ITopSellingProducts _topSellingProducts,
                                      ITopFiveProductByRating _topFiveProductByRating) : IDashBoardInformation
    {
        public DashboardResponseModel GetDashBoardDetails(int year)
        {
            var customerCountResult = _customerCountByMonth.GetCustomerCount(year);
            var orderCountResult = _ordersCountByMonth.GetOrderCount(year);
            var topSellingProductResult = _topSellingProducts.GetTopFiveSellingProduct(year);
            var topFiveRatedProductResult = _topFiveProductByRating.GetTopFiveRatedProduct(year);

            return new DashboardResponseModel
            {
                CustomerCountResponseModel = customerCountResult,
                OrderCountResponseModel = orderCountResult,
                TopSellingProductResponseModel = topSellingProductResult,
                TopProductByRatingResponseModel = topFiveRatedProductResult,
            };
        }
    }
}
