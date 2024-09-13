namespace PracticeProject.Core.Interface
{
    public interface IPlaceOrder
    {
        string OrderPlacing(int customerId, int productId, int orderQuantity);
    }
}