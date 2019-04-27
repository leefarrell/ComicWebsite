using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComicWebsite.API.Helpers;
using ComicWebsite.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ComicWebsite.API.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context){
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public async Task<User> DeleteUser(int id)
        {
            var user = await GetUser(id);
            _context.Users.Attach(user);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.Include(p => p.Photos).FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.Include(p => p.Photos).ToListAsync();

            return users;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}