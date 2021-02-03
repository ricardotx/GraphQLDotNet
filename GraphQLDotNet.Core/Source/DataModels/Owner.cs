using GraphQLDotNet.Core.Source.ApiModels;
using GraphQLDotNet.Core.Source.Converters;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GraphQLDotNet.Core.Source.DataModels
{
	public class Owner : IConvertModel<Owner, OwnerApiModel>
	{
		public ICollection<Account> Accounts { get; set; }

		public string Address { get; set; }

		[Key]
		public Guid Id { get; set; }

		[Required(ErrorMessage = "Name is required")]
		public string Name { get; set; }

		public OwnerApiModel Convert()
		{
			return new OwnerApiModel
			{
				Id = Id,
				Name = Name,
				Address = Address
			};
		}
	}
}
