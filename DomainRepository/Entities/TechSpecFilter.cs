using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainRepository.Entities
{
    public class TechSpecFilter
    {
        public int PropertyID { get; set; }
        public int SubCategoryID { get; set; }
        public int Min_Value { get; set; }
        public int Max_Value { get; set; }
    }
}



