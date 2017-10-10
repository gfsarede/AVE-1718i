using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovHubDb;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovHubDb.Model;

namespace HtmlReflectTest
{
    [TestClass]
    public class MovHubDbTest
    {
        [TestMethod]
        public void testPerson()
        {
            TheMovieDbClient client = new TheMovieDbClient();
            Person person = client.PersonDetais(3489);
            Assert.AreEqual("1968-09-28", person.Birthday);
            Assert.AreEqual("Naomi Watts", person.Name);
            Assert.AreEqual("nm0915208", person.Imdb_id);
        }

        [TestMethod]
        public void testPersonCredits()
        {
            MovieSearchItem[] testArray = new MovieSearchItem[3];
            TheMovieDbClient client = new TheMovieDbClient();
            testArray = client.PersonMovies(3489);
            Assert.AreEqual("Ann Darrow", testArray[0].Character);
            Assert.AreEqual("King Kong", testArray[0].Original_title);
            Assert.AreEqual("2003-09-06", testArray[1].Release_date);
            Assert.AreEqual(6.5, testArray[2].Vote_average);
        }

        [TestMethod]
        public void Credits_Test()
        {

            TheMovieDbClient tmdc = new TheMovieDbClient();

            CreditsItem[] ci = tmdc.MovieCredits(860);

            Assert.AreEqual("David Lightman", ci[0].Character);
            Assert.AreEqual(16, ci[1].Cast_id);
            Assert.AreEqual("52fe4283c3a36847f8024d6f", ci[2].Credit_id);
            Assert.AreEqual("John Wood", ci[3].Name);
        }

        [TestMethod]
        public static void TestGetMovieSearch()
        {
            TheMovieDbClient tmdc = new TheMovieDbClient();

            Movie movie = tmdc.MovieDetails(1018);

            Assert.AreEqual("false", movie.Adult);
            Assert.AreEqual("/ihkQywNs6Si24WssdmT1rNHuAYy.jpg", movie.Backdrop_path);
            Assert.AreEqual(2341, movie.Budget);

        }


        
    }
}
