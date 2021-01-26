using GraphQL;
using GraphQL.DataLoader;

using GraphQLDotNet.Api.GraphQL.Contracts;
using GraphQLDotNet.Data.Contracts;
using GraphQLDotNet.Data.Entities;

using System;
using System.Collections.Generic;

namespace GraphQLDotNet.Api.GraphQL.Resolvers
{
    public class OwnerResolver : IOwnerResolver
    {
        private readonly IAccountRepository _accountRepo;
        private readonly IOwnerRepository _repo;

        public OwnerResolver(IOwnerRepository repo, IAccountRepository accountRepo)
        {
            _repo = repo;
            _accountRepo = accountRepo;
        }

        public IDataLoaderResult<IEnumerable<Account>> DataLoaderAccounts(IResolveFieldContext<Owner> context, IDataLoaderContextAccessor dataLoader)
        {
            var loader = dataLoader.Context.GetOrAddCollectionBatchLoader<Guid, Account>(nameof(_accountRepo.DataLoaderAccountsByOwnerIdsAsync),
                _accountRepo.DataLoaderAccountsByOwnerIdsAsync);

            return loader.LoadAsync(context.Source.Id);
        }

        public Owner MutationOwnerCreate(IResolveFieldContext context)
        {
            var owner = context.GetArgument<Owner>("owner");
            return _repo.CreateOwner(owner);
        }

        public string MutationOwnerDelete(IResolveFieldContext context)
        {
            var ownerId = context.GetArgument<Guid>("ownerId");
            var owner = _repo.GetById(ownerId);

            if (owner == null)
            {
                context.Errors.Add(new ExecutionError("Couldn't find owner in db."));
                return null;
            }

            _repo.DeleteOwner(owner);
            return $"The owner with the id: {ownerId} has been successfully deleted from db.";
        }

        public Owner MutationOwnerUpdate(IResolveFieldContext context)
        {
            var owner = context.GetArgument<Owner>("owner");
            var ownerId = context.GetArgument<Guid>("ownerId");
            var dbOwner = _repo.GetById(ownerId);

            if (dbOwner == null)
            {
                context.Errors.Add(new ExecutionError("Couldn't find owner in db."));
                return null;
            }

            return _repo.UpdateOwner(dbOwner, owner);
        }

        public Owner QueryOwner(IResolveFieldContext context)
        {
            Guid id;

            if (!Guid.TryParse(context.GetArgument<string>("ownerId"), out id))
            {
                context.Errors.Add(new ExecutionError("Wrong value for guid"));
                return null;
            }

            return _repo.GetById(id);
        }

        public IEnumerable<Owner> QueryOwners()
        {
            return _repo.GetAll();
        }
    }
}
