using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Wedding.Models
{
    public class SongRequest
    {
        private string _songName = String.Empty;
        private string _artistName = String.Empty;

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SongRequestId { get; set; }

        [StringLength(255), DisplayName("Song")]
        public string SongName
        {
            get { return _songName; }
            set { _songName = value ?? String.Empty; }
        }

        [StringLength(100), DisplayName("Artist")]
        public string ArtistName
        {
            get { return _artistName; }
            set { _artistName = value ?? String.Empty; }
        }

        [StringLength(100), Required]
        public string IPAddress { get; set; }

        public DateTime Updated { get; set; }
    }
}