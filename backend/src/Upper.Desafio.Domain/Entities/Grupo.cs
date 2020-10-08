using System;
using System.Collections.Generic;
using System.Text;
using Repository.Pattern.Ef.Entities;

namespace Upper.Desafio.Domain.Entities
{
    public class Grupo: EntityBase
    {

        public Grupo(int id, string nome, string descricao)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
        }

        public Grupo()
        {
            GruposArvore = new List<GrupoArvore>();
        }

        public string Nome { get;  set; }
        public string Descricao { get;  set; }
        public virtual ICollection<GrupoArvore> GruposArvore { get; set; }

    }
}
