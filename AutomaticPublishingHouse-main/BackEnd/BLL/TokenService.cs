using Common;
using DAL;
using Domain;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace BLL
{
    public class TokenService
    {
        private readonly AuthOptions _authOpions;
        private readonly ApplicationContext _context;

        public TokenService(AuthOptions authOpions,
            ApplicationContext context)
        {
            _authOpions = authOpions;
            _context = context;
        }


        public string GenerateJwtToken(User user)
        {
            var securityKey = _authOpions.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Name)
            };

            var roles = _context.Roles;

            claims.AddRange(roles
                .Where(role => user.RoleId == role.Id).ToList()
                .Select(role => new Claim("role", role.Name)));

            var token = new JwtSecurityToken(_authOpions.Issuer,
                _authOpions.Audience,
                claims,
                expires: DateTime.Now.AddSeconds(_authOpions.TokenLifeTime),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public JwtSecurityToken GetCurrentToken(string accessToken)
        {
            var token = accessToken.Split(" ")[1];

            return new JwtSecurityTokenHandler().ReadToken(token) as JwtSecurityToken;
        }
    }
}
