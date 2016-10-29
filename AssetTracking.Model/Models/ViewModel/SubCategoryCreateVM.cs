using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using AssetTrackingSystemApps.Models;

namespace AssetTracking.Model.Models.ViewModel
{
    public class SubCategoryCreateVM
    {
        public List<SelectListItem> GeneralCategories { get; set; }
        public List<SelectListItem> Categories { get; set; } 
        public SubCategory SubCategory { get; set; }
       

    }
}
