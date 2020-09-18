using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto.Model;
using Microsoft.AspNetCore.Mvc;
using Services.AuthenticationService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AStoryApiNew.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : Controller
    {
        private IAuthentication _service;

        public AuthenticationController (IAuthentication service)
        {
            _service = service;
        }
      
        [HttpPost("signup")]
        public IActionResult SignUp([FromBody] AuthenticationDto user)
        {
            var response = _service.SignUpUser(user);
           return (response.error != null) ? (IActionResult)BadRequest(response) : (IActionResult)Ok(response);
        }

        
        [HttpPost("SignIn")]
        public IActionResult SignIn(int id, [FromBody] AuthenticationDto user)
        {
            var response = _service.SignInUser(user);
            return (response?[0].error != null) ? (IActionResult)BadRequest(response) : (IActionResult)Ok(response);
        }

        
        [HttpPost("token")]
        public IActionResult getToken([FromForm] FirebaseIdTokenRequest token)
        {
            var response = _service.getIdTokenByRefreshToken(token);

            return (response.error != null) ? (IActionResult)BadRequest(response) : (IActionResult)Ok(response);
        }

        [HttpPost("sociallogin")]
        public IActionResult SocialLogin([FromBody] UserDto user)
        {
            var response = _service.SocialLogin(user);
            return (response.error != null) ? (IActionResult)BadRequest(response) : (IActionResult)Ok(response);
        }
    }
}
