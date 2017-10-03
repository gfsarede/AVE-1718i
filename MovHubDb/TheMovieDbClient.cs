using MovHubDb.Model;
using Newtonsoft.Json;
using System;
using System.Net;

namespace MovHubDb
{
    public class TheMovieDbClient
    {

        static WebClient client = new WebClient();

        /// <summary>
        /// e.g.: https://api.themoviedb.org/3/search/movie?api_key=bf3af3188d1b9a4a4e7bcf1a02ef3f58&query=war%20games
        /// </summary>
        public MovieSearchItem[] Search(string title, int page)
        {
            string body = client.DownloadString("https://api.themoviedb.org/3/search/movie?api_key=bf3af3188d1b9a4a4e7bcf1a02ef3f58&query=war%20games");
            return new MovieSearchItem[0];
        }

        /// <summary>
        /// e.g.: https://api.themoviedb.org/3/movie/508?api_key=bf3af3188d1b9a4a4e7bcf1a02ef3f58
        /// </summary>
        public Movie MovieDetails(int id) {
           // string body = client.DownloadString("https://api.themoviedb.org/3/movie/508?api_key=bf3af3188d1b9a4a4e7bcf1a02ef3f58");
            return new Movie();
        }

        /// <summary>
        /// e.g.: https://api.themoviedb.org/3/movie/508/credits?api_key=*****
        /// </summary>
        public CreditsItem[] MovieCredits(int id) {
           
            return new CreditsItem[0];
        }

        /// <summary>
        /// e.g.: https://api.themoviedb.org/3/person/3489?api_key=bf3af3188d1b9a4a4e7bcf1a02ef3f58
        /// </summary>
        public Person PersonDetais(int actorId)
        {
            string body = client.DownloadString("https://api.themoviedb.org/3/person/3489?api_key=bf3af3188d1b9a4a4e7bcf1a02ef3f58");
            object obj = JsonConvert.DeserializeObject(body, typeof(Person));

            return (Person)obj;
        }

        /// <summary>
        /// e.g.: https://api.themoviedb.org/3/person/3489/movie_credits?api_key=bf3af3188d1b9a4a4e7bcf1a02ef3f58
        /// </summary>
        public MovieSearchItem[] PersonMovies(int actorId) {
            return new MovieSearchItem[0];
        }
    }
}
