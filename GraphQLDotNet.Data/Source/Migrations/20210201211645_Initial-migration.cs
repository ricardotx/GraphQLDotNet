using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GraphQLDotNet.Data.Source.Migrations
{
    public partial class Initialmigration : Migration
    {
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
                        onDelete: ReferentialAction.Cascade);
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
                    { new Guid("4fc8c99e-d975-449c-9d2a-1ffe86c08f6d"), "John Doe's address", "John Doe" },
                    { new Guid("99e225ed-d0df-416b-b67c-e0cf416baf52"), "Jane Doe's address", "Jane Doe" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { new Guid("31e0c425-aaa9-4315-b138-fd957e04bf0a"), "admin", "Admin" },
                    { new Guid("d7a77eab-6b8c-44b9-a114-f36d81d80990"), "user", "User" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Description", "OwnerId", "Type" },
                values: new object[,]
                {
                    { new Guid("768e238b-3fb6-4b1d-a8ed-ec9111a41bea"), "Cash account for our users", new Guid("4fc8c99e-d975-449c-9d2a-1ffe86c08f6d"), 0 },
                    { new Guid("67ad16a9-d217-4dc1-8f4a-069617f7d1ab"), "Savings account for our users", new Guid("99e225ed-d0df-416b-b67c-e0cf416baf52"), 1 },
                    { new Guid("fccc5a20-dc27-43ca-ad17-f63f87dda843"), "Income account for our users", new Guid("99e225ed-d0df-416b-b67c-e0cf416baf52"), 3 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "RoleId", "Status" },
                values: new object[] { new Guid("d368833f-6584-47a2-ae55-97962a527954"), "admin@mail.com", "Admin", "123", new Guid("31e0c425-aaa9-4315-b138-fd957e04bf0a"), 1 });

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
    }
}
