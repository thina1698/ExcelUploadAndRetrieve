﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject.Model.RequestModels
{
    public class CustomerRequestModel
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string MobileNumber { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
