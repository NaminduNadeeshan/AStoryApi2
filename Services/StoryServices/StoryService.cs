﻿using System;
using System.Collections.Generic;
using AutoMapper;
using Data.Entity;
using Dto.Model;
using Repository.CommonRepository;
using Repository.StoryRepository;

namespace Services.StoryServices
{
    public class StoryService : IStotyService
    {
        private readonly IGenaricRepository<Story> _commonStoryContext;
        private readonly IStoryRepository _stotyRepo;

        public StoryService(IGenaricRepository<Story> commonStoryContext, IStoryRepository stotyRepo)
        {
            _commonStoryContext = commonStoryContext;
            _stotyRepo = stotyRepo;
        }

        public SingleStoryDto AddStory(SingleStoryDto story)
        {
            try
            {
                var insertableStory = new Story
                {
                    autherId = story.autherId,
                    coverImageUrl = story.coverImageUrl,
                    isActive = false,
                    storyName = story.storyName,
                    storyShortDescription = story.storyShortDescription,

                };

                var responseStory = _commonStoryContext.Insert(insertableStory);

                var returnStory = new SingleStoryDto
                {
                    autherId = responseStory.autherId,
                    coverImageUrl = responseStory.coverImageUrl,
                    storyId = responseStory.storyId,
                    storyName = responseStory.storyName,
                    storyShortDescription = responseStory.storyShortDescription
                };

                return returnStory;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public StoryApprovedResponse Approve(StoryApproveRequestDto approve)
        {

           return _stotyRepo.ApproveRepository(approve);
        }

        public SingleStoryDto EditStory(Story story)
        {
            try
            {
                var storyE = new Story
                {
                    autherId = story.autherId,
                    coverImageUrl = story.coverImageUrl,
                    storyId = story.storyId,
                    storyName = story.storyName,
                    storyShortDescription = story.storyShortDescription
                };

                var responseStory = _commonStoryContext.Update(storyE);

                var returnStory = new SingleStoryDto
                {
                    autherId = responseStory.autherId,
                    coverImageUrl = responseStory.coverImageUrl,
                    storyId = responseStory.storyId,
                    storyName = responseStory.storyName,
                    storyShortDescription = responseStory.storyShortDescription,
                };
                return returnStory;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<SingleStoryDto> GetAllStories()
        {
            var allStories = _commonStoryContext.GetAll();
            var allStoriesList = new List<SingleStoryDto>();

            foreach( Story story in allStories)
            {
                var storyDto = new SingleStoryDto
                {
                    autherId = story.autherId,
                    coverImageUrl = story.coverImageUrl,
                    isActive = story.isActive,
                    storyId = story.storyId,
                    storyName =  story.storyName,
                    storyShortDescription = story.storyShortDescription,
                };

                allStoriesList.Add(storyDto);
            }

            return allStoriesList;
        }

        public List<EpisodeDtoBeforeSubscribe> GetEpisodesByStoryId(int storyId, int skip, int take)
        {
            return _stotyRepo.GetEpisodesByStoryId(storyId, skip, take);
        }

        public List<StoryWithAutherDto> GetStoriesWithAuther(int skip, int take)
        {

            return _stotyRepo.GetStoriesWithAuther(skip, take);
        }

        public List<AutherByStoriesDto> StoryByAuther(int id, int skip, int take)
        {
            return _stotyRepo.GetPostByAutherId(id, skip, take); ;

        }
    }
}
