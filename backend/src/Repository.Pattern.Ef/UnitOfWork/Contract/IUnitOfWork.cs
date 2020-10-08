using Repository.Pattern.Ef.DataContext;

namespace Repository.Pattern.Ef.UnitOfWork.Contract
{
    public interface IUnitOfWork
    {
        int SaveChanges();

        void OpenTransaction();

        void Commit();

        void Rollback();

        void AddContext(IDataContext dataContext);
    }
}
