using System.ComponentModel.DataAnnotations;

namespace ComicWebsite.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 8, ErrorMessage ="Between 8 and 20")]
        public string Password { get; set; }
    }
}