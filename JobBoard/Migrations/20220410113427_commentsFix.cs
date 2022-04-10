using Microsoft.EntityFrameworkCore.Migrations;

namespace JobBoard.Migrations
{
    public partial class commentsFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterviewComment_AspNetUsers_UserId",
                table: "InterviewComment");

            migrationBuilder.DropForeignKey(
                name: "FK_InterviewComment_Interviews_InterviewId",
                table: "InterviewComment");

            migrationBuilder.DropForeignKey(
                name: "FK_ReviewComment_AspNetUsers_UserId",
                table: "ReviewComment");

            migrationBuilder.DropForeignKey(
                name: "FK_ReviewComment_Reviews_ReviewId",
                table: "ReviewComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReviewComment",
                table: "ReviewComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InterviewComment",
                table: "InterviewComment");

            migrationBuilder.RenameTable(
                name: "ReviewComment",
                newName: "reviewComments");

            migrationBuilder.RenameTable(
                name: "InterviewComment",
                newName: "interviewComments");

            migrationBuilder.RenameIndex(
                name: "IX_ReviewComment_UserId",
                table: "reviewComments",
                newName: "IX_reviewComments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ReviewComment_ReviewId",
                table: "reviewComments",
                newName: "IX_reviewComments_ReviewId");

            migrationBuilder.RenameIndex(
                name: "IX_InterviewComment_UserId",
                table: "interviewComments",
                newName: "IX_interviewComments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_InterviewComment_InterviewId",
                table: "interviewComments",
                newName: "IX_interviewComments_InterviewId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                newName: "ReviewComment");

            migrationBuilder.RenameTable(
                name: "interviewComments",
                newName: "InterviewComment");

            migrationBuilder.RenameIndex(
                name: "IX_reviewComments_UserId",
                table: "ReviewComment",
                newName: "IX_ReviewComment_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_reviewComments_ReviewId",
                table: "ReviewComment",
                newName: "IX_ReviewComment_ReviewId");

            migrationBuilder.RenameIndex(
                name: "IX_interviewComments_UserId",
                table: "InterviewComment",
                newName: "IX_InterviewComment_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_interviewComments_InterviewId",
                table: "InterviewComment",
                newName: "IX_InterviewComment_InterviewId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReviewComment",
                table: "ReviewComment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InterviewComment",
                table: "InterviewComment",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dummyId",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0f477b15-858c-4a4d-bf69-e1eba176c11d", "f1027d6a-3192-4fa8-add8-c7e79e98981f" });

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewComment_AspNetUsers_UserId",
                table: "InterviewComment",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewComment_Interviews_InterviewId",
                table: "InterviewComment",
                column: "InterviewId",
                principalTable: "Interviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewComment_AspNetUsers_UserId",
                table: "ReviewComment",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewComment_Reviews_ReviewId",
                table: "ReviewComment",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
