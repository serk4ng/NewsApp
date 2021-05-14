using StrasbourgNews.DAL.Models;
using StrasbourgNews.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StrasbourgNews.DAL.Repository
{
    public class STNRepository<T> where T : BaseModel
    {
        private readonly DbContext _baContext;
        private readonly DbSet<T> _dbSet;

        public STNRepository(STNUnitOfWork uow)
        {
            _baContext = uow.GetContext();
            _dbSet = _baContext.Set<T>();
        }
        public virtual void Add(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(typeof(T).Name + " boş olamaz");

            entity.IsItDeleted = false;
            _dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(typeof(T).Name + " boş olamaz.");

            _dbSet.Attach(entity);
            _baContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(typeof(T).Name + " boş olamaz.");

            entity.IsItDeleted = true;
            entity.Status = false;
            Update(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> query)
        {
            if (query == null) throw new ArgumentNullException(typeof(T).Name + " sorgu boş olamaz.");

            ICollection<T> list = GetList(query).ToList();
            foreach (var item in list)
            {
                item.IsItDeleted = true;
                item.Status = false;
                Update(item);
            }
        }

        public virtual T Get(Expression<Func<T, bool>> query, params Expression<Func<T, object>>[] includeExpressions)
        {
            var newquery = _dbSet.Where(x => x.IsItDeleted == false);

            if (includeExpressions.Any())
                newquery = includeExpressions.Aggregate(newquery, (current, includeExpression) => current.Include(includeExpression));

            var result = newquery.SingleOrDefault(query);

            return result;
        }

        public virtual IQueryable<T> GetList(Expression<Func<T, bool>> query = null, params Expression<Func<T, object>>[] includeExpressions)
        {
            var newquery = _dbSet.Where(x => x.IsItDeleted == false);

            if (query != null)
                newquery = newquery.Where(query);


            if (includeExpressions.Any())
                newquery = includeExpressions.Aggregate(newquery, (current, includeExpression) => current.Include(includeExpression));


            return newquery;
        }

        public virtual int GetCount(Expression<Func<T, bool>> query = null)
        {
            return query == null ? _dbSet.Count(x => x.IsItDeleted == false) : _dbSet.Where(x => x.IsItDeleted == false).Count(query);
        }

        public virtual bool Any(Expression<Func<T, bool>> query = null)
        {
            return query == null ? _dbSet.Any(x => x.IsItDeleted == false) : _dbSet.Where(x => x.IsItDeleted == false).Any(query);
        }
    }
}
