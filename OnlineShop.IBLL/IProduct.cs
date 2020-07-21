using OnlineShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.IBLL
{
    public interface IProduct
    {
        ProductModel AddUpdateNewProduct(ProductDetails produt);
        List<ProductDetails> GetAllProductList(ProductDetails product);
        List<ProductDetails> SearchProductByCategory(ProductDetails product);
        ProductModel RemoveProduct(ProductDetails product);
    }
}
