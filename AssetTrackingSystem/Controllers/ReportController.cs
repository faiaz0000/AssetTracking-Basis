using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using AssetTrackingSystem.BLL;
using Microsoft.Reporting.WebForms;

namespace AssetTrackingSystem.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report

        OrganizationManager orgnanizationManager = new OrganizationManager();
        public ActionResult OrganizationList()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OrganizationList(OrganizationListSearchCriteriaVM model)
        {
            var organizations = orgnanizationManager.GetAll();

            if (!String.IsNullOrEmpty(model.Name))
            {
                organizations = organizations.Where(c => c.Name.Contains(model.Name)).ToList();

            }

            if (!String.IsNullOrEmpty(model.Code ))
            {
                organizations = organizations.Where(c => c.Code.Contains(model.Code)).ToList();
            }


            ReportViewer reportViewer = new ReportViewer();
            reportViewer.KeepSessionAlive = true;
            reportViewer.SizeToReportContent = true;
            reportViewer.Width = new Unit(100);


            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) +
                                                  @"\Report\OrganizationReport.rdlc";

            ReportDataSource rds = new ReportDataSource("DS_Organization",organizations);

            reportViewer.LocalReport.DataSources.Add(rds);

            ReportParameter parameter = new ReportParameter("ReportName","Detail Report For Organization "+model.Name + " "+model.Code);

            reportViewer.LocalReport.SetParameters(parameter);

            ViewBag.ReportViewer = reportViewer;

            return PartialView("_Report");
        }
    }

    public class OrganizationListSearchCriteriaVM
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}