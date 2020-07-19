using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Model
{
    public class SearchProduct
    {
        public long ProductId { get; set; }
        public string FuzzySearch { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public decimal FromPrice { get; set; }
        public decimal ToPrice { get; set; }
        public int StartIndex { get; set; }
        public int NumberOfRows { get; set; }

    }
}
