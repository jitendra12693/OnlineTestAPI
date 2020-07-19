using OnlineShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.IBLL
{
    public interface ICategory
    {
        Category AddNewCategory(Category category);
        List<Category> GetAllCategoryList(Category category);
    }
}
