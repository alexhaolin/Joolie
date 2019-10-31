using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Joolie.Models;
using Joolie.Dal;
using Joolie.ViewModel;

namespace Joolie.Controllers
{
    public class SearchController : Controller
    {
        

        // GET: Search
        public ActionResult Index()
        {
            return RedirectToAction("SearchPage", "Search");

        }

        public ActionResult SearchPage()
        {
            SearchViewModel vm = new SearchViewModel();

            SearchCategoryDal C_dal = new SearchCategoryDal();
            List<SearchCategory> CategoryList = C_dal.Category.ToList<SearchCategory>();

            SearchSubCategoryDal S_dal = new SearchSubCategoryDal();
            
            List<SearchSubCategory> SubCategoryList = S_dal.SubCategory.ToList<SearchSubCategory>();


            var JoinTables = from subcategoy in SubCategoryList
                             join category in CategoryList
                             on subcategoy.CategoryID equals category.CategoryID
                             select new { Category = category.CategoryName, Subcategory = subcategoy.SubCategory };

            
            List<Search1> searchList = new List<Search1>();
            foreach (var item in JoinTables)
            {
                Search1 temp = new Search1();
                temp.Category = item.Category;
                temp.SubCategory = item.Subcategory;
                searchList.Add(temp);
            }

            vm.Categories = searchList;
      
            return View("SearchPage", vm);
        }



        public ActionResult ChangeCategory()
        {

            string Selected = Request.Form["Category"];           

            SearchViewModel vm = new SearchViewModel();

            ViewData["selectedCategory"] = Selected; // send the data to View

            SearchCategoryDal C_dal = new SearchCategoryDal();
            List<SearchCategory> CategoryList = C_dal.Category.ToList<SearchCategory>();

            SearchSubCategoryDal S_dal = new SearchSubCategoryDal();
            List<SearchSubCategory> SubCategoryList = S_dal.SubCategory.ToList<SearchSubCategory>();


            var JoinTables = from subcategoy in SubCategoryList
                             join category in CategoryList
                             on subcategoy.CategoryID equals category.CategoryID
                             select new { Category = category.CategoryName, Subcategory = subcategoy.SubCategory };

            List<Search1> searchList = new List<Search1>();
            foreach (var item in JoinTables)
            {
                Search1 temp = new Search1();
                temp.Category = item.Category;
                temp.SubCategory = item.Subcategory;
                searchList.Add(temp);
            }

            

            //SearchDal dal = new SearchDal();  //  no join table 
            //List<Search> searchList = dal.Categories.ToList<Search>();  //  no join table 

            if (Selected != "All Categories")
            {
                for (int i = 0; i < searchList.Count(); i++)
                {
                    if (searchList[i].Category != Selected)
                    {
                        searchList[i].SubCategory = null;
                    }
                }
            }
          
            // searchList get data from DB 
            vm.Categories = searchList;
            // vm get data from searchList

            return View("SearchPage", vm);
        }


        // HAV Fans
        public ActionResult SelectSubCategory()
        {
            string selectedSbuCategory = Request.Form["SubCategory"];
            
            //var JoinedTable = TempData["JoinedTable"] as IEnumerable<Search>  // useless;
             string selectedCategory ="";

            SearchCategoryDal C_dal = new SearchCategoryDal();
            List<SearchCategory> CategoryList = C_dal.Category.ToList<SearchCategory>();

            SearchSubCategoryDal S_dal = new SearchSubCategoryDal();
            List<SearchSubCategory> SubCategoryList = S_dal.SubCategory.ToList<SearchSubCategory>();


            var JoinTables = from subcategoy in SubCategoryList
                             join category in CategoryList
                             on subcategoy.CategoryID equals category.CategoryID
                             select new { Category = category.CategoryName, Subcategory = subcategoy.SubCategory };

            List<Search1> searchList = new List<Search1>();
            foreach (var item in JoinTables)
            {
                if(selectedSbuCategory == item.Subcategory)
                {
                    selectedCategory = item.Category;
                }
                Search1 temp = new Search1();
                temp.Category = item.Category;
                temp.SubCategory = item.Subcategory;
                searchList.Add(temp);
            }

            string URL = "~/Views/" + selectedCategory + "/" + selectedSbuCategory + ".cshtml";

            Session["url"] = URL;
            // Short code
            if (selectedCategory != "")
            {
                ViewBag.Category = selectedCategory;
                 ViewBag.SubCategory = selectedSbuCategory;

                TempData["Category"] = selectedCategory;
                TempData["SubCategory"] = selectedSbuCategory;
                // return RedirectToAction(selectedSbuCategory, selectedCategory)
              
                return RedirectToAction("List", "Product");
            }
            else
            {
                return RedirectToAction("SearchPage", "Search");
            }



            ///// Long code 
            //if (selectedSbuCategory == "Fans")
            //{
            //    return RedirectToAction("Fans", "Mechanical");
            //}
            //else if (selectedSbuCategory == "Microwave")
            //{
            //    return RedirectToAction("Microwave", "Electrical");
            //}
            //else if (selectedSbuCategory == "Refrigerator")
            //{
            //    return RedirectToAction("Refrigerator", "Electrical");
            //}
            //else
            //{
            //    return RedirectToAction("SearchPage", "Search");
            //}

            //return RedirectToAction("SearchPage", "Search");
        }
    }
}