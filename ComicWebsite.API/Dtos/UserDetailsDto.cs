using System;
using System.Collections.Generic;
using ComicWebsite.API.Models;

namespace ComicWebsite.API.Dtos
{
    public class UserDetailsDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Interests {get; set;}
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string PhotoUrl { get; set;}
        public ICollection<PhotoDetailsDto> Photos { get; set; }
    }
}