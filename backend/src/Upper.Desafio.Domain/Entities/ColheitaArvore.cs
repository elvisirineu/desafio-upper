using System;
using System.Collections.Generic;
using System.Text;
using Repository.Pattern.Ef.Entities;

namespace Upper.Desafio.Domain.Entities
{
    public class ColheitaArvore : EntityBase
    {
        public ColheitaArvore(int arvoreId, int colheitaId)
        {
            ArvoreId = arvoreId;
            ColheitaId = colheitaId;
        }

        public int ArvoreId { get; set; }
        public int ColheitaId { get; set; }

        public virtual Arvore Arvore { get; set; }
        public virtual Colheita Colheita { get; set; }

    }
}
