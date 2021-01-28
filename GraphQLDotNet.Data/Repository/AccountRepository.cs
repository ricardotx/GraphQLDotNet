using GraphQLDotNet.Data.Context;
using GraphQLDotNet.Data.Entities;
using GraphQLDotNet.Data.Repository.Contracts;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDotNet.Data.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationContext _context;

        public AccountRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Account CreateAccount(Account account)
        {
            account.Id = Guid.NewGuid();
            _context.Add(account);
            _context.SaveChanges();
            return account;
        }

        public async Task<ILookup<Guid, Account>> DataLoaderAccountsByOwnerIdsAsync(IEnumerable<Guid> ownerIds)
        {
            var accounts = await _context.Accounts.Where(a => ownerIds.Contains(a.OwnerId)).ToListAsync();
            return accounts.ToLookup(x => x.OwnerId);
        }

        public void DeleteAccount(Account account)
        {
            _context.Remove(account);
            _context.SaveChanges();
        }

        public IEnumerable<Account> GetAll() => _context.Accounts.ToList();

        public IEnumerable<Account> GetAllAccountsPerOwner(Guid ownerId) => _context.Accounts
            .Where(a => a.OwnerId.Equals(ownerId))
            .ToList();

        public Account GetById(Guid id) => _context.Accounts.SingleOrDefault(x => x.Id.Equals(id));

        public Account UpdateAccount(Account dbAccount, Account account)
        {
            dbAccount.Description = account.Description;
            dbAccount.Type = account.Type;
            dbAccount.OwnerId = account.OwnerId;
            _context.SaveChanges();
            return dbAccount;
        }
    }
}
