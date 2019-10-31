using Report_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report_BLL
{
    public class JoolieReport_BLL
    {
        /* insert a SubCategory to retrieve all products*/
        public DataSet getAllProductsBySubCategory_BLL(string subCategory)
        {
            JoolieReport_DAL rep = new JoolieReport_DAL();
            return (rep.getAllProductsBySubCategory_DAL(subCategory));
        }

        public int getProductSubCategoryID_BLL(string subCategory)
        {
            JoolieReport_DAL rep = new JoolieReport_DAL();
            return (rep.getProductSubCategoryID_DAL(subCategory));
        }

        // insert property name and get property id
        public int getPropertyIDByName_BLL(string property)
        {
            JoolieReport_DAL rep = new JoolieReport_DAL();
            return (rep.getPropertyIDByName_DAL(property));
           
        }


        // get min value of property
        public int GetPropertyMinValue_BLL(int PropertyId)
        {
            JoolieReport_DAL rep = new JoolieReport_DAL();
            return (rep.GetPropertyMinValue_DAL(PropertyId));
        }
        // get max value of property
        public int GetPropertyMaxValue_BLL(int PropertyId)
        {
            JoolieReport_DAL rep = new JoolieReport_DAL();
            return (rep.GetPropertyMaxValue_DAL(PropertyId));
        }
    }
}
