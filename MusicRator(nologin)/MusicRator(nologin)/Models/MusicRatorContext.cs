﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MusicRator_nologin_.Models
{
    public class MusicRatorContext: DbContext
    {

        public DbSet<UserModel> Users { get; set; }
        public DbSet<ReviewModel> Reviews { get; set; }
        public DbSet<GenreModel> Genres { get; set; }
        public DbSet<AlbumModel> Albums { get; set; }


    }
}