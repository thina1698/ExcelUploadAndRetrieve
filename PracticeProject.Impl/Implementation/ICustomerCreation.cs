using PracticeProject.Model.RequestModels;

namespace PracticeProject.Core.Implementation
{
    public interface ICustomerCreation
    {
        void CreateProductCustomer(CustomerRequestModel requestModel);
    }
}