using System;
namespace Dto.Model
{
    public class StoryApproveRequestDto
    {
        public int aprrovedBy { get; set; }

        public string aprrovedType { get; set; }

        public int propertyId { get; set; }

        public bool value { get; set; }

    }

    public class StoryApprovedResponse
    {
        public bool isSuccess { get; set; }
    }
}
