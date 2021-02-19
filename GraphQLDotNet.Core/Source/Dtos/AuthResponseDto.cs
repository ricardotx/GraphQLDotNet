namespace GraphQLDotNet.Core.Source.Dtos
{
	public class AuthResponseDto
	{
		public string AccessToken { get; set; }
		public string AccessTokenExpiracy { get; set; }
		public string RefreshToken { get; set; }
		public string RefreshTokenExpiracy { get; set; }
	}
}
