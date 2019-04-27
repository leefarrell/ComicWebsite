using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComicWebsite.API.Helpers;
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
        // public async Task<Like> GetLike(int userId, int comicId)
        //{
           // return await _context
        //}

        public async Task<Comic> GetComic(int id)
        {
            var comic = await _context.Comics.FirstOrDefaultAsync(c => c.Id == id);

            return comic;
        }

        public static DateTime minDate = new DateTime(1970, 1, 1);
        public static DateTime maxDate = new DateTime(2030, 12, 31);
        DateTime dateOnlyMin = minDate.Date;
        DateTime dateOnlyMax = maxDate.Date;

        public async Task<Paging<Comic>> GetComics(PageParameters pageParameters)
        {
            var comics = _context.Comics.AsQueryable();

            if (pageParameters.MinDate != minDate || pageParameters.MaxDate != maxDate)
            {
                comics = comics.Where(c => c.Published >= minDate && c.Published <= maxDate);
            }

            return await Paging<Comic>.CreateAsync(comics, pageParameters.PageNumber, pageParameters.PageSize);
        }
        public async Task<IEnumerable<Comic>> GetComicsH()
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