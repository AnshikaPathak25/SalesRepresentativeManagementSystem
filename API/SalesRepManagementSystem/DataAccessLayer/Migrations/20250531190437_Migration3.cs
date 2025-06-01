using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Migration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesRepresentative_Platform_PlafromPlatformId",
                table: "SalesRepresentative");

            migrationBuilder.DropIndex(
                name: "IX_SalesRepresentative_PlafromPlatformId",
                table: "SalesRepresentative");

            migrationBuilder.DropColumn(
                name: "PlafromPlatformId",
                table: "SalesRepresentative");

            migrationBuilder.CreateIndex(
                name: "IX_SalesRepresentative_PlatformId",
                table: "SalesRepresentative",
                column: "PlatformId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesRepresentative_Platform_PlatformId",
                table: "SalesRepresentative",
                column: "PlatformId",
                principalTable: "Platform",
                principalColumn: "PlatformId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesRepresentative_Platform_PlatformId",
                table: "SalesRepresentative");

            migrationBuilder.DropIndex(
                name: "IX_SalesRepresentative_PlatformId",
                table: "SalesRepresentative");

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

            migrationBuilder.AddForeignKey(
                name: "FK_SalesRepresentative_Platform_PlafromPlatformId",
                table: "SalesRepresentative",
                column: "PlafromPlatformId",
                principalTable: "Platform",
                principalColumn: "PlatformId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
