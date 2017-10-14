using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HtmlReflect
{
    class BuildSingleObject : ExistingValues
    {

        PropertyInfo[] info;

        public BuildSingleObject(PropertyInfo[] info)
        {
            this.info = info;
        }

        public PropertyInfo[] ExistingProperties(object obj)
        {
            return obj.GetType().GetProperties();
        }
    }
}
