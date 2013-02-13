using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Text;
using Wedding.Models;

namespace Wedding
{
    //Reproduced from Gunnar Peipman's blog article and tweakled a little for my needs.
    //http://weblogs.asp.net/gunnarpeipman/archive/2011/04/28/creating-tag-cloud-using-asp-net-mvc-and-entity-framework.aspx
    public static class HtmlExtensions
    {
        public static string MakeTagCloud()
        {
            var output = new StringBuilder();
            output.Append(@"<div class=""tagCloud"">");

            using (var bg = new BlogContext())
            {
                var tagItems = bg.GetTagCloudItems();

                foreach (TagCloudItem tag in tagItems)
                {
                    output.AppendFormat(@"<span class=""tag{0}""><a href=""/tag/{1}"">{1}</a></span>", tag.Rank, tag.Name);
                    output.Append("&nbsp;");
                }
            }

            output.Append("</div>");

            return output.ToString();
        }

        public static string GetDaysToGo()
        {
            var daysToGo = new DateTime(2013, 06, 15).Subtract(DateTime.Today).Days;
            return daysToGo.ToString();
        }
    }
}