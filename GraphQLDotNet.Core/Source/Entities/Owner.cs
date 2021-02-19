using GraphQLDotNet.Core.Source.Converters;
using GraphQLDotNet.Core.Source.Dtos;

using System;
using System.Collections.Generic;

namespace GraphQLDotNet.Core.Source.Entities
{
	public class Owner : IConvertModel<Owner, OwnerDto>
	{
		public ICollection<Account> Accounts { get; set; }

		public string Address { get; set; }

		public Guid Id { get; set; }

		public string Name { get; set; }

		public OwnerDto Convert()
		{
			return new OwnerDto
			{
				Id = Id,
				Name = Name,
				Address = Address
			};
		}
	}
}
