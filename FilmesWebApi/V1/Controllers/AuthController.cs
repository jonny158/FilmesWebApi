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
    [Route("Autentication")]
    public class AuthController : ControllerBase
    {
        private readonly IJwtUtils _jwtUtils;
        private readonly IUserAppService _userAppService;
        

        public AuthController(IJwtUtils jwtUtils, IUserAppService userAppService)
        {
            _jwtUtils = jwtUtils;
            _userAppService = userAppService;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {

            if (await _userAppService.Authenticate(model.Username, model.Password)){
                // Se a autenticação for bem-sucedida, iremos gerar um token JWT
                var token = _jwtUtils.GenerateJwtToken(model.Username);
                return Ok(new { Token = token });
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] LoginViewModel model)
        {
            await _userAppService.CreateUser(model);

            return Ok($"O usuário {model.Username} foi criado com sucesso.");
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userAppService.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user); 
        }

    }

}
