using GraphQLDotNet.Core.Source.Converters;
using GraphQLDotNet.Core.Source.Entities;

using System;
using System.Collections.Generic;

namespace GraphQLDotNet.Core.Source.Dtos
{
	public class OwnerDto : IConvertModel<OwnerDto, Owner>
	{
		public ICollection<AccountDto> Accounts { get; set; }

		public string Address { get; set; }

		public Guid Id { get; set; }

		public string Name { get; set; }

		public Owner Convert()
		{
			return new Owner
			{
				Id = Id,
				Name = Name,
				Address = Address
			};
		}
	}
}
