using GraphQLDotNet.Core.Source.DataModels;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLDotNet.Core.Source.Repositories
{
	public interface IAccountRepository : IBaseRepository<Account>
	{
		Task<IEnumerable<Account>> GetAllPerOwnerAsync(Guid ownerId);
	}
}
