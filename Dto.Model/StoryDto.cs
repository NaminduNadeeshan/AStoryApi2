using System;
using System.Collections.Generic;

namespace Dto.Model
{
    public class SingleStoryDto
    {
        public int storyId { get; set; }

        public string storyName { get; set; }

        public string storyShortDescription { get; set; }

        public string coverImageUrl { get; set; }

        public bool isActive { get; set; }

        public int autherId { get; set; }

    }

    //public class StoryDto
    //{
    //    public int storyId { get; set; }

    //    public string storyName { get; set; }

    //    public string storyShortDescription { get; set; }

    //    public string coverImageUrl { get; set; }

    //    public bool isActive { get; set; }

    //    public IList<EpisodeDto> episodes { get; set; }
    //}


    public class AutherByStoriesDto : AutherDto
    {
        public IList<SingleStoryDto> stories { get; set; }
    }

    public class StoryWithAutherDto
    {
        public int storyId { get; set; }

        public string storyName { get; set; }

        public string storyShortDescription { get; set; }

        public string coverImageUrl { get; set; }

        public bool isActive { get; set; }

        public AutherDto autherDetails { get; set; }
    }
}
