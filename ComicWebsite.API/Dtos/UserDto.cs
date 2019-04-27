using System;

namespace ComicWebsite.API.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        // public DateTime LastActive { get; set; }
        public string PhotoUrl { get; set;}
    }
}