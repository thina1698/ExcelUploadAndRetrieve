using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject.Infra.Tables
{
    public class Order
    {
        public int OrderId {  get; set; }
        public int CustomerId { get; set; }
        public int ProductId {  get; set; }
        public int Quantity {  get; set; }
        public DateTime OrderedDate { get; set; }
        public Product Product { get; set; }
        public Customer Customer { get; set; }

    }
}
