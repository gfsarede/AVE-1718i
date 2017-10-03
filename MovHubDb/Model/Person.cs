namespace MovHubDb.Model
{
    public class Person
    {

        string birthday;
        string deathday;
        int id;
        string name;
        int gender;
        string biography;
        double popularity;
        string place_of_birth;
        string profile_path;
        bool adult;
        string imdb_id;
        string homepage;

        public string Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }

        public string Deathday
        {
            get { return deathday; }
            set { deathday = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public string Biography
        {
            get { return biography; }
            set { biography = value; }
        }

        public double Popularity
        {
            get { return popularity; }
            set { popularity = value; }
        }

        public string Place_of_birth
        {
            get { return place_of_birth; }
            set { place_of_birth = value; }
        }

        public string Profile_path
        {
            get { return profile_path; }
            set { profile_path = value; }
        }

        public bool Adult
        {
            get { return adult; }
            set { adult = value; }
        }

        public string Imdb_id
        {
            get { return imdb_id; }
            set { imdb_id = value; }
        }

        public string Homepage
        {
            get { return homepage; }
            set { homepage = value; }
        }
    }
}
