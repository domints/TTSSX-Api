using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TTSSXApi.Migrations
{
    public partial class AddRouteTripFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RouteId",
                table: "Passages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TripId",
                table: "Passages",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RouteId",
                table: "Passages");

            migrationBuilder.DropColumn(
                name: "TripId",
                table: "Passages");
        }
    }
}
