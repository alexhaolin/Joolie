using DomainRepository.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainRepository.Concrete
{
    public class EFDBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        //public DbSet<SubCategory> SubCategorys { get; set; }
        //public DbSet<TypeFilter> TypeFilter { get; set; }
        //public DbSet<TechSpecFilter> TechSpecFilter { get; set; }
    }
}
