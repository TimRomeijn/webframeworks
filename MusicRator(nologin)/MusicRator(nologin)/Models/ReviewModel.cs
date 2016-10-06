using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MusicRator_nologin_.Models
{
    public class ReviewModel
    {
        [Key]
        public int Id { get; set; }

        public string ReviewText { get; set; }

        public int Rating { get; set; }

        public DateTime Date { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public UserModel User { get; set; }

        [ForeignKey("Album")]
        public int AlbumId { get; set; }

        public AlbumModel Album { get; set; }
    }
}