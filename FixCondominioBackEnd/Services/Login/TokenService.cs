using FixCondominioBackEnd.Configs;
using FixCondominioBackEnd.Models;
using FixCondominioBackEnd.Models.ViewModels;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FixCondominioBackEnd.Services
{
    internal class TokenService
    {
        public static ViewUsuarioModel GenerateTokem(UsuarioModel user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(TokenSecret.Secret);
            var expires = DateTime.UtcNow.AddHours(2);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.ID.ToString()),
                    new Claim(ClaimTypes.Role, user.Regra.ToString())

                }),
                Expires = expires,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new ViewUsuarioModel()
            {
                ID = user.ID,
                Nome = user.Nome,
                Role = user.Regra,
                Token = tokenHandler.WriteToken(token)
            };

        }
    }
}
