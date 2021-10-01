using Microsoft.AspNetCore.Mvc;
using WordAnalyzer.Domain.Models;
using WordAnalyzer.Domain.Services;

namespace WordAnalyzerr.Controllers
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
