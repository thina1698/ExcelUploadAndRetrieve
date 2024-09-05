using OfficeOpenXml;
using PracticeProject.Core.Interface;
using PracticeProject.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject.Core.Implementation
{
    public class ProductGetEpPlus : IProductGetEpPlus
    {
        private readonly PracticeDbContext _practiceDbContext;

        public ProductGetEpPlus(PracticeDbContext practiceDbContext)
        {
            _practiceDbContext = practiceDbContext;
        }

            public byte[] ExportProductsToExcel()
            {
                var products = _practiceDbContext.Product.ToList();

                if (products == null || products.Count == 0)
                {
                    return Array.Empty<byte>();
                }

                using (var stream = new MemoryStream())
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                    using (var package = new ExcelPackage(stream))
                    {
                        var worksheet = package.Workbook.Worksheets.Add("Products");

                        worksheet.Cells[1, 1].Value = "Product Id";
                        worksheet.Cells[1, 2].Value = "Product Name";
                        worksheet.Cells[1, 3].Value = "Product Price";

                        for (int i = 0; i < products.Count; i++)
                        {
                            worksheet.Cells[i + 2, 1].Value = products[i].ProductId;     
                            worksheet.Cells[i + 2, 2].Value = products[i].ProductName;   
                            worksheet.Cells[i + 2, 3].Value = products[i].ProductPrice;  
                        }

                        
                        worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                        package.Save();
                    }

                    return stream.ToArray();
                }
            }
        }
    }
