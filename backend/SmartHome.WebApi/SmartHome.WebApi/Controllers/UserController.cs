using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SmartHome.Application.Services;
using SmartHome.DataTransferObjects.Requests;
using SmartHome.DataTransferObjects.Responses;
using SmartHome.Domain.Models;
using SmartHome.Domain.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SmartHome.WebApi.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        private readonly IActivationTokenService _activationTokenService;
        private readonly IFileService _fileService;
        public UserController(IUserService userService, IEmailService emailService, IFileService fileService, IActivationTokenService activationTokenService,IMapper mapper) : base(mapper)
        {
            _userService = userService;
            _emailService = emailService;
            _activationTokenService = activationTokenService;
            _fileService = fileService;
        }

        [HttpPost("")]
        public async Task<IActionResult> AddUser([FromForm] CreateUserRequestDTO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            string imagePath = await _fileService.SaveImageAsync(user.ImageFile, "static/users");
            User response = _mapper.Map<User>(user);
            response.ProfilePictureUrl = imagePath;
            if (_user == null)
            {
                response.Status = Status.INACTIVE;
                response.Role = Role.USER;
            }
            else if(_user.Role == Role.SUPERADMIN)
            {
                response.Status = Status.ACTIVE;
                response.Role = Role.ADMIN;
            }
            
            User addedUser = await _userService.Add(response);
            if(addedUser.Status == Status.INACTIVE) {
                ActivationToken activationToken = await _activationTokenService.AddOne(addedUser.Id);
                await _emailService.SendActivationEmail(addedUser, activationToken);
            }
            
            return Ok(_mapper.Map<UserResponseDTO>(addedUser));
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequestDTO oldUser)
        {
            User user = _mapper.Map<User>(oldUser);
            await _userService.Update(user);
            return Ok("User Updated!");
        }

        [HttpPut("activate")]
        public async Task<IActionResult> ActivateUser([FromBody] ActivationTokenRequestDTO activationTokenRequestDTO)
        {
            ActivationToken activationToken = _mapper.Map<ActivationToken>(activationTokenRequestDTO);
            User user = await _userService.GetById(activationToken.UserId);
            if(_activationTokenService.IsTokenValid(activationToken).Result)
            {
                user.Status = Status.ACTIVE;
                await _userService.Update(user);
                return Ok("Account activated successfuly!");
            }
            else
            {
                ActivationToken newActivationToken = await _activationTokenService.AddOne(user.Id);
                await _emailService.SendActivationEmail(user, newActivationToken);
                return BadRequest("Token expired! Check email for new");
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest credentials)
        {
            User user = await _userService.GetByEmailAndPassword(credentials.Email, credentials.Password);

            if (user == null)
            {
                return Unauthorized();
            }
            if(user.Status == Status.INACTIVE)
            {
                return Forbid("Your Account is not activated! Check your e-mail.");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim(ClaimTypes.Version, user.Status.ToString()),
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("smarthomesmarthomesmarthome"));
            var credentialsJWT = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentialsJWT
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            Response.Cookies.Append("jwtToken", tokenString, new CookieOptions
            {
                HttpOnly = true,
                Secure = false,
                Expires = DateTime.UtcNow.AddDays(30),

            });

            return Ok(_mapper.Map<UserResponseDTO>(user));
        }
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Append("jwtToken", "", new CookieOptions
            {
                HttpOnly = true,
                Secure = false,
                Expires = DateTime.UtcNow.AddYears(-1),
            });

            return Ok();
        }

      
        [HttpGet("authenticate")]
        public async Task<ActionResult> Authenticate()
        {
            if (_user == null)
            {
                return Unauthorized();
                
            }
            else
            {
                return Ok(_user);
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            User user = await _userService.GetById(id);
            UserResponseDTO response = _mapper.Map<UserResponseDTO>(user);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(Guid id)
        {
            await _userService.Delete(id);
            return Ok("User Deleted!");
        }
    }
}
