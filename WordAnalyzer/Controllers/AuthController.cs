using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using WordAnalyzer.Domain.Models;
using WordAnalyzer.Domain.Services;

namespace WordAnalyzer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService service;
        public AuthController(IAuthenticationService service)
        {
            this.service = service;
        }

        [HttpPost]       
        public MessageModel<string> Auth([FromBody] TextModel text)
        {
            return service.GenerateToken(text.Body);
        }
    }
}
