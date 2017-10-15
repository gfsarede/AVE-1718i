using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HtmlReflect
{
    interface ExistingValues
    {
        bool ExistingProperties(object obj, List<object> list);
    }
}
