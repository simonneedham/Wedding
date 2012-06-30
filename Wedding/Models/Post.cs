using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Wedding.Models
{
    public class Post
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostId { get; set; }

        [Required, StringLength(100)]
        public string Title { get; set; }

        [MaxLength, Required]
        public string PostContent { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed), DisplayFormat(DataFormatString="{0:dd-MMM-yyyy hh:mm tt}")]
        public DateTime Updated { get; set; }

        public int UserId { get; set; }
    }
}