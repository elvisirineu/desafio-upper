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
    public class ArvoreService : Service<Arvore>, IArvoreService
    {
        private readonly IArvoreRepository _repository;
        private readonly IGrupoArvoreRepository _grupoArvoreRepository;
        protected readonly IMapper _mapper;
        public ArvoreService(IArvoreRepository repository,
                             IUnitOfWork unitOfWork,
                             IGrupoArvoreRepository grupoArvoreRepository,
                              IMapper mapper) : base(repository, unitOfWork)
        {
            _repository = repository;
            _grupoArvoreRepository = grupoArvoreRepository;
            _mapper = mapper;
        }

        public ArvoreViewModel Incluir(ArvoreViewModel arvore)
        {
            try
            {
                if (isValid(arvore))
                {
                    var oArvore = _mapper.Map<Arvore>(arvore);

                    _repository.Insert(oArvore);

                    _unitOfWork.SaveChanges();
                }
                return arvore;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool isValid(ArvoreViewModel arvore)
        {
            if (string.IsNullOrEmpty(arvore.Descricao))
                throw new Exception("Descrição é um campo Obrigatório");

            if (arvore.EspecieId == 0)
                throw new Exception("Especie é um campo Obrigatório");

            return true;
        }

        public ArvoreViewModel Alterar(ArvoreViewModel arvore)
        {
            try
            {
                if (arvore.Id == 0)
                    throw new Exception("Identificador é um campo Obrigatório");

                var oArvore = _repository.FindByKey(arvore.Id);

                if (isValid(arvore))
                {
                    oArvore.Descricao = arvore.Descricao;
                    oArvore.Idade = arvore.idade;
                    oArvore.EspecieId = arvore.EspecieId;

                    _repository.Update(oArvore);

                    _unitOfWork.SaveChanges();
                }
                return _mapper.Map<ArvoreViewModel>(oArvore);
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

                var arvore = _repository.FindByInclude(p => p.Id == id, p => p.ColheitasArvore).FirstOrDefault();

                if (arvore.ColheitasArvore.Count > 0)
                {
                    if (arvore.Id == 0)
                        throw new Exception("Esta árvore possui colheita cadastrada.");
                }

                var grupoArvore = _grupoArvoreRepository.FindBy(p=>p.ArvoreId == id).ToList();
                foreach (var item in grupoArvore)
                {
                    _grupoArvoreRepository.Delete(item);
                }

                _repository.Delete(arvore);

                _unitOfWork.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
