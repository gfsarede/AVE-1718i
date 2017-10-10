using MovHubDb;
using System;
using System.Reflection;


namespace HtmlReflect
{
    public class Htmlect
    {

        string str = "<ul class='list-group'>";
        string listGroupItem = "<li class='list-group-item'><strong> ";
        string closeStrong = "</strong>: ";
        string closeGroupItem = "</li>";
        string closeListGroup = "</ul>";

        public string ConstructHtmlString(object target, HtmlAsAttribute attrs)
        {
            return "";
        }


        public string ToHtmlCustom(object obj)
        {
            Type t = obj.GetType();

            foreach (PropertyInfo p in t.GetProperties())
            {
                if (!p.IsDefined(typeof(HtmlIgnoreAttribute), false))
                {
                    str += listGroupItem + p.Name + closeStrong + p.GetValue(obj) + closeGroupItem;
                }

                if (p.IsDefined(typeof(HtmlAsAttribute), false))
                {
                    object instance = Activator.CreateInstance(t);
                    object attributes = p.GetCustomAttributes(typeof(HtmlAsAttribute), false);
                    str += ConstructHtmlString(instance, (HtmlAsAttribute)attributes);
                }
            }

            str += closeListGroup;
            return str;
        }

        public string ToHtmlCustom(object[] obj)
        {
            Type t = obj.GetType();



            return "";
        }

        public string ToHtml(object obj)
        {

            foreach (PropertyInfo f in obj.GetType().GetProperties())
                str += listGroupItem + f.Name + closeStrong + f.GetValue(obj) + closeGroupItem;

            str += closeListGroup;
            return str;
        }

        public string ToHtml(object[] arr)
        {
            string str = "";


            str = ConstructHtml(arr);

            return str;
        }

        private string ConstructHtml(object[] obj)
        {
            string str = "<table class='table table-hover'><thead><tr>";
            string td = "<td>";
            string closeThread = "</thead>";
            string closeTd = "</td>";
            string tbody = "<tbody>";
            string strong = "<strong>";
            string closeStrong = "</strong>";
            string closeTbody = "</tbody>";
            string tr = "<tr>";
            string closeTr = "</tr>";

            Type t_item = obj.GetType().GetElementType();

            foreach (PropertyInfo p in t_item.GetProperties())
            {
                str += td + strong + p.Name + closeStrong + closeTd;
            }

            str += closeThread + tbody;

            for (int i = 0; i < obj.Length; i++)
            {
                str += tr;
                foreach (PropertyInfo p in t_item.GetProperties())
                {
                    if (p.Name.Equals("id"))

                        str += td + "<a href =http://localhost:3000/movies/" + p.GetValue(obj[i]) + "?api_key=bf3af3188d1b9a4a4e7bcf1a02ef3f58>" + p.GetValue(obj[i]) + "</a>";
                    else
                        str += td + p.GetValue(obj[i]) + closeTd;
                }
                str += closeTr;

            }
            return str;
        }
    }
}
