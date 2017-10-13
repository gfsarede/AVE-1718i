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
        public void Search_Test()
        {

            TheMovieDbClient tmdc = new TheMovieDbClient();

            MovieSearchItem[] msi = tmdc.Search("Drive", 1);
            Assert.AreEqual(64690, msi[0].Id);
            Assert.AreEqual("Drive", msi[1].Title);
            Assert.AreEqual("Mulholland Drive", msi[2].Original_title);
            Assert.AreEqual("2008-10-16", msi[3].Release_date);
        }

        [TestMethod]
        public void TestGetMovieSearch()
        {
            TheMovieDbClient tmdc = new TheMovieDbClient();

            Movie movie = tmdc.MovieDetails(1018);
            Assert.AreEqual(false, movie.Adult);
            Assert.AreEqual("/ihkQywNs6Si24WssdmT1rNHuAYy.jpg", movie.Backdrop_path);
            Assert.AreEqual(15000000, movie.Budget);

        }

        [TestMethod]
        public void MovieDetailsTest()
        {

            TheMovieDbClient client = new TheMovieDbClient();
            Movie movie = client.MovieDetails(508);

            Assert.AreEqual(40000000, movie.Budget);
            Assert.AreEqual("http://www.loveactually.com/", movie.Homepage);
        }

        [TestMethod]
        public void Custom_Attrs_Test()
        {
            TheMovieDbClient client = new TheMovieDbClient();
            HtmlReflect.Htmlect a = new HtmlReflect.Htmlect();
            MovieSearchItem[] moviesList = client.Search("drive", 1);
            string movie = "<div><form><input type = 'text' name = 'title' placeholder = 'Insert Title Here'.. ><button> GO </button></form ></div><table class='table table-hover'><thead><tr><th>Id</th><th>Title</th><th>Release_date</th><th>Vote_average</th></tr></thead><tbody><tr><td> <a href = '/movies/64690' > 64690</a></td><td>Drive</td><td>2011-08-06</td><td>7.4</td></tr><tr><td> <a href = '/movies/25571' > 25571</a></td><td>Drive</td><td>1997-08-06</td><td>6.6</td></tr><tr><td> <a href = '/movies/1018' > 1018</a></td><td>Mulholland Drive</td><td>2001-05-16</td><td>7.7</td></tr><tr><td> <a href = '/movies/13523' > 13523</a></td><td>Sex Drive</td><td>2008-10-16</td><td>6</td></tr><tr><td> <a href = '/movies/466550' > 466550</a></td><td>Drive</td><td></td><td>10</td></tr><tr><td> <a href = '/movies/47327' > 47327</a></td><td>Drive Angry</td><td>2011-02-24</td><td>5.3</td></tr><tr><td> <a href = '/movies/256092' > 256092</a></td><td>Drive Hard</td><td>2014-05-26</td><td>3.9</td></tr><tr><td> <a href = '/movies/284286' > 284286</a></td><td>Learning to Drive</td><td>2014-08-21</td><td>6.1</td></tr><tr><td> <a href = '/movies/13704' > 13704</a></td><td>License to Drive</td><td>1988-07-06</td><td>6.1</td></tr><tr><td> <a href = '/movies/45441' > 45441</a></td><td>DRIVE</td><td>2002-01-01</td><td>7</td></tr><tr><td> <a href = '/movies/477591' > 477591</a></td><td>Drive</td><td>1974-05-22</td><td>0</td></tr><tr><td> <a href = '/movies/46302' > 46302</a></td><td>Drive Thru</td><td>2007-05-29</td><td>5</td></tr><tr><td> <a href = '/movies/14429' > 14429</a></td><td>Drive Me Crazy</td><td>1999-10-01</td><td>5.8</td></tr><tr><td> <a href = '/movies/144414' > 144414</a></td><td>Cattle Drive</td><td>1951-08-08</td><td>4.2</td></tr><tr><td> <a href = '/movies/31161' > 31161</a></td><td>Adrenaline Drive</td><td>1999-06-12</td><td>7.3</td></tr><tr><td> <a href = '/movies/16933' > 16933</a></td><td>They Drive by Night</td><td>1940-07-27</td><td>6.7</td></tr><tr><td> <a href = '/movies/365901' > 365901</a></td><td>Big Drive</td><td>2011-01-01</td><td>5</td></tr><tr><td> <a href = '/movies/284106' > 284106</a></td><td>Hard Drive</td><td>2014-08-15</td><td>3.5</td></tr><tr><td> <a href = '/movies/57215' > 57215</a></td><td>Drive, He Said</td><td>1971-06-13</td><td>6.8</td></tr><tr><td> <a href = '/movies/112039' > 112039</a></td><td>Sex Drive</td><td>2003-04-02</td><td>0</td></tr></tbody></table>";
            Assert.AreEqual(movie, a.ToHtml(moviesList));

        }
        [TestMethod]
        public void Custom_Attrs_Test_Single_()
        {
            TheMovieDbClient client = new TheMovieDbClient();
            HtmlReflect.Htmlect a = new HtmlReflect.Htmlect();
            Movie movie = client.MovieDetails(1018);
            string movieStr = "<li class='list-group-item'><strong>Original_title</strong> Mulholland Drive</li><li class='list-group-item'><strong>Tagline</strong> An actress longing to be a star. A woman searching for herself. Both worlds will collide... on Mulholland Drive.</li><ul class='list-group'><li class='list-group-item'><a href='/movies/1018/credits'>Cast and crew </a></li></strong> </ul><li class='list-group-item'><strong>Budget</strong> 15000000</li><li class='list-group-item'><strong>Vote_average</strong> 7.7</li><li class='list-group-item'><strong>Release_date</strong> 2001-05-16</li><ul class='list-group'><div class='card-body bg-light'><div><strong>Overview</strong>:</div>After a car wreck on the winding Mulholland Drive renders a woman amnesic, she and a perky Hollywood-hopeful search for clues and answers across Los Angeles in a twisting venture beyond dreams and reality.</div></strong> </ul></ul>";
            Assert.AreEqual(movieStr, a.ToHtml(movie));

        }
    }
}
