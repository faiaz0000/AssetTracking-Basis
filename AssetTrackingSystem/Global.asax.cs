using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AssetTrackingSystem.Models;
using AssetTrackingSystem.Models.ViewModel;
using AutoMapper;

namespace AssetTrackingSystem
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Mapper.Initialize(configuration =>
            {

                configuration.CreateMap<OrganizationCreateVM, Organization>();
            }

            );
        }
    }
}
