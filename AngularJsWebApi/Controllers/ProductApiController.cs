using OnlineShop.IBLL;
using OnlineShop.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AngularJsWebApi.Controllers
{
    [RoutePrefix("api/Product")]
    public class ProductApiController : ApiController
    {
        IProduct iproduct;
        
        public ProductApiController(IProduct _iproduct)
        {
            iproduct = _iproduct;
        }
        [HttpPost]
        [Route("GetAllProductList")]
        public async Task<HttpResponseMessage> GetAllProductList(ProductDetails product)
        {
            List<ProductDetails> productList = new List<ProductDetails>();
            try
            {
                product.Action = "S";
                await Task.Run(() =>
                {
                    productList = iproduct.GetAllProductList(product);
                });
                if(productList!=null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, productList);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { StatusCode = HttpStatusCode.NotFound, Status = "Failed" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("SaveProductDetails")]
        public async Task<HttpResponseMessage> SaveProductDetails(ProductDetails product)
        {
            ProductModel prodModel = new ProductModel();
            try
            {
                product.Action = product.ProductId>0?"U":"I";
                await Task.Run(() =>
                {
                    prodModel = iproduct.AddUpdateNewProduct(product);
                });
                return Request.CreateResponse(HttpStatusCode.OK, prodModel);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("RemoveProduct")]
        public async Task<HttpResponseMessage> RemoveProduct(ProductDetails product)
        {
            ProductModel prodModel = new ProductModel();
            try
            {
                product.Action =  "D";
                await Task.Run(() =>
                {
                    prodModel = iproduct.RemoveProduct(product);
                });
                return Request.CreateResponse(HttpStatusCode.OK, prodModel);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("SearchProductByCategory")]
        public async Task<HttpResponseMessage> SearchProductByCategory(ProductDetails product)
        {
            try
            {
                List<ProductDetails> proImg = await Task.Run(() => iproduct.SearchProductByCategory(product));
                if(proImg!=null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, proImg);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { StatusCode=HttpStatusCode.BadRequest,Status="Failed" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
