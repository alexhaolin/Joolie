using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainRepository.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public int ManufacturerID { get; set; }
        public int SubCategoryID { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public string Series { get; set; }
        public string Model { get; set; }
        public int Model_Year { get; set; }
        public string Series_info { get; set; }
    }
}
