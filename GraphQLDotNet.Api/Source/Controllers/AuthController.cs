using GraphQLDotNet.Core.Source.ApiModels;
using GraphQLDotNet.Core.Source.Enums;

using Microsoft.AspNetCore.Mvc;

using System;

namespace GraphQLDotNet.Api.Source.Controllers
{
	[Route("auth")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		public AuthController()
		{
		}

		[HttpPost("grant")]
		public IActionResult Grant([FromBody] AuthRequestBodyApiModel body)
		{
			if (body.GrantType == GrantTypeEnum.password.ToString())
			{
				return Ok(new AuthResponseApiModel
				{
					AccessToken = Guid.NewGuid().ToString(),
					AccessTokenExpiracy = "",
					RefreshToken = Guid.NewGuid().ToString(),
					RefreshTokenExpiracy = "",
				});
			}

			if (body.GrantType == GrantTypeEnum.refresh_token.ToString())
			{
				return Ok(new AuthResponseApiModel
				{
					AccessToken = Guid.NewGuid().ToString(),
					AccessTokenExpiracy = "",
					RefreshToken = Guid.NewGuid().ToString(),
					RefreshTokenExpiracy = "",
				});
			}

			return BadRequest("unsupported_grant_type");
		}
	}
}
