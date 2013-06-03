using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Wedding.Models
{
    public class Post
    {
        string _userName = string.Empty;
        List<Tag> _tags;

        public Post()
        {
            this.Updated = DateTime.UtcNow;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostId { get; set; }

        [Required, StringLength(100)]
        public string Title { get; set; }

        [MaxLength, Required, AllowHtml]
        public string PostContent { get; set; }

        public DateTime Updated { get; set; }

        [Required, StringLength(50)]
        public string UserName
        {
            get { return _userName.ToLower(); }
            set { _userName = value.ToLower(); }
        }

        [NotMapped]
        public string TagString
        {
            get
            {
                var tags = this.Tags.Select(n => n.Name).ToList<string>();
                return String.Join(" ", tags);
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    string tagString = value;

                    if (tagString.Contains(" "))
                    {
                        var tagNames = tagString.Split(' ');

                        for (int i = 0; i < tagNames.Length; i++)
                        {
                            if(this.Tags.Where(t => t.Name == tagNames[i]).SingleOrDefault() == null)
                                this.Tags.Add(new Tag() { Name = tagNames[i].Trim() });
                        }
                    }
                    else
                    {
                        this.Tags.Add(new Tag() { Name = tagString.Trim() });
                    }
                }
            }
        }

        public virtual List<Tag> Tags
        {
            get
            {
                if(_tags==null)
                    _tags = new List<Tag>();

                return _tags;
            }
            set
            {
                _tags = value;
            }
        }
    }
}