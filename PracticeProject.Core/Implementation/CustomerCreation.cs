using PracticeProject.Core.Interface;
using PracticeProject.Infra;
using PracticeProject.Infra.Tables;
using PracticeProject.Model.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject.Core.Implementation
{
    public class CustomerCreation : ICustomerCreation
    {
        private readonly PracticeDbContext _practiceDbcontext;

        public CustomerCreation(PracticeDbContext practiceDbcontext)
        {
            _practiceDbcontext = practiceDbcontext;
        }
        public void CreateCustomer(CustomerRequestModel requestModel)
        {

            var customer = new Customer()
            {
                CustomerId = requestModel.CustomerId,
                CustomerName = requestModel.CustomerName,
                MobileNumber = requestModel.MobileNumber,
                Age = requestModel.Age,
                Address = requestModel.Address,
                CreatedDateTime =DateTime.Now
            };
            _practiceDbcontext.Customer.Add(customer);
            _practiceDbcontext.SaveChanges();
        }
    }
}
