using GraphQLDotNet.Core.Source.Entities;
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
		private readonly StorageContext db;

		public AccountRepository(StorageContext context) : base(context)
		{
			this.db = context;
		}

		public override async Task AddAsync(Account account)
		{
			account.Id = Guid.NewGuid();
			await this.db.Accounts.AddAsync(account);
		}

		public async Task<IEnumerable<Account>> GetAllPerOwnerAsync(Guid ownerId)
		{
			return await this.db.Accounts.Where(a => a.OwnerId.Equals(ownerId)).ToListAsync();
		}
	}
}
