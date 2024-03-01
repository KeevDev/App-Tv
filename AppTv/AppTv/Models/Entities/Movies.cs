using System;
using System.Collections.Generic;
using System.Text;

namespace AppTv.Models.Entities
{
    class Movies
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public bool Subtitles { get; set; }
        public string Language { get; set; }
        public string Description { get; set; }
    }
}
