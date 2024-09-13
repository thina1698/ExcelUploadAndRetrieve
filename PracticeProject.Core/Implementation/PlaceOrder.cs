using Microsoft.EntityFrameworkCore;
using PracticeProject.Core.Interface;
using PracticeProject.Infra;
using PracticeProject.Infra.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject.Core.Implementation
{
    public class PlaceOrder : IPlaceOrder
    {
        private readonly PracticeDbContext _practiceDbContext;

        public PlaceOrder(PracticeDbContext practiceDbContext)
        {
            _practiceDbContext = practiceDbContext;
        }

        public string OrderPlacing(int customerId, int productId, int orderQuantity)
        {
            // Get the data from the database
            var product = _practiceDbContext.Product.Find(productId); //Instead of where

            if (product == null)
            {
                return "Product not found.";
            }

            // Check the stock is available
            if (product.Quantity < orderQuantity)
            {
                return "Insufficient stock available.";
            }

            // reduce the Quantity for every order
            product.Quantity = product.Quantity - orderQuantity;

            // For new ORDER
            var order = new Order
            {
                CustomerId = customerId,
                ProductId = productId,
                Quantity = orderQuantity,
                OrderedDate = DateTime.Now,
            };

            _practiceDbContext.Order.Add(order);
            _practiceDbContext.SaveChanges();

            return "Order placed successfully.";
        }

    }
}
