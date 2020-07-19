using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Model;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using OnlineShop.DataAccessLayer.Repository;

namespace OnlineShop.DataAccessLayer
{
    public class CategoryDA : ICategoryDA
    {
        SqlConnection connString = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnection"].ToString());
        SqlCommand cmd;

        Category ICategoryDA.AddNewCategory(Category category)
        {
            Category cat = new Category();
            try
            {
                if (connString.State == ConnectionState.Closed)
                    connString.Open();
                cmd = new SqlCommand("CRUDCategory", connString);
                DataTable dt = new DataTable();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CategoryId", category.CategoryId);
                cmd.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                cmd.Parameters.AddWithValue("@Action", category.Action);
                
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                sda.Dispose();
                cat = ExtensionMethods.ConvertToListOf<Category>(dt).FirstOrDefault();
                return cat;
            }
            catch (Exception ex)
            {
                return cat;
            }
            finally
            {
                connString.Close();
            }
        }

        List<Category> ICategoryDA.GetAllCategoryList(Category category)
        {
            List<Category> list = new List<Category>();
            try
            {
                DataSet ds = new DataSet();

                if (connString.State == ConnectionState.Closed)
                    connString.Open();
                cmd = new SqlCommand("CRUDCategory", connString);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CategoryId", category.CategoryId);
                cmd.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                cmd.Parameters.AddWithValue("@Action", category.Action);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(ds);
                sda.Dispose();

                list = ExtensionMethods.ConvertToListOf<Category>(ds.Tables[0]);

                return list;

            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                connString.Close();
            }
        }
    }
}
