using System;
using System.Data.Entity;
using System.Linq;
using rg.GenericRepository.Core;

namespace rg.GenericRepository.Impl.EF
{
    // http://www.asp.net/mvc/tutorials/getting-started-with-ef-using-mvc/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application

    public class SqlRepository<TEntity> : IRepository<TEntity>
            where TEntity : class, IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SqlRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <exception cref="System.ArgumentNullException">context</exception>
        public SqlRepository(DbContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public TEntity GetSingle(int entityId)
        {
            return _dbSet.Find(entityId);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            Delete(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        // Not currently used
        //public virtual IEnumerable<TEntity> Get(
        //    Expression<Func<TEntity, bool>> filter = null,
        //    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        //    string includeProperties = "")
        //{
        //    IQueryable<TEntity> query = dbSet;

        //    if (filter != null)
        //    {
        //        query = query.Where(filter);
        //    }

        //    foreach (var includeProperty in includeProperties.Split
        //        (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        //    {
        //        query = query.Include(includeProperty);
        //    }

        //    if (orderBy != null)
        //    {
        //        return orderBy(query).ToList();
        //    }
        //    else
        //    {
        //        return query.ToList();
        //    }
        //}

        #region Private fields

        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        #endregion
    }
}
