using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssetTrackingSystem.Models.ViewModel
{
    public class OrganizationBranchCreateVM
    {
        public OrganizationBranch OrganizationBranch { get; set; }

        public List<SelectListItem> OrganizationList { get; set; } 



    }
}