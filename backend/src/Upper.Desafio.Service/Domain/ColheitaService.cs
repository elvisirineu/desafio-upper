using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using AutoMapper;
using AutoMapper.Internal;
using Repository.Pattern.Ef.UnitOfWork.Contract;
using Upper.Desafio.Domain.Entities;
using Upper.Desafio.Domain.Repositories.Contracts;
using Upper.Desafio.Domain.ViewModel;
using Upper.Desafio.Service.Base;
using Upper.Desafio.Service.Domain.Contracts;

namespace Upper.Desafio.Service.Domain
{
    public class ColheitaService : Service<Colheita>, IColheitaService
    {
        private readonly IColheitaRepository _repository;
        private readonly IGrupoArvoreRepository _grupoArvoreRepository;
        private readonly IColheitaArvoreRepository _colheitaArvoreRepository;
        protected readonly IMapper _mapper;
        public ColheitaService(IColheitaRepository repository,
                                IUnitOfWork unitOfWork,
                                IMapper mapper,
                                IColheitaArvoreRepository colheitaArvoreRepository,
                                IGrupoArvoreRepository grupoArvoreRepository) : base(repository, unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _colheitaArvoreRepository = colheitaArvoreRepository;
            _grupoArvoreRepository = grupoArvoreRepository;
        }

        public ColheitaViewModel Incluir(ColheitaViewModel colheita)
        {
            try
            {
                if (isValid(colheita))
                {
                    var oColheita = new Colheita(colheita.Id, colheita.Informacao, colheita.Data, colheita.PesoBruto);

                    _repository.Insert(oColheita);
                    foreach (var item in colheita.Arvores)
                    {
                        var oColheitaArvore = new ColheitaArvore(item.Id, oColheita.Id);
                        _colheitaArvoreRepository.Insert(oColheitaArvore);
                    }

                    _unitOfWork.SaveChanges();
                }

                return colheita;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool isValid(ColheitaViewModel colheita)
        {

            if (string.IsNullOrEmpty(colheita.Informacao))
                throw new Exception("Informação é um campo Obrigatório");

            if (string.IsNullOrEmpty(colheita.Data.ToString()))
                throw new Exception("Data é um campo Obrigatório");

            if (string.IsNullOrEmpty(colheita.PesoBruto.ToString()))
                throw new Exception("Peso Bruto é um campo Obrigatório");

            if (!colheita.Arvores.Any())
                throw new Exception("Árvores são obrigatórias, para o cadastro de uma Colheita");

            return true;
        }

        public ColheitaViewModel Alterar(ColheitaViewModel colheita)
        {
            try
            {
                if (colheita.Id == 0)
                    throw new Exception("Identificador é um campo Obrigatório");

                var oColheita = _repository.FindByInclude(p => p.Id == colheita.Id, p => p.ColheitasArvore).FirstOrDefault();

                if (isValid(colheita))
                {
                    oColheita.Data = colheita.Data;
                    oColheita.Informacao = colheita.Informacao;
                    oColheita.PesoBruto = colheita.PesoBruto;

                    foreach (var item in oColheita.ColheitasArvore)
                    {
                        _colheitaArvoreRepository.Delete(item);
                    }
                    foreach (var item in colheita.Arvores)
                    {
                        _colheitaArvoreRepository.Insert(new ColheitaArvore(item.Id, oColheita.Id));
                    }

                    _repository.Update(oColheita);

                    _unitOfWork.SaveChanges();

                }

                return _mapper.Map<ColheitaViewModel>(oColheita);
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

                var oColheita = _repository.FindByInclude(p => p.Id == id, p => p.ColheitasArvore).FirstOrDefault();

                foreach (var item in oColheita.ColheitasArvore)
                {
                    _colheitaArvoreRepository.Delete(item);
                }
                _repository.Delete(oColheita);

                _unitOfWork.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ICollection<ColheitaViewModel> GetByArvoreId(int arvoreId)
        {
            try
            {
                var result = _colheitaArvoreRepository.FindByInclude(p => p.ArvoreId == arvoreId, p => p.Colheita).ToList();

                return _mapper.Map<ICollection<ColheitaViewModel>>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ICollection<ColheitaViewModel> GetByGrupoId(int grupoId)
        {
            try
            {
                var result = _grupoArvoreRepository.FindByInclude(p => p.GrupoId == grupoId, p => p.Arvore).ToList();

                return _mapper.Map<ICollection<ColheitaViewModel>>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ICollection<ColheitaViewModel> GetByPeriodo(string periodo)
        {
            try
            {

                List<DateTime> datas = ExtractListDatesFromString(periodo);

                var result = _repository.FindByInclude(p => p.Data >= datas.First() && p.Data <= datas.Last(), p => p.ColheitasArvore).ToList(); ;

                return _mapper.Map<ICollection<ColheitaViewModel>>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private List<DateTime> ExtractListDatesFromString(string periodo)
        {
            try
            {
                var listDatas = periodo.Split("-");

                if (listDatas.Length == 0)
                    throw new Exception("Informe o Período Correto");

                DateTime inicio = DateTime.ParseExact(listDatas[0]?.Trim(), "dd/MM/yyyy", new CultureInfo("pt-BR")).Date;
                DateTime fim = DateTime.ParseExact(listDatas[1]?.Trim(), "dd/MM/yyyy", new CultureInfo("pt-BR")).Date;

                return new List<DateTime>
                {
                    inicio,
                    fim
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}