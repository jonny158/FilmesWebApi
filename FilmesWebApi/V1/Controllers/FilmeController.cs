using Filmes.Application.Interfaces;
using Filmes.Application.Models;
using FilmesWebApi.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesWebApi.V1.Controllers
{
    [ApiController]
    [Route("Filme")]
    public class FilmeController : ControllerBase
    {     
        private readonly IFilmeAppService _filmeAppService;

        public FilmeController(IFilmeAppService filmeAppService)
        {
            _filmeAppService = filmeAppService;
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var filme = await _filmeAppService.GetById(id);

            if (filme == null)
            {
                return NotFound(); // Retorna 404 Not Found se o filme não for encontrado
            }

            return Ok(filme); // Retorna 200 OK com o filme encontrado
        }

        [HttpGet("ListFilmes")]
        [Authorize]
        public async Task<IActionResult> ListFilmes()
        {
            var listFilmes = await _filmeAppService.ListFilms();
            return Ok(listFilmes);
        }

        [HttpPost("CreateFilme")]
        [Authorize]
        public async Task<IActionResult> CreateFilme([FromBody] FilmeViewModel model)
        {
            await _filmeAppService.CreateFilme(model);

            return Ok($"O filme {model.Name} foi criado com sucesso.");
        }

        [HttpPut("UpdateFilme")]
        [Authorize]
        public async Task<IActionResult> UpdateFilme([FromBody] FilmeViewModel model)
        {
            await _filmeAppService.UpdateFilme(model);

            return Ok($"Atualizado com sucesso.");
        }

        [HttpDelete("RemoveFilme")]
        [Authorize]
        public async Task<IActionResult> RemoveFilme([FromQuery] int id)
        {
            await _filmeAppService.RemoveFilme(id);

            return Ok($"Removido com sucesso.");
        }

        [HttpDelete("RemoveAll")]
        [Authorize]
        public IActionResult DeleteItems([FromBody] List<int> ids)
        {
            if (ids == null || ids.Count == 0)
            {
                return BadRequest("A lista de IDs não pode estar vazia.");
            }

            _filmeAppService.RemoveAll(ids.ToArray());

            return Ok($"Filmes com IDs {string.Join(", ", ids)} foram deletados com sucesso.");
        }
    }
}
