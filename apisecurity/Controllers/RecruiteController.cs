using apisecurity.Models;
using apisecurity.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apisecurity.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RecruiteController : ControllerBase
    {
        private readonly ITokenRepository _tokenRepository; 

        public RecruiteController(ITokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository; 
        }
         
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var recruites = new List<string>()
            {
                "mashhad",
                "kerman",
                "tehran"
            };
            return recruites;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(Users usersdata) 
        {
            var token = _tokenRepository.Authenticate(usersdata);

            if (usersdata == null)
            {
                return Unauthorized();
            }

           return Ok(token);
        }

    }
}
