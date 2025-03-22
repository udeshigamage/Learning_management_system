using Learning_management_system.dbcontext;
using Learning_management_system.Models;
using Learning_management_system.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;

namespace Learning_management_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly Appdbcontext _context;
        private readonly Authservice _authservice;

        public AuthController(Appdbcontext context, Authservice authservice)
        {
            _context = context;
            _authservice = authservice;

        }
        [HttpPost("login")]

        public async Task<IActionResult> Login([FromBody]Login login)
        {
            var user = _context.Users.SingleOrDefault(c=> c.Email == login.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(login.Password, user.PasswordHash))
            {
                return Unauthorized(new { message = "unauthorized" });
            }
            var token = _authservice.Generatetoken(user);
            return Ok(token);
        }




    }
}
