using System;
using System.Collections.Generic;
using Data.Entity;
using Dto.Model;

namespace Services.StoryServices
{
    public interface IStotyService
    {
        SingleStoryDto AddStory(SingleStoryDto story);
        List<AutherByStoriesDto> StoryByAuther(int id, int skip, int take);
        List<StoryWithAutherDto> GetStoriesWithAuther(int skip, int take);
        List<EpisodeDtoBeforeSubscribe> GetEpisodesByStoryId(int storyId, int skip, int take);
        SingleStoryDto EditStory(Story story);
        StoryApprovedResponse Approve(StoryApproveRequestDto approve);
        List<SingleStoryDto> GetAllStories();
    }
}
