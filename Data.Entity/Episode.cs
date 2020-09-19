using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Entity
{
    public class Episode
    {
        [Key]
        public int episodeId { get; set; }

        public string episodeName { get; set; }

        public string episodeShortDescription { get; set; }

        public string episodeCoverImageUrl { get; set; }

        public string episodeContent { get; set; }

        public int storyId { get; set; }

        public bool isActive { get; set; }

        public virtual Story story { get; set; }
    }
}
