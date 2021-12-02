using Microsoft.EntityFrameworkCore.Migrations;

namespace collection_control_api.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_loans_ClientId",
                table: "loans");

            migrationBuilder.CreateIndex(
                name: "IX_loans_ClientId",
                table: "loans",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_loans_ClientId",
                table: "loans");

            migrationBuilder.CreateIndex(
                name: "IX_loans_ClientId",
                table: "loans",
                column: "ClientId",
                unique: true);
        }
    }
}
