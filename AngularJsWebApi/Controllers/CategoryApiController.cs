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
    [RoutePrefix("api/Category")]
    public class CategoryApiController : ApiController
    {
        ICategory icategory;

        public CategoryApiController(ICategory _icategory)
        {
            icategory = _icategory;
        }
        [HttpPost]
        [Route("GetAllCategoryList")]
        public async Task<HttpResponseMessage> GetAllCategoryList(Category category)
        {
            List<Category> categoryList = new List<Category>();
            try
            {
                category.Action = "S";
                await Task.Run(() =>
                {
                    categoryList = icategory.GetAllCategoryList(category);
                });
                if (categoryList != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, categoryList);
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
        [Route("SaveCategoryDetails")]
        public async Task<HttpResponseMessage> AddNewCategory(Category category)
        {
            Category categoryModel = new Category();
            try
            {
                category.Action = category.CategoryId > 0 ? "U" : "I";
                await Task.Run(() =>
                {
                    categoryModel = icategory.AddNewCategory(category);
                });
                return Request.CreateResponse(HttpStatusCode.OK, categoryModel);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
