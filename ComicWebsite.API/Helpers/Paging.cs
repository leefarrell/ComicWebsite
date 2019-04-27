using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ComicWebsite.API.Helpers
{
    public class Paging<Comic> : List<Comic>
    {
        
        public int CurrentPage {get; set;}
        public int TotalPages {get; set;}
        public int PageSize {get; set;}
        public int TotalCount {get; set;}

         public Paging(List<Comic> comicNum, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(comicNum);
        }

        public static async Task<Paging<Comic>> CreateAsync(IQueryable<Comic> source, int pageNumber, int pageSize)
        {
            var count = await source.CountAsync();
            var comicNum = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return new Paging<Comic>(comicNum, count, pageNumber, pageSize);
        }
    }
}