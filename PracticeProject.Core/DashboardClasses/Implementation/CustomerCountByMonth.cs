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
    public class CustomerCountByMonth(PracticeDbContext practiceDbContext) : ICustomerCountByMonth
    {
        public List<CustomerCountResponseModel> GetCustomerCount(int year)
        {
            var customerCount = practiceDbContext.Customer
                                .Where(t => t.CreatedDateTime.Year == year)
                                .GroupBy(t => t.CreatedDateTime.Month)
                                .Select(t => new CustomerCountResponseModel
                                {
                                    Month = t.Key,
                                    Count = t.Count()
                                }).ToList();

            return customerCount;
            //var customerCount = new List<CustomerCountResponseModel>();

            //for (int i = 1; i <= 12; i++)
            //{
            //    var count = practiceDbContext.Customer
            //                .Count(t => t.CreatedDateTime.Year == year && t.CreatedDateTime.Month == i);
            //    customerCount.Add(new CustomerCountResponseModel
            //    {
            //        Month = i,
            //        Count = count
            //    });
            //}
            //return customerCount;
        }
    }
}

