using GraphQLDotNet.Core.Source.Converters;
using GraphQLDotNet.Core.Source.Dtos;
using GraphQLDotNet.Core.Source.Enums;

using System;

namespace GraphQLDotNet.Core.Source.Entities
{
	public class Account : IConvertModel<Account, AccountDto>
	{
		public string Description { get; set; }

		public Guid Id { get; set; }

		public Owner Owner { get; set; }

		public Guid OwnerId { get; set; }

		public AccountTypeEnum Type { get; set; }

		public AccountDto Convert()
		{
			return new AccountDto
			{
				Id = Id,
				Type = Type,
				Description = Description,
				OwnerId = OwnerId,
			};
		}
	}
}
