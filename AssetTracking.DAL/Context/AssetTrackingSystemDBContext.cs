using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AssetTracking.Model.Models;
using AssetTrackingSystem.Models;
using AssetTrackingSystemApps.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AssetTrackingSystem.Context
{
    public class AssetTrackingSystemDBContext:IdentityDbContext<ApplicationUser>
    {

        public AssetTrackingSystemDBContext()
            : base("AssetTrackingSystemDBContext")
        {
            
        }

        public DbSet<Organization> Organizations { get; set; }
        public DbSet<OrganizationBranch> OrganizationBranches { get; set; }

        public DbSet<GeneralCategory> GeneralCategories { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
    }
}