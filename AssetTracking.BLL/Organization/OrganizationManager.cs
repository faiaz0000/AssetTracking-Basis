using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AssetTrackingSystem.DAL;
using AssetTrackingSystem.Models;

namespace AssetTrackingSystem.BLL
{
    public class OrganizationManager
    {
        private OrganizationRepository _organizationRepository;

        public OrganizationManager()
        {
            _organizationRepository = new OrganizationRepository();
        }

        public bool Save(Organization organization)
        {
            
            //everything is alright

            int rowAffected = _organizationRepository.Save(organization);

            bool isSaved = rowAffected > 0;

            return isSaved;
            
        }

        public List<Organization> GetAll()
        {
            return _organizationRepository.GetAll();
        }


    }
}