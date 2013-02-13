using System.ServiceModel.Syndication;
using System.Web.Mvc;
using System.Xml;

namespace Wedding.Controllers
{
    public class RssActionResult : ActionResult
    {
        SyndicationFeed _feed;

        //Default Constructor
        public RssActionResult() { }

        public RssActionResult(SyndicationFeed feed)
        {
            _feed = feed;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.ContentType = "application/rss+xml";

            Rss20FeedFormatter formatter = new Rss20FeedFormatter(_feed);
            using (XmlWriter writer = XmlWriter.Create(context.HttpContext.Response.Output))
            {
                formatter.WriteTo(writer);
            }
        }
    }
}