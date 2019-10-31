using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using System.Configuration;

namespace Report_BLL
{
    public class ProductDetails
    {
        public JObject GetProductDetails(int[] ProductIDs, string connString)
        {
            // Store all the detailed properties inside a json object
            dynamic json = new JObject();
            json.PROFILE = new JObject();
            json.DESCRIPTION = new JObject();
            json.TYPE = new JObject();
            json["TECHNICAL SPECIFICATIONS"] = new JObject();

            // Build database connection
            string connectionString = connString;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            // Fetch properties of each products using stored procedure
            SqlCommand cmd;
            SqlDataReader dataReader;
            HashSet<string> PropertySet = new HashSet<string>();
            for (int i = 0; i < ProductIDs.Length; i++)
            {
                cmd = new SqlCommand("dbo.spGetComparedProductsDetails", con);
                cmd.Parameters.Add("@ProductID", System.Data.SqlDbType.Int, 8).Value = ProductIDs[i];
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    string PropertyName = dataReader["PropertyName"].ToString();
                    if (dataReader["IsType"].ToString() == "true")
                    {
                        if (!PropertySet.Contains(PropertyName))
                        {
                            json.TYPE[PropertyName] = new JArray();
                            PropertySet.Add(PropertyName);
                        }
                        ((JArray)json.TYPE[PropertyName]).Add(dataReader["Value"]);
                    }
                    else
                    {
                        if (!PropertySet.Contains(PropertyName))
                        {
                            json["TECHNICAL SPECIFICATIONS"][PropertyName] = new JArray();
                            PropertySet.Add(PropertyName);
                        }
                        ((JArray)json["TECHNICAL SPECIFICATIONS"][PropertyName]).Add(dataReader["Value"]);
                    }
                }
                dataReader.Close();
            }

            // Retrieve manufacturer, series, model, image
            json.DESCRIPTION.Manufacturer = new JArray();
            json.DESCRIPTION.Series = new JArray();
            json.DESCRIPTION.Model = new JArray();
            //json.TYPE["Model year"] = new JArray();
            json.PROFILE.Image = new JArray();
            for (int i = 0; i < ProductIDs.Length; i++)
            {
                cmd = new SqlCommand("dbo.spGetManufacturereAndImage", con);
                cmd.Parameters.Add("@ProductID", System.Data.SqlDbType.Int, 8).Value = ProductIDs[i];
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                dataReader = cmd.ExecuteReader();
                dataReader.Read();
                ((JArray)json.DESCRIPTION.Manufacturer).Add(dataReader["ManufacturerName"]);
                ((JArray)json.DESCRIPTION.Series).Add(dataReader["Series"]);
                ((JArray)json.DESCRIPTION.Model).Add(dataReader["Model"]);
                //((JArray)json.TYPE["Model year"]).Add(dataReader["Model_Year"]);
                ((JArray)json.PROFILE.Image).Add(dataReader["ProductImage"]);
                dataReader.Close();
            }

            // Retrieve category, subcategory
            cmd = new SqlCommand("dbo.spGetCategoryAndSubcategory", con);
            cmd.Parameters.Add("@ProductID", System.Data.SqlDbType.Int, 8).Value = ProductIDs[0];
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            dataReader = cmd.ExecuteReader();
            dataReader.Read();
            System.Diagnostics.Debug.WriteLine("-------------------------");
            System.Diagnostics.Debug.WriteLine(dataReader["CategoryName"]);
            System.Diagnostics.Debug.WriteLine(dataReader["subCategory"]);
            System.Diagnostics.Debug.WriteLine("-------------------------");
            json.Category = dataReader["CategoryName"];
            json.Subcategory = dataReader["subCategory"];
            dataReader.Close();
            con.Close();

            return json;
        }
    }
}
