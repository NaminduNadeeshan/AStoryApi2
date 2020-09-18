using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.AutherService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AStoryApiNew.Controllers.Auther
{
    [Route("api/[controller]")]
    public class AutherController : Controller
    {
        private readonly IAutherService _autherService;

       public AutherController(IAutherService autherService)
        {
            _autherService = autherService;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost("AddAuther")]
        public IActionResult AddAuther([FromBody] AutherDto auther)
        {
            return Ok(_autherService.AddAuther(auther));
        }

        // PUT api/values/5
        [Authorize]
        [HttpPost("EditAuther")]
        public IActionResult EditAuther([FromBody] AutherDto auther)
        {
            return Ok(_autherService.EditAuther(auther));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
