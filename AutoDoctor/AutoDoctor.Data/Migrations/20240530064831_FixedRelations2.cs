using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoDoctor.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixedRelations2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Parts_PartId",
                table: "Offers");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Parts_PartId",
                table: "Offers",
                column: "PartId",
                principalTable: "Parts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Parts_PartId",
                table: "Offers");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Parts_PartId",
                table: "Offers",
                column: "PartId",
                principalTable: "Parts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
