using OnlineShop.Model;
using System.Collections.Generic;

namespace OnlineShop.DataAccessLayer.Repository
{
    public interface ICategoryDA
    {
        Category AddNewCategory(Category category);
        List<Category> GetAllCategoryList(Category category);
    }
}
