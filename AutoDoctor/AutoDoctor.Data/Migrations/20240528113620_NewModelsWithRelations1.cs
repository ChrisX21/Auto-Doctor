using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoDoctor.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewModelsWithRelations1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Parts_PartId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_partVehicles_Parts_PartId",
                table: "partVehicles");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Parts_PartId",
                table: "Offers",
                column: "PartId",
                principalTable: "Parts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_partVehicles_Parts_PartId",
                table: "partVehicles",
                column: "PartId",
                principalTable: "Parts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Parts_PartId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_partVehicles_Parts_PartId",
                table: "partVehicles");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Parts_PartId",
                table: "Offers",
                column: "PartId",
                principalTable: "Parts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_partVehicles_Parts_PartId",
                table: "partVehicles",
                column: "PartId",
                principalTable: "Parts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
