using System;
using System.Collections.Generic;
using System.Web.Mvc.Extensions.Template;

namespace System.Web.Mvc.Extensions
{
    public class HtmlFactory : ElementFactory
    {
        #region Fields
        /// <summary>
        /// inner factories
        /// </summary>
        private List<HtmlElementFactory> _elementFactories;
        #endregion

        #region Contructors
        public HtmlFactory()
        {
            this._elementFactories = new List<HtmlElementFactory>();
        } 
        #endregion

        #region Methods
        /// <summary>
        /// Adds an element builder factory for required tag name
        /// </summary>
        public HtmlElementFactory Add(string tagName)
        {
            var elementFactory = new HtmlElementFactory(tagName);
            this._elementFactories.Add(elementFactory);

            return elementFactory;
        }

        /// <summary>
        /// Produces result in MvcHtmlString
        /// </summary>
        public override MvcHtmlString ToMvcHtmlString()
        {
            var result = string.Empty;

            foreach (var item in this._elementFactories)
            {
                result += item.ToString();
            }

            return MvcHtmlString.Create(result);
        } 
        #endregion
    }
}
