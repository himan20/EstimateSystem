using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstimateSystem.BL.Repository
{
    public class MasterRepository
    {
        // Masters will only be modified from the Database - current implementation
        #region Client Master
        //Get all Clients
        public List<ClientMaster> GetAllClients()
        {
            try
            {
                using (EstimateDBEntities context = new EstimateDBEntities())
                {
                    var query = context.ClientMasters.Select(c => c).ToList();
                    return query;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Get Client By Id
        public ClientMaster GetClientById(int clientID)
        {
            try
            {
                using(EstimateDBEntities context = new EstimateDBEntities())
                {
                    var query = context.ClientMasters.Where(c => c.ClientID == clientID).Select(c => c).FirstOrDefault();
                    return query;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Brand Master
        //Get all Brands
        public List<BrandMaster> GetAllBrands()
        {
            try
            {
                using (EstimateDBEntities context = new EstimateDBEntities())
                {
                    var query = context.BrandMasters.Select(b => b).ToList();
                    return query;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Get Brand By Id
        public BrandMaster GetBrandById(int brandID)
        {
            try
            {
                using (EstimateDBEntities context = new EstimateDBEntities())
                {
                    var query = context.BrandMasters.Where(b => b.BrandID == brandID).Select(b => b).FirstOrDefault();
                    return query;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Caption Master
        //Get all Captions
        public List<CaptionMaster> GetAllCaptions()
        {
            try
            {
                using (EstimateDBEntities context = new EstimateDBEntities())
                {
                    var query = context.CaptionMasters.Select(c => c).ToList();
                    return query;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Get Caption By Id
        public CaptionMaster GetCaptionById(int captionID)
        {
            try
            {
                using (EstimateDBEntities context = new EstimateDBEntities())
                {
                    var query = context.CaptionMasters.Where(c => c.CaptionID == captionID).Select(c => c).FirstOrDefault();
                    return query;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

    }
}
