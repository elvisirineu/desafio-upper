using System;
using System.Collections.Generic;
using System.Text;
using Upper.Desafio.Domain.Entities;
using Upper.Desafio.Domain.ViewModel;
using Upper.Desafio.Service.Base.Contract;

namespace Upper.Desafio.Service.Domain.Contracts
{
    public interface IColheitaService : IService<Colheita>
    {

        ColheitaViewModel Incluir(ColheitaViewModel colheita);
        ColheitaViewModel Alterar(ColheitaViewModel colheita);
        void Excluir(int id);
        ICollection<ColheitaViewModel> GetByArvoreId(int arvoreId);
        ICollection<ColheitaViewModel> GetByGrupoId(int grupoId);
        ICollection<ColheitaViewModel> GetByPeriodo(string periodo);

    }
}
