using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AssetTrackingSystem.Models.Validators;

namespace AssetTrackingSystem.Models
{
    public class Organization
    {
        public Organization()
        {
            
        }
        //public Organization(string name,string shortName, string code, string location)
        //{
        //    this.Name = name;
        //    this.ShortName = short;
        //    this.Location = location;
        //}

        
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DisplayName("Short Name")]
        
        public string ShortName { get; set; }


        
        [DisplayName("Code")]
        //[StringLength(3, ErrorMessage = "The Field Short Name must be three character long")]
        [OrganizationCodeValidation]
        public string Code { get; set; }
        public string Location { get; set; }

        public virtual List<OrganizationBranch> Branches { get; set; } 
    }
}