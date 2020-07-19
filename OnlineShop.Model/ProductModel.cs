using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Model
{
    public class ProductModel
    {
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public string Status { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Result { get; set; }
    }
}
