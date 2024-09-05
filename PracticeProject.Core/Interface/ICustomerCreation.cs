using PracticeProject.Model.RequestModels;

namespace PracticeProject.Core.Interface
{
    public interface ICustomerCreation
    {
        void CreateCustomer(CustomerRequestModel requestModel);
    }
}