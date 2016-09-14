using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TTSSXApi.Models.Db;

namespace TTSSXApi.Migrations
{
    [DbContext(typeof(TtssxContext))]
    partial class TtssxContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("TTSSXApi.Models.Db.Depo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("depid");

                    b.Property<string>("Name")
                        .HasColumnName("depname");

                    b.HasKey("Id");

                    b.ToTable("depos");
                });

            modelBuilder.Entity("TTSSXApi.Models.Db.Passage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("CompositionNo")
                        .HasColumnName("compositionno");

                    b.Property<string>("Direction")
                        .HasColumnName("direction");

                    b.Property<string>("Line")
                        .HasColumnName("line");

                    b.Property<string>("PlannedTime")
                        .HasColumnName("plannedtime");

                    b.Property<string>("RouteId")
                        .HasColumnName("routeid");

                    b.Property<string>("TheirId")
                        .HasColumnName("theirid");

                    b.Property<string>("TramNo")
                        .HasColumnName("tramno");

                    b.Property<string>("TripId")
                        .HasColumnName("tripid");

                    b.Property<string>("VehicleId")
                        .HasColumnName("vehicleid");

                    b.Property<DateTime>("submitTime")
                        .HasColumnName("submittime");

                    b.HasKey("Id");

                    b.ToTable("passages");
                });

            modelBuilder.Entity("TTSSXApi.Models.Db.Tram", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("traid");

                    b.Property<int>("DepoId")
                        .HasColumnName("tradepid");

                    b.Property<string>("SideNo")
                        .HasColumnName("trasideno");

                    b.Property<string>("TheirId")
                        .HasColumnName("tratheirid");

                    b.Property<int>("TramTypeId")
                        .HasColumnName("trattyid");

                    b.HasKey("Id");

                    b.HasIndex("DepoId");

                    b.HasIndex("TramTypeId");

                    b.ToTable("trams");
                });

            modelBuilder.Entity("TTSSXApi.Models.Db.TramType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ttyid");

                    b.Property<int>("LowFloor")
                        .HasColumnName("ttylowfloor");

                    b.Property<string>("Name")
                        .HasColumnName("ttyname");

                    b.HasKey("Id");

                    b.ToTable("tramtypes");
                });

            modelBuilder.Entity("TTSSXApi.Models.Db.Tram", b =>
                {
                    b.HasOne("TTSSXApi.Models.Db.Depo", "Depo")
                        .WithMany()
                        .HasForeignKey("DepoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TTSSXApi.Models.Db.TramType", "TramType")
                        .WithMany()
                        .HasForeignKey("TramTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
