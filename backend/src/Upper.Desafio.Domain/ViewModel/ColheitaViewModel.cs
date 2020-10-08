using System;
using System.Collections.Generic;
using System.Text;

namespace Upper.Desafio.Domain.ViewModel
{
    public class ColheitaViewModel
    {
        public int Id { get; set; }
        public string Informacao { get; set; }
        public DateTime Data { get; set; }
        public decimal PesoBruto { get; set; }
        public ICollection<ArvoreViewModel> Arvores { get; set; }

    }
}
