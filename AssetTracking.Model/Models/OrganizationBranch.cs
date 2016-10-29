using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssetTrackingSystem.Models
{
    public class OrganizationBranch
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }

        public virtual Organization  Organization { get; set; }

        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}