using OnlineShop.Model;
using System.Collections.Generic;

namespace OnlineShop.DataAccessLayer.Repository
{
    public interface IProductDA
    {
        ProductModel AddUpdateNewProduct(ProductDetails product);
        List<ProductDetails> GetAllProductList(ProductDetails product);
        List<M_Category> SelectAllCategory(int categoryId, int parentCategoryId);
        List<ProductDetails> SearchProductByCategory(ProductDetails product);
    }
}
