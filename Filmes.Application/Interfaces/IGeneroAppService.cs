using Filmes.Application.Models;
using Filmes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmes.Application.Interfaces
{
    public interface IGeneroAppService 
    {
        Task<GeneroViewModel> GetById(int id);
        Task CreateGenero(GeneroViewModel genero);
        Task UpdateGenero(GeneroViewModel genero);
        Task RemoveGenero(int id);
        Task<IEnumerable<GeneroViewModel>> ListGeneros();
    }
}
