using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebBotCore.Tests.Helpers
{
    public static class HtmlDocumentExt
    {
        public static void MergeBody(this HtmlDocument htmlDocument, params HtmlDocument[] htmlDocumentOthers)
        {
            var body = htmlDocument.DocumentNode.SelectSingleNode("//body");

            foreach (var htmlDocumentOther in htmlDocumentOthers)
            {
                var bodyOther = htmlDocumentOther.DocumentNode.SelectSingleNode("//body");
                foreach (var ch in bodyOther.ChildNodes)
                    body.ChildNodes.Add(ch);
            }

        }
    }
}
