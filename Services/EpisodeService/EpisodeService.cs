using System;
using Data.Entity;
using Dto.Model;
using Repository.CommonRepository;
using Repository.EpisodeRepository;

namespace Services.EpisodeService
{
    public class EpisodeService: IEpisodeService
    {
        private readonly IGenaricRepository<Episode> _commonContext;
        private readonly IEpisodeRepository _episodeRepository;

        public EpisodeService(IGenaricRepository<Episode> commonContext, IEpisodeRepository episodeRepository)
        {
            _commonContext = commonContext;
            _episodeRepository = episodeRepository;
        }

        public EpisodeDto AddEpisode(EpisodeDto episode)
        {
            var episodeToEntity = new Episode
            {
                episodeContent = episode.episodeContent,
                episodeCoverImageUrl = episode.episodeCoverImageUrl,
                episodeName = episode.episodeName,
                episodeShortDescription = episode.episodeShortDescription,
                storyId = episode.storyId,
                isActive = false
            };

            var entityToDto = _commonContext.Insert(episodeToEntity);

            var dto = new EpisodeDto
            {
                storyId = entityToDto.storyId,
                episodeContent = entityToDto.episodeContent,
                episodeShortDescription = entityToDto.episodeShortDescription,
                episodeCoverImageUrl = entityToDto.episodeCoverImageUrl,
                episodeId = entityToDto.episodeId,
                episodeName = entityToDto.episodeName
            };

            return dto;
        }

        public StoryApprovedResponse Approve(StoryApproveRequestDto approve)
        {
            return _episodeRepository.ApproveRepository(approve);
        }
    }
}
