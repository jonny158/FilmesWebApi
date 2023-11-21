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
    public class FilmeRepository : RepositoryBase<Filme>, IFilmeRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private DbSet<Filme> films;

        public FilmeRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            films = applicationDbContext.Set<Filme>();
        }

        public void RemoveAll(int[] ids)
        {
            // Pegando todos os filmes para remoção
            var filmsToRemove = films.Where(e => ids.Contains(e.Id)).ToList();
            films.RemoveRange(filmsToRemove);
        }
    }
}
