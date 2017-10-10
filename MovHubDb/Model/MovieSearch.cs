namespace MovHubDb.Model
{
    public class MovieSearch
    {
        public int page;
        public int total_results;
        public int total_pages;
        public MovieSearchItem[] results;
    }
}