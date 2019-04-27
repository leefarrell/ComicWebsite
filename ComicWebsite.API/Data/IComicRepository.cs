using System.Collections.Generic;
using System.Threading.Tasks;
using ComicWebsite.API.Helpers;
using ComicWebsite.API.Models;

namespace ComicWebsite.API.Data
{
    public interface IComicRepository
    { //          T  T entity
         Task<Comic> AddComic(Comic comic);
         Task<Comic> DeleteComic(int id) ;
         Task<bool> SaveAll();
         Task<Paging<Comic>> GetComics(PageParameters pageParameters);
         Task<IEnumerable<Comic>> GetComicsH();
         Task<Comic> GetComic(int id);
          // Task<Like> GetLike(int userId , int comicId);
    }
}