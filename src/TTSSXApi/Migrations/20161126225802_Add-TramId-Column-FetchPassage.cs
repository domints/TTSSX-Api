using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TTSSXApi.Migrations
{
    public partial class AddTramIdColumnFetchPassage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ftptraid",
                table: "fetchpassages",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_fetchpassages_ftptraid",
                table: "fetchpassages",
                column: "ftptraid");

            migrationBuilder.AddForeignKey(
                name: "FK_fetchpassages_trams_ftptraid",
                table: "fetchpassages",
                column: "ftptraid",
                principalTable: "trams",
                principalColumn: "traid",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fetchpassages_trams_ftptraid",
                table: "fetchpassages");

            migrationBuilder.DropIndex(
                name: "IX_fetchpassages_ftptraid",
                table: "fetchpassages");

            migrationBuilder.DropColumn(
                name: "ftptraid",
                table: "fetchpassages");
        }
    }
}
