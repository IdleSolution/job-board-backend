using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobBoard.Migrations
{
    public partial class mergeConflict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5L, "Nokia" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Comment", "CompanyId", "From", "Issued", "Position", "Rating", "TagId", "To" },
                values: new object[,]
                {
                    { 7L, "Jest niezle", 2L, null, new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intern", 3, 8L, null },
                    { 8L, "Jest niezle", 2L, null, new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intern", 2, 10L, null },
                    { 9L, "Jest niezle", 4L, new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intern", 5, 3L, new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10L, "Jest niezle", 4L, new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intern", 5, 3L, null }
                });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Comment", "CompanyId", "From", "TagId", "To" },
                values: new object[] { "Firma jak firma", 5L, null, 4L, null });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "Comment", "CompanyId", "From", "TagId" },
                values: new object[] { "Ja tam polecam", 5L, null, 11L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Comment", "CompanyId", "From", "TagId", "To" },
                values: new object[] { "Jest niezle", 4L, new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3L, new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "Comment", "CompanyId", "From", "TagId" },
                values: new object[] { "Jest niezle", 4L, new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3L });
        }
    }
}
