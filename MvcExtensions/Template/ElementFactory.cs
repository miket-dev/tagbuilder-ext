using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Web.Mvc.Extensions.Template
{
    public abstract class ElementFactory
    {
        public abstract MvcHtmlString ToMvcHtmlString();

        public override string ToString()
        {
            return this.ToMvcHtmlString().ToString();
        }
    }
}
