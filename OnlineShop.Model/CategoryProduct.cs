﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Model
{
    public class CategoryProduct
    {
        public int CategoryId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryIds { get; set; }
        public string CategoryName { get; set; }
        public string Result { get; set; }
    }
}
