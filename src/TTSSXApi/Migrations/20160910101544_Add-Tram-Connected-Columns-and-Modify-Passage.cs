using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TTSSXApi.Migrations
{
    public partial class AddTramConnectedColumnsandModifyPassage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Passages",
                table: "Passages");

            migrationBuilder.CreateTable(
                name: "depos",
                columns: table => new
                {
                    depid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    depname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_depos", x => x.depid);
                });

            migrationBuilder.CreateTable(
                name: "tramtypes",
                columns: table => new
                {
                    ttyid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    ttylowfloor = table.Column<int>(nullable: false),
                    ttyname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tramtypes", x => x.ttyid);
                });

            migrationBuilder.CreateTable(
                name: "trams",
                columns: table => new
                {
                    traid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    tradepid = table.Column<int>(nullable: false),
                    trasideno = table.Column<string>(nullable: true),
                    tratheirid = table.Column<string>(nullable: true),
                    trattyid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trams", x => x.traid);
                    table.ForeignKey(
                        name: "FK_trams_depos_tradepid",
                        column: x => x.tradepid,
                        principalTable: "depos",
                        principalColumn: "depid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_trams_tramtypes_trattyid",
                        column: x => x.trattyid,
                        principalTable: "tramtypes",
                        principalColumn: "ttyid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddPrimaryKey(
                name: "PK_passages",
                table: "Passages",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_trams_tradepid",
                table: "trams",
                column: "tradepid");

            migrationBuilder.CreateIndex(
                name: "IX_trams_trattyid",
                table: "trams",
                column: "trattyid");

            migrationBuilder.RenameColumn(
                name: "submitTime",
                table: "Passages",
                newName: "passubmittime");

            migrationBuilder.RenameColumn(
                name: "VehicleId",
                table: "Passages",
                newName: "passvehicleid");

            migrationBuilder.RenameColumn(
                name: "TripId",
                table: "Passages",
                newName: "pastripid");

            migrationBuilder.RenameColumn(
                name: "TramNo",
                table: "Passages",
                newName: "pastramno");

            migrationBuilder.RenameColumn(
                name: "TheirId",
                table: "Passages",
                newName: "pastheirid");

            migrationBuilder.RenameColumn(
                name: "RouteId",
                table: "Passages",
                newName: "pasrouteid");

            migrationBuilder.RenameColumn(
                name: "PlannedTime",
                table: "Passages",
                newName: "pasplannedtime");

            migrationBuilder.RenameColumn(
                name: "Line",
                table: "Passages",
                newName: "pasline");

            migrationBuilder.RenameColumn(
                name: "Direction",
                table: "Passages",
                newName: "pasdirection");

            migrationBuilder.RenameColumn(
                name: "CompositionNo",
                table: "Passages",
                newName: "pascompositionno");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Passages",
                newName: "pasid");

            migrationBuilder.RenameTable(
                name: "Passages",
                newName: "passages");

            migrationBuilder.Sql("INSERT INTO depos (depname) VALUES ('Zajezdnia Podgórze'), ('Zajezdnia Nowa Huta');");
            migrationBuilder.Sql("INSERT INTO tramtypes (ttyname, ttylowfloor) VALUES ('105N/Na', 0), ('E1', 0), ('GT8S', 0), ('N8C/N8S', 0), ('405N-Kr', 1), ('EU8N', 1), ('NGT6', 2), ('NGT6-2', 2), ('NGT8', 2), ('2014N ''Krakowiak''', 2);");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_passages",
                table: "passages");

            migrationBuilder.DropTable(
                name: "trams");

            migrationBuilder.DropTable(
                name: "depos");

            migrationBuilder.DropTable(
                name: "tramtypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Passages",
                table: "passages",
                column: "pasid");

            migrationBuilder.RenameColumn(
                name: "passubmittime",
                table: "passages",
                newName: "submitTime");

            migrationBuilder.RenameColumn(
                name: "passvehicleid",
                table: "passages",
                newName: "VehicleId");

            migrationBuilder.RenameColumn(
                name: "pastripid",
                table: "passages",
                newName: "TripId");

            migrationBuilder.RenameColumn(
                name: "pastramno",
                table: "passages",
                newName: "TramNo");

            migrationBuilder.RenameColumn(
                name: "pastheirid",
                table: "passages",
                newName: "TheirId");

            migrationBuilder.RenameColumn(
                name: "pasrouteid",
                table: "passages",
                newName: "RouteId");

            migrationBuilder.RenameColumn(
                name: "pasplannedtime",
                table: "passages",
                newName: "PlannedTime");

            migrationBuilder.RenameColumn(
                name: "pasline",
                table: "passages",
                newName: "Line");

            migrationBuilder.RenameColumn(
                name: "pasdirection",
                table: "passages",
                newName: "Direction");

            migrationBuilder.RenameColumn(
                name: "pascompositionno",
                table: "passages",
                newName: "CompositionNo");

            migrationBuilder.RenameColumn(
                name: "pasid",
                table: "passages",
                newName: "Id");

            migrationBuilder.RenameTable(
                name: "passages",
                newName: "Passages");
        }
    }
}
