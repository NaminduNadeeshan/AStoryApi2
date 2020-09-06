using System;
using System.Collections.Generic;
using Dto.Model;

namespace Services.StoryServices
{
    public interface IStotyService
    {
        SingleStoryDto AddStory(SingleStoryDto story);
        List<AutherByStoriesDto> StoryByAuther(int id);
        List<StoryWithAutherDto> GetStoriesWithAuther(int skip, int take);
        List<EpisodeDtoBeforeSubscribe> GetEpisodesByStoryId(int storyId, int skip, int take);
    }
}
