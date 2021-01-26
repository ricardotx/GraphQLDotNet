# Dotnet API with Graphql using [GraphQL.NET](https://github.com/graphql-dotnet/graphql-dotnet)
* Code-First approach.
* Data Loader implementation.
* Code splitting.

📣 *This is a self study project to allow me to better understand the `GraphQL` in the `.Net` environment and **not** a production ready API.*

👉The `RootQuery` and `RootMutation` are ***partial classes*** and the *queries* and *mutations* of the `Owner` and `Account` are an extension of them. By doing that we are improving our code organization.
The [GraphQL .NET](https://graphql-dotnet.github.io/docs/getting-started/query-organization) documentation explain how to do code organization in a different way, but the final result is a messy schema with queries and mutation aggregated by *entity*.

# References
* [Getting Started with GraphQL in ASP.NET Core](https://code-maze.com/graphql-aspnetcore-basics/)
* [Advanced GraphQL Queries, Error Handling, Data Loader](https://code-maze.com/advanced-graphql-queries/)
* [GraphQL Mutations in ASP.NET Core](https://code-maze.com/graphql-mutations/)

# Packages
* [Pomelo.EntityFrameworkCore.MySql](https://www.nuget.org/packages/Pomelo.EntityFrameworkCore.MySql/5.0.0-alpha.2?_src=template)
* [Microsoft.EntityFrameworkCore.Tools](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools/5.0.1?_src=template)
* [GraphQL](https://www.nuget.org/packages/GraphQL/3.3.1?_src=template)
* [GraphQL.Server.Transports.AspNetCore](https://www.nuget.org/packages/GraphQL.Server.Transports.AspNetCore/4.4.1?_src=template)
* [GraphQL.Server.Transports.AspNetCore.SystemTextJson](https://www.nuget.org/packages/GraphQL.Server.Transports.AspNetCore.SystemTextJson/4.4.1?_src=template)
* [GraphQL.Server.Ui.Playground](https://www.nuget.org/packages/GraphQL.Server.Ui.Playground/4.4.1?_src=template)

# Schema

````graphql
type Query {
  account(accountId: String!): AccountType
  accounts: [AccountType]
  owner(ownerId: String!): OwnerType
  owners: [OwnerType]
}

type OwnerType {
  accounts: [AccountType]
  # Address property from the owner object.
  address: String!
  # Id property from the owner object.
  id: ID
  # Name property from the owner object.
  name: String!
}

type AccountType {
  # Description property from the account object.
  description: String!
  # Id property from the account object.
  id: ID
  owner: OwnerType
  # OwnerId property from the account object.
  ownerId: ID
  type: AccountTypeEnumType
}

# Enumeration for the account type object.
enum AccountTypeEnumType {
  CASH
  SAVINGS
  EXPENSE
  INCOME
}

type Mutation {
  accountCreate(account: AccountInput!): AccountType
  accountDelete(accountId: ID!): String
  accountUpdate(account: AccountInput!, accountId: String!): AccountType
  ownerCreate(owner: OwnerInput!): OwnerType
  ownerDelete(ownerId: ID!): String
  ownerUpdate(owner: OwnerInput!, ownerId: String!): OwnerType
}

input OwnerInput {
  name: String!
  address: String!
}

input AccountInput {
  type: AccountTypeEnumType!
  description: String
  ownerId: String!
}
````

# Queries example

````graphql
# Get all Owners
{
  owners{
    id
    address
    name
    accounts {
      id
      description
      ownerId
      type
    }
  }
}

# Get one Owner
{
  owner(ownerId: "3e85e4e3-d02a-4d52-ba80-83c34be6e233"){
    id
    address
    name
    accounts {
      id
      description
      ownerId
      type
    }
  }
}

# Get all Accounts
{
  accounts {
    id
    type
    description
    ownerId
    owner {
      id
      address
      name
    }
  }
}

# Get one Account
{
  account(accountId: "e58dc519-f9f7-414c-bb24-5252e1abc548") {
    id
    type
    description
    ownerId
    owner {
      id
      name
    }
  }
}
````

# Mutations example

````graphql
# Create an Owner
mutation($owner: OwnerInput!) {
  ownerCreate(owner: $owner) {
    id
    name
    address
  }
}
# Mutation
{
  "owner": {
    "name": "New owner",
    "address": "owner address"
  }
}

# Update an Owner
mutation($owner: OwnerInput!, $ownerId: String!) {
  ownerUpdate(owner: $owner, ownerId: $ownerId) {
    id
    name
    address
  }
}
# Mutation variables
{
  "owner": {
    "name": "update owner",
    "address": "update address"
  },
  "ownerId": "d33e753f-8aed-4b48-bd6a-8c601fd25ac3"
}

# Delete an Owner
mutation($ownerId: ID!) {
	ownerDelete(ownerId: $ownerId)
}
# Mutation variables
{
  "ownerId": "d33e753f-8aed-4b48-bd6a-8c601fd25ac3"
}

# Create one Account
mutation($account: AccountInput!) {
  accountCreate(account: $account) {
    id
    description
    type
    ownerId
    owner {
      id
      name
    }
  }
}
# Mutation variables
{
  "account": {
    "description": "New account",
    "type": "Income",
    "ownerId": "3e85e4e3-d02a-4d52-ba80-83c34be6e233"
  }
}

# Update an Account
mutation($account: AccountInput!, $accountId: String!) {
  accountUpdate(account: $account, accountId: $accountId) {
    id
    description
    type
    ownerId
    owner {
      id
      name
    }
  }
}
# Mutation variables
{
  "account": {
    "description": "Updated account",
    "type": "Income",
    "ownerId": "3e85e4e3-d02a-4d52-ba80-83c34be6e233"
  },
  "accountId": "e58dc519-f9f7-414c-bb24-5252e1abc548"
}

# Delete an Account
mutation($accountId: ID!) {
  accountDelete(accountId: $accountId)
}
# Mutation variables
{
  "accountId": "e58dc519-f9f7-414c-bb24-5252e1abc548"
}
````