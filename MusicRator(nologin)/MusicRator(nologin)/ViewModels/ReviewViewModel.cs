using MusicRator_nologin_.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicRator_nologin_.ViewModels
{
    public class ReviewViewModel
    {
        [Key]
        public int rvId { get; set; }

        public ReviewModel ReviewModel { get; set; }
        public AlbumModel AlbumModel { get; set; }
    }
}