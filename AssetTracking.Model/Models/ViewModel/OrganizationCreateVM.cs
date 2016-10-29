using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;

namespace AssetTrackingSystem.Models.ViewModel
{
    public class OrganizationCreateVM
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string ShortName { get; set; }
        public string Location { get; set; }
        public List<Organization> Organizations { get; set; }
    }
}