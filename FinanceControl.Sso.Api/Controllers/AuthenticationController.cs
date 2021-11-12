

using Common.Domain.Helpers;
using FinanceControl.Sso.Api.Interfaces;
using FinanceControl.Sso.Api.Models;
using FinanceControl.Sso.Api.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FinanceControl.Sso.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            var user = await this.authenticationService.Auth(login.UserName, login.Password);
            if (user.IsNull())
                return Unauthorized(new
                {
                    isValid = false,
                    message = "Login or passward are invalid"
                });

            var token = TokenService.GenerateToken(user);



            return Ok(new { token = token });
        }
    }
}
