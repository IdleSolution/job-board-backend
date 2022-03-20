using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobBoard.Migrations
{
    public partial class testStillWorking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Comment", "CompanyId", "From", "Issued", "Position", "Rating", "TagId", "To" },
                values: new object[] { 5L, "Jest niezle", 4L, new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intern", 5, 3L, new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Comment", "CompanyId", "From", "Issued", "Position", "Rating", "TagId", "To" },
                values: new object[] { 6L, "Jest niezle", 4L, new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intern", 5, 3L, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6L);
        }
    }
}
