using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TTSSXApi.Migrations
{
    public partial class AddLineDirectionColumnsFetchPassages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ftpdirection",
                table: "fetchpassages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ftpline",
                table: "fetchpassages",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ftpdirection",
                table: "fetchpassages");

            migrationBuilder.DropColumn(
                name: "ftpline",
                table: "fetchpassages");
        }
    }
}
