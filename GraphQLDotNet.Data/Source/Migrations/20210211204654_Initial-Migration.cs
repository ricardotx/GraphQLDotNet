using Microsoft.EntityFrameworkCore.Migrations;

using System;

namespace GraphQLDotNet.Data.Source.Migrations
{
	public partial class InitialMigration : Migration
	{
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Accounts");

			migrationBuilder.DropTable(
				name: "Users");

			migrationBuilder.DropTable(
				name: "Owners");

			migrationBuilder.DropTable(
				name: "Roles");
		}

		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Owners",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "char(36)", nullable: false),
					Address = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
					Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Owners", x => x.Id);
				});

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
				name: "Accounts",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "char(36)", nullable: false),
					Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
					OwnerId = table.Column<Guid>(type: "char(36)", nullable: false),
					Type = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Accounts", x => x.Id);
					table.ForeignKey(
						name: "FK_Accounts_Owners_OwnerId",
						column: x => x.OwnerId,
						principalTable: "Owners",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
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
					{ new Guid("bd692961-78d8-488e-bdec-3663d6401b61"), "John Doe's address", "John Doe" },
					{ new Guid("7acdde20-2a8c-4b4e-b535-20d933a50308"), "Jane Doe's address", "Jane Doe" }
				});

			migrationBuilder.InsertData(
				table: "Roles",
				columns: new[] { "Id", "Code", "Name" },
				values: new object[,]
				{
					{ new Guid("7f027bad-48c1-448b-879f-d01aa1d0b7e2"), "admin", "Admin" },
					{ new Guid("4cee5850-6572-4bcc-a7d3-cee687ddcfd9"), "user", "User" }
				});

			migrationBuilder.InsertData(
				table: "Accounts",
				columns: new[] { "Id", "Description", "OwnerId", "Type" },
				values: new object[,]
				{
					{ new Guid("eef35151-b79d-4a49-80f3-4835d88fadb2"), "Cash account for our users", new Guid("bd692961-78d8-488e-bdec-3663d6401b61"), 0 },
					{ new Guid("d4f59aaa-789c-43ee-ba0b-4360086cba8b"), "Savings account for our users", new Guid("7acdde20-2a8c-4b4e-b535-20d933a50308"), 1 },
					{ new Guid("8eab6378-7189-4359-bbd1-8759c8570706"), "Income account for our users", new Guid("7acdde20-2a8c-4b4e-b535-20d933a50308"), 3 }
				});

			migrationBuilder.InsertData(
				table: "Users",
				columns: new[] { "Id", "Email", "Name", "Password", "RoleId", "Status" },
				values: new object[] { new Guid("4954d130-1b75-4ee7-a234-02d95f696d38"), "admin@mail.com", "Admin", "123", new Guid("7f027bad-48c1-448b-879f-d01aa1d0b7e2"), 1 });

			migrationBuilder.CreateIndex(
				name: "IX_Accounts_OwnerId",
				table: "Accounts",
				column: "OwnerId");

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
