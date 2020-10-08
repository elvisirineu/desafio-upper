using AutoMapper;
using Repository.Pattern.Ef.UnitOfWork.Contract;
using System;
using System.Linq;
using Upper.Desafio.Domain.Entities;
using Upper.Desafio.Domain.Repositories.Contracts;
using Upper.Desafio.Domain.ViewModel;
using Upper.Desafio.Service.Base;
using Upper.Desafio.Service.Domain.Contracts;

namespace Upper.Desafio.Service.Domain
{
    public class EspecieService : Service<Especie>, IEspecieService
    {

        private readonly IEspecieRepository _repository;
        protected readonly IMapper _mapper;

        public EspecieService(IEspecieRepository repository,
                                IMapper mapper,
                                IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;

        }

        public EspecieViewModel Incluir(EspecieViewModel especie)
        {
            try
            {
                if (isValid(especie))
                {
                    var oEspecie = _mapper.Map<Especie>(especie);

                    _repository.Insert(oEspecie);

                    _unitOfWork.SaveChanges();
                }
                return especie;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EspecieViewModel Alterar(EspecieViewModel especie)
        {
            try
            {
                if (especie.Id == 0)
                    throw new Exception("Identificador é um campo Obrigatório");

                var oEspecie = _repository.FindByKey(especie.Id);

                if (isValid(especie))
                {
                    oEspecie.Descricao = especie.Descricao;

                    _repository.Update(oEspecie);

                    _unitOfWork.SaveChanges();
                }
                return _mapper.Map<EspecieViewModel>(especie);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Excluir(int id)
        {
            try
            {
                if (id == 0)
                    throw new Exception("Identificador é um campo Obrigatório");

                var oEspecie = _repository.FindByInclude(p => p.Id == id, p => p.Arvores).FirstOrDefault();

                if (oEspecie.Arvores.Count() > 0)
                    throw new Exception("Não é possível excluir espécie, existe árvores vinculadas.");

                _repository.Delete(oEspecie);

                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool isValid(EspecieViewModel especie)
        {
            if (string.IsNullOrEmpty(especie.Descricao))
                throw new Exception("Descrição é um campo Obrigatório");

            return true;
        }
    }
}
