using Microsoft.EntityFrameworkCore;
using PracticeProject.Core.Interface;
using PracticeProject.Infra;
using PracticeProject.Model.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject.Core.Implementation
{
    public class FetchOrderDetailsByDate : IFetchOrderDetailsByDate
    {
        private readonly PracticeDbContext _practiceDbContext;

        public FetchOrderDetailsByDate(PracticeDbContext practiceDbContext)
        {
            _practiceDbContext = practiceDbContext;
        }

        public List<OrderDetailsByDateModel> OrderInformationByDate(int customerId, DateTime fromDate, DateTime toDate)
        {
            var info = _practiceDbContext.Order
                        .Include(i => i.Customer)
                        .Include(i => i.Product)
                        .Where(i => i.CustomerId == customerId && i.OrderedDate >= fromDate && i.OrderedDate <= toDate)
                        .Select(s => new OrderDetailsByDateModel
                        {
                            CustomerName = s.Customer.CustomerName,
                            ProductName = s.Product.ProductName,
                            ProductPrice = s.Product.ProductPrice,
                            OrderDate = s.OrderedDate
                        }).ToList();

            return info;
        }
    }
}
