using Repository.Pattern.Ef.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Upper.Desafio.Domain.Entities;

namespace Upper.Desafio.Domain.Entities
{
    public class GrupoArvore: EntityBase
    {
        public GrupoArvore(int arvoreId, int grupoId)
        {
            ArvoreId = arvoreId;
            GrupoId = grupoId;
        }
        public int ArvoreId { get; private set; }
        public int GrupoId { get; private set; }

        public virtual Arvore Arvore { get; set; }
        public virtual Grupo Grupo { get; set; }

    }
}
