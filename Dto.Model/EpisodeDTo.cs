using System;
using System.Collections.Generic;

namespace Dto.Model
{
    public class EpisodeDto
    {
        public int episodeId { get; set; }

        public string episodeName { get; set; }

        public string episodeShortDescription { get; set; }

        public string episodeCoverImageUrl { get; set; }

        public string episodeContent { get; set; }

        public int storyId { get; set; }

    }


    public class EpisodeDtoBeforeSubscribe
    {
        public int episodeId { get; set; }

        public string episodeName { get; set; }

        public string episodeShortDescription { get; set; }

        public string episodeCoverImageUrl { get; set; }

        public int storyId { get; set; }

    }



    //public class EpisodeWithAutherAndStory : AutherDto
    //{
    //    public IList<StoryDto> story { get; set; }
    //}
}
