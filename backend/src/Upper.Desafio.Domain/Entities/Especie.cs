using System;
using System.Collections.Generic;
using System.Text;
using Repository.Pattern.Ef.Entities;

namespace Upper.Desafio.Domain.Entities
{
    public class Especie : EntityBase
    {
        public Especie(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }

        public Especie()
        {
            Arvores = new List<Arvore>();
        }

        public string Descricao { get; set; }

        public virtual ICollection<Arvore> Arvores { get; set; }
    }
}
