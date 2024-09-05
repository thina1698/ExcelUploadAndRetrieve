using PracticeProject.Infra.Tables;
using PracticeProject.Infra;
using PracticeProject.Model.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticeProject.Core.Interface;

namespace PracticeProject.Core.Implementation
{
    public class ProductCreation : IProductCreation
    {
        private readonly PracticeDbContext _practiceDbcontext;

        public ProductCreation(PracticeDbContext practiceDbcontext)
        {
            _practiceDbcontext = practiceDbcontext;
        }
        public void CreateProductCustomer(ProductRequestModel requestModel)
        {

            var product = new Product()
            {
                ProductId = requestModel.ProductId,
                ProductName = requestModel.ProductName,
            };
            _practiceDbcontext.Product.Add(product);
            _practiceDbcontext.SaveChanges();
        }
    }
}
