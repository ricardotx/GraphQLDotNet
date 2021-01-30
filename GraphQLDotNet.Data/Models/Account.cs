using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQLDotNet.Data.Models
{
	public enum TypeOfAccount
	{
		Cash,
		Savings,
		Expense,
		Income
	}

	public class Account
	{
		public string Description { get; set; }

		[Key]
		public Guid Id { get; set; }

		public Owner Owner { get; set; }

		[ForeignKey("OwnerId")]
		public Guid OwnerId { get; set; }

		[Required(ErrorMessage = "Type is required")]
		public TypeOfAccount Type { get; set; }
	}
}
