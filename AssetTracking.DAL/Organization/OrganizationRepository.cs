using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AssetTrackingSystem.Context;
using AssetTrackingSystem.Models;

namespace AssetTrackingSystem.DAL
{
    public class OrganizationRepository:IDisposable
    {
        private AssetTrackingSystemDBContext db;
        public OrganizationRepository()
        {
            db = new AssetTrackingSystemDBContext();
        }
        public int Save(Organization organization)
        {
            db.Organizations.Add(organization);
            int rowAffected = db.SaveChanges();
            return rowAffected;
        }

        public int Update(Organization organization)
        {
            db.Organizations.Attach(organization);
            db.Entry(organization).State = EntityState.Modified;
            return db.SaveChanges();
        }

        public List<Organization> GetAll()
        {
            return db.Organizations.ToList();
        }

        
        public void Dispose()
        {
            if (db!=null)
            {
                db.Dispose();
            }
        }
    }
}