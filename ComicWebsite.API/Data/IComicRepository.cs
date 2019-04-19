using System.Collections.Generic;
using System.Threading.Tasks;
using ComicWebsite.API.Models;

namespace ComicWebsite.API.Data
{
    public interface IComicRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
         Task<IEnumerable<Comic>> GetComics();
         Task<Comic> GetComic(int id);
    }
}