using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Management.SupportHub.Domain.DTOs.Messages;
using Management.SupportHub.Domain.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Company.Management.SupportHub.Application.Services.Tokenization;

public class TokenizationService(IConfiguration configuration) : ITokenizationService
{
	public Guid ValidateToken(string token)
	{
		try
		{
			if (string.IsNullOrWhiteSpace(token))
				throw new TokenAccessException(MessageExceptions.TOKEN_NOT_PROVIDED);

			var tokenSegments = token.Split('.');
			if (tokenSegments.Length != 3)
				throw new TokenAccessException(MessageExceptions.TOKEN_NOT_PROVIDED);

			new JwtSecurityTokenHandler().ValidateToken(token, new TokenValidationParameters
			{
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Jwt:Secret"]!)),
				ValidateIssuer = false,
				ValidateAudience = false,
				ValidateLifetime = true
			}, out var validatedToken);

			var jwtToken = (JwtSecurityToken)validatedToken;

			if (jwtToken.ValidTo < DateTime.UtcNow)
				throw new SecurityTokenNoExpirationException();

			return new Guid(jwtToken.Claims.First(x => x.Type == "id").Value);
		}
		catch (SecurityTokenNoExpirationException)
		{
			throw new TokenAccessException(MessageExceptions.TOKEN_EXPIDED);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			throw;
		}
	}

	public string GenerateToken(string id)
	{
		try
		{
			var tokenHandler = new JwtSecurityTokenHandler();

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new[]
				{
					new Claim("id", id)
				}),
				Expires = DateTime.UtcNow.Add(TimeSpan.Parse(configuration["Jwt:Expiry"]!, CultureInfo.CurrentCulture)),
				SigningCredentials = new SigningCredentials(
					new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Jwt:Secret"]!)),
					SecurityAlgorithms.HmacSha256Signature)
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);

			return tokenHandler.WriteToken(token);
		}
		catch (Exception ex)
		{
			throw new InvalidOperationException(ex.Message);
		}
	}

	public string GenerateRefreshToken()
	{
		var salt = new byte[32];
		using var random = RandomNumberGenerator.Create();
		random.GetBytes(salt);
		return Convert.ToBase64String(salt);
	}
}