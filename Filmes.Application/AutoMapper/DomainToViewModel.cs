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
    public class DomainToViewModel : Profile
    {
        public DomainToViewModel()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<Filme, FilmeViewModel>();
            CreateMap<Genero, GeneroViewModel>();
        }
    }
}
