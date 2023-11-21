using FilmesWebApi.Util;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filmes.Application.AutoMapper;

namespace FilmesWebApi.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            //// Registrando configurações de elementos do projeto em geral
            services.AddAutoMapper(typeof(DomainToViewModel), typeof(ViewModelToDomain));

            //Registrando configurações de elementos da API
            services.AddSingleton<IJwtUtils, JwtUtils>();

            //Registrando configurações de serviços e respositórios
            Filmes.Infrastructure.CrossCutting.Configurations.DependencyInjectionConfig.Register(services);
        }
    }
}
