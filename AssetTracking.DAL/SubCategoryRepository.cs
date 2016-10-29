using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTrackingSystem.Context;
using AssetTrackingSystemApps.Models;

namespace AssetTracking.DAL
{
    public class SubCategoryRepository
    {
        private AssetTrackingSystemDBContext db;

        public SubCategoryRepository()
        {
            db = new AssetTrackingSystemDBContext();
            
        }
        public List<SubCategory> GetAll()
        {
            return db.SubCategories.ToList();
        }
    }
}
