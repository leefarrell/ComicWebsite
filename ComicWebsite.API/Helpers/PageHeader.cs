namespace ComicWebsite.API.Helpers
{
    public class PageHeader
    {
        public int CurrentPage { get; set; }
        public int ComicsPerPage { get; set; }
        public int TotalComics { get; set; }
        public int TotalPages { get; set; }

        public PageHeader(int currentPage, int comicsPerPage, int totalComics, int totalPages)
        {
            this.CurrentPage = currentPage;
            this.ComicsPerPage = comicsPerPage;
            this.TotalComics = totalComics;
            this.TotalPages = totalPages;
        }
    }
}