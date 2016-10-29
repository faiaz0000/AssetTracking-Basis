using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using AssetTrackingSystem.BLL;
using AssetTrackingSystem.Context;
using AssetTrackingSystem.Models;
using AssetTrackingSystem.Models.ViewModel;
using AutoMapper;

namespace AssetTrackingSystem.Controllers
{
    public class OrganizationController : Controller
    {
        AssetTrackingSystemDBContext db = new AssetTrackingSystemDBContext();

        private OrganizationManager _organizationManager;

        public OrganizationController()
        {
            _organizationManager = new OrganizationManager();
        }
        public ActionResult Create()
        {
            var model = new OrganizationCreateVM();
            model.Organizations = db.Organizations.ToList();
            return View(model);
        }

        [HttpPost]
        public ViewResult Create(OrganizationCreateVM modelVM)
        {
            if (ModelState.IsValid)
            {
                Organization organization = Mapper.Map<Organization>(modelVM);
                bool isSaved = _organizationManager.Save(organization);

                if (isSaved)
                {
                    ViewBag.Message = "Saved Successfully!";
                }
            }
            
            return View(modelVM);
        }

        public ActionResult Search()
        {
            var organizations = GetAllOrganizations();
            return View(organizations);
        }

        [HttpPost]
        public ActionResult Search(OrganizationSearchCriteriaViewModel organizationSearchCriteria)
        {
            var organizations = GetOrganizationBySearchCriteria(organizationSearchCriteria);
            return View(organizations);
        }
        private List<Organization> GetAllOrganizations()
        {
            var organizations = db.Organizations.ToList();
            return organizations;

        }

        public List<Organization> GetOrganizationBySearchCriteria(OrganizationSearchCriteriaViewModel searchCriteriaViewModel)
        {
            var organizations = db.Organizations.AsQueryable();


            if (!String.IsNullOrEmpty(searchCriteriaViewModel.Name))
            {
                organizations = organizations.Where(c => c.Name.ToLower().Contains(searchCriteriaViewModel.Name.ToLower()));
            }

            if (!String.IsNullOrEmpty(searchCriteriaViewModel.Code))
            {
                organizations = organizations.Where(c => c.Code.Equals(searchCriteriaViewModel.Code));
            }

            if (!String.IsNullOrEmpty(searchCriteriaViewModel.Location))
            {
                organizations = organizations.Where(c => c.Location.ToLower().Contains(searchCriteriaViewModel.Location));
            }

            return organizations.OrderBy(o => o.Name).ToList();
        }

        [HttpPost]
        public ActionResult Edit(Organization organization)
        {
            //var existingOrganization = db.Organizations.SingleOrDefault(c => c.Id == organization.Id);


            //existingOrganization.Code = organization.Code;
            //existingOrganization.Name = organization.Name;
            //existingOrganization.Location = organization.Location;




            db.Organizations.Attach(organization);
            db.Entry(organization).State = EntityState.Modified;
            int rowAffected = db.SaveChanges();
            

            if (rowAffected>0)
            {
                ViewBag.Message = "Updated Successfully!";
            }
            return View(organization);
        }

        public ActionResult Edit(int? id)
        {
            if (id==null)
            {
                return HttpNotFound();
            }

            var existingOrganization = db.Organizations.SingleOrDefault(c => c.Id == id);

            if (existingOrganization == null)
            {
                return HttpNotFound();
            }
            return View(existingOrganization);
        }
    }
}