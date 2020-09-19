using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.EpisodeService;
using Services.StoryServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AStoryApiNew.Controllers.Story
{
    [Route("api/[controller]")]
    [Authorize]
    public class StoryController : Controller
    {
        private readonly IStotyService _service;
        private readonly IEpisodeService _episodeService;

        public StoryController(IStotyService service, IEpisodeService episodeService)
        {
            _service = service;
            _episodeService = episodeService;
        }

        [HttpGet("GetAllStories")]
        public IActionResult GetAllStories([FromQuery(Name = "skip")] int skip, [FromQuery(Name = "take")] int take)
        {
            return Ok(_service.GetStoriesWithAuther(skip, take));
        }

        [HttpGet("GetAllStoriesForSupperUser")]
        public IActionResult GetAllStoriesForSuberUser()
        {
            return Ok(_service.GetAllStories());
        }



        // GET api/values/5
        [HttpGet("Story/{id}/Episodes")]
        public IActionResult EpisodesByStoryId(int id, [FromQuery] int skip, [FromQuery] int take)
        {

            return Ok(_service.GetEpisodesByStoryId(id, skip, take));
        }

        // POST api/values
        [HttpPost("AddStory")]
        public IActionResult Post([FromBody] SingleStoryDto story)
        {
            return Ok(_service.AddStory(story));
        }

        [HttpGet("getStoriesByAutherId/{id}")]
        public IActionResult GetStoryByAutherId(int id, [FromQuery(Name = "skip")] int skip, [FromQuery(Name = "take")] int take)
        {
            return Ok(_service.StoryByAuther(id, skip, take));
        }

        // PUT api/values/5
        [HttpPost("Update")]
        public IActionResult Update([FromBody] StoryApproveRequestDto story)
        {
            return Ok(_service.Approve(story));
        }

        [HttpPost("approve")]
        public IActionResult Approve([FromBody] StoryApproveRequestDto approve)
        {

            if (approve.aprrovedType.Equals("story"))
            {
                return Ok(_service.Approve(approve));
            }
            else if (approve.aprrovedType.Equals("episode"))
            {
                return Ok(_episodeService.Approve(approve));
            } else
            {
                return BadRequest();
            }
        }
    }
}
