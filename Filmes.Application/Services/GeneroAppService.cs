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
    public class GeneroAppService : IGeneroAppService
    {
        private readonly IGeneroRepository _generoRepository;
        private readonly IMapper _mapper;

        public GeneroAppService(IGeneroRepository repository, IMapper mapper)
        {
            _generoRepository = repository;
            _mapper = mapper;
        }

        public async Task CreateGenero(GeneroViewModel genero)
        {
            _generoRepository.Add(_mapper.Map<GeneroViewModel, Genero>(genero));
            _generoRepository.SaveChanges();
        }

        public async Task<GeneroViewModel> GetById(int id)
        {
            return _mapper.Map<Genero, GeneroViewModel>(_generoRepository.GetById(id));
        }

        public Task<IEnumerable<GeneroViewModel>> ListGeneros()
        {
            var listGeneros = _generoRepository.GetAll().ToList();
            return Task.FromResult(_mapper.Map<IEnumerable<Genero>, IEnumerable<GeneroViewModel>>(listGeneros));
        }

        public async Task RemoveGenero(int id)
        {
            _generoRepository.Remove(id);
            _generoRepository.SaveChanges();
        }

        public async Task UpdateGenero(GeneroViewModel genero)
        {
            _generoRepository.Update(_mapper.Map<GeneroViewModel, Genero>(genero));
            _generoRepository.SaveChanges();
        }


    }
}
