using GraphQLDotNet.Core.Source.Converters;
using GraphQLDotNet.Core.Source.DataModels;

using System;
using System.Collections.Generic;

namespace GraphQLDotNet.Core.Source.ApiModels
{
	public class RoleApiModel : IConvertModel<RoleApiModel, Role>
	{
		public string Code { get; set; }

		public Guid Id { get; set; }

		public string Name { get; set; }

		public ICollection<UserApiModel> Users { get; set; }

		public Role Convert()
		{
			return new Role
			{
				Id = Id,
				Name = Name,
				Code = Code
			};
		}
	}
}
