using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TTSSXApi.Migrations
{
    public partial class MidFixPassageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "passubmittime",
                table: "passages",
                newName: "submittime");

            migrationBuilder.RenameColumn(
                name: "passvehicleid",
                table: "passages",
                newName: "vehicleid");

            migrationBuilder.RenameColumn(
                name: "pastripid",
                table: "passages",
                newName: "tripid");

            migrationBuilder.RenameColumn(
                name: "pastramno",
                table: "passages",
                newName: "tramno");

            migrationBuilder.RenameColumn(
                name: "pastheirid",
                table: "passages",
                newName: "theirid");

            migrationBuilder.RenameColumn(
                name: "pasrouteid",
                table: "passages",
                newName: "routeid");

            migrationBuilder.RenameColumn(
                name: "pasplannedtime",
                table: "passages",
                newName: "plannedtime");

            migrationBuilder.RenameColumn(
                name: "pasline",
                table: "passages",
                newName: "line");

            migrationBuilder.RenameColumn(
                name: "pasdirection",
                table: "passages",
                newName: "direction");

            migrationBuilder.RenameColumn(
                name: "pascompositionno",
                table: "passages",
                newName: "compositionno");

            migrationBuilder.RenameColumn(
                name: "pasid",
                table: "passages",
                newName: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "submittime",
                table: "passages",
                newName: "passubmittime");

            migrationBuilder.RenameColumn(
                name: "vehicleid",
                table: "passages",
                newName: "passvehicleid");

            migrationBuilder.RenameColumn(
                name: "tripid",
                table: "passages",
                newName: "pastripid");

            migrationBuilder.RenameColumn(
                name: "tramno",
                table: "passages",
                newName: "pastramno");

            migrationBuilder.RenameColumn(
                name: "theirid",
                table: "passages",
                newName: "pastheirid");

            migrationBuilder.RenameColumn(
                name: "routeid",
                table: "passages",
                newName: "pasrouteid");

            migrationBuilder.RenameColumn(
                name: "plannedtime",
                table: "passages",
                newName: "pasplannedtime");

            migrationBuilder.RenameColumn(
                name: "line",
                table: "passages",
                newName: "pasline");

            migrationBuilder.RenameColumn(
                name: "direction",
                table: "passages",
                newName: "pasdirection");

            migrationBuilder.RenameColumn(
                name: "compositionno",
                table: "passages",
                newName: "pascompositionno");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "passages",
                newName: "pasid");
        }
    }
}
