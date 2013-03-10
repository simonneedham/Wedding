using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Wedding.Models
{
    public class Rsvp
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RsvpId { get; set; }

        [Required, StringLength(255)]
        public string Invitees { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        public int NoOfAttendees { get; set; }

        [StringLength(500)]
        public string DietaryRequirements { get; set; }
    }
}