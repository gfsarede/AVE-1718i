using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovHubDb
{
    class CustomAttributes
    {
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class HtmlIgnoreAttribute : Attribute
    {

    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class HtmlAsAttribute : Attribute
    {
        public HtmlAsAttribute(string html)
        {
            Html = html;
        }

        public string Html
        {
            get; set;
        }

    }
}
