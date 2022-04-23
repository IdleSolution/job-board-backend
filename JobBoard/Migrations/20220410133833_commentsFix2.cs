using Microsoft.EntityFrameworkCore.Migrations;

namespace JobBoard.Migrations
{
    public partial class commentsFix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_interviewComments_AspNetUsers_UserId",
                table: "interviewComments");

            migrationBuilder.DropForeignKey(
                name: "FK_interviewComments_Interviews_InterviewId",
                table: "interviewComments");

            migrationBuilder.DropForeignKey(
                name: "FK_reviewComments_AspNetUsers_UserId",
                table: "reviewComments");

            migrationBuilder.DropForeignKey(
                name: "FK_reviewComments_Reviews_ReviewId",
                table: "reviewComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_reviewComments",
                table: "reviewComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_interviewComments",
                table: "interviewComments");

            migrationBuilder.RenameTable(
                name: "reviewComments",
                newName: "ReviewComments");

            migrationBuilder.RenameTable(
                name: "interviewComments",
                newName: "InterviewComments");

            migrationBuilder.RenameIndex(
                name: "IX_reviewComments_UserId",
                table: "ReviewComments",
                newName: "IX_ReviewComments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_reviewComments_ReviewId",
                table: "ReviewComments",
                newName: "IX_ReviewComments_ReviewId");

            migrationBuilder.RenameIndex(
                name: "IX_interviewComments_UserId",
                table: "InterviewComments",
                newName: "IX_InterviewComments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_interviewComments_InterviewId",
                table: "InterviewComments",
                newName: "IX_InterviewComments_InterviewId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ReviewComments",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "InterviewComments",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReviewComments",
                table: "ReviewComments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InterviewComments",
                table: "InterviewComments",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dummyId",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6cff0648-143e-491a-8aa4-9f233c390529", "f2fca08f-7d9c-4b5a-b884-249f54153047" });

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewComments_AspNetUsers_UserId",
                table: "InterviewComments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewComments_Interviews_InterviewId",
                table: "InterviewComments",
                column: "InterviewId",
                principalTable: "Interviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewComments_AspNetUsers_UserId",
                table: "ReviewComments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewComments_Reviews_ReviewId",
                table: "ReviewComments",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterviewComments_AspNetUsers_UserId",
                table: "InterviewComments");

            migrationBuilder.DropForeignKey(
                name: "FK_InterviewComments_Interviews_InterviewId",
                table: "InterviewComments");

            migrationBuilder.DropForeignKey(
                name: "FK_ReviewComments_AspNetUsers_UserId",
                table: "ReviewComments");

            migrationBuilder.DropForeignKey(
                name: "FK_ReviewComments_Reviews_ReviewId",
                table: "ReviewComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReviewComments",
                table: "ReviewComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InterviewComments",
                table: "InterviewComments");

            migrationBuilder.RenameTable(
                name: "ReviewComments",
                newName: "reviewComments");

            migrationBuilder.RenameTable(
                name: "InterviewComments",
                newName: "interviewComments");

            migrationBuilder.RenameIndex(
                name: "IX_ReviewComments_UserId",
                table: "reviewComments",
                newName: "IX_reviewComments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ReviewComments_ReviewId",
                table: "reviewComments",
                newName: "IX_reviewComments_ReviewId");

            migrationBuilder.RenameIndex(
                name: "IX_InterviewComments_UserId",
                table: "interviewComments",
                newName: "IX_interviewComments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_InterviewComments_InterviewId",
                table: "interviewComments",
                newName: "IX_interviewComments_InterviewId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "reviewComments",
                type: "varchar(200)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "interviewComments",
                type: "varchar(200)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_reviewComments",
                table: "reviewComments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_interviewComments",
                table: "interviewComments",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dummyId",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8458e7fb-1f01-4b9a-a985-8a1be13d4c44", "a5b6f615-454d-4d50-85ca-224e61b8e1a4" });

            migrationBuilder.AddForeignKey(
                name: "FK_interviewComments_AspNetUsers_UserId",
                table: "interviewComments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_interviewComments_Interviews_InterviewId",
                table: "interviewComments",
                column: "InterviewId",
                principalTable: "Interviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reviewComments_AspNetUsers_UserId",
                table: "reviewComments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_reviewComments_Reviews_ReviewId",
                table: "reviewComments",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
