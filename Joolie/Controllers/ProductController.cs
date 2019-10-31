using DomainRepository.Abstract;
using Joolie.Models;
//using Joolie.ViewModels;
using Report_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using Newtonsoft.Json.Linq;
using Joolie.ViewModels;

namespace Joolie.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
     

        private readonly IProductRepository repos;

        // GET: Productkkkk
        public ProductController(IProductRepository repos)
        {
            this.repos = repos;
        }
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult List()
        {
            ProductListViewModel productViewModel = new ProductListViewModel();
            JoolieReport_BLL joolieReport_BLL = new JoolieReport_BLL();
            


          //  int ID= repos.GetProductSubCategoryID("Fans");
             int ID = joolieReport_BLL.getProductSubCategoryID_BLL("Fans");
            productViewModel.Products = repos.Products.Where(p => p.SubCategoryID == ID);
            //productViewModel.Products = repos.Products.Where(p => p.SubCategoryID == ID);
            //string[] Properties = { "ModelYear", "AirFlow", "MaxPower", "FanSpeedDiameter", "Height", "Firm", "Global" };
        
            productViewModel.Category =  " HVan Fans";
            productViewModel.SubCategory =  "Mechanics";
            productViewModel.fanproperties.ModelYearPropertID = joolieReport_BLL.getPropertyIDByName_BLL("ModelYear");
            //    MinMax = repos.GetPropertyMinMax(ID, productViewModel.fanproperties.AirFlowPropertID);
            //productViewModel.fanproperties.MinAirFlow = MinMax[0];
            productViewModel.fanproperties.MinModelYear = joolieReport_BLL.GetPropertyMinValue_BLL(productViewModel.fanproperties.ModelYearPropertID);
            //productViewModel.fanproperties.MaxAirFlow = MinMax[1];
            productViewModel.fanproperties.MaxModelYear = joolieReport_BLL.GetPropertyMaxValue_BLL(productViewModel.fanproperties.ModelYearPropertID);

            //productViewModel.fanproperties.AirFlowPropertID = repos.GetPropertyIDByPropertyName("AirFlow");
            productViewModel.fanproperties.AirFlowPropertID = joolieReport_BLL.getPropertyIDByName_BLL("AirFlow");
            //    MinMax = repos.GetPropertyMinMax(ID, productViewModel.fanproperties.AirFlowPropertID);
            //productViewModel.fanproperties.MinAirFlow = MinMax[0];
            productViewModel.fanproperties.MinAirFlow = joolieReport_BLL.GetPropertyMinValue_BLL(productViewModel.fanproperties.AirFlowPropertID);
            //productViewModel.fanproperties.MaxAirFlow = MinMax[1];
            productViewModel.fanproperties.MaxAirFlow = joolieReport_BLL.GetPropertyMaxValue_BLL(productViewModel.fanproperties.AirFlowPropertID);

            //productViewModel.fanproperties.MaxPowerPropertyID = repos.GetPropertyIDByPropertyName("MaxPower");
            productViewModel.fanproperties.MaxPowerPropertyID = joolieReport_BLL.getPropertyIDByName_BLL("MaxPower");
            //MinMax = repos.GetPropertyMinMax(ID, productViewModel.fanproperties.MaxPowerPropertyID);
            //productViewModel.fanproperties.MinMaxPower = MinMax[0];
            productViewModel.fanproperties.MinMaxPower = joolieReport_BLL.GetPropertyMinValue_BLL(productViewModel.fanproperties.MaxPowerPropertyID);
            //productViewModel.fanproperties.MaxMaxPower = MinMax[1];
            productViewModel.fanproperties.MaxMaxPower = joolieReport_BLL.GetPropertyMaxValue_BLL(productViewModel.fanproperties.MaxPowerPropertyID);


            //productViewModel.fanproperties.FanSpeedDimaterPropertyID = repos.GetPropertyIDByPropertyName("FanSpeedDiameter");
            productViewModel.fanproperties.FanSpeedDimaterPropertyID= joolieReport_BLL.getPropertyIDByName_BLL("FanSpeedDiameter");
            //MinMax = repos.GetPropertyMinMax(ID, productViewModel.fanproperties.FanSpeedDimaterPropertyID);
            //productViewModel.fanproperties.MinFanSpeedDimater = MinMax[0];
            productViewModel.fanproperties.MinFanSpeedDimater = joolieReport_BLL.GetPropertyMinValue_BLL(productViewModel.fanproperties.FanSpeedDimaterPropertyID);
            //productViewModel.fanproperties.MaxFanSpeedDimater = MinMax[1];
            productViewModel.fanproperties.MaxFanSpeedDimater = joolieReport_BLL.GetPropertyMaxValue_BLL(productViewModel.fanproperties.FanSpeedDimaterPropertyID);


            //productViewModel.fanproperties.HeightPropertyID = repos.GetPropertyIDByPropertyName("Height");
            productViewModel.fanproperties.HeightPropertyID = joolieReport_BLL.getPropertyIDByName_BLL("Height");
            //MinMax = repos.GetPropertyMinMax(ID, productViewModel.fanproperties.HeightPropertyID);
            //productViewModel.fanproperties.MinHeight = MinMax[0];
            productViewModel.fanproperties.MinHeight = joolieReport_BLL.GetPropertyMinValue_BLL(productViewModel.fanproperties.HeightPropertyID);
            //productViewModel.fanproperties.MaxHeight = MinMax[1];
             productViewModel.fanproperties.MaxHeight = joolieReport_BLL.GetPropertyMaxValue_BLL(productViewModel.fanproperties.HeightPropertyID);

            //productViewModel.fanproperties.FirmPropertyID = repos.GetPropertyIDByPropertyName("Firm");
            productViewModel.fanproperties.FirmPropertyID = joolieReport_BLL.getPropertyIDByName_BLL("Firm");
            //MinMax = repos.GetPropertyMinMax(ID, productViewModel.fanproperties.FirmPropertyID);
            //productViewModel.fanproperties.MinFirm = MinMax[0];
            productViewModel.fanproperties.MinFirm = joolieReport_BLL.GetPropertyMinValue_BLL(productViewModel.fanproperties.FirmPropertyID);
            //productViewModel.fanproperties.MaxFirm = MinMax[1];
            productViewModel.fanproperties.MaxFirm = joolieReport_BLL.GetPropertyMaxValue_BLL(productViewModel.fanproperties.FirmPropertyID);

            productViewModel.SubCategoryID = ID;
            //productViewModel.CategoryId = 





            //productViewModel.fanproperties.GlobalPropertyID = repos.GetPropertyIDByPropertyName("Global");
            productViewModel.fanproperties.GlobalPropertyID = joolieReport_BLL.getPropertyIDByName_BLL("Global");
            //MinMax = repos.GetPropertyMinMax(ID, productViewModel.fanproperties.GlobalPropertyID);
            //productViewModel.fanproperties.MinGlobal = MinMax[0];
            productViewModel.fanproperties.MinGlobal = joolieReport_BLL.GetPropertyMinValue_BLL(productViewModel.fanproperties.GlobalPropertyID);
            //productViewModel.fanproperties.MaxGlobal = MinMax[1];
            productViewModel.fanproperties.MaxGlobal = joolieReport_BLL.GetPropertyMaxValue_BLL(productViewModel.fanproperties.GlobalPropertyID);
            

            return View(productViewModel);

        }

        [HttpPost]
        public ActionResult List(FormCollection form)
        {

            ProductListViewModel productListViewModel = new ProductListViewModel();


            if (form.Count==0 && form==null)
            {
                productListViewModel.fanproperties.MinModelYear = Convert.ToInt32(form["fanproperties.MinModelYear"]);
                productListViewModel.fanproperties.MaxModelYear = Convert.ToInt32(form["fanproperties.MaxModelYear"]);
                productListViewModel.fanproperties.ModelYearPropertID = Convert.ToInt32(form["fanproperties.ModelYearPropertID"]);
                productListViewModel.fanproperties.MinAirFlow = Convert.ToInt32(form["fanproperties.MinAirFlow"]);
                productListViewModel.fanproperties.MaxAirFlow = Convert.ToInt32(form["fanproperties.MaxAirFlow"]);
                productListViewModel.fanproperties.AirFlowPropertID = Convert.ToInt32(form["fanproperties.AirFlowPropertID"]);
                productListViewModel.fanproperties.MinMaxPower = Convert.ToInt32(form["fanproperties.MinMaxPower"]);
                productListViewModel.fanproperties.MaxMaxPower = Convert.ToInt32(form["fanproperties.MaxMaxPower"]);
                productListViewModel.fanproperties.MaxPowerPropertyID = Convert.ToInt32(form["fanproperties.MaxPowerPropertyID"]);
                productListViewModel.fanproperties.MinFanSpeedDimater = Convert.ToInt32(form["fanproperties.MinFanSpeedDimater"]);
                productListViewModel.fanproperties.MaxFanSpeedDimater = Convert.ToInt32(form["fanproperties.MaxFanSpeedDimater"]);
                productListViewModel.fanproperties.FanSpeedDimaterPropertyID = Convert.ToInt32(form["fanproperties.FanSpeedDimaterPropertyID"]);
                productListViewModel.fanproperties.MinHeight = Convert.ToInt32(form["fanproperties.MinHeight"]);
                productListViewModel.fanproperties.MaxHeight = Convert.ToInt32(form["fanproperties.MaxHeight"]);
                productListViewModel.fanproperties.HeightPropertyID = Convert.ToInt32(form["fanproperties.HeightPropertyID"]);
                productListViewModel.fanproperties.MinFirm = Convert.ToInt32(form["fanproperties.MinFirm"]);
                productListViewModel.fanproperties.MaxFirm = Convert.ToInt32(form["fanproperties.MaxFirm"]);
                productListViewModel.fanproperties.FirmPropertyID = Convert.ToInt32(form["fanproperties.FirmPropertyID"]);
                productListViewModel.fanproperties.MinGlobal = Convert.ToInt32(form["fanproperties.MinGlobal"]);
                productListViewModel.fanproperties.MaxGlobal = Convert.ToInt32(form["fanproperties.MaxGlobal"]);
                productListViewModel.fanproperties.GlobalPropertyID = Convert.ToInt32(form["fanproperties.GlobalPropertyID"]);

                productListViewModel.CategoryId = Convert.ToInt32(form["CategoryId"]);
                productListViewModel.SubCategoryID = Convert.ToInt32(form["SubCategoryID"]);
                productListViewModel.Category = form["Category"];
                productListViewModel.SubCategory = form["SubCategory"];


                // int ID = joolieReport_BLL.getProductSubCategoryID_BLL();
                productListViewModel.Products = repos.Products.Where(p => p.SubCategoryID == productListViewModel.SubCategoryID);
                return View(productListViewModel);
            }
            else return RedirectToAction("list", productListViewModel);
           
        }

        private string connectionString = ConfigurationManager.ConnectionStrings["EFDBContext"].ConnectionString;

        [HttpPost]
        public ActionResult ProductsComparison(FormCollection form)
        {
            List<int> arr = new List<int>();
            foreach (var key in form.GetValues("ProductCheckbox"))
            {
                if (!key.Equals("false"))
                {
                    arr.Add(Int32.Parse(key));
                    System.Diagnostics.Debug.WriteLine(key);
                }
            }

            int[] ProductIDs = arr.ToArray();
            ProductDetails productDetails = new ProductDetails();
            JObject jObject = productDetails.GetProductDetails(ProductIDs, connectionString);

            ViewData.Add("Category", ((dynamic)jObject)["Category"]);
            ViewData.Add("Subcategory", ((dynamic)jObject)["Subcategory"]);
            jObject.Remove("Category");
            jObject.Remove("Subcategory");
            ViewData.Add("products", jObject);
            ViewData.Add("ProductIDs", ProductIDs);

            System.Diagnostics.Debug.WriteLine("-------------------------");
            System.Diagnostics.Debug.WriteLine("Comparison it is.");
            System.Diagnostics.Debug.WriteLine("-------------------------");

            return View();
        }

        public ActionResult ProductSummary(int ProductID)
        {
            int[] ProductIDs = new int[1];
            ProductIDs[0] = ProductID;
            ProductDetails productDetails = new ProductDetails();
            JObject jObject = productDetails.GetProductDetails(ProductIDs, connectionString);

            jObject.Remove("Category");
            jObject.Remove("Subcategory");
            jObject.Remove("PROFILE");
            ViewData.Add("products", jObject);

            System.Diagnostics.Debug.WriteLine("-------------------------");
            System.Diagnostics.Debug.WriteLine("Summary it is.");
            System.Diagnostics.Debug.WriteLine("-------------------------");

            return View();
        }
    }
}