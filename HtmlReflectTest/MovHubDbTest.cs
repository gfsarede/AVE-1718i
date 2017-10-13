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
        public void ToHtmlArrayTest()
        {
            TheMovieDbClient client = new TheMovieDbClient();
            HtmlReflect.Htmlect a = new HtmlReflect.Htmlect();
            MovieSearchItem[] moviesList = client.Search("drive", 1);
            string movie = "<div><form><input type = 'text' name = 'title' placeholder = 'Insert Title Here'.. ><button> GO </button></form ></div><table class='table table-hover'><thead><tr><th>Id</th><th>Title</th><th>Release_date</th><th>Vote_average</th><th>Vote_count</th><th>Video</th><th>Popularity</th><th>Poster_path</th><th>Original_language</th><th>Original_title</th><th>Genre_ids</th><th>Backdrop_path</th><th>Adult</th><th>Overview</th><th>Character</th><th>Credit_id</th></tr></thead><tbody><tr><td>64690</td><td>Drive</td><td>2011-08-06</td><td>7.4</td><td>3797</td><td>False</td><td>19.29022</td><td>/nu7XIa67cXc2t7frXCE5voXUJcN.jpg</td><td>en</td><td>Drive</td><td>System.Int32[]</td><td>/ekLAySalu0CGoGogPWY0BG6uAul.jpg</td><td>False</td><td>A Hollywood stunt performer who moonlights as a wheelman for criminals discovers that a contract has been put on him after a heist gone wrong.</td><td></td><td></td></tr><tr><td>25571</td><td>Drive</td><td>1997-08-06</td><td>6.6</td><td>25</td><td>False</td><td>8.123217</td><td>/zdlL3ROrZaYP98beN5f1OnOwIls.jpg</td><td>en</td><td>Drive</td><td>System.Int32[]</td><td>/7fP7puDA7n8noKjU1PN7NF73CP1.jpg</td><td>False</td><td>Drive follows Toby Wong (Mark Dacascos), whose employers at Hong Kong's Leung Corporation have implanted in his chest a bio-energy module that enhances his physical abilities. Toby has escaped from the Leung Corporation's control and is making his way to Los Angeles, where a competing company has offered to remove the implant and give him his life back.After arriving in San Francisco, Toby encounters -- and, in desparation, kidnaps -- Malik Brodie (Kadeem Hardison), who has the means to get him to Los Angeles. Following close behind are professional assassins and junk-culture connoisseurs Vic Madison (John Pyper-Ferguson) and The Hedgehog (Tracey Walter), who are pursuing Toby in the employ of the Leung Corporation's president, Mr. Lau (James Shigeta).</td><td></td><td></td></tr><tr><td>1018</td><td>Mulholland Drive</td><td>2001-05-16</td><td>7.7</td><td>1517</td><td>False</td><td>22.32861</td><td>/oKyY4TFaLjQTgyX8oRde82GinOw.jpg</td><td>en</td><td>Mulholland Drive</td><td>System.Int32[]</td><td>/ihkQywNs6Si24WssdmT1rNHuAYy.jpg</td><td>False</td><td>After a car wreck on the winding Mulholland Drive renders a woman amnesic, she and a perky Hollywood-hopeful search for clues and answers across Los Angeles in a twisting venture beyond dreams and reality.</td><td></td><td></td></tr><tr><td>13523</td><td>Sex Drive</td><td>2008-10-16</td><td>6</td><td>347</td><td>False</td><td>12.66556</td><td>/bwXrZy2xqsyDnno4z8AENEgVfsO.jpg</td><td>en</td><td>Sex Drive</td><td>System.Int32[]</td><td>/1RaVsWb6gz6L5ZzQfviFAjWmLBP.jpg</td><td>False</td><td>A high school senior drives cross-country with his best friends to hook up with a babe he met online.</td><td></td><td></td></tr><tr><td>466550</td><td>Drive</td><td></td><td>10</td><td>1</td><td>False</td><td>1.641425</td><td>/ha11cK3K2JtewCfacOf19uaMbyx.jpg</td><td>hi</td><td>à¤§à¥‹à¤¨à¥€</td><td>System.Int32[]</td><td>/1mCMIbrMUQUrTv2YKAuyuRGu0V.jpg</td><td>False</td><td>An unnamed stunt driver who moonlights as a getaway driver. However, soon after he becomes attracted to a female neighbor whose husband owes some money to a local gangster, he is drawn deeper into a dangerous underworld.</td><td></td><td></td></tr><tr><td>47327</td><td>Drive Angry</td><td>2011-02-24</td><td>5.3</td><td>604</td><td>False</td><td>9.590001</td><td>/afYwV0EAO8YLRyrTnNaSRysDrCh.jpg</td><td>en</td><td>Drive Angry</td><td>System.Int32[]</td><td>/fjJyicmZ7wfsZrRuv1Ve2Vv0Zlf.jpg</td><td>False</td><td>Milton is a hardened felon who has broken out of Hell, intent on finding the vicious cult who brutally murdered his daughter and kidnapped her baby. He joins forces with Piper, a sexy, tough-as-nails waitress with a 69 Charger, who's also seeking redemption of her own. Caught in a deadly race against time, Milton has three days to avoid capture, avenge his daughter's death, and save her baby before she's mercilessly sacrificed by the cult.</td><td></td><td></td></tr><tr><td>256092</td><td>Drive Hard</td><td>2014-05-26</td><td>3.9</td><td>74</td><td>False</td><td>7.324289</td><td>/nINoOfBJAsWGUv82G5crn4p9uBG.jpg</td><td>en</td><td>Drive Hard</td><td>System.Int32[]</td><td>/mKQ1xgeT2ASt7QHt3aNc0Z0WvGP.jpg</td><td>False</td><td>A former race car driver is abducted by a mysterious thief and forced to be the wheel-man for a crime that puts them both in the sights of the cops and the mob.</td><td></td><td></td></tr><tr><td>284286</td><td>Learning to Drive</td><td>2014-08-21</td><td>6.1</td><td>79</td><td>False</td><td>12.03377</td><td>/7rSgR0M7yOHuCJa8msQgCcsTK2J.jpg</td><td>en</td><td>Learning to Drive</td><td>System.Int32[]</td><td>/pkDNjjJrnnIDYJcgODxp0FSBKsm.jpg</td><td>False</td><td>As her marriage dissolves, a Manhattan writer takes driving lessons from a Sikh instructor with marriage troubles of his own. In each other's company they find the courage to get back on the road and the strength to take the wheel.</td><td></td><td></td></tr><tr><td>13704</td><td>License to Drive</td><td>1988-07-06</td><td>6.1</td><td>100</td><td>False</td><td>10.69467</td><td>/fIEH2uWrR2KkFuYKnL56f0PQFrP.jpg</td><td>en</td><td>License to Drive</td><td>System.Int32[]</td><td>/e90RPZKUJUmDf1Z81muikwBUmBc.jpg</td><td>False</td><td>Teenager Les Anderson thinks his life can't get any worse after he flunks his driver's exam, but he's wrong. Even though he didn't receive his license, Les refuses to break his date with the cool Mercedes Lane, and he decides to lift his family's prize luxury car for the occasion. Unfortunately, Mercedes sneaks some booze along and passes out drunk, and a confused Les makes the bad decision of enlisting his rebellious friend, Dean, to help.</td><td></td><td></td></tr><tr><td>45441</td><td>DRIVE</td><td>2002-01-01</td><td>7</td><td>7</td><td>False</td><td>1.353366</td><td>/lzLmfsmbvvWUlCvIJPFhyORTPBH.jpg</td><td>ja</td><td>ãƒ‰ãƒ©ã‚¤ãƒ–</td><td>System.Int32[]</td><td>/6QY5NFee09LlYykNbvoRGhiHx6v.jpg</td><td>False</td><td>A salaryman is hijacked by bank robbers.</td><td></td><td></td></tr><tr><td>477591</td><td>Drive</td><td>1974-05-22</td><td>0</td><td>0</td><td>False</td><td>1.192972</td><td>/6HCrJZF1iJmL7Ftine9Xg8svPJF.jpg</td><td>en</td><td>Drive</td><td>System.Int32[]</td><td></td><td>False</td><td>Murderous madwoman Arachne plots to kidnap a scientist who has developed a drug that eradicates the sex drive, in a scheme to rid the world of sex.</td><td></td><td></td></tr><tr><td>46302</td><td>Drive Thru</td><td>2007-05-29</td><td>5</td><td>30</td><td>False</td><td>2.923061</td><td>/A7jj7Sm99ClbIE96cR0lqQh4mog.jpg</td><td>en</td><td>Drive Thru</td><td>System.Int32[]</td><td>/8JSzuwykHHnLIYexaHmT7H9s2WE.jpg</td><td>False</td><td>Horror gets Super Sized when Horny The Clown, the demonic mascot of \"Hella-Burger,\" starts slashing Orange County teenagers with his meat cleaver from Hell.</td><td></td><td></td></tr><tr><td>14429</td><td>Drive Me Crazy</td><td>1999-10-01</td><td>5.8</td><td>62</td><td>False</td><td>4.551959</td><td>/ljg0qL7RPUaP8Td6jQ1yOPVSodK.jpg</td><td>en</td><td>Drive Me Crazy</td><td>System.Int32[]</td><td>/oY3yo3RTnYvX27k4R12AjTVSi3N.jpg</td><td>False</td><td>Nicole and Chase live next door to each other but are worlds apart. However, they plot a scheme to date each other in order to attract the interest and jealousy of their respective romantic prey. But in the mist of planning a gala centennial celebration, Nicole and Chase find that the one they always wanted was closer than they ever thought.</td><td></td><td></td></tr><tr><td>144414</td><td>Cattle Drive</td><td>1951-08-08</td><td>4.2</td><td>5</td><td>False</td><td>2.485235</td><td>/xSGfyd1kJ10eQXjNg62Xdx73SG9.jpg</td><td>nl</td><td>Cattle Drive</td><td>System.Int32[]</td><td>/sLRlNOVwMYITZY7MYP6whjhdAcJ.jpg</td><td>False</td><td>The spoilt young son of a wealthy railroad owner manages to get himself lost in the middle of nowhere. He is found by a cowboy on a cattle drive and the lad must start learning the hard lessons of working in a team if he wants to make it to San Diego.</td><td></td><td></td></tr><tr><td>31161</td><td>Adrenaline Drive</td><td>1999-06-12</td><td>7.3</td><td>3</td><td>False</td><td>1.312109</td><td>/1cQvsNQsWxQni9HmNnncDQwr9Og.jpg</td><td>ja</td><td>ã‚¢ãƒ‰ãƒ¬ãƒŠãƒªãƒ³ãƒ‰ãƒ©ã‚¤ãƒ–</td><td>System.Int32[]</td><td>/uT8jajGwAQqwBU2hR5aJg7tUQJ.jpg</td><td>False</td><td>A gas leak explosion at a yakuza hideout provides a shy nurse and a rental car clerk with the opportunity to take a briefcase full of money. A cross-country chase ensues.</td><td></td><td></td></tr><tr><td>16933</td><td>They Drive by Night</td><td>1940-07-27</td><td>6.7</td><td>25</td><td>False</td><td>3.07962</td><td>/VOZx5cY3le1jrcHsvssssCfJhq.jpg</td><td>en</td><td>They Drive by Night</td><td>System.Int32[]</td><td>/c9xa3KlvXJbX9C1Yi3AtmucRYsa.jpg</td><td>False</td><td>Joe (George Raft) and Paul Fabrini (Humphrey Bogart) are Wildcat or, independent truck drivers who have their own small one truck business. The Fabrini boys constantly battle distributors, rivals and loan collectors, while trying to make a success of their transport company.</td><td></td><td></td></tr><tr><td>365901</td><td>Big Drive</td><td>2011-01-01</td><td>5</td><td>1</td><td>True</td><td>1.042353</td><td>/zC89ylSHbBf3OFTM0sSxIAR6OcF.jpg</td><td>fr</td><td>Sur la route</td><td>System.Int32[]</td><td></td><td>False</td><td></td><td></td><td></td></tr><tr><td>284106</td><td>Hard Drive</td><td>2014-08-15</td><td>3.5</td><td>2</td><td>False</td><td>1.668788</td><td>/4VEdFlY1F8WDyjylZXQisjseg5J.jpg</td><td>en</td><td>Hard Drive</td><td>System.Int32[]</td><td></td><td>False</td><td>One young man's plunge into adulthood and the uplifting joy of first love.</td><td></td><td></td></tr><tr><td>57215</td><td>Drive, He Said</td><td>1971-06-13</td><td>6.8</td><td>4</td><td>False</td><td>2.561366</td><td>/dPFuF3twG4wShi1bHBubk07G8nh.jpg</td><td>en</td><td>Drive, He Said</td><td>System.Int32[]</td><td>/rV2pDbXghLTIiuOWTNhtHcOipit.jpg</td><td>False</td><td>Hector is a star basketball player for the College basketball team he plays for, the Leopards. His girlfriend, Olive, doesn't know whether to stay with him or leave him. And his friend, Gabriel, who may have dropped out from school and become a protestor, wants desperately not to get drafted for Vietnam.</td><td></td><td></td></tr><tr><td>112039</td><td>Sex Drive</td><td>2003-04-02</td><td>0</td><td>0</td><td>False</td><td>1.568749</td><td>/oMA7HxWqc5MIxY8pecyYLrlvEtw.jpg</td><td>en</td><td>Sex Drive</td><td>System.Int32[]</td><td></td><td>False</td><td>A 'sexperienced' fashion photographer and a broken-hearted fashion model take on a journey of fun and sex going to Sagada. Along the way they pick up an amnesia-hit guy starting a chain of conflicts.</td><td></td><td></td></tr></tbody></table>";
            Assert.AreEqual(movie, a.ToHtml(moviesList));

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
    }
}
