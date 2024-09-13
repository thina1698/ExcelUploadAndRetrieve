using Microsoft.EntityFrameworkCore;
using PracticeProject.Core.DashboardClasses.Interface;
using PracticeProject.Infra;
using PracticeProject.Model.CustomerAndProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject.Core.DashboardClasses.Implementation
{
    public class TopSellingProducts(PracticeDbContext practiceDbContext) : ITopSellingProducts
    {
        public List<TopSellingProductResponseModel> GetTopFiveSellingProduct(int year)
        {
            var productList = practiceDbContext.Order
                .Include(t => t.Product)
                .Where(t => t.OrderedDate.Year == year)
                .GroupBy(t => t.Product)
                .OrderByDescending(t => t.Sum(order => order.Quantity))
                .Take(5)
                .Select(t => new TopSellingProductResponseModel
                {
                    ProductId = t.Key.ProductId,
                    ProductName = t.Key.ProductName,
                    ProductPrice = t.Key.ProductPrice,
                    TotalQuantitySold = t.Sum(o => o.Quantity)
                })
                .ToList();

            return productList;
        }
    }
}
