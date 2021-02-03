using GraphQLDotNet.Core.Source.Converters;
using GraphQLDotNet.Core.Source.DataModels;
using GraphQLDotNet.Core.Source.Enums;

using System;

namespace GraphQLDotNet.Core.Source.ApiModels
{
	public class AccountApiModel : IConvertModel<AccountApiModel, Account>
	{
		public string Description { get; set; }

		public Guid Id { get; set; }

		public OwnerApiModel Owner { get; set; }

		public Guid OwnerId { get; set; }

		public AccountTypeEnum Type { get; set; }

		public Account Convert()
		{
			return new Account
			{
				Id = Id,
				OwnerId = OwnerId,
				Type = Type
			};
		}
	}
}
