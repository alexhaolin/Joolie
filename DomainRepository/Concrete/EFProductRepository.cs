using DomainRepository.Abstract;
using DomainRepository.Entities;
//using Report_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainRepository.Concrete
{
    public class EFProductRepository : IProductRepository
    {
     
        public EFDBContext Context = new EFDBContext() ;
        //public EFProductRepository(DbContext dbContext )
        //{
        //  //  Context = dbContext;
        //}
        public IEnumerable<Product> Products
        {
            get { return Context.Products; }

        }

        //public IEnumerable<SubCategory> SubCategorys
        //{
        //    get { return Context.SubCategorys; }
        //}


       // public int GetProductSubCategoryID(string subCategory)
        //{

        //       // int Id =Convert.ToInt32(from sub in Context.SubCategory

        //           //      where sub.subCategory == subCategory
        //              //   select sub.SubCategoryID)
        //       var dt = Context.SubCategorys.Single(Sub => Sub.subCategory == subCategory);

        //        return dt.SubCategoryID; 
                
        //}
        //public IEnumerable<TypeFilter> TypeFilter {
        //    get { return Context.TypeFilter; }
        //}



        //public int GetPropertyIDByPropertyName(string PropertyName)
        //{
        //    int propID =Convert.ToInt32( from prop in Context.TypeFilter
        //                 where prop.TypeName == PropertyName
        //                 select prop.PropertyID);
        //    return propID;
        //}


        //public IEnumerable<TechSpecFilter> TechSpecFilter {

        //    get
        //    {
        //        return Context.TechSpecFilter;
        //    }
        //}
        //public int[] GetPropertyMinMax(int propID, int subCategoryID)
        //{
        //    int[] MinMax = new int[2];

        //    var dt = Context.TechSpecFilter.Where(prop => prop.PropertyID == propID && prop.SubCategoryID == subCategoryID).
        //    Select(prop => new { prop.Min_Value, prop.Max_Value } ).ToList();
        //    MinMax[0] = Convert.ToInt32( dt[0]);
        //    MinMax[1] = Convert.ToInt32(dt[1]);

        //    return  MinMax;
        //}


    }
}
