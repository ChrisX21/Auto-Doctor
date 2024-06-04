using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoDoctor.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixedRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_partVehicles_Parts_PartId",
                table: "partVehicles");

            migrationBuilder.DropIndex(
                name: "IX_Offers_PartId",
                table: "Offers");

            migrationBuilder.AddColumn<Guid>(
                name: "OfferId",
                table: "Parts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Offers_PartId",
                table: "Offers",
                column: "PartId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_partVehicles_Parts_PartId",
                table: "partVehicles",
                column: "PartId",
                principalTable: "Parts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_partVehicles_Parts_PartId",
                table: "partVehicles");

            migrationBuilder.DropIndex(
                name: "IX_Offers_PartId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "OfferId",
                table: "Parts");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_PartId",
                table: "Offers",
                column: "PartId");

            migrationBuilder.AddForeignKey(
                name: "FK_partVehicles_Parts_PartId",
                table: "partVehicles",
                column: "PartId",
                principalTable: "Parts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
