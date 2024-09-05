using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject.Infra.Tables
{
    public class Mapping
    {
        public int MappingId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public Customer Customer { get; set; }
        public Product Product { get; set; }
    }
}
