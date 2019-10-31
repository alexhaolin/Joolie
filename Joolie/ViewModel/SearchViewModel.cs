using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Joolie.Models;

namespace Joolie.ViewModel
{
    public class SearchViewModel
    {
        // get one category
        public Search1 Category { get; set; }
        // get all categories and then select one category after a category is selected in View
        public List<Search1> Categories { get; set; }
    }
}