using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracking.DAL;
using AssetTracking.Model.Models;
using AssetTrackingSystemApps.Models;

namespace AssetTracking.BLL.Organization
{
    public class BaseCategoryManager
    {
        private GeneralCategoryRepository _generalCategoryRepository;
        private CategoryRepository _categoryRepository;
        private SubCategoryRepository _subCategoryRepository;

        public BaseCategoryManager()
        {
            _generalCategoryRepository = new GeneralCategoryRepository();
            _categoryRepository = new CategoryRepository();
            _subCategoryRepository = new SubCategoryRepository();
        }
        public List<GeneralCategory> GetAllGeneralCategories()
        {
            return _generalCategoryRepository.GetAll();
        }

        public List<Category> GetCategoriesByGeneralCategory(int generalCategoryId)
        {
            return _categoryRepository.GetCategoriesByGeneralCategory(generalCategoryId);
        }
    }
}
