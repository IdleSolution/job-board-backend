using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobBoard.Migrations
{
    public partial class More : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2L, "Comarch" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3L, "SWM" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4L, "Capgemini" });

            migrationBuilder.InsertData(
                table: "Interviews",
                columns: new[] { "Id", "Comment", "CompanyId", "Difficulty", "Issued", "Position", "Tag" },
                values: new object[,]
                {
                    { 2L, "ez", 2L, 1, new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intern", "C#" },
                    { 3L, "ez", 3L, 1, new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intern", "C#" },
                    { 4L, "ez", 4L, 1, new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intern", "C#" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Comment", "CompanyId", "From", "Issued", "Position", "Rating", "Tag", "To" },
                values: new object[,]
                {
                    { 2L, "Jest niezle", 2L, null, new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intern", 1, "C#", null },
                    { 3L, "Jest niezle", 3L, null, new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intern", 5, "Java", null },
                    { 4L, "Jest niezle", 4L, null, new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intern", 5, "Java", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Interviews",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Interviews",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Interviews",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 4L);
        }
    }
}
