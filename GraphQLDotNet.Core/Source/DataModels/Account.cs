using GraphQLDotNet.Core.Source.ApiModels;
using GraphQLDotNet.Core.Source.Converters;
using GraphQLDotNet.Core.Source.Enums;

using System;

namespace GraphQLDotNet.Core.Source.DataModels
{
	public class Account : IConvertModel<Account, AccountApiModel>
	{
		public string Description { get; set; }

		public Guid Id { get; set; }

		public Owner Owner { get; set; }

		public Guid OwnerId { get; set; }

		public AccountTypeEnum Type { get; set; }

		public AccountApiModel Convert()
		{
			return new AccountApiModel
			{
				Id = Id,
				Type = Type,
				Description = Description,
				OwnerId = OwnerId,
			};
		}
	}
}
