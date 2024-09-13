using PracticeProject.Model.ResponseModel;

namespace PracticeProject.Core.Interface
{
    public interface IFetchOrderDetailsByDate
    {
        List<OrderDetailsByDateModel> OrderInformationByDate(int customerId, DateTime fromDate, DateTime toDate);
    }
}