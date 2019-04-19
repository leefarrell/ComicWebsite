using System;

namespace ComicWebsite.API.Dtos
{
    public class ComicDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string WriterName { get; set; }
        public DateTime Published { get; set; }
        public string PhotoUrl { get; set; }
    }
}