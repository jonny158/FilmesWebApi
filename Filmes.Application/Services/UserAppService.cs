using AutoMapper;
using Filmes.Application.Interfaces;
using Filmes.Application.Models;
using Filmes.Domain.Entities;
using Filmes.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmes.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserAppService(IUserRepository repository, IMapper mapper)
        {
            _userRepository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Authenticate(string username, string password)
        {
            return await _userRepository.Authenticate(username, password);
        }

        public async Task CreateUser(LoginViewModel user)
        {
            _userRepository.Add(new User() { Username = user.Username, Password = user.Password });
            _userRepository.SaveChanges();
        }

        public async Task<UserViewModel> GetById(int id)
        {
            return _mapper.Map<User, UserViewModel>(_userRepository.GetById(id));
        }

        public Task<IEnumerable<UserViewModel>> ListUsers()
        {
            var listUsers = _userRepository.GetAll().ToList();
            return Task.FromResult(_mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(listUsers));
        }
    }
}
