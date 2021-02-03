using GraphQLDotNet.Core.Source;
using GraphQLDotNet.Core.Source.Repositories;
using GraphQLDotNet.Data.Source.Context;

using System.Threading.Tasks;

namespace GraphQLDotNet.Data.Source
{
	public class Repository : IRepository
	{
		private readonly ApplicationContext _context;
		private IAccountRepository _accountRepository;
		private IOwnerRepository _ownerRepository;
		private IRoleRepository _roleRepository;
		private IUserRepository _userRepository;

		public Repository(
			ApplicationContext context,
			IAccountRepository accountRepository,
			IOwnerRepository ownerRepository,
			IRoleRepository roleRepository,
			IUserRepository userRepository
		)
		{
			_context = context;
			_accountRepository = accountRepository;
			_ownerRepository = ownerRepository;
			_roleRepository = roleRepository;
			_userRepository = userRepository;
		}

		public IAccountRepository Account => _accountRepository;
		public IOwnerRepository Owner => _ownerRepository;
		public IRoleRepository Role => _roleRepository;
		public IUserRepository User => _userRepository;

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
