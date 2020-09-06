using System;
using System.Collections.Generic;
using Data.Entity;
using Dto.Model;
using Repository.CommonRepository;

namespace Repository.StoryRepository
{
    public interface IStoryRepository: IGenaricRepository<Story>
    {
        List<AutherByStoriesDto> GetPostByAutherId(int autherId);
        List<StoryWithAutherDto> GetStoriesWithAuther(int skip, int take);
        List<EpisodeDtoBeforeSubscribe> GetEpisodesByStoryId(int storyId, int skip, int take);

    }
}
