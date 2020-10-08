using Microsoft.EntityFrameworkCore.Storage;
using Repository.Pattern.Ef.DataContext;
using Repository.Pattern.Ef.UnitOfWork.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Pattern.Ef.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        protected IDataContext _context;

        protected IDbContextTransaction _transaction;
        public UnitOfWork(IDataContext context)
        {
            _context = context;
        }

        public virtual void Commit()
        {
            throw new NotImplementedException();
        }

        public virtual void Rollback()
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void AddContext(IDataContext dataContext)
        {
            _context = dataContext;
        }

        public virtual void OpenTransaction()
        {
            throw new NotImplementedException();
        }
    }
}
