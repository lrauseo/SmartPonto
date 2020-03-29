using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace SmartPonto.Api.Models.TokenAuth
{
    /// <summary>
    /// classe para manipulação e validação do token
    /// </summary>
    public class TokenAuthentication : ITokenAuthentication
    {
        private readonly AppSettings _AppSettings;

        public TokenAuthentication(IOptions<AppSettings> settings)
        {
            _AppSettings = settings.Value;
        }
        /// <summary>
        /// Utilizado para gerar um token de autorização para utilização da API
        /// </summary>
        /// <param name="userName"> parametro para identificar para qual usuario é destinado o token</param>
        /// <returns></returns>
        /// todo alterar o parametro username para receber um objeto de usuario futuramente
        public string GenerateToken(string userName)
        {
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_AppSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userName)
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
