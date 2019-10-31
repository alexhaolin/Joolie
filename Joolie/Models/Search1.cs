using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace Joolie.Models
{
    public class Search1
    {
        public string Category { get; set; }
        
        [Key]
        public string SubCategory { get; set; }
    }

    public class SearchCategory
    {
        [Key]
        public int CategoryID { get; set; }
        public String CategoryName { get; set; }
    }

    public class SearchSubCategory
    {
        [Key]
        public int SubCategoryID {get; set; }
        public int CategoryID { get; set; }
        public String SubCategory { get; set; }
    }

  
    

}