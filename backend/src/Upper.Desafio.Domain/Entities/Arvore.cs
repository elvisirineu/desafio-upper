using Repository.Pattern.Ef.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Upper.Desafio.Domain.Entities
{
    public class Arvore : EntityBase
    {

        public Arvore(int id,  string descricao, int idade, int especieId)
        {
            Id = id;
            Descricao = descricao;
            Idade = idade;
            EspecieId = especieId;
        }
        public Arvore()
        {
            ColheitasArvore = new List<ColheitaArvore>();
            GruposArvore = new List<GrupoArvore>();
        }

        public string Descricao { get;  set; }
        public int Idade { get;  set; }
        public int EspecieId { get;  set; }

        public virtual Especie Especie { get; set; }
        public virtual ICollection<ColheitaArvore> ColheitasArvore { get; set; }
        public virtual ICollection<GrupoArvore> GruposArvore { get; set; }
    }
}
