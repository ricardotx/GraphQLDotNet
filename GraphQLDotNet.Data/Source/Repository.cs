using GraphQLDotNet.Core.Source.Contracts;
using GraphQLDotNet.Core.Source.Contracts.Repositories;
using GraphQLDotNet.Data.Source.Context;
using GraphQLDotNet.Data.Source.Repositories;

using System.Threading.Tasks;

namespace GraphQLDotNet.Data.Source
{
	public class Repository : IRepository
	{
		private readonly ApplicationContext _context;
		private AccountRepository _accountRepository;
		private DataLoaderRepository _dataLoaderRepository;
		private OwnerRepository _ownerRepository;
		private RoleRepository _roleRepository;
		private UserRepository _userRepository;

		public Repository(ApplicationContext context)
		{
			_context = context;
		}

		public IAccountRepository Account => _accountRepository = _accountRepository ?? new AccountRepository(_context);

		public IDataLoaderRepository DataLoader => _dataLoaderRepository = _dataLoaderRepository ?? new DataLoaderRepository(_context);

		public IOwnerRepository Owner => _ownerRepository = _ownerRepository ?? new OwnerRepository(_context);

		public IRoleRepository Role => _roleRepository = _roleRepository ?? new RoleRepository(_context);

		public IUserRepository User => _userRepository = _userRepository ?? new UserRepository(_context);

		public void Dispose()
		{
			_context.Dispose();
		}

		public async Task<int> SaveChangesAsync()
		{
			return await _context.SaveChangesAsync();
		}
	}
}
