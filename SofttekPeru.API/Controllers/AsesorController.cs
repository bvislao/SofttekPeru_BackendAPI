using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SofttekPeru.API.DTOS;
using SofttekPeru.API.Repository.Interfaces;
using SofttekPeru.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SofttekPeru.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AsesorController : ControllerBase
    {
        readonly IAsesorRepository _asesorRepository;
        private readonly IConfiguration _configuration;
        public AsesorController(IAsesorRepository asesorRepository, IConfiguration configuration)
        {
            _asesorRepository = asesorRepository;
            _configuration = configuration;
        }



        [HttpGet]
        public ActionResult<List<Asesor>> GetAsesores()
        {
            return Ok(_asesorRepository.getAsesores());
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult LoginAsesores(UserRequest user)
        {
            var objResult = new object();
            try
            {
                var searchUsuario = _asesorRepository.AccesoAsesor(user.Usuario, user.Pwd);
                if (searchUsuario == null)
                {
                    objResult = new
                    {
                        status=false,
                        codigoAsesor = string.Empty,
                        nombreAsesor = string.Empty,
                        token = string.Empty
                    };
                    return Ok(objResult);
                }
                else
                {
                    var issuer = _configuration.GetValue<string>("Jwt:Issuer");
                    var audience = _configuration.GetValue<string>("Jwt:Audience");
                    var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("Jwt:Key"));
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new[]
           {
               new Claim("Id",  searchUsuario.CodigoAsesor.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, searchUsuario.CodigoAsesor.ToString()),
               
             }),
                        Expires = DateTime.UtcNow.AddMinutes(5),
                        Issuer = issuer,
                        Audience = audience,
                        SigningCredentials = new SigningCredentials
           (new SymmetricSecurityKey(key),
           SecurityAlgorithms.HmacSha512Signature)
                    };
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var jwtToken = tokenHandler.WriteToken(token);
                    var stringToken = tokenHandler.WriteToken(token);
                    objResult = new
                    {
                        status = true,
                        codigoAsesor = searchUsuario.CodigoAsesor,
                        nombreAsesor = searchUsuario.NombreAsesor,
                        token = stringToken
                    };
                }

            }
            catch (Exception)
            {
                return NotFound();
            }
            return Ok(objResult);

            }
    }
}
