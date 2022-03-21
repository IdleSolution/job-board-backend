using Microsoft.EntityFrameworkCore.Migrations;

namespace JobBoard.Migrations
{
    public partial class userRelation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_AspNetUsers_UserId",
                table: "Interviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_UserId",
                table: "Reviews");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dummyId",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8105b60c-6ab3-44e6-afa8-2416b93ce503", "9967eca6-bc4e-4c79-8848-a6ca40ddc556" });

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_AspNetUsers_UserId",
                table: "Interviews",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_UserId",
                table: "Reviews",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_AspNetUsers_UserId",
                table: "Interviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_UserId",
                table: "Reviews");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dummyId",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4610ab8b-3c21-4bb8-a8ef-42b65fdc1bd8", "77cbb8c7-3fb2-42db-b65f-a8cdc98fe46f" });

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_AspNetUsers_UserId",
                table: "Interviews",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_UserId",
                table: "Reviews",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
