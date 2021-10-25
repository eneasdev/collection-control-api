using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace collection_control_api.Migrations
{
    public partial class notinitialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleasedYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "loans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_loans_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PagesNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_books_items_Id",
                        column: x => x.Id,
                        principalTable: "items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Singer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SongsNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cds_items_Id",
                        column: x => x.Id,
                        principalTable: "items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "dvds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Staring = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dvds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dvds_items_Id",
                        column: x => x.Id,
                        principalTable: "items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemLoan",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    LoanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemLoan", x => new { x.ItemId, x.LoanId });
                    table.ForeignKey(
                        name: "FK_ItemLoan_items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemLoan_loans_LoanId",
                        column: x => x.LoanId,
                        principalTable: "loans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemLoan_LoanId",
                table: "ItemLoan",
                column: "LoanId");

            migrationBuilder.CreateIndex(
                name: "IX_loans_ClientId",
                table: "loans",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "cds");

            migrationBuilder.DropTable(
                name: "dvds");

            migrationBuilder.DropTable(
                name: "ItemLoan");

            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropTable(
                name: "loans");

            migrationBuilder.DropTable(
                name: "clients");
        }
    }
}
