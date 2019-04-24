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
        public async Task<Comic> AddComic(Comic comic)
        {
            await _context.Comics.AddAsync(comic);
            await _context.SaveChangesAsync();

            return comic;
        }

        public async Task<Comic> DeleteComic(int id)
        {
            var comic = await GetComic(id);
            _context.Comics.Attach(comic);
            _context.Comics.Remove(comic);
            await _context.SaveChangesAsync();

            return comic;
        }

        public async Task<Comic> GetComic(int id)
        {
            var comic = await _context.Comics.FirstOrDefaultAsync(c => c.Id == id);

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