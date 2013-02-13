using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wedding.Models;
using System.ServiceModel.Syndication;

namespace Wedding.Controllers
{ 
    public class SyndicationController : Controller
    {
        private BlogContext _db = new BlogContext();

        [CompressFilter]
        public AtomActionResult Atom()
        {
            return new AtomActionResult(GetFeed());
        }


        [CompressFilter]
        public RssActionResult RSS()
        {
            return new RssActionResult(GetFeed());
        }

        private SyndicationFeed GetFeed()
        {
            //get website urls
            string feedUrl = Request.Url.AbsoluteUri;
            string siteUrl = Request.Url.GetLeftPart(UriPartial.Authority);

            //get posts & tags
            var posts = _db.Posts.Include(p => p.Tags).OrderByDescending(p => p.Updated);

            //populate feed
            var lastUpdate = posts.Take(1).SingleOrDefault().Updated;
            var feed = new SyndicationFeed("Simon & Helen Wedding News", "Keeping you up to date with news and information regarding Simon & Helen's wedding.", new Uri(feedUrl), "FeedID", lastUpdate);

            var items = posts.ToList().Select(p => new SyndicationItem(
                                    p.Title,
                                    new TextSyndicationContent(p.PostContent),
                                    new Uri(siteUrl + "/News/" + "/" + p.PostId),
                                    p.PostId.ToString(),
                                    p.Updated
                                    )).ToDictionary(p => p.Id);

            foreach (var postWithTags in posts.Where(p => p.Tags.Count > 0))
            {
                var item = items[postWithTags.PostId.ToString()];
                foreach (var tag in postWithTags.Tags)
                    item.Categories.Add(new SyndicationCategory(tag.Name));
            }


            feed.Items = items.Values.ToList<SyndicationItem>();

            //Set other feed properties
            feed.Id = "C27D9B11-1039-4209-9333-4A853CAFD306";
            feed.Language = "en-gb";
            feed.Generator = "Needham Blog Engine 1.0";
            feed.ImageUrl = new Uri(siteUrl + "/images/apple-touch-icon-114x114.png");

            SyndicationPerson sp = new SyndicationPerson("simonandhelen@needham.uk.net", "Simon & Helen", siteUrl);
            
            feed.Authors.Add(sp);
            feed.Contributors.Add(sp);

            feed.Copyright = new TextSyndicationContent("Copyright (c) Simon Needham & Helen Tweedle 2012");
            feed.Description = new TextSyndicationContent("Keeping you up to date with news and information regarding Simon & Helen's wedding.");

            return feed;
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}