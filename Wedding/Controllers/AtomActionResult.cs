using System.ServiceModel.Syndication;
using System.Web.Mvc;
using System.Xml;

namespace Wedding.Controllers
{
    public class AtomActionResult : ActionResult
    {
        SyndicationFeed _feed;

        //Default Constructor
        public AtomActionResult() { }

        public AtomActionResult(SyndicationFeed feed)
        {
            _feed = feed;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.ContentType = "application/atom+xml";

            Atom10FeedFormatter formatter = new Atom10FeedFormatter(_feed);
            using (XmlWriter writer = XmlWriter.Create(context.HttpContext.Response.Output))
            {
                formatter.WriteTo(writer);
            }
        }
    }
}