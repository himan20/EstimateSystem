using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstimateSystem.BO;
using AutoMapper;

namespace EstimateSystem.BL
{
    public class EstimateData
    {
        public static List<EstimateBO> GetAllEstimates()
        {
            EstimateDBEntities context = new EstimateDBEntities();
            GenericRepository<EstimateHeader> repo = new GenericRepository<EstimateHeader>(context);
            var results = repo.GetAll();

            //List<EstimateBO> estimates = new List<EstimateBO>();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<EstimateHeader,EstimateBO>());
            var mapper = config.CreateMapper();
            var estimates = mapper.Map<List<EstimateBO>>(results);

            //foreach (var item in results)
            //{
            //    var estimate = new EstimateBO
            //    {
            //        AAC_PER = item.AAC_PER,
            //        Agency = item.Agency,
            //        BrandID = item.BrandID,
            //        Campaign = item.Campaign,
            //        ClientID = item.ClientID,
            //        EST_Date = item.EST_Date,
            //        EST_ID = item.EST_ID,
            //        EST_NO = item.EST_NO,
            //        Gross_Cost = item.Gross_Cost,
            //        Net_Cost = item.Net_Cost,
            //        PeriodFrom = item.PeriodFrom,
            //        PeriodTo = item.PeriodTo,
            //        PO_Date = item.PO_Date,
            //        PO_NO = item.PO_NO,
            //        SAC_PER = item.SAC_PER,
            //        Status = item.Status
            //    };
            //    estimates.Add(estimate);
            //}
            return estimates;
        }

        public static EstimateBO GetEstimateById(int id)
        {
            EstimateDBEntities context = new EstimateDBEntities();
            GenericRepository<EstimateHeader> repo = new GenericRepository<EstimateHeader>(context);
            var item = repo.GetById(id);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<EstimateHeader, EstimateBO>());
            var mapper = config.CreateMapper();
            var estimate = mapper.Map<EstimateBO>(item);

            //var estimate = new EstimateBO
            //{
            //    AAC_PER = item.AAC_PER,
            //    Agency = item.Agency,
            //    BrandID = item.BrandID,
            //    Campaign = item.Campaign,
            //    ClientID = item.ClientID,
            //    EST_Date = item.EST_Date,
            //    EST_ID = item.EST_ID,
            //    EST_NO = item.EST_NO,
            //    Gross_Cost = item.Gross_Cost,
            //    Net_Cost = item.Net_Cost,
            //    PeriodFrom = item.PeriodFrom,
            //    PeriodTo = item.PeriodTo,
            //    PO_Date = item.PO_Date,
            //    PO_NO = item.PO_NO,
            //    SAC_PER = item.SAC_PER,
            //    Status = item.Status
            //};
            return estimate;
        }

        public static object GetBrands()
        {
            EstimateDBEntities context = new EstimateDBEntities();
            GenericRepository<BrandMaster> repo = new GenericRepository<BrandMaster>(context);

            var results = repo.GetAll();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<BrandMaster, BrandBO>());
            var mapper = config.CreateMapper();
            var brands = mapper.Map<List<BrandBO>>(results);
            return brands;
        }

        public static List<ClientBO> GetClients()
        {
            EstimateDBEntities context = new EstimateDBEntities();
            GenericRepository<ClientMaster> repo = new GenericRepository<ClientMaster>(context);

           var results = repo.GetAll();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<ClientMaster, ClientBO>());
            var mapper = config.CreateMapper();
            var clients = mapper.Map<List<ClientBO>>(results);
            return clients;
        }

        public static void DeleteEstimates(List<int> ids)
        {
            EstimateDBEntities context = new EstimateDBEntities();
            GenericRepository<EstimateHeader> repo = new GenericRepository<EstimateHeader>(context);

            foreach (var id in ids)
            {
                repo.Delete(id);
            }

            repo.Save();
        }

        public static void Save(EstimateBO estimateToAdd)
        {
            EstimateDBEntities context = new EstimateDBEntities();
            GenericRepository<EstimateHeader> repo = new GenericRepository<EstimateHeader>(context);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<EstimateBO, EstimateHeader> ());
            var mapper = config.CreateMapper();
            var estimate = mapper.Map<EstimateHeader>(estimateToAdd);

            //var estimate = new EstimateHeader
            //{
            //    AAC_PER = estimateToAdd.AAC_PER,
            //    Agency = estimateToAdd.Agency,
            //    BrandID = estimateToAdd.BrandID,
            //    Campaign = estimateToAdd.Campaign,
            //    ClientID = estimateToAdd.ClientID,
            //    EST_Date = estimateToAdd.EST_Date,
            //    EST_ID = estimateToAdd.EST_ID,
            //    EST_NO = estimateToAdd.EST_NO,
            //    Gross_Cost = estimateToAdd.Gross_Cost,
            //    Net_Cost = estimateToAdd.Net_Cost,
            //    PeriodFrom = estimateToAdd.PeriodFrom,
            //    PeriodTo = estimateToAdd.PeriodTo,
            //    PO_Date = estimateToAdd.PO_Date,
            //    PO_NO = estimateToAdd.PO_NO,
            //    SAC_PER = estimateToAdd.SAC_PER,
            //    Status = estimateToAdd.Status

            //};
            repo.Insert(estimate);

            repo.Save();
        }

        public static void Update(EstimateBO estimateToUpdate)
        {
            EstimateDBEntities context = new EstimateDBEntities();
            GenericRepository<EstimateHeader> repo = new GenericRepository<EstimateHeader>(context);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<EstimateBO, EstimateHeader>());
            var mapper = config.CreateMapper();
            var estimate = mapper.Map<EstimateHeader>(estimateToUpdate);

            //var estimate = new EstimateHeader
            //{
            //    AAC_PER = estimateToUpdate.AAC_PER,
            //    Agency = estimateToUpdate.Agency,
            //    BrandID = estimateToUpdate.BrandID,
            //    Campaign = estimateToUpdate.Campaign,
            //    ClientID = estimateToUpdate.ClientID,
            //    EST_Date = estimateToUpdate.EST_Date,
            //    EST_ID = estimateToUpdate.EST_ID,
            //    EST_NO = estimateToUpdate.EST_NO,
            //    Gross_Cost = estimateToUpdate.Gross_Cost,
            //    Net_Cost = estimateToUpdate.Net_Cost,
            //    PeriodFrom = estimateToUpdate.PeriodFrom,
            //    PeriodTo = estimateToUpdate.PeriodTo,
            //    PO_Date = estimateToUpdate.PO_Date,
            //    PO_NO = estimateToUpdate.PO_NO,
            //    SAC_PER = estimateToUpdate.SAC_PER,
            //    Status = estimateToUpdate.Status

            //};
            repo.Update(estimate);

            repo.Save();
        }

    }
}
