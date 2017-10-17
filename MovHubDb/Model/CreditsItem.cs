namespace MovHubDb.Model
{
    public class CreditsItem
    {

        [HtmlAs(" <a href='/person/{value}/movies'> {value}</a>")]
        public int Id { get; set; }
        public string Character { get; set; }
        public string Name { get; set; }

        [HtmlIgnore]
        public int Cast_id { get; set; }
        [HtmlIgnore]
        public string Credit_id { get; set; }
        [HtmlIgnore]
        public int Gender { get; set; }
        [HtmlIgnore]
        public int Order { get; set; }
        [HtmlIgnore]
        public string Profile_path { get; set; }

    }
}