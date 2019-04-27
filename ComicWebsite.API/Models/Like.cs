namespace ComicWebsite.API.Models
{
    public class Like
    {
        //public int LikerId { get; set; }
        //public int LikedId { get; set; }
        //public User Liker { get; set; }
        //public Comic Liked { get; set; }
        public int Id { get; set; }
        public User Likes { get; set; }

    }
}