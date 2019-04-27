using System;

namespace ComicWebsite.API.Dtos
{
    public class ComicDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Published { get; set; }
        public string PhotoUrl { get; set; }
    }
}