using System;
using System.Collections.Generic;
using System.Text;

namespace Upper.Desafio.Domain.ViewModel
{
    public class GrupoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public ICollection<ArvoreViewModel> Arvores { get; set; }

    }
}
