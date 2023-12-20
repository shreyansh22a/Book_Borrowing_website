using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_Access_Layer.Migrations
{
    /// <inheritdoc />
    public partial class updatebooktable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Users_CurrentlyBorrowedById",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Users_LentByUserId",
                table: "Books");

            migrationBuilder.AlterColumn<string>(
                name: "LentByUserId",
                table: "Books",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CurrentlyBorrowedById",
                table: "Books",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Users_CurrentlyBorrowedById",
                table: "Books",
                column: "CurrentlyBorrowedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Users_LentByUserId",
                table: "Books",
                column: "LentByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Users_CurrentlyBorrowedById",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Users_LentByUserId",
                table: "Books");

            migrationBuilder.AlterColumn<string>(
                name: "LentByUserId",
                table: "Books",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CurrentlyBorrowedById",
                table: "Books",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Users_CurrentlyBorrowedById",
                table: "Books",
                column: "CurrentlyBorrowedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Users_LentByUserId",
                table: "Books",
                column: "LentByUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
