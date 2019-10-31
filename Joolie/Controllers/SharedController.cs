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
    public class SharedController : Controller
    {

        

        // GET: SharedSearchBar
        public ActionResult Index()
        {
            //return RedirectToAction("SearchPage", "Shared");
            return RedirectToAction("SearchPage", "Shared");
        }
        

        public ActionResult SearchPage()
        {
            // save the url
            
            string url = Request.Url.PathAndQuery;
               
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

            //return PartialView("~/Views/Mechanical/Fans.cshtml", vm);

            return View("SharedSearchBar", vm);
        }



        public ActionResult ChangeCategory()
        {

            //string url = Request.Url.PathAndQuery;  // useless

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

            Session["SearchBar"] = vm;

            string url = Session["url"].ToString();
            string cshtml_path = "~/Views" + url + ".cshtml";


            return View(cshtml_path, vm);  // Stay at the same page, but search bar does not change

            //return View("SharedSearchBar", vm); // got SharedSearchBar but didn't stay the same page.

    
            //return View("SharedSearchBar", vm);
            //return PartialView("SharedSearchBar", vm);
        }


        
        public ActionResult SelectSubCategory()
        {
            string selectedSbuCategory = Request.Form["SubCategory"];

            //var JoinedTable = TempData["JoinedTable"] as IEnumerable<Search>  // useless;
            string selectedCategory = "";

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
                if (selectedSbuCategory == item.Subcategory)
                {
                    selectedCategory = item.Category;
                }
                Search1 temp = new Search1();
                temp.Category = item.Category;
                temp.SubCategory = item.Subcategory;
                searchList.Add(temp);
            }

            // Short code
            if (selectedCategory != "")
            {
                return RedirectToAction(selectedSbuCategory, selectedCategory);
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