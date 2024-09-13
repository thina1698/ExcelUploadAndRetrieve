using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject.Model.RequestModels
{
    public class ProductRequestModel
    {
        public int ProductId {  get; set; }
        public string ProductName { get; set; }
        public Decimal ProductPrice { get; set; }
        public int Quantity {  get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
