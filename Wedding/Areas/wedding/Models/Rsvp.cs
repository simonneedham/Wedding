using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Wedding.Models
{
    public class Rsvp
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RsvpId { get; set; }

        [Required, StringLength(255)]
        [DisplayName("Your Names")]
        public string Invitees { get; set; }

        [StringLength(255)]
        [DisplayName("Contact email address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DisplayName("No of attendees")]
        public int NoOfAttendees { get; set; }

        [StringLength(500)]
        [DisplayName("Any dietary requirements")]
        [DataType(DataType.MultilineText)]
        public string DietaryRequirements { get; set; }
    }
}