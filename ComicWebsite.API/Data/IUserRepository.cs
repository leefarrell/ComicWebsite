using System.Collections.Generic;
using System.Threading.Tasks;
using ComicWebsite.API.Helpers;
using ComicWebsite.API.Models;

namespace ComicWebsite.API.Data
{
    public interface IUserRepository
    {
         void Add<T>(T entity) where T: class;
         Task<User> DeleteUser(int id);
         Task<bool> SaveAll();
         Task<IEnumerable<User>> GetUsers();
         Task<User> GetUser(int id);
    }
}