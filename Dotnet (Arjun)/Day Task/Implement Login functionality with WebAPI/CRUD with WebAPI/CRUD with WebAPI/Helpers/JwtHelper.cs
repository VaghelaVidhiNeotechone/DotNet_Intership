using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CRUD_with_WebAPI.Helpers
{
    public static class JwtHelper
    {
        // returns (isValid, principal or null, errorMessage or null)
        public static (bool IsValid, ClaimsPrincipal? Principal, string? Error) ValidateToken(string token, IConfiguration config)
        {
            if (string.IsNullOrWhiteSpace(token))
                return (false, null, "Token is null or empty");

            // remove "Bearer " prefix if present
            if (token.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                token = token.Substring("Bearer ".Length).Trim();

            var keyString = config["Jwt:Key"];
            var issuer = config["Jwt:Issuer"];
            var audience = config["Jwt:Audience"];

            if (string.IsNullOrEmpty(keyString))
                return (false, null, "JWT key not configured");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyString));
            var tokenHandler = new JwtSecurityTokenHandler();

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer = issuer,
                ValidAudience = audience,
                IssuerSigningKey = key,

                // allow small clock difference
                ClockSkew = TimeSpan.FromMinutes(5),

                RoleClaimType = "role" // Uncomment if your tokens use "role" as claim name
            };

            try
            {
                var principal = tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);
                return (true, principal, null);
            }
            catch (SecurityTokenExpiredException)
            {
                return (false, null, "Token expired");
            }
            catch (SecurityTokenInvalidSignatureException)
            {
                return (false, null, "Invalid signature");
            }
            catch (SecurityTokenValidationException ex)
            {
                return (false, null, "Token validation failed: " + ex.Message);
            }
            catch (Exception ex)
            {
                return (false, null, "Token validation error: " + ex.Message);
            }
        }
    }
}