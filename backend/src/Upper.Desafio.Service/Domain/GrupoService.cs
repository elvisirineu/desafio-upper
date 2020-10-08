using AutoMapper;
using Microsoft.EntityFrameworkCore.Internal;
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
    public class GrupoService : Service<Grupo>, IGrupoService
    {
        private readonly IGrupoRepository _repository;
        private readonly IGrupoArvoreRepository _grupoArvoreRepository;
        protected readonly IMapper _mapper;

        public GrupoService(IGrupoRepository repository,
                                IUnitOfWork unitOfWork,
                                IMapper mapper,
                                IGrupoArvoreRepository grupoArvoreRepository
                                ) : base(repository, unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _grupoArvoreRepository = grupoArvoreRepository;
        }

        public GrupoViewModel Incluir(GrupoViewModel grupo)
        {
            try
            {
                var oGrupo = _mapper.Map<Grupo>(grupo);

                if (isValid(grupo))
                {
                    _repository.Insert(oGrupo);

                    foreach (var item in grupo.Arvores)
                    {
                        var oGrupoArvore = new GrupoArvore(item.Id, oGrupo.Id);
                        _grupoArvoreRepository.Insert(oGrupoArvore);
                    }

                    _unitOfWork.SaveChanges();
                }
                return _mapper.Map<GrupoViewModel>(oGrupo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool isValid(GrupoViewModel grupo)
        {
            if (string.IsNullOrEmpty(grupo.Descricao))
                throw new Exception("Descrição é um campo Obrigatório");

            if (string.IsNullOrEmpty(grupo.Nome))
                throw new Exception("Nome é um campo Obrigatório");

            if (!grupo.Arvores.Any())
                throw new Exception("Árvores são obrigatórias, para o cadastro de Grupo");

            return true;
        }

        public GrupoViewModel Alterar(GrupoViewModel grupo)
        {
            try
            {
                if (grupo.Id == 0)
                    throw new Exception("Identificador é um campo Obrigatório");

                var oGrupo = _repository.FindByInclude(p=>p.Id == grupo.Id, p=>p.GruposArvore).FirstOrDefault();

                if (isValid(grupo))
                {
                    oGrupo.Nome = grupo.Nome;
                    oGrupo.Descricao = grupo.Descricao;

                    foreach (var item in oGrupo.GruposArvore)
                    {
                        _grupoArvoreRepository.Delete(item);
                    }
                    foreach (var item in grupo.Arvores)
                    {
                        _grupoArvoreRepository.Insert(new GrupoArvore(item.Id, oGrupo.Id));
                    }
                    
                    _repository.Update(oGrupo);

                    _unitOfWork.SaveChanges();
                }
                return _mapper.Map<GrupoViewModel>(grupo);
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

                var oGrupo = _repository.FindByInclude(p => p.Id == id, p => p.GruposArvore).FirstOrDefault();

                foreach (var item in oGrupo.GruposArvore)
                {
                    _grupoArvoreRepository.Delete(item);
                }

                _repository.Delete(oGrupo);

                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
