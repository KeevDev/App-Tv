﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ApiAppTv.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public string? Director { get; set; }
        public int? Duration { get; set; }
        public string? Synopsis { get; set; }
        public bool? Available { get; set; }
        public byte[]? Cover { get; set; }
        public byte[]? MovieVideo { get; set; }
        public int? SubtitleLanguageId { get; set; }
        public int? Rating { get; set; }
        public int? Views { get; set; }
        public int? ReleaseYear { get; set; }
    }

}
