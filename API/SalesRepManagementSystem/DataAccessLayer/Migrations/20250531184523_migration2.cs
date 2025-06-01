using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlafromPlatformId",
                table: "SalesRepresentative",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SalesRepresentative_PlafromPlatformId",
                table: "SalesRepresentative",
                column: "PlafromPlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesRepresentative_ProductId",
                table: "SalesRepresentative",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesRepresentative_RegionId",
                table: "SalesRepresentative",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesRepresentative_Platform_PlafromPlatformId",
                table: "SalesRepresentative",
                column: "PlafromPlatformId",
                principalTable: "Platform",
                principalColumn: "PlatformId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesRepresentative_Product_ProductId",
                table: "SalesRepresentative",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesRepresentative_Region_RegionId",
                table: "SalesRepresentative",
                column: "RegionId",
                principalTable: "Region",
                principalColumn: "RegionId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesRepresentative_Platform_PlafromPlatformId",
                table: "SalesRepresentative");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesRepresentative_Product_ProductId",
                table: "SalesRepresentative");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesRepresentative_Region_RegionId",
                table: "SalesRepresentative");

            migrationBuilder.DropIndex(
                name: "IX_SalesRepresentative_PlafromPlatformId",
                table: "SalesRepresentative");

            migrationBuilder.DropIndex(
                name: "IX_SalesRepresentative_ProductId",
                table: "SalesRepresentative");

            migrationBuilder.DropIndex(
                name: "IX_SalesRepresentative_RegionId",
                table: "SalesRepresentative");

            migrationBuilder.DropColumn(
                name: "PlafromPlatformId",
                table: "SalesRepresentative");
        }
    }
}
