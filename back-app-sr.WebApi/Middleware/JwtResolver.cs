using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using back_app_sr.Domain.Options;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace back_app_sr.WebApi.Middleware;

public class JwtResolver
{
    private readonly RequestDelegate _next;
    private readonly JwtSettings _jwtSettings;

    public JwtResolver(RequestDelegate next, IOptions<JwtSettings> jwtSettings)
    {
        _next = next;
        _jwtSettings = jwtSettings.Value;
    }

    public async Task Invoke(HttpContext context)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (token != null)
        {
            AttachUserToContext(context, token);
        }

        await _next(context);
    }

    private void AttachUserToContext(HttpContext context, string token)
    {
        var handler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true, 
            ClockSkew = TimeSpan.Zero 
        };
        
        var principal = handler.ValidateToken(token, tokenValidationParameters, out _);
        var roleClaim = principal?.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Role)?.Value;
        switch (roleClaim)
        {
            case "user" or "admin":
                context.Items["User"] = new { Role = roleClaim };
                break;
            default:
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                break;
        }
    }
}