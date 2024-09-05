using OfficeOpenXml;
using PracticeProject.Core.Interface;
using PracticeProject.Infra;
using PracticeProject.Infra.Tables;

namespace PracticeProject.Core.Implementation
{
    public class ProductAddEpPlus : IProductAddEpPlus
    {
        private readonly PracticeDbContext _practiceDbcontext;

        public ProductAddEpPlus(PracticeDbContext practiceDbcontext)
        {
            _practiceDbcontext = practiceDbcontext;
        }

        public void AddProductsFromExcel(Stream stream)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(stream))
            {
                var worksheet = package.Workbook.Worksheets[0];
                var rowCount = worksheet.Dimension.Rows;
                // List<Product> productList = new List<Product>();

                // Iterate over rows starting from the second row (assuming first row is header)
                for (int row = 2; row <= rowCount; row++)
                {
                    // Parsing product details from Excel
                    var product = new Product()
                    {
                        ProductName = worksheet.Cells[row, 1].Value.ToString(),
                        ProductPrice = Convert.ToDecimal(worksheet.Cells[row, 2].Value.ToString())
                    };
                    _practiceDbcontext.Product.Add(product);
                }
                _practiceDbcontext.SaveChanges();
            }

        }

    }
}
