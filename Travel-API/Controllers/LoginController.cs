using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Travel_API.Model.DTO;
using Travel_API.UserModel.DTO;
using Travel_API.UsersRepositories.Token;

namespace Travel_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private ITokenRepository tokenRepository;

        public LoginController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserDTO adduserDTO)
        {
            var identityUser = new IdentityUser()
            {
                UserName = adduserDTO.Username,
                Email = adduserDTO.Username
            };

            var identityResult = await userManager.CreateAsync(identityUser, adduserDTO.Password);
            if (identityResult.Succeeded)
            {
                if (adduserDTO.Roles != null && adduserDTO.Roles.Any())
                {
                    identityResult = await userManager.AddToRolesAsync(identityUser, adduserDTO.Roles);

                    if (identityResult.Succeeded)
                    {
                        return Ok(new { status = "success", message = "Successfully registered" });
                    }
                }
            }

            return BadRequest(new { status = "error", message = "Something went wrong" });

        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var user = await userManager.FindByEmailAsync(loginRequestDto.Username);
            if (user != null)
            {
                var result = await userManager.CheckPasswordAsync(user, loginRequestDto.Password);
                if (result)
                {
                    var roles = await userManager.GetRolesAsync(user);

                    if (roles != null)
                    {
                        var jwtToken = tokenRepository.CreateJWTToken(user, roles.ToList());
                        var response = new LoginResponseDto
                        {
                            JwtToken = jwtToken
                        };
                        return Ok(response);
                    }
                }

            }
            return BadRequest("Incorrect password or email");

        }
    }
}
