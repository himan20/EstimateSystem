using AutoMapper;
using EstimateSystem.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstimateSystem.BL
{
    public class EditionData
    {
        public static List<EditionBO> GetAllEditions()
        {
            EstimateDBEntities context = new EstimateDBEntities();
            GenericRepository<EstimateEdition> repo = new GenericRepository<EstimateEdition>(context);
            var results = repo.GetAll();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<EstimateEdition, EditionBO>());
            var mapper = config.CreateMapper();
            var editions = mapper.Map<List<EditionBO>>(results);

            return editions;
        }

        public static object GetAllEditionsForPublication(int id)
        {
            EstimateDBEntities context = new EstimateDBEntities();
            GenericRepository<EstimateEdition> repo = new GenericRepository<EstimateEdition>(context);
            var results = repo.GetAllWhere(p => p.EST_PUBID == id);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<EstimateEdition, EditionBO>());
            var mapper = config.CreateMapper();
            var editions = mapper.Map<List<EditionBO>>(results);

            return editions;
        }

        public static EditionBO GetEditionById(int id)
        {
            EstimateDBEntities context = new EstimateDBEntities();
            GenericRepository<EstimateEdition> repo = new GenericRepository<EstimateEdition>(context);
            var item = repo.GetById(id);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<EstimateEdition, EditionBO>());
            var mapper = config.CreateMapper();
            var edition = mapper.Map<EditionBO>(item);

            return edition;
        }

        public static void DeleteEditions(List<int> ids)
        {
            EstimateDBEntities context = new EstimateDBEntities();
            GenericRepository<EstimateEdition> repo = new GenericRepository<EstimateEdition>(context);

            foreach (var id in ids)
            {
                repo.Delete(id);
            }

            repo.Save();
        }

        public static void Save(EditionBO editionToAdd)
        {
            EstimateDBEntities context = new EstimateDBEntities();
            GenericRepository<EstimateEdition> repo = new GenericRepository<EstimateEdition>(context);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<EditionBO, EstimateEdition>());
            var mapper = config.CreateMapper();
            var edition = mapper.Map<EstimateEdition>(editionToAdd);

            repo.Insert(edition);

            repo.Save();
        }

        public static void Update(EditionBO editionToUpdate)
        {
            EstimateDBEntities context = new EstimateDBEntities();
            GenericRepository<EstimateEdition> repo = new GenericRepository<EstimateEdition>(context);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<EditionBO, EstimateEdition>());
            var mapper = config.CreateMapper();
            var edition = mapper.Map<EstimateEdition>(editionToUpdate);

            repo.Update(edition);

            repo.Save();
        }
    }
}
