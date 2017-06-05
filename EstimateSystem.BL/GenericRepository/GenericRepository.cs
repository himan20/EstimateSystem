using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstimateSystem.BL
{
    public class GenericRepository<T> where T : class
    {
        #region Private Members
        private EstimateDBEntities Context;
        private DbSet<T> DbSet;
        #endregion

        #region Constructor
        public GenericRepository(EstimateDBEntities context)
        {
            this.Context = context;
            this.DbSet = context.Set<T>();
        }
        #endregion

        public List<T> GetAll() {
            var query = DbSet;
            return query.ToList();
        }

        public T GetById(int ID)
        {
            var query = DbSet.Find(ID);
            return query;
        }

        public void Insert(T newEntity)
        {
            DbSet.Add(newEntity);
        }

        public void Delete(int ID)
        {
            var entityToDelete = DbSet.Find(ID);
            DbSet.Remove(entityToDelete);
        }

        public void Update(T entityToUpdate)
        {
            DbSet.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public List<T> GetAllWhere(Func<T, bool> where)
        {
            return DbSet.Where(where).Select(a => a).ToList();
        }
        
        //Generic Save method
        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
