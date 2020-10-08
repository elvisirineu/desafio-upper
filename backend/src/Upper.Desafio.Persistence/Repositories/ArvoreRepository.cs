using Repository.Pattern.Ef.DataContext;
using System;
using System.Collections.Generic;
using System.Text;
using Upper.Desafio.Domain.Entities;
using Upper.Desafio.Domain.Repositories.Contracts;
using Upper.Desafio.Persistence.Base;

namespace Upper.Desafio.Persistence.Repositories
{
    public class ArvoreRepository : Repository<Arvore>, IArvoreRepository
    {
        public ArvoreRepository(IDataContext context) : base(context)
        {
        }
    }
}
