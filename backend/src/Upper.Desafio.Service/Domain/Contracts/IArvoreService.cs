using System;
using System.Collections.Generic;
using System.Text;
using Upper.Desafio.Domain.Entities;
using Upper.Desafio.Domain.ViewModel;
using Upper.Desafio.Service.Base.Contract;

namespace Upper.Desafio.Service.Domain.Contracts
{
    public interface IArvoreService : IService<Arvore>
    {

       ArvoreViewModel Incluir(ArvoreViewModel arvore);
       ArvoreViewModel Alterar(ArvoreViewModel arvore);
       void Excluir(int id);

    }
}
