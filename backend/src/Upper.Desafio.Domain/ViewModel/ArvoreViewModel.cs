using System;
using System.Collections.Generic;
using System.Text;

namespace Upper.Desafio.Domain.ViewModel
{
    public class ArvoreViewModel
    {

        public int Id { get; set; }
        public string Descricao { get; set; }
        public int idade { get; set; }
        public int EspecieId { get; set; }
        public EspecieViewModel Especie { get; set; }

    }
}
