using System;
using System.Collections.Generic;

namespace OnlineShop.Model
{
    public class ProductDetails
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string ProductImage { get; set; }
        public string Result { get; set; }
        public string Action { get; set; }
        public string CategoryIds { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
    }
}
