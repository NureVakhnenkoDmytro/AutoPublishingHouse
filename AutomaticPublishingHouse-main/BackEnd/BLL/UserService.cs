using DAL;
using Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class UserService
    {
        private readonly ApplicationContext _context;

        public UserService(ApplicationContext context)
        {
            _context = context;
        }

        public void AddUser(User model)
        {
            _context.Add(model);
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAllNotDeletedUsers()
        {
            return _context.Users.Include(u => u.Role)
                .Where(u => u.IsDeleted == false);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.Include(u => u.Role);
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.First(u => u.Id == id);
            user.IsDeleted = true;
            _context.Update(user);
            _context.SaveChanges();
        }
    }
}
