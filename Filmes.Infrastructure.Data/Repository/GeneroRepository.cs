using Filmes.Domain.Entities;
using Filmes.Domain.Interfaces;
using Filmes.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmes.Infrastructure.Data.Repository
{
    public class GeneroRepository : RepositoryBase<Genero>, IGeneroRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private DbSet<Genero> generos;

        public GeneroRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            generos = applicationDbContext.Set<Genero>();
        }

    }
}
