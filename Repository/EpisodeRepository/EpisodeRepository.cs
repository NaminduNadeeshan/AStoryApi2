using System;
using Data.Entity;
using Dto.Model;
using Repository.CommonRepository;

namespace Repository.EpisodeRepository
{
    public class EpisodeRepository: GenaricRepository<Episode>, IEpisodeRepository
    {
        private readonly AStoryDatabaseContext _context;

        public EpisodeRepository(AStoryDatabaseContext context):base(context)
        {
            _context = context;
        }

        public StoryApprovedResponse ApproveRepository(StoryApproveRequestDto request)
        {
            try
            {
                var episode = GetById(request.propertyId);

                if (episode != null)
                {
                    episode.isActive = request.value;

                    Update(episode);

                    return new StoryApprovedResponse
                    {
                        isSuccess = true,
                    };
                }
                else
                {
                    return new StoryApprovedResponse
                    {
                        isSuccess = false,
                    };
                }



            }
            catch (Exception e)
            {
                return new StoryApprovedResponse
                {
                    isSuccess = false,
                };
            }

        }
    }
}
