

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JtTcc;
using JtTcc.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;

namespace ApiBalada.Services
{
    public class TokenService
    {
        public string CreateToken(Usuario funcio, List<string>perm)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, funcio.Nome.ToString()),
                new Claim("Permissao", string.Join(",", perm))
                }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }

}
