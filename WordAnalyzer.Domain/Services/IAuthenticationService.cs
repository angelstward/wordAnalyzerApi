using System.IdentityModel.Tokens.Jwt;
using WordAnalyzer.Domain.Models;

namespace WordAnalyzer.Domain.Services
{
    public interface IAuthenticationService
    {
        MessageModel<string> GenerateToken(string sha);
    }
}
