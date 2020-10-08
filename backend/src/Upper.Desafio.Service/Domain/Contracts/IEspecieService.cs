using System;
using System.Collections.Generic;
using System.Text;
using Upper.Desafio.Domain.Entities;
using Upper.Desafio.Domain.ViewModel;
using Upper.Desafio.Service.Base.Contract;

namespace Upper.Desafio.Service.Domain.Contracts
{
    public interface IEspecieService : IService<Especie>
    {

        EspecieViewModel Incluir(EspecieViewModel especie);
        EspecieViewModel Alterar(EspecieViewModel especie);
        void Excluir(int especieId);

    }
}
