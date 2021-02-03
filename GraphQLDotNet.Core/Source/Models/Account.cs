using GraphQLDotNet.Core.Source.Enums;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQLDotNet.Core.Source.Models
{
	public class Account
	{
		public string Description { get; set; }

		[Key]
		public Guid Id { get; set; }

		public Owner Owner { get; set; }

		[ForeignKey("OwnerId")]
		public Guid OwnerId { get; set; }

		[Required(ErrorMessage = "Type is required")]
		public AccountTypeEnum Type { get; set; }
	}
}
