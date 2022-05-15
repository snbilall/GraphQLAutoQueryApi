using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Transactions;

namespace DataLayer.GenericRepositoryBase
{
    public class RepositoryBase<TContext> : IRepositoryBase where TContext : DbContext
    {
        private TContext _context { get; set; }

        protected RepositoryBase(TContext context)
        {
            _context = context;
        }

        public async Task<T> FirstOrDefaultNoLockAsync<T>(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, params Expression<Func<T, object>>[] includes) where T : BaseEntity
        {

            using (var scope = new TransactionScope(
           TransactionScopeOption.Required,
           new TransactionOptions()
           {
               IsolationLevel = IsolationLevel.ReadUncommitted
           }, TransactionScopeAsyncFlowOption.Enabled))
            {
                var query = constructQuery(predicate, includes, orderBy).AsNoTracking();
                var response = await query.FirstOrDefaultAsync();
                scope.Complete();
                return response;
            }
        }
        public virtual Task<T> FirstOrDefaultAsync<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
            where T : BaseEntity
        {
            var query = constructQuery(predicate, includes, null);
            return query.FirstOrDefaultAsync();
        }
        public virtual Task<T> SingleOrDefaultAsync<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes) where T : BaseEntity
        {
            var query = constructQuery(predicate, includes, null);
            return query.SingleOrDefaultAsync();
        }
        public virtual async Task<T> SingleOrDefaultNoLockAsync<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes) where T : BaseEntity
        {

            using (var scope = new TransactionScope(
          TransactionScopeOption.Required,
          new TransactionOptions()
          {
              IsolationLevel = IsolationLevel.ReadUncommitted
          }, TransactionScopeAsyncFlowOption.Enabled))
            {
                var query = constructQuery(predicate, includes).AsNoTracking();
                var response = await query.SingleOrDefaultAsync();
                scope.Complete();
                return response;
            }
        }
        public virtual IQueryable<T> Query<T>() where T : BaseEntity
        {
            var set = _context.Set<T>().AsQueryable();
            return set;
        }
        public virtual Task<int> CountAsync<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity
        {
            var query = constructQuery(predicate, null, null);

            return query.CountAsync();
        }
        public virtual int Count<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity
        {

            var query = constructQuery(predicate, null, null);
            int toReturn = query.Count();
            return toReturn;
        }
        public virtual int CountNoLock<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity
        {

            using (var scope = new TransactionScope(
            TransactionScopeOption.Required,
            new TransactionOptions()
            {
                IsolationLevel = IsolationLevel.ReadUncommitted
            }))
            {

                var query = constructQuery(predicate, null, null).AsNoTracking();
                int toReturn = query.Count();
                scope.Complete();
                return toReturn;
            }
        }
        public virtual async Task<int> CountNoLockAsync<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity
        {

            using (var scope = new TransactionScope(
            TransactionScopeOption.Required,
            new TransactionOptions()
            {
                IsolationLevel = IsolationLevel.ReadUncommitted
            }, TransactionScopeAsyncFlowOption.Enabled))
            {

                var query = constructQuery(predicate, null, null).AsNoTracking();
                int toReturn = await query.CountAsync();
                scope.Complete();
                return toReturn;
            }
        }

        public virtual Task<List<T>> GetAsync<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
            where T : BaseEntity
        {
            var query = constructQuery(predicate, includes, null);

            return query.ToListAsync();
        }

        private IQueryable<T> constructQuery<T>(Expression<Func<T, bool>> predicate, Expression<Func<T, object>>[] includes, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null) where T : BaseEntity
        {
            var query = (predicate == null) ?
                _context.Set<T>() :
                _context.Set<T>().Where(predicate);
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query;
        }


        public virtual void Add<T>(params T[] entities)
            where T : BaseEntity
        {
            foreach (var entity in entities)
            {
                if (entity != null)
                {
                    _context.Set<T>().Add(entity);
                }
            }
        }

        public virtual void Delete<T>(T entity)
            where T : BaseEntity
        {
            _context.Set<T>().Remove(entity);
        }

        public virtual void Update<T>(T entity)
            where T : BaseEntity
        {
            _context.Entry(entity).State = EntityState.Modified;

        }


        public virtual async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public virtual int Commit()
        {

            return _context.SaveChanges();
        }
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Task<T> FirstOrDefaultAsync<T>(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, params Expression<Func<T, object>>[] includes) where T : BaseEntity
        {
            throw new NotImplementedException();
        }

        public Task ReloadAsync(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
