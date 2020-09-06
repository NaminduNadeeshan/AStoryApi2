using System;
using Data.Entity;
using Dto.Model;
using Repository.CommonRepository;

namespace Services.EpisodeService
{
    public class EpisodeService: IEpisodeService
    {
        private readonly IGenaricRepository<Episode> _commonContext;
        public EpisodeService(IGenaricRepository<Episode> commonContext)
        {
            _commonContext = commonContext;
        }

        public EpisodeDto AddEpisode(EpisodeDto episode)
        {
            var episodeToEntity = new Episode
            {
                episodeContent = episode.episodeContent,
                episodeCoverImageUrl = episode.episodeCoverImageUrl,
                episodeName = episode.episodeName,
                episodeShortDescription = episode.episodeShortDescription,
                storyId = episode.storyId
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
    }
}
