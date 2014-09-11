using System.Linq;

namespace rg.GenericRepository.Core
{
    public interface IRepository<TEntity>
        where TEntity : class, IEntity
    {
        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Insert(TEntity entity);

        /// <summary>
        /// Gets the entity with the specified id.
        /// </summary>
        /// <param name="entityId">The entity id.</param>
        /// <returns></returns>
        TEntity GetSingle(int entityId);

        /// <summary>
        /// Gets all the entities.
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Update(TEntity entity);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Delete(TEntity entity);

        /// <summary>
        /// Saves the changes.
        /// </summary>
        void SaveChanges();
    }
}
