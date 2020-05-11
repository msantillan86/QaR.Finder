using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QaR.Finder.Infrastructure.Persistence.Migrations
{
    public partial class QaRFinderMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreadoPor = table.Column<string>(nullable: true),
                    CreadoFecha = table.Column<DateTime>(nullable: false),
                    ActualizadoPor = table.Column<string>(nullable: true),
                    ActualizadoFecha = table.Column<DateTime>(nullable: true),
                    Text = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
