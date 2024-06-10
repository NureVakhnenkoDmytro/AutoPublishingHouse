using Common;
using DAL;
using Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Web.Helpers;

namespace BLL
{
    public class AuthService
    {
        private readonly ApplicationContext _context;

        public AuthService(ApplicationContext context)
        {
            _context = context;
        }

        public bool IsLoginTaken(string login)
        {
            return _context.Users.Where(u => u.Login == login).FirstOrDefault() != null;
        }
        public bool IsNameTaken(string name)
        {
            return _context.Users.Where(u => u.Name == name).FirstOrDefault() != null;
        }
        public User Register(string login, string name, string password, RoleEnum roleEnum)
        {
            var hashPassword = HashPassword(password);
            var role = _context.Roles.First(r => r.Id == (int)roleEnum);
            var user = new User()
            {
                Login = login,
                Name = name,
                Password = hashPassword,
                IsDeleted = false,
                Role = role
            };

            _context.Add(user);
            _context.SaveChanges();

            return user;
        }
        public User Authenticate(string login, string password)
        {
            var user = _context.Users.Where(x => x.Login == login && !x.IsDeleted)
               .SingleOrDefault();

            if (user == null) return null;

            return Crypto.VerifyHashedPassword(user.Password, password) ? user : null;
        }
        private string HashPassword(string rawPassword)
        {
            return Crypto.HashPassword(rawPassword);
        }
        public User GetCurrentUser(HttpContext http)
        {
            return _context.Users.Where(u => u.Id == int.Parse(http.User
                .Claims.First(c => c.Type == JwtRegisteredClaimNames.Sub)
                .Value)).First();
        }
    }

}

