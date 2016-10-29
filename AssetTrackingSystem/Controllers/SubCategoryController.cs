using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssetTracking.BLL.Organization;
using AssetTracking.Model.Models.ViewModel;
using AssetTrackingSystemApps.Models;

namespace AssetTrackingSystemApps.Controllers
{
    public class SubCategoryController : Controller
    {
        //
        // GET: /SubCategory/


        private BaseCategoryManager _baseCategoryManager;

        public SubCategoryController()
        {
            _baseCategoryManager = new BaseCategoryManager();
        }

        public ActionResult Create()
        {

            SubCategoryCreateVM modelVM = new SubCategoryCreateVM();

            var generalCategories = _baseCategoryManager.GetAllGeneralCategories();

            List<SelectListItem> generalCategoriesSelectListItems = new List<SelectListItem>()
            {
                new SelectListItem(){Value = "",Text = "Select..."}
            };

            foreach (var generalCategory in generalCategories)
            {
                SelectListItem item=new SelectListItem(){Value=generalCategory.Id.ToString(), Text=generalCategory.Name};

                generalCategoriesSelectListItems.Add(item);
            }


            modelVM.GeneralCategories = generalCategoriesSelectListItems;

            return View(modelVM);
        }
        [HttpPost]
        public ActionResult Create(SubCategory subCategory)
        {
            ViewBag.Message = "Saved Successfully!";
            return View();
        }


        public JsonResult GetCategoriesByGeneralCategory(int generalCategoryId)
        {

            var categories = _baseCategoryManager
                .GetCategoriesByGeneralCategory(generalCategoryId)
                .Select(c=>new{Id=c.Id, Name=c.Name});

            return Json(categories,JsonRequestBehavior.AllowGet);
        }
	}
}