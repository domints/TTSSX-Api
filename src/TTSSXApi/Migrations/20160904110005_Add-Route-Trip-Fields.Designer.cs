using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TTSSXApi.Models.Db;

namespace TTSSXApi.Migrations
{
    [DbContext(typeof(TtssxContext))]
    [Migration("20160904110005_Add-Route-Trip-Fields")]
    partial class AddRouteTripFields
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("TTSSXApi.Models.Db.Passage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompositionNo");

                    b.Property<string>("Line");

                    b.Property<string>("PlannedTime");

                    b.Property<string>("RouteId");

                    b.Property<string>("TheirId");

                    b.Property<string>("TramNo");

                    b.Property<string>("TripId");

                    b.Property<string>("VehicleId");

                    b.Property<DateTime>("submitTime");

                    b.HasKey("Id");

                    b.ToTable("Passages");
                });
        }
    }
}
