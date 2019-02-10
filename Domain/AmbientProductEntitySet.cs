using Domain;
using Mehdime.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Domain
{
    public class AmbientProductEntitySet<TEntity, TContext>: IEntitySet<TEntity> 
        where TEntity : class 
        where TContext:DbContext
    {
        private DbSet<TEntity> _set;

        private DbSet<TEntity> Set => _set ?? (_set = _contextLocator.Get<TContext>().Set<TEntity>());

        private DbContext _dbContext;
        private DbContext DbContext => _dbContext ?? (_dbContext = _contextLocator.Get<TContext>());

        private readonly IAmbientDbContextLocator _contextLocator;

        public AmbientProductEntitySet(IAmbientDbContextLocator contextLocator)
        {
            _contextLocator = contextLocator;
        }

        public void Add(TEntity entity)
        {
            Set.Add(entity);
        }

        public void Remove(TEntity entity)
        {
            Set.Remove(entity);
        }

        public IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            return Set.AddRange(entities);
        }

        IQueryProvider IQueryable.Provider => ((IQueryable)Set).Provider;

        Expression IQueryable.Expression => ((IQueryable)Set).Expression;

        Type IQueryable.ElementType => ((IQueryable)Set).ElementType;

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Set).GetEnumerator();
        }

        IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator()
        {
            return ((IEnumerable<TEntity>)Set).GetEnumerator();
        }
    }
}
