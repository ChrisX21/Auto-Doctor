using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoDoctor.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixedRelations1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
