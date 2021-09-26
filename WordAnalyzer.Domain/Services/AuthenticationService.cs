using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WordAnalyzer.Domain.Models;

namespace WordAnalyzer.Domain.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private const double time = 4;
        private readonly IConfiguration _configuration;
        public AuthenticationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public MessageModel<string> GenerateToken(string sha)
        {
            MessageModel<string> message = new MessageModel<string>();
            string secret = _configuration.GetSection("Credentials")["secret"];

            if (/*GetSHA256(secret)*/ secret == sha)
            {
                
                try
                {
                    byte[] key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("SecretKey"));
                    SymmetricSecurityKey IssuerSigningKey = new SymmetricSecurityKey(key);

                    ClaimsIdentity claims = new ClaimsIdentity();
                    claims.AddClaim(new Claim(ClaimTypes.AuthenticationMethod, "Auth"));

                    SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = claims,
                        Expires = DateTime.UtcNow.AddHours(time),
                    };

                    JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                    SecurityToken createdTocken = tokenHandler.CreateToken(tokenDescriptor);
                    string token = tokenHandler.WriteToken(createdTocken);

                    message.Status = true;
                    message.Data = token;
                }
                catch (Exception ex)
                {
                    message.Status = false;
                    message.Message = ex.Message;
                }
            }
            else
            {
                message.Status = false;
                message.Message = "Unauthorized";
            }

            return message;
        }

        public static string GetSHA256(string str)
        {
            SHA256 sha256 = SHA256.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            StringBuilder sb = new StringBuilder();
            byte[] stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++)
            {
                sb.AppendFormat("{0:x2}", stream[i]);
            }

            return sb.ToString();
        }
    }
}
