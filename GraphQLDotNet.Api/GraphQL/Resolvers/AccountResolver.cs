using GraphQL;
using GraphQL.DataLoader;

using GraphQLDotNet.Api.Data.Contracts;
using GraphQLDotNet.Api.Data.Entities;
using GraphQLDotNet.Api.GraphQL.Contracts;

using System;
using System.Collections.Generic;

namespace GraphQLDotNet.Api.GraphQL.Resolvers
{
    public class AccountResolver : IAccountResolver
    {
        private readonly IOwnerRepository _ownerRepo;
        private readonly IAccountRepository _repo;

        public AccountResolver(IAccountRepository repo, IOwnerRepository ownerRepo)
        {
            _repo = repo;
            _ownerRepo = ownerRepo;
        }

        public IDataLoaderResult<Owner> DataLoaderOwner(IResolveFieldContext<Account> context, IDataLoaderContextAccessor dataLoader)
        {
            var loader = dataLoader.Context.GetOrAddBatchLoader<Guid, Owner>(nameof(_ownerRepo.DataLoaderOwnersByIdAsync), _ownerRepo.DataLoaderOwnersByIdAsync);
            return loader.LoadAsync(context.Source.OwnerId);
        }

        public Account MutationAccountCreate(IResolveFieldContext context)
        {
            var owner = context.GetArgument<Account>("account");
            return _repo.CreateAccount(owner);
        }

        public string MutationAccountDelete(IResolveFieldContext context)
        {
            var accountId = context.GetArgument<Guid>("accountId");
            var account = _repo.GetById(accountId);

            if (account == null)
            {
                context.Errors.Add(new ExecutionError("Couldn't find owner in db."));
                return null;
            }

            _repo.DeleteAccount(account);
            return $"The account with the id: {accountId} has been successfully deleted from db.";
        }

        public Account MutationAccountUpdate(IResolveFieldContext context)
        {
            var account = context.GetArgument<Account>("account");
            var accountId = context.GetArgument<Guid>("accountId");
            var dbAccount = _repo.GetById(accountId);

            if (dbAccount == null)
            {
                context.Errors.Add(new ExecutionError("Couldn't find account in db."));
                return null;
            }

            return _repo.UpdateAccount(dbAccount, account);
        }

        public Account QueryAccount(IResolveFieldContext context)
        {
            Guid id;

            if (!Guid.TryParse(context.GetArgument<string>("accountId"), out id))
            {
                context.Errors.Add(new ExecutionError("Wrong value for guid"));
                return null;
            }

            return _repo.GetById(id);
        }

        public IEnumerable<Account> QueryAccounts()
        {
            return _repo.GetAll();
        }
    }
}
