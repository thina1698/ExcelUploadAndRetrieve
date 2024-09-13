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
    public class OrdersCountByMonth(PracticeDbContext practiceDbContext) : IOrdersCountByMonth
    {
        public List<OrderCountResponseModel> GetOrderCount(int year)
        {
            var orderCount = practiceDbContext.Order
                            .Where(t => t.OrderedDate.Year == year)
                            .GroupBy(t => t.OrderedDate.Month)
                            .Select(t => new OrderCountResponseModel
                            {
                                Month = t.Key,
                                Count = t.Count()
                            }).ToList();
            return orderCount;

            //var orderCount = new List<OrderCountResponseModel>();
            //for (int i = 1; i <= 12; i++)
            //{
            //    var count = practiceDbContext.Order
            //                .Count(t => t.OrderedDate.Year == year && t.OrderedDate.Month == i);
            //    orderCount.Add(new OrderCountResponseModel
            //    {
            //        Month = i,
            //        Count = count
            //    });
            //}
        }
    }
}
