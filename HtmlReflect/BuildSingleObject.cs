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

        public bool ExistingProperties(object obj, List<object> list)
        {

            PropertyInfo[] pi = obj.GetType().GetProperties();
            int j = 0;

            for (int i = 0; i < list.Count; ++i)
            {
                    foreach(PropertyInfo info in list[i].GetType().GetProperties())
                   {
                        object z = pi[j].GetValue(obj);
                        object a = info.GetValue(list[i]);

                    if (a != null && z != null)
                    {
                        if (!a.Equals(z)) return false;
                    }
                    ++j;
                   }
            }
            return true;
        }
    }
}
