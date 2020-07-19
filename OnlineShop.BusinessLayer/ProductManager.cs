using System;
using OnlineShop.IBLL;
using OnlineShop.Model;
using OnlineShop.DataAccessLayer.Repository;
using OnlineShop.DataAccessLayer;
using System.Collections.Generic;

namespace OnlineShop.BusinessLayer
{
    public class ProductManager : IProduct
    {
        IProductDA iProduct;
        public ProductManager(IProductDA _iProduct)
        {
            iProduct = _iProduct;
        }
        ProductModel IProduct.AddUpdateNewProduct(ProductDetails product)
        {
            try
            {
                return iProduct.AddUpdateNewProduct(product);
            }
            catch (Exception)
            {
                return new ProductModel();
            }
        }

        List<ProductDetails> IProduct.GetAllProductList(ProductDetails productDetails)
        {
            List<ProductDetails> list = new List<ProductDetails>();
            try
            {
                list = iProduct.GetAllProductList(productDetails);
                return list;
            }
            catch (Exception)
            {
                return list;
            }
        }

        List<ProductDetails> IProduct.SearchProductByCategory(ProductDetails product)
        {
            List<ProductDetails> list = new List<ProductDetails>();
            try
            {
                list = iProduct.SearchProductByCategory(product);
                return list;
            }
            catch (Exception)
            {
                return list;
            }
        }
        
    }
}
