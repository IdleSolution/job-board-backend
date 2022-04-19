using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace JobBoard.Migrations
{
    public partial class comments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InterviewComment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Message = table.Column<string>(type: "text", nullable: false),
                    Issued = table.Column<DateTime>(type: "datetime", nullable: false),
                    UserId = table.Column<string>(type: "varchar(200)", nullable: true),
                    InterviewId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InterviewComment_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InterviewComment_Interviews_InterviewId",
                        column: x => x.InterviewId,
                        principalTable: "Interviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReviewComment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Message = table.Column<string>(type: "text", nullable: false),
                    Issued = table.Column<DateTime>(type: "datetime", nullable: false),
                    UserId = table.Column<string>(type: "varchar(200)", nullable: true),
                    ReviewId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewComment_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReviewComment_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dummyId",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0f477b15-858c-4a4d-bf69-e1eba176c11d", "f1027d6a-3192-4fa8-add8-c7e79e98981f" });

            migrationBuilder.CreateIndex(
                name: "IX_InterviewComment_InterviewId",
                table: "InterviewComment",
                column: "InterviewId");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewComment_UserId",
                table: "InterviewComment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewComment_ReviewId",
                table: "ReviewComment",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewComment_UserId",
                table: "ReviewComment",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterviewComment");

            migrationBuilder.DropTable(
                name: "ReviewComment");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dummyId",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8105b60c-6ab3-44e6-afa8-2416b93ce503", "9967eca6-bc4e-4c79-8848-a6ca40ddc556" });
        }
    }
}
