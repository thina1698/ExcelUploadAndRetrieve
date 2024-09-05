using PracticeProject.Model.RequestModels;

namespace PracticeProject.Core.Interface
{
    public interface IProductCreation
    {
        void CreateProduct(ProductRequestModel requestModel);
    }
}