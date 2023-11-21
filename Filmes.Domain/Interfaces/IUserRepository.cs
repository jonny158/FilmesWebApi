using Filmes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmes.Domain.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<bool> Authenticate(string username, string password);
    }
}
