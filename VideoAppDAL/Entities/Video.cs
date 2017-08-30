using System;
using System.Collections.Generic;
using System.Text;

namespace VideoAppUI.VideoAppDAL.Entities
{
    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; }
    }
}
