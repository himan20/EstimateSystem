using EstimateSystem.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using EstimateSystem.BO;

namespace EstimateSystem.Controllers
{
    
    public class EstimateController : Controller
    {
        // GET: Estimate
        [Route("Estimate/GetAllEstimates")]
        public ActionResult GetAllEstimates()
        {
            var results = EstimateData.GetAllEstimates();

            var jsonResult = SerializeObjectToJson(results);
            return jsonResult;
        }

        [Route("Estimate/SaveEstimate")]
        public ActionResult SaveEstimate(EstimateBO estimateEntity)
        {
            if(estimateEntity.EST_ID != 0 && estimateEntity.EST_ID != null)
            {
                EstimateData.Update(estimateEntity);
                return new HttpStatusCodeResult(201, "Update successful");
            }
            else
            {
                EstimateData.Save(estimateEntity);
                return new HttpStatusCodeResult(201, "Creation successful");
            }

        }

        [Route("Estimate/GetEstimateById/{id}")]
        public ActionResult GetEstimateById(int id)
        {
            var results = EstimateData.GetEstimateById(id);

            var jsonResult = SerializeObjectToJson(results);
            return jsonResult;
        }

        [Route("Estimate/DeleteEstimates")]
        public ActionResult DeleteEstimates(List<int> ids)
        {
            EstimateData.DeleteEstimates(ids);

            return new HttpStatusCodeResult(200, "Deletion Successful");
        }


        //[Route("Estimate/TrialPost")]
        //public ActionResult TrialPost(EstimateBO est)
        //{
        //    return new HttpStatusCodeResult(200, "Success");
        //}

        [Route("Estimate/GetClients")]
        public ActionResult GetClients()
        {
            var results = EstimateData.GetClients();

            var jsonResult = SerializeObjectToJson(results);
            return jsonResult;
        }

        [Route("Estimate/GetBrands")]
        public ActionResult GetBrands()
        {
            var results = EstimateData.GetBrands();

            var jsonResult = SerializeObjectToJson(results);
            return jsonResult;
        }


        public ContentResult SerializeObjectToJson(object obj)
        {
            var camelCaseFormatter = new JsonSerializerSettings();
            camelCaseFormatter.ContractResolver = new CamelCasePropertyNamesContractResolver();
            var jsonResult = new ContentResult
            {
                Content = JsonConvert.SerializeObject(obj, camelCaseFormatter),
                ContentType = "application/json"
            };
            return jsonResult;
        }
    }
}