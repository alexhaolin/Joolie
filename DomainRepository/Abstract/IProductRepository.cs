using DomainRepository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DomainRepository.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get;  }
        //IEnumerable<SubCategory> SubCategorys { get; }
        //int GetProductSubCategoryID(string subCategory);

        //IEnumerable<TypeFilter> TypeFilter { get; }

        //IEnumerable<TechSpecFilter> TechSpecFilter { get; }
        //int GetPropertyIDByPropertyName(string PropertyName);

        //int[] GetPropertyMinMax(int propID,  int subCategoryID);





    }
}
