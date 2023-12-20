using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentalAgreements_Users_UserId",
                table: "RentalAgreements");

            migrationBuilder.DropIndex(
                name: "IX_RentalAgreements_UserId",
                table: "RentalAgreements");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "RentalAgreements",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "RentalAgreements",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_RentalAgreements_UserId",
                table: "RentalAgreements",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RentalAgreements_Users_UserId",
                table: "RentalAgreements",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
