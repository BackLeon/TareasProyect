using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using Infrastructure.Repository.Abstract;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Repository.Implemetation
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;

        private readonly SymmetricSecurityKey _key;

        public TokenService(IConfiguration config)
        {
            _config = config;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Token"]!));
        }


         public string CreateToken(AppUser user)
        {
            //var claims = new List<Claim>
            //{
            //    new Claim(ClaimTypes.Email, user.Email!),
            //    new Claim(ClaimTypes.Name, user.Name!),
            //    new Claim(ClaimTypes.Role, user.Roles)
            //};
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.Name} {user.LastName}"),
                new Claim(ClaimTypes.Role, user.Roles)
            };
            var tokenHandler = new JwtSecurityTokenHandler();

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescription = new JwtSecurityToken(
                           issuer: _config["JWT:Issuer"],
                           claims: claims,
                           expires: DateTime.Now.AddDays(7),
                           signingCredentials: creds
                           );

            var jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescription);
            return jwt;
        }


    }
}