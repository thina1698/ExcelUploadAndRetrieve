using PracticeProject.Model.RequestModels;

namespace PracticeProject.Core.Interface
{
    public interface IProductCreation
    {
        void CreateProductCustomer(ProductRequestModel requestModel);
    }
}