using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TTSSXApi.Migrations
{
    public partial class dbinit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Passages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    CompositionNo = table.Column<string>(nullable: true),
                    Line = table.Column<string>(nullable: true),
                    PlannedTime = table.Column<string>(nullable: true),
                    TheirId = table.Column<string>(nullable: true),
                    TramNo = table.Column<string>(nullable: true),
                    VehicleId = table.Column<string>(nullable: true),
                    submitTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passages", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Passages");
        }
    }
}
