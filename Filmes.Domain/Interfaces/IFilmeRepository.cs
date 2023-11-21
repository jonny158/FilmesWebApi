using Filmes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmes.Domain.Interfaces
{
    public interface IFilmeRepository : IRepositoryBase<Filme>
    {
        void RemoveAll(int[] ids);
    }
}
