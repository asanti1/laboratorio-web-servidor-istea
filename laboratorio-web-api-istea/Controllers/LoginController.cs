using laboratorio_web_api_istea.DTO.Login;
using laboratorio_web_api_istea.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApI_Preparcial_II.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _configuration;

        private readonly IEmpleadoService _empleadoService;

        public LoginController(IConfiguration configuration, IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
            _configuration = configuration;
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<object>> Login(LoginRequestDto login)
        {
            var userEntity = await _empleadoService.GetEmpleadoByUsuarioPass(login.UserName, login.Password);
            if (userEntity != null)
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub,_configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("UserId", userEntity.Id.ToString()),
                    new Claim("DisplayName", userEntity.Nombre),
                    new Claim("UserName", userEntity.Usuario),
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(10),
                    signingCredentials: signIn);

                return Ok(new JwtSecurityTokenHandler().WriteToken(token));
            }
            else
            {
                return BadRequest("");
            }
        }
    }
}