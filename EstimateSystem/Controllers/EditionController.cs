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
    public class EditionController : Controller
    {
        // GET: Estimate
        [Route("Edition/GetAllEditions")]
        public ActionResult GetAllEditions()
        {
            var results = EditionData.GetAllEditions();

            var jsonResult = SerializeObjectToJson(results);
            return jsonResult;
        }

        [Route("Edition/GetAllEditionsForPublication")]
        public ActionResult GetAllEditionsForPublication(int id)
        {
            var results = EditionData.GetAllEditionsForPublication(id);

            var jsonResult = SerializeObjectToJson(results);
            return jsonResult;
        }


        [Route("Edition/SaveEdition")]
        public ActionResult SaveEdition(EditionBO editionEntity)
        {
            if (editionEntity.EST_EditionID != 0 && editionEntity.EST_EditionID != null)
            {
                EditionData.Update(editionEntity);
                return new HttpStatusCodeResult(201, "Update successful");
            }
            else
            {
                EditionData.Save(editionEntity);
                return new HttpStatusCodeResult(201, "Creation successful");
            }

        }

        [Route("Edition/GetEditionById/{id}")]
        public ActionResult GetEditionById(int id)
        {
            var results = EditionData.GetEditionById(id);

            var jsonResult = SerializeObjectToJson(results);
            return jsonResult;
        }

        [Route("Edition/DeleteEditions")]
        public ActionResult DeleteEditions(List<int> ids)
        {
            EditionData.DeleteEditions(ids);

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