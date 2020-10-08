using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Repository.Pattern.Ef.DataContext;
using Repository.Pattern.Ef.Entities;
using Repository.Pattern.Ef.Repositories;
using Repository.Pattern.Ef.Repositories.Contract;
using Upper.Desafio.Persistence.Base;

namespace Upper.Desafio.Persistence.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        protected IDataContext _context;
        protected DbSet<TEntity> _dbSet;

        public Repository(IDataContext context)
        {
            _context = context;

            var dbContext = context as DbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public TEntity FindByKey(int id)
        {
            return _dbSet.TempFindById(_context as DbContext, id).FirstOrDefault();
        }


        public TEntity FindByKeyAsNoTracking(int id)
        {
            return _dbSet.TempFindById(_context as DbContext, id).AsNoTracking().FirstOrDefault();
        }


        public TEntity FindByKeyInclude(int id, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return _dbSet
                        .TempFindByIdInclude(_context as DbContext, id, includeProperties)
                        .FirstOrDefault();
        }

        public TEntity FindByKeyIncludeAsNoTracking(int id, Expression<Func<TEntity, object>>[] includeProperties)
        {
            return _dbSet
                        .TempFindByIdInclude(_context as DbContext, id, includeProperties)
                        .AsNoTracking()
                        .FirstOrDefault();
        }


        public IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public IEnumerable<TEntity> FindByInclude(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = GetlAllIncluding(includeProperties);
            return query.Where(predicate).ToList();
        }

        public IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return GetAllInclude(includeProperties).ToList();
        }

        public IEnumerable<TEntity> GetAllInclude(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return GetlAllIncluding(includeProperties).ToList();
        }

        public virtual void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public virtual void DeleteByKey(int id)
        {
            Delete(_dbSet.TempFindById(_context as DbContext, id).First());
        }

        public virtual void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        private IQueryable<TEntity> GetlAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = _dbSet.AsQueryable();
            foreach (var prop in includeProperties)
            {
                query = query.Include(prop);
            }

            return query;
        }

        protected IQueryable<TEntity> Queryable()
        {
            return _dbSet;
        }

        public IQueryable<TEntity> AsQueryable()
        {
            return _dbSet.AsQueryable();
        }

        public void AddContext(IDataContext dataContext)
        {
            _context = dataContext;

            var dbContext = dataContext as DbContext;
            _dbSet = dbContext.Set<TEntity>();
        }
    }
}
