using AutoMapper;
using Filmes.Application.Models;
using Filmes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmes.Application.AutoMapper
{
    public class ViewModelToDomain : Profile
    {
        public ViewModelToDomain()
        {
            CreateMap<UserViewModel, User>();
            CreateMap<FilmeViewModel, Filme>().ForMember(dest => dest.Genero, opt => opt.Ignore());
            CreateMap<GeneroViewModel, Genero>().ForMember(dest => dest.Filmes, opt => opt.Ignore());
        }
    }
}
