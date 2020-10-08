using System;
using System.Collections.Generic;
using System.Text;
using Upper.Desafio.Domain.Entities;
using Upper.Desafio.Domain.ViewModel;
using Upper.Desafio.Service.Base.Contract;

namespace Upper.Desafio.Service.Domain.Contracts
{
    public interface IGrupoService : IService<Grupo>
    {

        GrupoViewModel Incluir (GrupoViewModel grupo);
        GrupoViewModel Alterar (GrupoViewModel grupo);
        void Excluir (int id);

    }
}
