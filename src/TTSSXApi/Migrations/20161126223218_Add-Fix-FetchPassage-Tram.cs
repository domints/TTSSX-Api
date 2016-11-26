using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TTSSXApi.Migrations
{
    public partial class AddFixFetchPassageTram : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fetchpassages_trams_ftptraid",
                table: "fetchpassages");

            migrationBuilder.DropIndex(
                name: "IX_fetchpassages_ftptraid",
                table: "fetchpassages");

            migrationBuilder.AlterColumn<string>(
                name: "ftptraid",
                table: "fetchpassages",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ftptraid",
                table: "fetchpassages",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
