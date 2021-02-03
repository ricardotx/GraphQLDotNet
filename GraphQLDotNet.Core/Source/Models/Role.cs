using System;
using System.Collections.Generic;

namespace GraphQLDotNet.Core.Source.Models
{
	public class Role
	{
		public string Code { get; set; }

		public Guid Id { get; set; }

		public string Name { get; set; }

		public ICollection<User> Users { get; set; }
	}
}
