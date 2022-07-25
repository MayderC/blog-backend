using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BlogCore.Entities;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.IdentityModel.Tokens;

namespace BlogApplication.Helpers
{
    public class JsonWebToken
    {

        private byte[] _secretKey = null;

        public JsonWebToken(string secret)
        {
            _secretKey = Encoding.ASCII.GetBytes(secret);
        }


        public string CreateToken(User user)
        {
            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Username));

            var tokenDesc = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = 
                    new SigningCredentials(new SymmetricSecurityKey(_secretKey), 
                        SecurityAlgorithms.HmacSha256Signature)
            };

            var tokeHandler = new JwtSecurityTokenHandler();
            return tokeHandler.WriteToken(tokeHandler.CreateToken(tokenDesc));
        }

        public string CreateRefreshToken(User user)
        {
            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Username));

            var tokenDesc = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(35),
                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(_secretKey),
                        SecurityAlgorithms.HmacSha256Signature)
            };

            var tokeHandler = new JwtSecurityTokenHandler();
            return tokeHandler.WriteToken(tokeHandler.CreateToken(tokenDesc));
        }

    }
}
