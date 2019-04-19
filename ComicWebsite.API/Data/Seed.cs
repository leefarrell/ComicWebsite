using System.Collections.Generic;
using ComicWebsite.API.Models;
using Newtonsoft.Json;

namespace ComicWebsite.API.Data
{
    public class Seed
    {
        private readonly DataContext _context;
        public Seed(DataContext context)
        {
            _context = context;
        }

        public void SeedUsers()
        {
            var userData = System.IO.File.ReadAllText("Data/UserSeedData.json");
            var users = JsonConvert.DeserializeObject<List<User>>(userData);
            foreach (var user in users)
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash("password", out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.Username = user.Username.ToLower();

                _context.Users.Add(user);

            }
            _context.SaveChanges();
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                
            }
            
        }

         public void SeedComics()
        {
            var comicData = System.IO.File.ReadAllText("Data/ComicSeedData.json");
            var comics = JsonConvert.DeserializeObject<List<Comic>>(comicData);
            foreach (var comic in comics)
            {
                 _context.Comics.Add(comic);
            }
            _context.SaveChanges();
        }
    }
}