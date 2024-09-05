using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticeProject.Core.Interface;
using PracticeProject.Model.RequestModels;

namespace PracticeProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
         
        private readonly ICustomerCreation _customerCreation;
        private readonly IProductCreation _productCreation;
        private readonly IMappingCreation _mappingCreation;
        private readonly IMappingUpdation _mappingUpdation;
        private readonly IProductAddEpPlus _productAddEpPlus;
        private readonly IProductGetEpPlus _productGetEpPlus;
        public OrderController
            (IProductCreation productCreation,
            ICustomerCreation customerCreation,
            IMappingCreation mappingCreation,
            IMappingUpdation mappingUpdation,
            IProductAddEpPlus productAddEpPlus,
            IProductGetEpPlus productGetEpPlus)
        {
            _productCreation = productCreation;
            _customerCreation = customerCreation;
            _mappingCreation = mappingCreation;
            _mappingUpdation = mappingUpdation;
            _productAddEpPlus = productAddEpPlus;
            _productGetEpPlus = productGetEpPlus;
        }
        // POST api/<OrderManagementControllers>
        [HttpPost("AddCustomerToTheProducts")]
        public void PostCustomers([FromBody] CustomerRequestModel requestModel)
        {
            _customerCreation.CreateCustomer(requestModel);
        }

        [HttpPost("AddProductsOnly")]
        public void PostProducts([FromBody] ProductRequestModel requestModel)
        {
            _productCreation.CreateProduct(requestModel);
        }

        [HttpPost("AddMappingToCustomerAndProduct")]
        public void PostMapping([FromBody] MappingRequestModel requestModel)
        {
            _mappingCreation.CreateMapping(requestModel);
        }


        [HttpPut("UpdateMappingForCustomerAndProduct")]
        public void UpdateMapping([FromBody] MappingRequestModel requestModel)
        {
            _mappingUpdation.UpdateMapping(requestModel);
        }


        [HttpPut("UpdateMappingWithoutChangingTheOriginalValues")]
        public void UpdateMappingWithoutChangeTheReference([FromBody] MappingRequestModel requestModel)
        {
            _mappingUpdation.UpdateMappingWithoutReferenceChange(requestModel);
        }

        [HttpPost("Upload")]   
        public void ExcelUploadPost([FromForm] ProductExcelModel productExcelModel)
        {
            try
            {
                using (var stream = new MemoryStream()) 
                {
                    productExcelModel.formFile.CopyTo(stream);
                    _productAddEpPlus.AddProductsFromExcel(stream);
                }
            }
            catch
            {
                Console.Write("error");
            }
        }

        [HttpGet("RetrieveProductsfromDatabase")]
        public IActionResult ExportProductsToExcel()
        {
            try
            {
                // Call the service method to get the Excel file as a byte array
                var excelData = _productGetEpPlus.ExportProductsToExcel();

                // Check if the excelData is empty, indicating no data was found
                if (excelData == null || excelData.Length == 0)
                {
                    return NotFound("No products available to export.");
                }

                // Set the Excel file name with a timestamp
                string excelName = $"Products_{DateTime.Now.ToString("yyyy-MM-dd/HH:mm:ss")}.xlsx";

                // Return the Excel file as a downloadable file
                return File(excelData, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred while exporting data: {ex.Message}");
            }
        }
    }
}
