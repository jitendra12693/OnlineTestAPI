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
    public class ProductDA : IProductDA
    {
        SqlConnection connString = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnection"].ToString());
        SqlCommand cmd;
       
        ProductModel IProductDA.AddUpdateNewProduct(ProductDetails product)
        {
            ProductModel prod = new ProductModel();
            try
            {
                if (connString.State == ConnectionState.Closed)
                    connString.Open();
                cmd = new SqlCommand("CRUDProduct", connString);
                DataTable dt = new DataTable();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductId", product.ProductId);
                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@Description", product.Description);
                cmd.Parameters.AddWithValue("@ProductImage", product.ProductImage);
                cmd.Parameters.AddWithValue("@Action", product.Action);
                cmd.Parameters.AddWithValue("@CategoryIds", product.CategoryIds);
                cmd.Parameters.AddWithValue("@Price", product.Price);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                sda.Dispose();
                prod = ExtensionMethods.ConvertToListOf<ProductModel>(dt).FirstOrDefault();
                return prod;
            }
            catch (Exception ex)
            {
                return prod;
            }
            finally
            {
                connString.Close();
            }
        }

        List<ProductDetails> IProductDA.GetAllProductList(ProductDetails product)
        {
            List<ProductDetails> list = new List<ProductDetails>();
            try
            {
                DataSet ds = new DataSet();
                
                if (connString.State == ConnectionState.Closed)
                    connString.Open();
                cmd = new SqlCommand("CRUDProduct", connString);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductId", product.ProductId);
                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@Action", product.Action);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(ds);
                sda.Dispose();

                list = ExtensionMethods.ConvertToListOf<ProductDetails>(ds.Tables[0]);

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

        List<M_Category> IProductDA.SelectAllCategory(int categoryId, int parentCategoryId)
        {
            List<M_Category> list = new List<M_Category>();
            try
            {
                DataTable dt = new DataTable();
                if (connString.State == ConnectionState.Closed)
                    connString.Open();
                cmd = new SqlCommand("uspGetAllCategoryList", connString);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                cmd.Parameters.AddWithValue("@ParentCategoryId", parentCategoryId);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                sda.Dispose();

                list = ExtensionMethods.ConvertToListOf<M_Category>(dt);

                return list;
            }
            catch (Exception ex)
            {
                return list;
            }
            finally
            {
                connString.Close();
            }
        }
        
        List<ProductDetails> IProductDA.SearchProductByCategory(ProductDetails product)
        {
            List<ProductDetails> list = new List<ProductDetails>();
            try
            {
                DataSet ds = new DataSet();

                if (connString.State == ConnectionState.Closed)
                    connString.Open();
                cmd = new SqlCommand("uspSearchProduct", connString);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SearchExpression", product.CategoryName);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(ds);
                sda.Dispose();

                list = ExtensionMethods.ConvertToListOf<ProductDetails>(ds.Tables[0]);

                return list;
            }
            catch (Exception ex) {            }
            return list;
        }
    }
}
