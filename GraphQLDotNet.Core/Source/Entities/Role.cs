using GraphQLDotNet.Core.Source.Converters;
using GraphQLDotNet.Core.Source.Dtos;

using System;
using System.Collections.Generic;

namespace GraphQLDotNet.Core.Source.Entities

{
	public class Role : IConvertModel<Role, RoleDto>
	{
		public string Code { get; set; }

		public Guid Id { get; set; }

		public string Name { get; set; }

		public ICollection<User> Users { get; set; }

		public RoleDto Convert()
		{
			return new RoleDto
			{
				Id = Id,
				Name = Name,
				Code = Code
			};
		}
	}
}
