using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject.Model.ResponseModel
{
    public class OrderDetailsByDateModel
    {
        public string CustomerName {  get; set; }
        public string ProductName {  get; set; }
        public Decimal ProductPrice {  get; set; }
        public DateTime OrderDate { get; set; }
    }
}
