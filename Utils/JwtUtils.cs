﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using lms_auth_be.Enums;
using Microsoft.IdentityModel.Tokens;

namespace lms_auth_be.Utils;

public class JwtUtils
{
    private readonly IConfiguration _configuration;

    public JwtUtils(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(string userName, UserRoleEnums role = UserRoleEnums.Admin)
    {
        var key = _configuration["Jwt:Key"];
        var issuer = _configuration["Jwt:Issuer"];
        var audience = _configuration["Jwt:Audience"];
        var expiration = _configuration["Jwt:ExpireMinutes"] ?? "60";

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Name, userName),
            new Claim(ClaimTypes.Role, role.ToString()),
        };

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(Double.Parse(expiration)),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
