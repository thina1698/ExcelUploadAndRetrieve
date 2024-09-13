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
    public class TopFiveProductByRating(PracticeDbContext practiceDbContext) : ITopFiveProductByRating
    {
        public List<TopProductByRatingResponseModel> GetTopFiveRatedProduct(int year)
        {
            var topProductsByRating = practiceDbContext.Rating
                                        .Include(t => t.Product)
                                        .Where(t => t.Product.CreatedDateTime.Year == year)
                                        .GroupBy(t => t.Product)    
                                        .OrderByDescending(t => t.Average(t => t.ProductRating))
                                        .Take(5)
                                        .Select(t => new TopProductByRatingResponseModel
                                        {
                                            ProductId = t.Key.ProductId,
                                            ProductName = t.Key.ProductName,    
                                            ProductRating = t.Average(t => t.ProductRating),
                                        }).ToList();
            return topProductsByRating;
        }
    }
}
