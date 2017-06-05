using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstimateSystem.BL.Repository
{
    public class EstimateHeaderRepository
    {
        //Get All
         public List<EstimateHeader> GetAllEstimates()
        {
            try
            {
                using (EstimateDBEntities context = new EstimateDBEntities())
                {
                    var query = context.EstimateHeaders.Select(e => e).ToList();
                    return query;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }   
        //Get by Id
        public EstimateHeader GetEstimateById(int estimateID)
        {
            try
            {
                using (EstimateDBEntities context = new EstimateDBEntities())
                {
                    var query = context.EstimateHeaders.Where(e => e.EST_ID == estimateID).Select(e => e).FirstOrDefault();
                    return query;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Save
        //public void SaveEstimate(EstimateHeader newEstimate)
        //{
        //    try
        //    {
        //        using (EstimateDBEntities context = new EstimateDBEntities())
        //        {
        //            var query = context.EstimateHeaders.Where(e => e.EST_ID == estimateID).Select(e => e).FirstOrDefault();
        //            return query;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        //Update

        //Delete
    }
}
