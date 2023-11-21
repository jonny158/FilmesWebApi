using Filmes.Application.Models;
using Filmes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmes.Application.Interfaces
{
    public interface IFilmeAppService 
    {
        Task<FilmeViewModel> GetById(int id);
        Task CreateFilme(FilmeViewModel filme);
        Task UpdateFilme(FilmeViewModel filme);
        Task RemoveFilme(int id);
        Task RemoveAll(int[] ids);
        Task<IEnumerable<FilmeViewModel>> ListFilms();
    }
}
