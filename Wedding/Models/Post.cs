using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Wedding.Models
{
    public class Post
    {
        string _userName = string.Empty;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostId { get; set; }

        [Required, StringLength(100)]
        public string Title { get; set; }

        [MaxLength, Required]
        public string PostContent { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Updated { get; set; }

        [Required, StringLength(50)]
        public string UserName
        {
            get { return _userName.ToLower(); }
            set { _userName = value.ToLower(); }
        }
    }
}