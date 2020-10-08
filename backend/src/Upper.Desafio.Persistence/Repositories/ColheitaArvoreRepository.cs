using Repository.Pattern.Ef.DataContext;
using System;
using System.Collections.Generic;
using System.Text;
using Upper.Desafio.Domain.Entities;
using Upper.Desafio.Domain.Repositories.Contracts;

namespace Upper.Desafio.Persistence.Repositories
{
  
    public class ColheitaArvoreRepository : Repository<ColheitaArvore>, IColheitaArvoreRepository
    {
        public ColheitaArvoreRepository(IDataContext context) : base(context)
        {
        }
    }

}
