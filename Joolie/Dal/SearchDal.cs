using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

using Joolie.Models;


namespace Joolie.Dal
{
    public class SearchDal : DbContext
    {
        // Provide mapping
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<SearchDal>(null); // Solved, The model backing the <Database> context has changed since the database was created
            base.OnModelCreating(modelBuilder);

             modelBuilder.Entity<Search1>().ToTable("tblSubCategory");         
            
        }

        public DbSet<Search1> Categories { get; set; }

       

    }

    public class SearchCategoryDal : DbContext
    {
        // Provide mapping
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SearchCategory>().ToTable("Category");
        }
        public DbSet<SearchCategory> Category { get; set; }

    }

    public class SearchSubCategoryDal : DbContext
    {
        // Provide mapping
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SearchSubCategory>().ToTable("SubCategory");
        }
        public DbSet<SearchSubCategory> SubCategory { get; set; }

       
    }
}