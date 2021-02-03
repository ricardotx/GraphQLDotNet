using System.ComponentModel.DataAnnotations;

namespace GraphQLDotNet.Core.Source.ApiModels
{
	public class AuthRequestBodyApiModel
	{
		[Required]
		public string ClientId { get; set; }

		[Required]
		public string ClientSecret { get; set; }

		[Required]
		public string GrantType { get; set; }

		public string Password { get; set; }

		public string RefreshToken { get; set; }

		public string Username { get; set; }
	}
}
