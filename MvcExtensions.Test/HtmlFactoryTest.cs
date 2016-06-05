using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc.Extensions;

namespace MvcExtensions.Test
{
    [TestClass]
    public class HtmlFactoryTest
    {
        private HtmlFactory _htmlFactory = new HtmlFactory();

        [TestMethod]
        public void SimpleMarkup()
        {
            this._htmlFactory.Add("div");

            Assert.AreEqual("<div></div>", this._htmlFactory.ToString());
        }

        [TestMethod]
        public void SimpleMarkupWithClass()
        {
            this._htmlFactory.Add("div").Class("temp");

            Assert.AreEqual("<div class=\"temp\"></div>", this._htmlFactory.ToString());
        }

        [TestMethod]
        public void SimpleMarkupWithName()
        {
            this._htmlFactory.Add("div").Name("temp");

            Assert.AreEqual("<div name=\"temp\"></div>", this._htmlFactory.ToString());
        }

        [TestMethod]
        public void SimpleMarkupWithStyle()
        {
            this._htmlFactory.Add("div").Style("display", "none");

            Assert.AreEqual("<div style=\"display:none;\"></div>", this._htmlFactory.ToString());
        }

        [TestMethod]
        public void SimpleMarkupWithAttribute()
        {
            this._htmlFactory.Add("div").Attributes(new { custom = "custom" });

            Assert.AreEqual("<div custom=\"custom\"></div>", this._htmlFactory.ToString());
        }

        [TestMethod]
        public void SimpleMarkupWithText()
        {
            this._htmlFactory.Add("div").Text("temp");

            Assert.AreEqual("<div>temp</div>", this._htmlFactory.ToString());
        }

        [TestMethod]
        public void MarkupWithInnerItems()
        {
            this._htmlFactory.Add("div").Inner(factory =>
                {
                    factory.Add("div");
                });

            Assert.AreEqual("<div><div></div></div>", this._htmlFactory.ToString());
        }
    }
}
