using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicRator_nologin_.Models
{
    public class GenreModel : ICollection<AlbumModel>
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

    }
}