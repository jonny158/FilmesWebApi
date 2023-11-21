using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Filmes.Application.Interfaces;
using Filmes.Application.Services;
using Filmes.Domain.Interfaces;
using Filmes.Infrastructure.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Filmes.Infrastructure.CrossCutting.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void Register(IServiceCollection services)
        {
            //Configurando injeção de dependências para serviços
            services.AddTransient<IUserAppService, UserAppService>();
            services.AddTransient<IFilmeAppService, FilmeAppService>();
            services.AddTransient<IGeneroAppService, GeneroAppService>();


            //Configurando injeção de dependências para respositórios
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IFilmeRepository, FilmeRepository>();
            services.AddTransient<IGeneroRepository, GeneroRepository>();
        }
    }
}
