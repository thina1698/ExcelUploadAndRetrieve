using Microsoft.AspNetCore.Mvc;
using PracticeProject.ApiResponse;
using PracticeProject.Core.DashboardClasses.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PracticeProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashBoardController(IDashBoardInformation dashBoardInformation) : ControllerBase
    {

        [HttpGet("DashBoardDetails")]
        public CommonResponseModel Get(int enterTheYear)
        {
            var getData = dashBoardInformation.GetDashBoardDetails(enterTheYear);
            return new CommonResponseModel
            {
                Data = getData,
                HttpStatusCode = System.Net.HttpStatusCode.OK,
            };
        }
    }
}
