﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject.Model.RequestModels
{
    public class ProductExcelModel
    {
        public IFormFile formFile  { get; set; }
    }
}
