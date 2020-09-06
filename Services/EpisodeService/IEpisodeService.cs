using System;
using Dto.Model;

namespace Services.EpisodeService
{
    public interface IEpisodeService
    {
        public EpisodeDto AddEpisode(EpisodeDto episode);
    }
}
