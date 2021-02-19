using GraphQLDotNet.Core.Source.Converters;
using GraphQLDotNet.Core.Source.Entities;
using GraphQLDotNet.Core.Source.Enums;

using System;

namespace GraphQLDotNet.Core.Source.Dtos
{
	public class AccountDto : IConvertModel<AccountDto, Account>
	{
		public string Description { get; set; }

		public Guid Id { get; set; }

		public OwnerDto Owner { get; set; }

		public Guid OwnerId { get; set; }

		public AccountTypeEnum Type { get; set; }

		public Account Convert()
		{
			return new Account
			{
				Id = Id,
				Type = Type,
				Description = Description,
				OwnerId = OwnerId,
			};
		}
	}
}
