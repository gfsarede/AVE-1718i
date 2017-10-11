using MovHubDb;
using System;
using System.Reflection;


namespace HtmlReflect
{
    public class Htmlect
    {
                                                                        //Global variables to help in the construction of the HTML
        string ulClass = "<ul class='list-group'>";                         
        string listGroupItem = "<li class='list-group-item'>";
        string closeStrong = "</strong> ";
        string closeGroupItem = "</li>";
        string closeListGroup = "</ul>";
        string str = "<table class='table table-hover'><thead><tr>";
        string td = "<td>";
        string th = "<th>";
        string closeTh = "</th>";
        string closeThread = "</thead>";
        string closeTd = "</td>";
        string tbody = "<tbody>";
        string strong = "<strong>";
        string closeTbody = "</tbody>";
        string tr = "<tr>";
        string closeTr = "</tr>";
        string closeTable = "</table>";


        public string ToHtml(object obj)
        {
            Type t = obj.GetType();

            foreach (PropertyInfo p in t.GetProperties())
            {
                if (p.IsDefined(typeof(HtmlIgnoreAttribute), false))            //if its annotated with Ignore continue
                {
                    continue;
                }
                else if (p.IsDefined(typeof(HtmlAsAttribute), false))           //if it is annotaded with HtmlAs construct the Html as says in the customAttr
                {
                    HtmlAsAttribute[] attributes = (HtmlAsAttribute[])p.GetCustomAttributes(typeof(HtmlAsAttribute), false);
                    string aux = ConstructHtmlString(attributes);
                    string aux2 = aux.Replace("{name}", p.Name).Replace("{value}", p.GetValue(obj) + "") + closeStrong + closeListGroup;
                    ulClass += aux2;
                }
                else
                {
                    ulClass += listGroupItem + strong + p.Name + closeStrong + p.GetValue(obj) + closeGroupItem; 
                }
            }
            ulClass += closeListGroup;
            return ulClass;
        }


        public string ToHtml(object[] arr)                                      
        {
            foreach (PropertyInfo p in arr[0].GetType().GetProperties())                //Needed to put first the name of the properties
            {
                if (!p.IsDefined(typeof(HtmlIgnoreAttribute), false))
                    str += th + p.Name + closeTh;
            }

            str += closeTr + closeThread + tbody;

            for (int i = 0; i < arr.Length; i++)
            {
                str += tr;
                Type t = arr[i].GetType();

                foreach (PropertyInfo p in t.GetProperties())
                {
                    if (p.IsDefined(typeof(HtmlIgnoreAttribute), false))
                    {
                        continue;
                    }

                    else if (p.IsDefined(typeof(HtmlAsAttribute), false))
                    {
                        object[] attributes = p.GetCustomAttributes(typeof(HtmlAsAttribute), false);
                        string aux = ConstructHtmlString(attributes);
                        string aux2 = td + aux.Replace("{value}", p.GetValue(arr[i]) + "") + closeTd;
                        str += aux2;
                    }
                    else
                    {
                        str += td + p.GetValue(arr[i]) + closeTd;
                    }
                }
                str += closeTr;
            }
            str += closeTbody + closeTable;
            return str;

        }

        private string ConstructHtml(object[] obj)
        {
            string str = "<table class='table table-hover'><thead><tr>";
            Type t_item = obj.GetType().GetElementType();                   

            foreach (PropertyInfo p in t_item.GetProperties())                  //Needed to put first the name of the properties
            {
                str += td + strong + p.Name + closeStrong + closeTd;
            }

            str += closeThread + tbody;

            for (int i = 0; i < obj.Length; i++)
            {
                str += tr;
                foreach (PropertyInfo p in t_item.GetProperties())              //Then, fill the table with the value of the Properties
                {
                    str += td + p.GetValue(obj[i]) + closeTd;
                }
                str += closeTr;
            }
            return str;
        }

        public string ConstructHtmlString(object[] attrs)                       //Get the value of the annotated CustomAttribs
        {
            string str = "";

            foreach (object o in attrs)
                str = (string)(attrs[0].GetType().GetProperty("Html").GetValue(attrs[0]));
            return str;
        }
    }
}
