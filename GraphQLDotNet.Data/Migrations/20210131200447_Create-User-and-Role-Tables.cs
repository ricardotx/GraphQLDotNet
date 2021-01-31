using Microsoft.EntityFrameworkCore.Migrations;

using System;

namespace GraphQLDotNet.Data.Migrations
{
	public partial class CreateUserandRoleTables : Migration
	{
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Users");

			migrationBuilder.DropTable(
				name: "Roles");

			migrationBuilder.DeleteData(
				table: "Accounts",
				keyColumn: "Id",
				keyValue: new Guid("039cd6e9-a6e1-4443-8113-a18bf341409e"));

			migrationBuilder.DeleteData(
				table: "Accounts",
				keyColumn: "Id",
				keyValue: new Guid("502de685-91b2-412e-b941-3739973488e9"));

			migrationBuilder.DeleteData(
				table: "Accounts",
				keyColumn: "Id",
				keyValue: new Guid("545562e8-a5a5-4346-8275-ffff9812ac8b"));

			migrationBuilder.DeleteData(
				table: "Owners",
				keyColumn: "Id",
				keyValue: new Guid("4848e78f-86a2-4548-a87f-c25ef64aad17"));

			migrationBuilder.DeleteData(
				table: "Owners",
				keyColumn: "Id",
				keyValue: new Guid("618ebe4a-b37f-48f4-837c-7acb314195c0"));

			migrationBuilder.InsertData(
				table: "Owners",
				columns: new[] { "Id", "Address", "Name" },
				values: new object[] { new Guid("ef73ae5f-8b0c-434b-87c7-ba777d8feae9"), "John Doe's address", "John Doe" });

			migrationBuilder.InsertData(
				table: "Owners",
				columns: new[] { "Id", "Address", "Name" },
				values: new object[] { new Guid("5d3b52a0-d7ac-4584-a3d2-fde1f7905356"), "Jane Doe's address", "Jane Doe" });

			migrationBuilder.InsertData(
				table: "Accounts",
				columns: new[] { "Id", "Description", "OwnerId", "Type" },
				values: new object[] { new Guid("bbb1a9c4-7fbf-46c1-b8b6-500ac098d100"), "Cash account for our users", new Guid("ef73ae5f-8b0c-434b-87c7-ba777d8feae9"), 0 });

			migrationBuilder.InsertData(
				table: "Accounts",
				columns: new[] { "Id", "Description", "OwnerId", "Type" },
				values: new object[] { new Guid("884207d5-df87-45b5-897f-22401e355fee"), "Savings account for our users", new Guid("5d3b52a0-d7ac-4584-a3d2-fde1f7905356"), 1 });

			migrationBuilder.InsertData(
				table: "Accounts",
				columns: new[] { "Id", "Description", "OwnerId", "Type" },
				values: new object[] { new Guid("4a8d556d-4310-4da7-92e7-26cff54a43f9"), "Income account for our users", new Guid("5d3b52a0-d7ac-4584-a3d2-fde1f7905356"), 3 });
		}

		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DeleteData(
				table: "Accounts",
				keyColumn: "Id",
				keyValue: new Guid("4a8d556d-4310-4da7-92e7-26cff54a43f9"));

			migrationBuilder.DeleteData(
				table: "Accounts",
				keyColumn: "Id",
				keyValue: new Guid("884207d5-df87-45b5-897f-22401e355fee"));

			migrationBuilder.DeleteData(
				table: "Accounts",
				keyColumn: "Id",
				keyValue: new Guid("bbb1a9c4-7fbf-46c1-b8b6-500ac098d100"));

			migrationBuilder.DeleteData(
				table: "Owners",
				keyColumn: "Id",
				keyValue: new Guid("5d3b52a0-d7ac-4584-a3d2-fde1f7905356"));

			migrationBuilder.DeleteData(
				table: "Owners",
				keyColumn: "Id",
				keyValue: new Guid("ef73ae5f-8b0c-434b-87c7-ba777d8feae9"));

			migrationBuilder.CreateTable(
				name: "Roles",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "char(36)", nullable: false),
					Code = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
					Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Roles", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Users",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "char(36)", nullable: false),
					Email = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
					Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
					Password = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
					RoleId = table.Column<Guid>(type: "char(36)", nullable: false),
					Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Users", x => x.Id);
					table.ForeignKey(
						name: "FK_Users_Roles_RoleId",
						column: x => x.RoleId,
						principalTable: "Roles",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.InsertData(
				table: "Owners",
				columns: new[] { "Id", "Address", "Name" },
				values: new object[,]
				{
					{ new Guid("618ebe4a-b37f-48f4-837c-7acb314195c0"), "John Doe's address", "John Doe" },
					{ new Guid("4848e78f-86a2-4548-a87f-c25ef64aad17"), "Jane Doe's address", "Jane Doe" }
				});

			migrationBuilder.InsertData(
				table: "Roles",
				columns: new[] { "Id", "Code", "Name" },
				values: new object[,]
				{
					{ new Guid("a5575edf-c628-42c6-b653-29b7908c816f"), "admin", "Admin" },
					{ new Guid("7d7aa1eb-de63-414b-a4fc-43d8dec1843e"), "user", "User" }
				});

			migrationBuilder.InsertData(
				table: "Accounts",
				columns: new[] { "Id", "Description", "OwnerId", "Type" },
				values: new object[,]
				{
					{ new Guid("545562e8-a5a5-4346-8275-ffff9812ac8b"), "Cash account for our users", new Guid("618ebe4a-b37f-48f4-837c-7acb314195c0"), 0 },
					{ new Guid("039cd6e9-a6e1-4443-8113-a18bf341409e"), "Savings account for our users", new Guid("4848e78f-86a2-4548-a87f-c25ef64aad17"), 1 },
					{ new Guid("502de685-91b2-412e-b941-3739973488e9"), "Income account for our users", new Guid("4848e78f-86a2-4548-a87f-c25ef64aad17"), 3 }
				});

			migrationBuilder.InsertData(
				table: "Users",
				columns: new[] { "Id", "Email", "Name", "Password", "RoleId", "Status" },
				values: new object[] { new Guid("b3615b43-42f0-4ac3-b839-a0e22c900784"), "admin@mail.com", "Admin", "123", new Guid("a5575edf-c628-42c6-b653-29b7908c816f"), 1 });

			migrationBuilder.CreateIndex(
				name: "UniqueCode",
				table: "Roles",
				column: "Code",
				unique: true);

			migrationBuilder.CreateIndex(
				name: "IX_Users_RoleId",
				table: "Users",
				column: "RoleId");

			migrationBuilder.CreateIndex(
				name: "UniqueUserEmail",
				table: "Users",
				column: "Email",
				unique: true);
		}
	}
}
