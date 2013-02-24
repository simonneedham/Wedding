using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Wedding.Models
{
    public class BlogContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }


        public IList<TagCloudItem> GetTagCloudItems()
        {
            int totaltagCount = 0;

            foreach (var post in this.Posts.Where(p => p.Tags.Count > 0))
                totaltagCount += post.Tags.Count;

            var tagItems = this.Tags.Include(t => t.Posts).Where(t => t.Posts.Count>0).OrderBy(t => t.Name).Select(
                    t => new TagCloudItem() { TotalTagCount = totaltagCount, Count = t.Posts.Count, Name = t.Name });

            return tagItems.ToList();
        }


        protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
        {
            dbModelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}