using GraphQLDotNet.Core.Source.Models;
using GraphQLDotNet.Core.Source.Repositories;
using GraphQLDotNet.Data.Source.Context;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDotNet.Data.Source.Repositories
{
	public class AccountRepository : BaseRepository<Account>, IAccountRepository
	{
		private readonly ApplicationContext _db;

		public AccountRepository(ApplicationContext context) : base(context)
		{
			_db = context;
		}

		public override async Task AddAsync(Account account)
		{
			account.Id = Guid.NewGuid();
			await _db.Accounts.AddAsync(account);
		}

		public async Task<IEnumerable<Account>> GetAllPerOwnerAsync(Guid ownerId)
		{
			return await _db.Accounts.Where(a => a.OwnerId.Equals(ownerId)).ToListAsync();
		}
	}
}
