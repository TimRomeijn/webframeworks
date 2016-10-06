using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MusicRator_nologin_.Models
{
    public class AlbumModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Genre")]
        public int GenreId { get; set; }

        public GenreModel Genre { get; set; }

        public string Title { get; set; }

        public string Artist { get; set; }

        public int ReleaseYear { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<ReviewModel> Reviews { get; set; }
    }
}