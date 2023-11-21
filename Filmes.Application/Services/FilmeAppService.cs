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
    public class FilmeAppService : IFilmeAppService
    {
        private readonly IFilmeRepository _filmeRepository;
        private readonly IMapper _mapper;

        public FilmeAppService(IFilmeRepository repository, IMapper mapper)
        {
            _filmeRepository = repository;
            _mapper = mapper;
        }

        public Task<IEnumerable<FilmeViewModel>> ListFilms()
        {
            var listFilms = _filmeRepository.GetAll().ToList();
            return Task.FromResult(_mapper.Map<IEnumerable<Filme>, IEnumerable<FilmeViewModel>>(listFilms));
        }

        public async Task<FilmeViewModel> GetById(int id)
        {
            return _mapper.Map<Filme, FilmeViewModel>(_filmeRepository.GetById(id));
        }

        public async Task CreateFilme(FilmeViewModel filme)
        {
            _filmeRepository.Add(_mapper.Map<FilmeViewModel, Filme>(filme));
            _filmeRepository.SaveChanges();
        }

        public async Task UpdateFilme(FilmeViewModel filme)
        {
            _filmeRepository.Update(_mapper.Map<FilmeViewModel, Filme>(filme));
            _filmeRepository.SaveChanges();
        }

        public async Task RemoveFilme(int id)
        {
            _filmeRepository.Remove(id);
            _filmeRepository.SaveChanges();
        }

        public async Task RemoveAll(int[] ids)
        {
            _filmeRepository.RemoveAll(ids);
            _filmeRepository.SaveChanges();
        }
    }
}
