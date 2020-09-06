using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Data.Entity
{
    public class Story
    {
        [Key]
        public int storyId { get; set; }

        public string storyName { get; set; }

        public string storyShortDescription { get; set; }

        public string coverImageUrl { get; set; }

        public Boolean isActive { get; set; }

        public Auther auther { get; set; }

        public int autherId { get; set; }

        public virtual ICollection<Episode> episodes { get; set; }

    }
}
