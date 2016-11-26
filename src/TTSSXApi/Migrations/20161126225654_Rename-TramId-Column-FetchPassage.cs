using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TTSSXApi.Migrations
{
    public partial class RenameTramIdColumnFetchPassage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ftptraid",
                table: "fetchpassages",
                newName: "ftptheirtraid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ftptheirtraid",
                table: "fetchpassages",
                newName: "ftptraid");
        }
    }
}
