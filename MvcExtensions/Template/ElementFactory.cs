using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Web.Mvc.Extensions.Template
{
    /// <summary>
    /// Base class for element builder factories
    /// </summary>
    public abstract class ElementFactory
    {
        #region Methods
        /// <summary>
        /// Produces result in MvcHtmlString
        /// </summary>
        /// <returns></returns>
        public abstract MvcHtmlString ToMvcHtmlString();

        /// <summary>
        /// Produces result in string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.ToMvcHtmlString().ToString();
        } 
        #endregion
    }
}
