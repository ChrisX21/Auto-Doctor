using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoDoctor.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixedRelations5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderOffers_Offers_OfferId",
                table: "OrderOffers");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderOffers_Offers_OfferId",
                table: "OrderOffers",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderOffers_Offers_OfferId",
                table: "OrderOffers");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderOffers_Offers_OfferId",
                table: "OrderOffers",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
