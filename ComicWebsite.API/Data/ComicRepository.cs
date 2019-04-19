using System.Collections.Generic;
using System.Threading.Tasks;
using ComicWebsite.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ComicWebsite.API.Data
{
    public class ComicRepository : IComicRepository
    {
        private readonly DataContext _context;

        public ComicRepository(DataContext context){
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Comic> GetComic(int id)
        {
            var comic = await _context.Comics.FirstOrDefaultAsync(u => u.Id == id);

            return comic;
        }

        public async Task<IEnumerable<Comic>> GetComics()
        {
            var comics = await _context.Comics.ToListAsync();

            return comics;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}