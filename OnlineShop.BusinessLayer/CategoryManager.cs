using System;
using OnlineShop.IBLL;
using OnlineShop.Model;
using OnlineShop.DataAccessLayer.Repository;
using OnlineShop.DataAccessLayer;
using System.Collections.Generic;

namespace OnlineShop.BusinessLayer
{
    public class CategoryManager:ICategory
    {
        ICategoryDA iCategory;
        public CategoryManager(ICategoryDA _iCategory)
        {
            iCategory = _iCategory;
        }
        Category ICategory.AddNewCategory(Category category)
        {
            try
            {
                return iCategory.AddNewCategory(category);
            }
            catch (Exception)
            {
                return new Category();
            }
        }

        List<Category> ICategory.GetAllCategoryList(Category category)
        {
            List<Category> list = new List<Category>();
            try
            {
                list = iCategory.GetAllCategoryList(category);
                return list;
            }
            catch (Exception)
            {
                return list;
            }
        }
    }
}
