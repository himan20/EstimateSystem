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
    public class ScheduleController : Controller
    {
        // GET: Estimate
        [Route("Schedule/GetAllSchedules")]
        public ActionResult GetAllSchedules()
        {
            var results = ScheduleData.GetAllSchedules();

            var jsonResult = SerializeObjectToJson(results);
            return jsonResult;
        }

        [Route("Schedule/GetAllSchedulesForEdition")]
        public ActionResult GetAllSchedulesForEdition(int id)
        {
            var results = ScheduleData.GetAllSchedulesForEdition(id);

            var jsonResult = SerializeObjectToJson(results);
            return jsonResult;
        }

        [Route("Schedule/SaveSchedule")]
        public ActionResult SaveSchedule(ScheduleBO scheduleEntity)
        {
            if (scheduleEntity.EST_SchID != 0 && scheduleEntity.EST_SchID != null)
            {
                ScheduleData.Update(scheduleEntity);
                return new HttpStatusCodeResult(201, "Update successful");
            }
            else
            {
                ScheduleData.Save(scheduleEntity);
                return new HttpStatusCodeResult(201, "Creation successful");
            }

        }

        [Route("Schedule/GetScheduleById/{id}")]
        public ActionResult GetScheduleById(int id)
        {
            var results = ScheduleData.GetScheduleById(id);

            var jsonResult = SerializeObjectToJson(results);
            return jsonResult;
        }

        [Route("Schedule/DeleteSchedules")]
        public ActionResult DeleteSchedules(List<int> ids)
        {
            ScheduleData.DeleteSchedules(ids);

            return new HttpStatusCodeResult(200, "Deletion Successful");
        }

        [Route("Schedule/GetCaptions")]
        public ActionResult GetCaptions()
        {
            var results = ScheduleData.GetCaptions();

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