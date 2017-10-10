namespace MovHubDb.Model
{
    public struct Movie
    {
        public class Belongs_to_Collection
        {
            public int id;
            public string name;
            public string poster_path;
            public string backdrop_path;
        }

        public class Genres
        {
            public int id;
            public string name;
        }

        public class Production_Companies
        {
            public int id;
            public string name;
        }

        public class Production_Countries
        {
            public string iso_3166_1;
            public string name;
        }

        public class Spoken_Languages
        {
            public string iso_639_1;
            public string name;
        }

        public string Original_title { get; set; }
        public string Tagline { get; set; }
        //falta aqui a crew list
        [HtmlAs("<li class='list-group-item'><a href='/movies/{value}/credits'>Cast </a></li>")]
        public string Credits { get { return Id.ToString(); } }
        public int Budget { get; set; }
        public string Vote_average { get; set; }
        public string Release_date { get; set; }
        public string Overview { get; set; }

        [HtmlIgnore]
        public int Vote_count { get; set; }
        [HtmlAs(" < li class='list-group-item'><a href = '/movies/{value}' > {value}</a></li>")] // retirar, so para teste
        public int Id { get; set; }
        [HtmlIgnore]
        public string Imdb_id { get; set; }
        [HtmlIgnore]
        public string Homepage { get; set; }
        [HtmlIgnore]
        public bool Video { get; set; }
        [HtmlIgnore]
        public int Revenue { get; set; }
        [HtmlIgnore]
        public int Runtime { get; set; }
        [HtmlIgnore]
        public string Status { get; set; }
        [HtmlIgnore]
        public Belongs_to_Collection[] Belongs_to_collection { get; set; }
        [HtmlIgnore]
        public Production_Companies[] Production_companies { get; set; }
        [HtmlIgnore]
        public Production_Countries[] Production_countries { get; set; }
        [HtmlIgnore]
        public Spoken_Languages[] Spoken_languages { get; set; }
        [HtmlIgnore]
        public string Title { get; set; }
        [HtmlIgnore]
        public float Popularity { get; set; }
        [HtmlIgnore]
        public string Poster_path { get; set; }
        [HtmlIgnore]
        public string Original_language { get; set; }
        [HtmlIgnore]
        public Genres[] genres { get; private set; }
        [HtmlIgnore]
        public string Backdrop_path { get; set; }
        [HtmlIgnore]
        public bool Adult { get; set; }

    }
}