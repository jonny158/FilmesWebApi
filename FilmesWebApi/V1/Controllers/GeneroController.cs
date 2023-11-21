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
    [Route("Genero")]
    public class GeneroController : ControllerBase
    {     
        private readonly IGeneroAppService _generoAppService;

        public GeneroController(IGeneroAppService generoAppService)
        {
            _generoAppService = generoAppService;
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var genero = await _generoAppService.GetById(id);

            if (genero == null)
            {
                return NotFound(); // Retorna 404 Not Found se o genero não for encontrado
            }

            return Ok(genero); // Retorna 200 OK com o genero encontrado
        }

        [HttpPost("CreateGenero")]
        [Authorize]
        public async Task<IActionResult> CreateGenero([FromBody] GeneroViewModel model)
        {
            await _generoAppService.CreateGenero(model);

            return Ok($"O genero {model.Name} foi criado com sucesso.");
        }

        [HttpPut("UpdateGenero")]
        [Authorize]
        public async Task<IActionResult> UpdateGenero([FromBody] GeneroViewModel model)
        {
            await _generoAppService.UpdateGenero(model);

            return Ok($"Atualizado com sucesso.");
        }

        [HttpDelete("RemoveGenero")]
        [Authorize]
        public async Task<IActionResult> RemoveGenero([FromQuery] int id)
        {
            await _generoAppService.RemoveGenero(id);

            return Ok($"Removido com sucesso.");
        }
    }
}
