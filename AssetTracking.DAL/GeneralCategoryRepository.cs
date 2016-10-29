using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTrackingSystem.Context;
using AssetTrackingSystemApps.Models;

namespace AssetTracking.DAL
{
    public class GeneralCategoryRepository
    {
        private AssetTrackingSystemDBContext db;

        public GeneralCategoryRepository()
        {
            db = new AssetTrackingSystemDBContext();
        }
        public List<GeneralCategory> GetAll()
        {
            return db.GeneralCategories.ToList();
        }
    }
}
