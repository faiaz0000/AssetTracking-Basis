using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssetTrackingSystem.Context;
using AssetTrackingSystem.Models.ViewModel;

namespace AssetTrackingSystem.Controllers
{
    public class OrganizationBranchController:Controller
    {
        AssetTrackingSystemDBContext db = new AssetTrackingSystemDBContext();
        public ActionResult Create()
        {

            var organizationBranch = db.OrganizationBranches.SingleOrDefault(m => m.Id == 1);


            var organizationSelectListItems = GetOrganizationSelectListItems();

            var organizationBranchVM = new OrganizationBranchCreateVM();

          


            organizationBranchVM.OrganizationList = organizationSelectListItems;


            return View(organizationBranchVM);
        }

        private List<SelectListItem> GetOrganizationSelectListItems()
        {
            var organizations = db.Organizations.ToList();
            List<SelectListItem> organizationSelectListItems = new List<SelectListItem>();
            organizationSelectListItems.Add(new SelectListItem() {Value = "", Text = "Select..."});

            foreach (var organization in organizations)
            {
                organizationSelectListItems.Add(new SelectListItem()
                {
                    Value = organization.Id.ToString(),
                    Text = organization.Name
                });
            }
            return organizationSelectListItems;
        }

        [HttpPost]
        public ActionResult Create(OrganizationBranchCreateVM organizationBranchCreateVm)
        {
            var organizationBranch = organizationBranchCreateVm.OrganizationBranch;

            db.OrganizationBranches.Add(organizationBranch);

            int rowAffected = db.SaveChanges();

            organizationBranchCreateVm.OrganizationList = GetOrganizationSelectListItems();

            return View(organizationBranchCreateVm);
        }



    }
}