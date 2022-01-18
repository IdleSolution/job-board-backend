using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace JobBoard.Migrations
{
    public partial class tags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tag",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "Tag",
                table: "Interviews");

            migrationBuilder.AddColumn<long>(
                name: "TagId",
                table: "Reviews",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TagId",
                table: "Interviews",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "JS/TS" },
                    { 2L, "C#" },
                    { 3L, "Java" },
                    { 4L, "C/C++" },
                    { 5L, "Algorithms" },
                    { 6L, "Networks" },
                    { 7L, "Databases" },
                    { 8L, "Haskell" },
                    { 9L, "Python" },
                    { 10L, "Golang" },
                    { 11L, "Kotlin" }
                });

            migrationBuilder.UpdateData(
                table: "Interviews",
                keyColumn: "Id",
                keyValue: 1L,
                column: "TagId",
                value: 5L);

            migrationBuilder.UpdateData(
                table: "Interviews",
                keyColumn: "Id",
                keyValue: 2L,
                column: "TagId",
                value: 2L);

            migrationBuilder.UpdateData(
                table: "Interviews",
                keyColumn: "Id",
                keyValue: 3L,
                column: "TagId",
                value: 2L);

            migrationBuilder.UpdateData(
                table: "Interviews",
                keyColumn: "Id",
                keyValue: 4L,
                column: "TagId",
                value: 2L);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1L,
                column: "TagId",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2L,
                column: "TagId",
                value: 2L);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3L,
                column: "TagId",
                value: 3L);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4L,
                column: "TagId",
                value: 3L);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_TagId",
                table: "Reviews",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_TagId",
                table: "Interviews",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_Tags_TagId",
                table: "Interviews",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Tags_TagId",
                table: "Reviews",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_Tags_TagId",
                table: "Interviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Tags_TagId",
                table: "Reviews");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_TagId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Interviews_TagId",
                table: "Interviews");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Interviews");

            migrationBuilder.AddColumn<string>(
                name: "Tag",
                table: "Reviews",
                type: "text",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Tag",
                table: "Interviews",
                type: "text",
                nullable: false);

            migrationBuilder.UpdateData(
                table: "Interviews",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Tag",
                value: "JavaScript");

            migrationBuilder.UpdateData(
                table: "Interviews",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Tag",
                value: "C#");

            migrationBuilder.UpdateData(
                table: "Interviews",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Tag",
                value: "C#");

            migrationBuilder.UpdateData(
                table: "Interviews",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Tag",
                value: "C#");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Tag",
                value: "JavaScript");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Tag",
                value: "C#");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Tag",
                value: "Java");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Tag",
                value: "Java");
        }
    }
}
