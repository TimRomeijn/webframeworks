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

        [ForeignKey]
        public UserModel UserId { get; set; }

        [ForeignKey]
        public AlbumModel AlbumId { get; set; }
    }
}