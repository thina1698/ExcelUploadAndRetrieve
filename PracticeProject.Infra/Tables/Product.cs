using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject.Infra.Tables
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        [Precision(18, 2)]
        public Decimal ProductPrice { get; set; }
    }
}
