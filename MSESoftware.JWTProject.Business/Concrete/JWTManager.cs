using Microsoft.IdentityModel.Tokens;
using MSESoftware.JWTProject.Business.Interfaces;
using MSESoftware.JWTProject.Business.StringInfos;
using MSESoftware.JWTProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MSESoftware.JWTProject.Business.Concrete
{
    public class JWTManager : IJWTService
    {
        public string GenerateJWTToken(AppUser appUser, List<AppRole> roles)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTInfo.SecurityKey));

            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken
                (
                issuer: JWTInfo.Issuer,
                audience: JWTInfo.Audience,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(JWTInfo.TokenExpiration),
                signingCredentials: signingCredentials,
                claims: GetClaims(appUser, roles)
                );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            
            return handler.WriteToken(token);
        }

        private List<Claim> GetClaims(AppUser appUser, List<AppRole> roles)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, appUser.UserName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, appUser.Id.ToString()));

            if (roles.Count > 0)
            {
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role.Name));
                }
            }

            return claims;
        }
    }
}
