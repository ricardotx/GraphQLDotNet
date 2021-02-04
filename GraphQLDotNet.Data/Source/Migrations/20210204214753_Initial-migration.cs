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
                    { new Guid("0cdded52-9e3a-4249-be4d-3a5dca8e99f8"), "John Doe's address", "John Doe" },
                    { new Guid("778ff453-8593-424a-ba9b-a7e32fba0478"), "Jane Doe's address", "Jane Doe" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { new Guid("5cd0d301-c3f2-40ee-9736-b37826e4f027"), "admin", "Admin" },
                    { new Guid("24417ea1-2528-431b-89fc-6fd2611238fa"), "user", "User" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Description", "OwnerId", "Type" },
                values: new object[,]
                {
                    { new Guid("e913680c-1427-476e-855a-8c1f04aff95a"), "Cash account for our users", new Guid("0cdded52-9e3a-4249-be4d-3a5dca8e99f8"), 0 },
                    { new Guid("c11ec666-03e6-4e95-ab1e-664ff1e09615"), "Savings account for our users", new Guid("778ff453-8593-424a-ba9b-a7e32fba0478"), 1 },
                    { new Guid("6454474e-f180-470e-9447-6a325903a92c"), "Income account for our users", new Guid("778ff453-8593-424a-ba9b-a7e32fba0478"), 3 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "RoleId", "Status" },
                values: new object[] { new Guid("224a0932-2140-4cb7-a5f5-47342b5d6579"), "admin@mail.com", "Admin", "123", new Guid("5cd0d301-c3f2-40ee-9736-b37826e4f027"), 1 });

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
