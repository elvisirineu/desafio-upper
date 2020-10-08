using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Pattern.Ef.DataContext
{
    public interface IDataContext
    {
        int SaveChanges();
    }
}
