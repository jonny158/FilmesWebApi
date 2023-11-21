using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FilmesWebApi.Util
{
    public interface IJwtUtils
    {
        string GenerateJwtToken(string username);
    }

    public class JwtUtils : IJwtUtils
    {
        public string GenerateJwtToken(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            //Usando a mesma chave de configurações para o JWT, futuramente podemos deixar ambas vindas de um lugar só
            var key = Encoding.ASCII.GetBytes("JWTKEY_1234567890ABCDEFGHIJ");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, username),
                    // Podemos adicionar mais claims conforme necessário, caso não sejam só filmes.
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}
