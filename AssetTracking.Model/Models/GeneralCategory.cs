using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssetTrackingSystemApps.Models
{
    public class GeneralCategory
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(2, MinimumLength = 2)]
        
        public string Code { get; set; }
    }
}