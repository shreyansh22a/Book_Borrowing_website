using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentalAgreements_Cars_CarId",
                table: "RentalAgreements");

            migrationBuilder.DropIndex(
                name: "IX_RentalAgreements_CarId",
                table: "RentalAgreements");

            migrationBuilder.AlterColumn<string>(
                name: "CarId",
                table: "RentalAgreements",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "CarId",
                table: "RentalAgreements",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_RentalAgreements_CarId",
                table: "RentalAgreements",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_RentalAgreements_Cars_CarId",
                table: "RentalAgreements",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
