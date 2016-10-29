using System.ComponentModel.DataAnnotations;
using AssetTrackingSystemApps.Models;

namespace AssetTracking.Model.Models
{
    public class Category
    {
        public virtual GeneralCategory GeneralCategory { get; set; }
        public int Id { get; set; }

        public int GeneralCategoryId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        public string Description { get; set; }
    }
}