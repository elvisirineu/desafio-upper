using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Upper.Desafio.Domain.Entities;
using Upper.Desafio.Domain.ViewModel;

namespace Upper.Desafio.Domain.AutoMapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            // Entity to ViewModel
            CreateMap<Especie, EspecieViewModel>().ReverseMap();
            CreateMap<Arvore, ArvoreViewModel>().ReverseMap();
            CreateMap<Grupo, GrupoViewModel>().ReverseMap();
            CreateMap<Colheita, ColheitaViewModel>().ReverseMap();
        }


    }
}
