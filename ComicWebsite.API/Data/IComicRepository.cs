using System.Collections.Generic;
using System.Threading.Tasks;
using ComicWebsite.API.Models;

namespace ComicWebsite.API.Data
{
    public interface IComicRepository
    { //          T  T entity
         Task<Comic> AddComic(Comic comic);
         Task<Comic> DeleteComic(int id) ;
         Task<bool> SaveAll();
         Task<IEnumerable<Comic>> GetComics();
         Task<Comic> GetComic(int id);
    }
}