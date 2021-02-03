using GraphQLDotNet.Core.Source.ApiModels;
using GraphQLDotNet.Core.Source.Converters;
using GraphQLDotNet.Core.Source.Enums;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQLDotNet.Core.Source.DataModels
{
	public class Account : IConvertModel<Account, AccountApiModel>
	{
		public string Description { get; set; }

		[Key]
		public Guid Id { get; set; }

		public Owner Owner { get; set; }

		[ForeignKey("OwnerId")]
		public Guid OwnerId { get; set; }

		[Required(ErrorMessage = "Type is required")]
		public AccountTypeEnum Type { get; set; }

		public AccountApiModel Convert()
		{
			return new AccountApiModel
			{
				Id = Id,
				Description = Description,
				OwnerId = OwnerId,
				Type = Type
			};
		}
	}
}
