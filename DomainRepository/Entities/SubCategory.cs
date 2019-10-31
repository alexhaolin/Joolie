using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainRepository.Entities
{
    public class SubCategory
    {

        public int SubCategoryID { get; set; }
        public int CategoryID { get; set; }
        public string  subCategory { get; set; }
    }
}
