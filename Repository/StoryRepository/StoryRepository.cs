﻿using System;
using System.Collections.Generic;
using System.Linq;
using Data.Entity;
using Dto.Model;
using Microsoft.EntityFrameworkCore;
using Repository.CommonRepository;

namespace Repository.StoryRepository
{
    public class StoryRepository : GenaricRepository<Story>, IStoryRepository
    {
        private readonly AStoryDatabaseContext _context;

        public StoryRepository(AStoryDatabaseContext context) : base(context)
        {
            _context = context;
        }

        public List<EpisodeDtoBeforeSubscribe> GetEpisodesByStoryId(int storyId, int skip, int take)
        {
            var episodeList = _context.Episode.Where<Episode>(episode => episode.storyId == storyId).Skip(skip).Take(take).ToList();

            var episodeDtoList = new List<EpisodeDtoBeforeSubscribe>();


            foreach (Episode episode in episodeList)
            {
                var episodeDto = new EpisodeDtoBeforeSubscribe
                {
                    episodeCoverImageUrl = episode.episodeCoverImageUrl,
                    episodeId = episode.episodeId,
                    episodeName = episode.episodeName,
                    episodeShortDescription = episode.episodeShortDescription,
                    storyId = episode.storyId
                };

                episodeDtoList.Add(episodeDto);
            }
      


            return episodeDtoList;
        }

        public List<AutherByStoriesDto> GetPostByAutherId(int autherId)
        {
            try
            {
                var autherByStories = _context.Authers.Where<Auther>(auther => auther.AutherId == autherId).Include(auther => auther.stories).ToList();

                var storiesList = new List<SingleStoryDto>();
                var autherLiast = new List<AutherByStoriesDto>();
                foreach (Auther autherList in autherByStories)
                {
                    foreach (Story stories in autherList.stories)
                    {
                        var storyDto = new SingleStoryDto
                        {
                            coverImageUrl = stories.coverImageUrl,
                            autherId = stories.autherId,
                            isActive = stories.isActive,
                            storyId = stories.storyId,
                            storyName = stories.storyName,
                            storyShortDescription = stories.storyShortDescription,

                        };

                        storiesList.Add(storyDto);
                    }

                    var storiesByAuthers = new AutherByStoriesDto
                    {
                        AutherId = autherList.AutherId,
                        FirstName = autherList.FirstName,
                        LastName = autherList.LastName,
                        PhoneNumber = autherList.PhoneNumber,
                        ProfilePictureUrl = autherList.ProfilePictureUrl,
                        stories = storiesList.OrderByDescending(o => o.storyId).ToList()

                    };

                    autherLiast.Add(storiesByAuthers);
                }
                return autherLiast;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<StoryWithAutherDto> GetStoriesWithAuther(int skip, int take)
        {
            var postList = _context.Story.Skip(skip).Take(take).Include(story => story.auther).ToList();

            var storyWithAutherdtoList = new List<StoryWithAutherDto>();

            foreach (Story list in postList)
            {
                var autherDeteails = new AutherDto
                {
                    FirstName = list.auther.FirstName,
                    LastName = list.auther.LastName,
                    ProfilePictureUrl = list.auther.ProfilePictureUrl,
                    AutherId = list.auther.AutherId
                };

                var listDto = new StoryWithAutherDto
                {
                    coverImageUrl = list.coverImageUrl,
                    autherDetails = autherDeteails,
                    storyName = list.storyName,
                    storyId = list.storyId,
                    storyShortDescription = list.storyShortDescription

                };

                storyWithAutherdtoList.Add(listDto);
            }


            return storyWithAutherdtoList;
        }
    }
}
