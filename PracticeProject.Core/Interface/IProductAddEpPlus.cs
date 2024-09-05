using Microsoft.AspNetCore.Http;

namespace PracticeProject.Core.Interface
{
    public interface IProductAddEpPlus
    {
        void AddProductsFromExcel(Stream stream);
    }
}