using Repository.Pattern.Ef.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Upper.Desafio.Domain.Entities
{
    public class Colheita : EntityBase
    {
        public Colheita(int id,
                        string informacao,
                        DateTime data,
                        decimal pesoBruto
                        )
        {
            Id = id;
            Informacao = informacao;
            Data = data;
        }
        public Colheita()
        {
            ColheitasArvore = new List<ColheitaArvore>();
        }

        public string Informacao { get; set; }
        public DateTime Data { get; set; }
        public decimal PesoBruto { get; set; }
        public virtual ICollection<ColheitaArvore> ColheitasArvore { get; set; }

    }
}
