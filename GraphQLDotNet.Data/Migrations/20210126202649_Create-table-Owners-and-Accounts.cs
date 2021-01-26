using Microsoft.EntityFrameworkCore.Migrations;

using System;

namespace GraphQLDotNet.Data.Migrations
{
    public partial class CreatetableOwnersandAccounts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    Address = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    OwnerId = table.Column<Guid>(type: "char(36)", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_OwnerId",
                table: "Accounts",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Owners");
        }
    }
}
