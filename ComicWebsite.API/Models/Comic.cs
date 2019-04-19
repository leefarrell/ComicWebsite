using System;

namespace ComicWebsite.API.Models
{
    public class Comic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string WriterName { get; set; }
        public DateTime Published { get; set; }
        public string PhotoUrl { get; set; }
    }
}