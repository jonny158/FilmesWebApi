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
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private DbSet<User> users;

        public UserRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            users = applicationDbContext.Set<User>();
        }

        public async Task<bool> Authenticate(string username, string password)
        {
            return await this.users.AnyAsync(x => x.Username.Equals(username) && x.Password.Equals(password));
        }

    }
}
