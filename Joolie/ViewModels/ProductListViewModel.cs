using DomainRepository.Entities;
using Joolie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Product = DomainRepository.Entities.Product;

namespace Joolie.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        // public  Dictionary<string, string> PropertyNames  = new Dictionary<string, string> ();
        public fanProperties fanproperties = new fanProperties();
        public List<SelectList> Brands { get; set; }
        public string Category { get; set; }
        public int CategoryId { get; set; }
        public string SubCategory { get; set; }
        public int SubCategoryID { get; set; }

    }
}