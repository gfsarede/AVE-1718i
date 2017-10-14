using MovHubDb.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;

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
            string firstBody = client.DownloadString("https://api.themoviedb.org/3/search/movie?api_key=bf3af3188d1b9a4a4e7bcf1a02ef3f58&query=" + title);
            MovieSearch movieSearch = (MovieSearch)JsonConvert.DeserializeObject(firstBody, typeof(MovieSearch));
            return movieSearch.results;

        }

        /// <summary>
        /// e.g.: https://api.themoviedb.org/3/movie/508?api_key=bf3af3188d1b9a4a4e7bcf1a02ef3f58
        /// </summary>
        public Movie MovieDetails(int id) {
            string body = client.DownloadString("https://api.themoviedb.org/3/movie/" + id + "?api_key=bf3af3188d1b9a4a4e7bcf1a02ef3f58");
            Movie obj = (Movie)JsonConvert.DeserializeObject(body, typeof(Movie));

            return obj;
        }

        /// <summary>
        /// e.g.: https://api.themoviedb.org/3/movie/508/credits?api_key=bf3af3188d1b9a4a4e7bcf1a02ef3f58
        /// </summary>
        public CreditsItem[] MovieCredits(int id)
        {

            string body = client.DownloadString("https://api.themoviedb.org/3/movie/" + id + "/credits?api_key=bf3af3188d1b9a4a4e7bcf1a02ef3f58");
            Credits credits = (Credits)JsonConvert.DeserializeObject(body, typeof(Credits));

            return credits.Cast;

        }

        /// <summary>
        /// e.g.: https://api.themoviedb.org/3/person/3489?api_key=bf3af3188d1b9a4a4e7bcf1a02ef3f58
        /// </summary>
        public Person PersonDetais(int actorId)
        {
            string body = client.DownloadString("https://api.themoviedb.org/3/person/"+actorId +"?api_key=bf3af3188d1b9a4a4e7bcf1a02ef3f58");
            object obj = JsonConvert.DeserializeObject(body, typeof(Person));

            return (Person)obj;
        }

        /// <summary>
        /// e.g.: https://api.themoviedb.org/3/person/3489/movie_credits?api_key=bf3af3188d1b9a4a4e7bcf1a02ef3f58
        /// </summary>
        public MovieSearchItem[] PersonMovies(int actorId) {
   
            string body = client.DownloadString("https://api.themoviedb.org/3/person/" + actorId + "/movie_credits?api_key=bf3af3188d1b9a4a4e7bcf1a02ef3f58");

            PersonCredits personCredits = (PersonCredits)JsonConvert.DeserializeObject(body, typeof(PersonCredits));

            return personCredits.Cast;
        }
    }
}
