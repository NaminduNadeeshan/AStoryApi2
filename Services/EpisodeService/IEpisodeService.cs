using System;
using Dto.Model;

namespace Services.EpisodeService
{
    public interface IEpisodeService
    {
        EpisodeDto AddEpisode(EpisodeDto episode);
    }
}
