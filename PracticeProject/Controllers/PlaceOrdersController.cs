using Microsoft.AspNetCore.Mvc;
using PracticeProject.ApiResponse;
using PracticeProject.Core.Interface;
using PracticeProject.Infra.Tables;
using PracticeProject.Model.RequestModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PracticeProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceOrdersController : ControllerBase
    {

        private readonly IPlaceOrder _placeOrder;
        private readonly IFetchOrderDetailsByDate _fetchOrderDetailsByDate;

        public PlaceOrdersController(IPlaceOrder placeOrder,IFetchOrderDetailsByDate fetchOrderDetailsByDate)
        {
            _placeOrder = placeOrder;
            _fetchOrderDetailsByDate = fetchOrderDetailsByDate;
        }

        [HttpPost("PlaceTheOrder")]
        public CommonResponseModel Post([FromBody] OrderRequestModel orderRequest)
        {
            var data = _placeOrder.OrderPlacing(orderRequest.CustomerId,orderRequest.ProductId,orderRequest.Quantity);

            if (data == "Order placed successfully.")
            {
                return new CommonResponseModel
                {
                    HttpStatusCode = System.Net.HttpStatusCode.OK,
                    Message = "Order Placed Successfully",
                };
            }
            else
            {
                return new CommonResponseModel
                {
                    HttpStatusCode= System.Net.HttpStatusCode.BadRequest,
                    Message="Order Placed Failed"
                };
            }
        }
        [HttpGet("FetchOrderDetailsByDate")]
        public CommonResponseModel FetchOrderDetailsByDate(int customerId,DateTime fromDate,DateTime toDate)
        {
            var getData = _fetchOrderDetailsByDate.OrderInformationByDate(customerId,fromDate,toDate);
            return new CommonResponseModel
            {
                Data = getData,
                Message="Order Details Based on given Date Information Fetched Successfully"
            };
        }
    }
}
