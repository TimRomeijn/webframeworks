using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MusicRator_nologin_.Models
{
    public class AlbumModel: ICollection<ReviewModel>
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey]
        public GenreModel GenreId { get; set; }

        public string Title { get; set; }

        public string Artist { get; set; }

        public int ReleaseYear { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }
    }
}