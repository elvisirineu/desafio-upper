

using Repository.Pattern.Ef.DataContext;
using Repository.Pattern.Ef.Entities;
using Repository.Pattern.Ef.Repositories.Contract;
using Repository.Pattern.Ef.UnitOfWork.Contract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Upper.Desafio.Service.Base.Contract;

namespace Upper.Desafio.Service.Base
{
    public abstract class Service<TEntity> : IService<TEntity> where TEntity : EntityBase
    {
        protected IRepository<TEntity> _repository;
        protected IUnitOfWork _unitOfWork;

        public Service(IRepository<TEntity> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public TEntity FindByKey(int id)
        {
            return _repository.FindByKey(id);
        }

        public TEntity FindByKeyAsNoTracking(int id)
        {
            return _repository.FindByKeyAsNoTracking(id);
        }


        public TEntity FindByKeyInclude(int id, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return _repository.FindByKeyInclude(id, includeProperties);
        }

        public TEntity FindByKeyIncludeAsNoTracking(int id, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return _repository.FindByKeyIncludeAsNoTracking(id, includeProperties);
        }

        public IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return _repository.GetAll(includeProperties);
        }

        public virtual void Insert(TEntity entity)
        {
            _repository.Insert(entity);
            _unitOfWork.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            _repository.Update(entity);
            _unitOfWork.SaveChanges();
        }

        public virtual void DeleteByKey(int id)
        {
            _repository.DeleteByKey(id);
            _unitOfWork.SaveChanges();
        }

        public virtual void Delete(TEntity entity)
        {
            _repository.Delete(entity);
            _unitOfWork.SaveChanges();
        }

        public IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.FindBy(predicate);
        }

        public IEnumerable<TEntity> FindByInclude(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return _repository.FindByInclude(predicate, includeProperties);
        }

        public void AddContext(IDataContext dataContext)
        {
            _unitOfWork.AddContext(dataContext);
        }

    }
}
