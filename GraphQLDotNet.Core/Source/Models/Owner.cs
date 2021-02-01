using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GraphQLDotNet.Core.Source.Models
{
	public class Owner
	{
		public ICollection<Account> Accounts { get; set; }

		public string Address { get; set; }

		[Key]
		public Guid Id { get; set; }

		[Required(ErrorMessage = "Name is required")]
		public string Name { get; set; }
	}
}
