using EstimateSystem.BL;
using EstimateSystem.BO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EstimateSystem.Controllers
{
    public class PublicationController : Controller
    {
        // GET: Estimate
        [Route("Publication/GetAllPublications")]
        public ActionResult GetAllPublications()
        {
            var results = PublicationData.GetAllPublications();

            var jsonResult = SerializeObjectToJson(results);
            return jsonResult;
        }

        [Route("Publication/GetAllPublicationsForEstimate")]
        public ActionResult GetAllPublicationsForEstimate(int id)
        {
            var results = PublicationData.GetAllPublicationsForEstimate(id);

            var jsonResult = SerializeObjectToJson(results);
            return jsonResult;
        }


        [Route("Publication/SavePublication")]
        public ActionResult SavePublication(PublicationBO publicationEntity)
        {
            if (publicationEntity.EST_PUBID != 0 && publicationEntity.EST_PUBID != null)
            {
                PublicationData.Update(publicationEntity);
                return new HttpStatusCodeResult(201, "Update successful");
            }
            else
            {
                PublicationData.Save(publicationEntity);
                return new HttpStatusCodeResult(201, "Creation successful");
            }

        }

        [Route("Publication/GetPublicationById/{id}")]
        public ActionResult GetPublicationById(int id)
        {
            var results = PublicationData.GetPublicationById(id);

            var jsonResult = SerializeObjectToJson(results);
            return jsonResult;
        }

        [Route("Publication/DeletePublications")]
        public ActionResult DeletePublications(List<int> ids)
        {
            PublicationData.DeletePublications(ids);

            return new HttpStatusCodeResult(200, "Deletion Successful");
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