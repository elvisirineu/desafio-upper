using Repository.Pattern.Ef.DataContext;
using System;
using System.Collections.Generic;
using System.Text;
using Upper.Desafio.Domain.Entities;
using Upper.Desafio.Domain.Repositories.Contracts;

namespace Upper.Desafio.Persistence.Repositories
{
  
    public class GrupoArvoreRepository : Repository<GrupoArvore>, IGrupoArvoreRepository
    {
        public GrupoArvoreRepository(IDataContext context) : base(context)
        {
        }
    }

}
