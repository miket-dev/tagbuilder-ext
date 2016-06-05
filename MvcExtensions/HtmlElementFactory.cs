using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc.Extensions.Template;

namespace System.Web.Mvc.Extensions
{
    public class HtmlElementFactory : ElementFactory
    {
        #region Fields
        private TagBuilder _tagBuilder;
        private HtmlFactory _innerFactory;
        #endregion

        #region Constructors
        public HtmlElementFactory(string tagName)
        {
            this._tagBuilder = new TagBuilder(tagName);
            this._innerFactory = new HtmlFactory();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Sets a markup for inner items
        /// </summary>
        public HtmlElementFactory Inner(Action<HtmlFactory> configurator)
        {
            configurator(this._innerFactory);

            return this;
        }

        /// <summary>
        /// Sets attributes for tag
        /// </summary>
        public HtmlElementFactory Attributes(object attributes)
        {
            foreach (var prop in attributes.GetType().GetProperties())
            {
                this._tagBuilder.Attributes.Add(prop.Name, prop.GetValue(attributes).ToString());
            }

            return this;
        }

        /// <summary>
        /// Sets attributes for tag
        /// </summary>
        public HtmlElementFactory Attributes(IDictionary<string, string> attributes)
        {
            foreach (var item in attributes)
            {
                this._tagBuilder.Attributes.Add(item.Key, item.Value);
            }

            return this;
        }

        /// <summary>
        /// adds class name for tag
        /// </summary>
        public HtmlElementFactory Class(string className)
        {
            this._tagBuilder.AddCssClass(className);
            return this;
        }

        /// <summary>
        /// adds style directive for tag
        /// </summary>
        public HtmlElementFactory Style(string name, string value)
        {
            this._tagBuilder.MergeAttribute("style", string.Format("{0}:{1};", name, value), false);
            return this;
        }

        /// <summary>
        /// sets the `name` attribute of tag
        /// </summary>
        public HtmlElementFactory Name(string name)
        {
            this._tagBuilder.MergeAttribute("name", name, true);

            return this;
        }

        /// <summary>
        /// sets inner text for tag
        /// </summary>
        public HtmlElementFactory Text(string text)
        {
            this._tagBuilder.SetInnerText(text);

            return this;
        }

        public override MvcHtmlString ToMvcHtmlString()
        {
            if (this._innerFactory != null)
            {
                this._tagBuilder.InnerHtml += this._innerFactory.ToString();
            }

            var result = this._tagBuilder.ToString();
            return MvcHtmlString.Create(result);
        }
        #endregion
    }
}
