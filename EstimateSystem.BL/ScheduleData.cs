using AutoMapper;
using EstimateSystem.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstimateSystem.BL
{
    public class ScheduleData
    {
        public static List<ScheduleBO> GetAllSchedules()
        {
            EstimateDBEntities context = new EstimateDBEntities();
            GenericRepository<EstimateScheduled> repo = new GenericRepository<EstimateScheduled>(context);
            var results = repo.GetAll();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<EstimateScheduled, ScheduleBO>());
            var mapper = config.CreateMapper();
            var schedules = mapper.Map<List<ScheduleBO>>(results);

            return schedules;
        }

        public static object GetAllSchedulesForEdition(int id)
        {
            EstimateDBEntities context = new EstimateDBEntities();
            GenericRepository<EstimateScheduled> repo = new GenericRepository<EstimateScheduled>(context);
            var results = repo.GetAllWhere(p => p.EST_EditionID == id);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<EstimateScheduled, ScheduleBO>());
            var mapper = config.CreateMapper();
            var schedules = mapper.Map<List<ScheduleBO>>(results);

            return schedules;
        }

        public static ScheduleBO GetScheduleById(int id)
        {
            EstimateDBEntities context = new EstimateDBEntities();
            GenericRepository<EstimateScheduled> repo = new GenericRepository<EstimateScheduled>(context);
            var item = repo.GetById(id);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<EstimateScheduled, ScheduleBO>());
            var mapper = config.CreateMapper();
            var schedules = mapper.Map<ScheduleBO>(item);

            return schedules;
        }

        public static void DeleteSchedules(List<int> ids)
        {
            EstimateDBEntities context = new EstimateDBEntities();
            GenericRepository<EstimateScheduled> repo = new GenericRepository<EstimateScheduled>(context);

            foreach (var id in ids)
            {
                repo.Delete(id);
            }

            repo.Save();
        }

        public static object GetCaptions()
        {
            EstimateDBEntities context = new EstimateDBEntities();
            GenericRepository<CaptionMaster> repo = new GenericRepository<CaptionMaster>(context);

            var results = repo.GetAll();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<CaptionMaster, CaptionBO>());
            var mapper = config.CreateMapper();
            var captions = mapper.Map<List<CaptionBO>>(results);
            return captions;
        }

        public static void Save(ScheduleBO schToAdd)
        {
            EstimateDBEntities context = new EstimateDBEntities();
            GenericRepository<EstimateScheduled> repo = new GenericRepository<EstimateScheduled>(context);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<ScheduleBO, EstimateScheduled>());
            var mapper = config.CreateMapper();
            var schedule = mapper.Map<EstimateScheduled>(schToAdd);

            repo.Insert(schedule);

            repo.Save();
        }

        public static void Update(ScheduleBO schToUpdate)
        {
            EstimateDBEntities context = new EstimateDBEntities();
            GenericRepository<EstimateScheduled> repo = new GenericRepository<EstimateScheduled>(context);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<ScheduleBO, EstimateScheduled>());
            var mapper = config.CreateMapper();
            var schedule = mapper.Map<EstimateScheduled>(schToUpdate);

            repo.Update(schedule);

            repo.Save();
        }
    }
}
