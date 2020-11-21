using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebBotCore.Tests.Helpers
{
    public class SimpleHtmlBuilder
    {
        private HtmlDocument htmlDocument = new HtmlDocument();
        private HtmlNode htmlNodeCurrent;

        public SimpleHtmlBuilder()
        {
            htmlNodeCurrent = htmlDocument.DocumentNode;
        }


        public SimpleHtmlBuilder GoToParent()
        {
            htmlNodeCurrent = htmlNodeCurrent.ParentNode;
            return this;
        }

        public SimpleHtmlBuilder CreateElement(string elementName, string elementValue = null)
        {
            var htmlNode = htmlDocument.CreateElement(elementName);

            if (!string.IsNullOrEmpty(elementValue))
                htmlNode.InnerHtml = HtmlDocument.HtmlEncode(elementValue);

            htmlNodeCurrent.AppendChild(htmlNode);

            htmlNodeCurrent = htmlNode;

            return this;
        }

        public SimpleHtmlBuilder CreateAttribute(string attributeName, string attributeValue)
        {
            var attribute = htmlDocument.CreateAttribute(attributeName);
            attribute.Value = attributeValue;
            htmlNodeCurrent.Attributes.Add(attribute);

            return this;
        }


        public static implicit operator HtmlDocument(SimpleHtmlBuilder htmlDocument)
        {
            return htmlDocument.htmlDocument;
        }

    }
}
