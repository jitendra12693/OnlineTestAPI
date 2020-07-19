using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Model
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Action { get; set; }
        public string Result { get; set; }
        public List<CategoryProduct> CategoryProductList { get; set; }
    }
}
