using System;

namespace MovHubDb.Model
{
    public class MovieSearchItem
    {
        [HtmlAs(" < li class='list-group-item'><a href = '/movies/{value}' > {value}</a></li>")]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Release_date { get; set; }
        public string Vote_average { get; set; }

        [HtmlIgnore]
        public int Vote_count { get; set; }
        [HtmlIgnore]
        public bool Video { get; set; }
        [HtmlIgnore]
        public float Popularity { get; set; }
        [HtmlIgnore]
        public string Poster_path { get; set; }
        [HtmlIgnore]
        public string Original_language { get; set; }
        [HtmlIgnore]
        public string Original_title { get; set; }
        [HtmlIgnore]
        public int[] Genre_ids { get; set; }
        [HtmlIgnore]
        public string Backdrop_path { get; set; }
        [HtmlIgnore]
        public bool Adult { get; set; }
        [HtmlIgnore]
        public string Overview { get; set; }
        public string Character { get; set; }
        public string Credit_id { get; set; }
    }
}