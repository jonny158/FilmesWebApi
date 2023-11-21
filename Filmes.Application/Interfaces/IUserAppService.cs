using Filmes.Application.Models;
using Filmes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmes.Application.Interfaces
{
    public interface IUserAppService 
    {
        Task<UserViewModel> GetById(int id);
        Task<bool> Authenticate(string username, string password);
        Task CreateUser(LoginViewModel user);
        Task<IEnumerable<UserViewModel>> ListUsers();
    }
}
