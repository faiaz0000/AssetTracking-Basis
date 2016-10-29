using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssetTrackingSystem.Models.Validators
{
    public class OrganizationCodeValidation:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            string input = value as string;

            if (String.IsNullOrEmpty(input))
            {
                return new ValidationResult("Value must be provided!");
            }

            //var db = new AssetTrackingSystemDBContext();

            //var existingCode = db.Organizations.SingleOrDefault(c => c.Code.ToLower().Equals(input.ToLower()));

            //if (existingCode!=null)
            //{
            //    return new ValidationResult("Code already Exists!");
            //}


            if (input.Length == 3)
            {
                return ValidationResult.Success;
            }

            

            if (input.ToString().Length > 3)
            {
                return new ValidationResult("Your value is more than three characters long!");
            }

            if (input.ToString().Length < 3)
            {
                return new ValidationResult("Your value is less than three characters long!");
            }

            return null;


        }
    }
}