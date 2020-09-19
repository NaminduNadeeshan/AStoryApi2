using System;
using Data.Entity;
using Dto.Model;
using Repository.CommonRepository;

namespace Repository.EpisodeRepository
{
    public interface IEpisodeRepository: IGenaricRepository<Episode>
    {
        StoryApprovedResponse ApproveRepository(StoryApproveRequestDto request);
    }
}
