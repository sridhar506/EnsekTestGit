using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EnsekEntities.Migrations
{
    public partial class Intialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "MeterReadings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(nullable: false),
                    MeterReadingDateTime = table.Column<DateTime>(nullable: false),
                    MeterReadValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeterReadings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeterReadings_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1234, "Freya", "Test" },
                    { 4534, "JOSH", "TEST" },
                    { 2356, "Craig", "Test" },
                    { 2355, "Arthur", "Test" },
                    { 2353, "Tony", "Test" },
                    { 2352, "Greg", "Test" },
                    { 2351, "Gladys", "Test" },
                    { 2350, "Colin", "Test" },
                    { 2349, "Simon", "Test" },
                    { 2348, "Tammy", "Test" },
                    { 2347, "Tara", "Test" },
                    { 2346, "Ollie", "Test" },
                    { 6776, "Laura", "Test" },
                    { 2345, "Jerry", "Test" },
                    { 2233, "Barry", "Test" },
                    { 1248, "Pam", "Test" },
                    { 1247, "Jim", "Test" },
                    { 1246, "Jo", "Test" },
                    { 1245, "Neville", "Test" },
                    { 1244, "Tony", "Test" },
                    { 1243, "Graham", "Test" },
                    { 1242, "Tim", "Test" },
                    { 1241, "Lara", "Test" },
                    { 1240, "Archie", "Test" },
                    { 1239, "Noddy", "Test" },
                    { 2344, "Tommy", "Test" },
                    { 8766, "Sally", "Test" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeterReadings_AccountId",
                table: "MeterReadings",
                column: "AccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeterReadings");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
