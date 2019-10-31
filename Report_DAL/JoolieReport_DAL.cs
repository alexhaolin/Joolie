using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
namespace Report_DAL
{
    public class JoolieReport_DAL
    {
        /* a method to retrieve all product by Category and SubCategory*/
        public DataSet getAllProductsBySubCategory_DAL(string subCategory)
        {
            DataSet ds = new DataSet();
            string conectionString = ConfigurationManager.ConnectionStrings["EFDBContext"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetSubCategoryID_Products", con);
                 cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("SubCategory", subCategory);
                // con.Open();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds,"Products");
                return ds;
            }

        }// end of  getAllProductsBySubCategory(string subCategory)  GeTProductsBSubCategory_Products 

        /* a method to retrieve product's SubCategory ID*/
        public int getProductSubCategoryID_DAL(string subCategory)
        {
           // DataSet ds = new DataSet();
            string conectionString = ConfigurationManager.ConnectionStrings["EFDBContext"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conectionString))
            {
                SqlCommand cmd = new SqlCommand("spGeSubCategoryID_Products", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("SubCategory", subCategory);
                // con.Open();
                //   SqlDataAdapter adp = new SqlDataAdapter(cmd);
                // adp.Fill(ds, "Products");
                con.Open();
                int id = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
                return id;
            }

        }// end of  method to retrieve product's SubCategory
         // get property id by Name

            // get Max value of property
        public int getPropertyIDByName_DAL(string property)
        {

            string conectionString = ConfigurationManager.ConnectionStrings["EFDBContext"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetPropertyIDByName_Property ", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("PropertyName", property);
                // con.Open();
                //   SqlDataAdapter adp = new SqlDataAdapter(cmd);
                // adp.Fill(ds, "Products");
                con.Open();
                int id = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
                return id;
            } // end of method public int getPropertyIDByName_DAL(string property)
        }

        public int GetPropertyMaxValue_DAL(int PropertyId)
        {
            string conectionString = ConfigurationManager.ConnectionStrings["EFDBContext"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetPropertyMax_TechSpecFilter", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("PropertyID", PropertyId);
                // con.Open();
                //   SqlDataAdapter adp = new SqlDataAdapter(cmd);
                // adp.Fill(ds, "Products");
                con.Open();
                int id = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
                return id;
            }
        } // end of GetPropertyMaxValue(int id)

        public int GetPropertyMinValue_DAL(int PropertyId)
        {
            string conectionString = ConfigurationManager.ConnectionStrings["EFDBContext"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetPropertyMin_TechSpecFilter", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("PropertyID", PropertyId);
                // con.Open();
                //   SqlDataAdapter adp = new SqlDataAdapter(cmd);
                // adp.Fill(ds, "Products");
                con.Open();
                int id = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
                return id;
            }
        } // end of GetPropertyMinValue(int id)

    }
}
