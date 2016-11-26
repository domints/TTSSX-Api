using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TTSSXApi.Migrations
{
    public partial class AddFetchingTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "fetches",
                columns: table => new
                {
                    fetid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    fetalerts = table.Column<string>(nullable: true),
                    fetstopid = table.Column<int>(nullable: false),
                    fettime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fetches", x => x.fetid);
                });

            migrationBuilder.CreateTable(
                name: "fetchpassages",
                columns: table => new
                {
                    ftpid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ftpactual = table.Column<TimeSpan>(nullable: true),
                    ftpfetid = table.Column<int>(nullable: false),
                    ftppassageid = table.Column<long>(nullable: false),
                    ftpplanned = table.Column<TimeSpan>(nullable: false),
                    ftprelative = table.Column<int>(nullable: false),
                    ftptraid = table.Column<int>(nullable: false),
                    ftptripid = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fetchpassages", x => x.ftpid);
                    table.ForeignKey(
                        name: "FK_fetchpassages_fetches_ftpfetid",
                        column: x => x.ftpfetid,
                        principalTable: "fetches",
                        principalColumn: "fetid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_fetchpassages_trams_ftptraid",
                        column: x => x.ftptraid,
                        principalTable: "trams",
                        principalColumn: "traid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_fetchpassages_ftpfetid",
                table: "fetchpassages",
                column: "ftpfetid");

            migrationBuilder.CreateIndex(
                name: "IX_fetchpassages_ftptraid",
                table: "fetchpassages",
                column: "ftptraid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fetchpassages");

            migrationBuilder.DropTable(
                name: "fetches");
        }
    }
}
