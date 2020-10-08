using Repository.Pattern.Ef.DataContext;
using Repository.Pattern.Ef.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repository.Pattern.Ef.Repositories.Contract
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        TEntity FindByKey(int id);

        TEntity FindByKeyInclude(int id, params Expression<Func<TEntity, object>>[] includeProperties);

        TEntity FindByKeyIncludeAsNoTracking(int id, Expression<Func<TEntity, object>>[] includeProperties);

        TEntity FindByKeyAsNoTracking(int id);

        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> FindByInclude(Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties);

        IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeProperties);

        IEnumerable<TEntity> GetAllInclude(params Expression<Func<TEntity, object>>[] includeProperties);

        IQueryable<TEntity> AsQueryable();

        void Insert(TEntity entity);

        void Update(TEntity entity);

        void DeleteByKey(int id);

        void Delete(TEntity entity);

        void AddContext(IDataContext dataContext);
    }
}
