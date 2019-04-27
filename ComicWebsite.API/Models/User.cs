

using System;
using System.Collections.Generic;

namespace ComicWebsite.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Interests {get; set;}
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public ICollection<Photo> Photos { get; set; }
        //public ICollection<Like> Likers { get; set; }
    }
}