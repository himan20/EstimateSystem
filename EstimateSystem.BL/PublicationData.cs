using AutoMapper;
using EstimateSystem.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstimateSystem.BL
{
    public class PublicationData
    {
        public static List<PublicationBO> GetAllPublications()
        {
            EstimateDBEntities context = new EstimateDBEntities();
            GenericRepository<EstimatePublication> repo = new GenericRepository<EstimatePublication>(context);
            var results = repo.GetAll();
            
            var config = new MapperConfiguration(cfg => cfg.CreateMap<EstimatePublication, PublicationBO>());
            var mapper = config.CreateMapper();
            var publications = mapper.Map<List<PublicationBO>>(results);
            
            return publications;
        }

        public static object GetAllPublicationsForEstimate(int id)
        {
            EstimateDBEntities context = new EstimateDBEntities();
            GenericRepository<EstimatePublication> repo = new GenericRepository<EstimatePublication>(context);
            var results = repo.GetAllWhere(p => p.EST_ID == id);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<EstimatePublication, PublicationBO>());
            var mapper = config.CreateMapper();
            var publications = mapper.Map<List<PublicationBO>>(results);

            return publications;
        }

        public static PublicationBO GetPublicationById(int id)
        {
            EstimateDBEntities context = new EstimateDBEntities();
            GenericRepository<EstimatePublication> repo = new GenericRepository<EstimatePublication>(context);
            var item = repo.GetById(id);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<EstimatePublication, PublicationBO>());
            var mapper = config.CreateMapper();
            var publication = mapper.Map<PublicationBO>(item);
            
            return publication;
        }

        public static void DeletePublications(List<int> ids)
        {
            EstimateDBEntities context = new EstimateDBEntities();
            GenericRepository<EstimatePublication> repo = new GenericRepository<EstimatePublication>(context);

            foreach (var id in ids)
            {
                repo.Delete(id);
            }

            repo.Save();
        }

        public static void Save(PublicationBO pubToAdd)
        {
            EstimateDBEntities context = new EstimateDBEntities();
            GenericRepository<EstimatePublication> repo = new GenericRepository<EstimatePublication>(context);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<PublicationBO, EstimatePublication>());
            var mapper = config.CreateMapper();
            var publication = mapper.Map<EstimatePublication>(pubToAdd);
            
            repo.Insert(publication);

            repo.Save();
        }

        public static void Update(PublicationBO pubToUpdate)
        {
            EstimateDBEntities context = new EstimateDBEntities();
            GenericRepository<EstimatePublication> repo = new GenericRepository<EstimatePublication>(context);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<PublicationBO, EstimatePublication>());
            var mapper = config.CreateMapper();
            var publication = mapper.Map<EstimatePublication>(pubToUpdate);
            
            repo.Update(publication);

            repo.Save();
        }
    }
}
