using System.Collections.Generic;
using System.Linq;
using rg.GenericRepository.Core;

namespace rg.GenericRepository.Impl.InMemory
{
    public class InMemoryRepository<TEntity> : IRepository<TEntity> 
        where TEntity : class, IEntity
    {
        public void Insert(TEntity entity)
        {
            Entities.Add(entity);

            //if (entity.Id == 0)
            //    entity.Id = _entities.Count;
        }

        public TEntity GetSingle(int entityId)
        {
            return Entities.Find(e => e.Id == entityId);
        }

        public IQueryable<TEntity> GetAll()
        {
            return Entities.AsQueryable();
        }

        public void Update(TEntity entity)
        {
            // do nothing
        }

        public void Delete(TEntity entity)
        {
            Entities.Remove(entity);
        }

        public void SaveChanges()
        {
            // do nothing
        }

        protected readonly List<TEntity> Entities = new List<TEntity>();
    }
}
