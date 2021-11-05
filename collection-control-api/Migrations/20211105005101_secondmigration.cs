using Microsoft.EntityFrameworkCore.Migrations;

namespace collection_control_api.Migrations
{
    public partial class secondmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_loans_clients_ClientId",
                table: "loans");

            migrationBuilder.DropForeignKey(
                name: "FK_loans_items_ItemId",
                table: "loans");

            migrationBuilder.DropIndex(
                name: "IX_loans_ClientId",
                table: "loans");

            migrationBuilder.DropIndex(
                name: "IX_loans_ItemId",
                table: "loans");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "loans",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "loans",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_loans_ClientId",
                table: "loans",
                column: "ClientId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_loans_clients_ClientId",
                table: "loans",
                column: "ClientId",
                principalTable: "clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_loans_clients_ClientId",
                table: "loans");

            migrationBuilder.DropIndex(
                name: "IX_loans_ClientId",
                table: "loans");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "loans",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "loans",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_loans_ClientId",
                table: "loans",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_loans_ItemId",
                table: "loans",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_loans_clients_ClientId",
                table: "loans",
                column: "ClientId",
                principalTable: "clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_loans_items_ItemId",
                table: "loans",
                column: "ItemId",
                principalTable: "items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
