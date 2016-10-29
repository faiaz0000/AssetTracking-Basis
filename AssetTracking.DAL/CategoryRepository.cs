using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracking.Model.Models;
using AssetTrackingSystem.Context;

namespace AssetTracking.DAL
{
    public class CategoryRepository
    {

        private AssetTrackingSystemDBContext db;

        public CategoryRepository()
        {
            db = new AssetTrackingSystemDBContext();
        }

        public List<Category> GetCategoriesByGeneralCategory(int generalCategoryId)
        {
            return db.Categories.Where(c => c.GeneralCategoryId == generalCategoryId).ToList();
        }
    }
}
