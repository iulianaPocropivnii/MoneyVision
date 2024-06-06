using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MoneyVision.Helpers
{
     public class JwtTokenGenerator
     {
          public static string GenerateToken(string st, int workspaceId, string secretKey)
          {
               var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
               var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

               var claims = new[]
               {
                    new Claim("st", st),
               };

               var nestedClaims = new Claim[]
               {
                    new Claim("workspaceId", new JsonArray(workspaceId).ToString())
               };

               var claimsIdentity = new ClaimsIdentity(claims, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/password");
               claimsIdentity.AddClaims(nestedClaims);


               var token = new JwtSecurityToken(
                   issuer: "yourdomain.com",
                   audience: "yourdomain.com",
                   claims: claims,
                   expires: DateTime.Now.AddHours(1),
                   signingCredentials: credentials
                );

               return new JwtSecurityTokenHandler().WriteToken(token);
          }
     }
}
