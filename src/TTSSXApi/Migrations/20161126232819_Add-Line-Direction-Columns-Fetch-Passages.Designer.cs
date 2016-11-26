using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TTSSXApi.Models.Db;

namespace TTSSXApi.Migrations
{
    [DbContext(typeof(TtssxContext))]
    [Migration("20161126232819_Add-Line-Direction-Columns-Fetch-Passages")]
    partial class AddLineDirectionColumnsFetchPassages
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

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

            modelBuilder.Entity("TTSSXApi.Models.Db.Fetch", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("fetid");

                    b.Property<string>("Alerts")
                        .HasColumnName("fetalerts");

                    b.Property<int>("StopId")
                        .HasColumnName("fetstopid");

                    b.Property<DateTime>("Time")
                        .HasColumnName("fettime");

                    b.HasKey("ID");

                    b.ToTable("fetches");
                });

            modelBuilder.Entity("TTSSXApi.Models.Db.FetchPassage", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ftpid");

                    b.Property<TimeSpan?>("ActualTime")
                        .HasColumnName("ftpactual");

                    b.Property<string>("Direction")
                        .HasColumnName("ftpdirection");

                    b.Property<int>("FetchId")
                        .HasColumnName("ftpfetid");

                    b.Property<string>("LineNo")
                        .HasColumnName("ftpline");

                    b.Property<long>("PassageId")
                        .HasColumnName("ftppassageid");

                    b.Property<TimeSpan>("PlannedTime")
                        .HasColumnName("ftpplanned");

                    b.Property<int>("RelativeTime")
                        .HasColumnName("ftprelative");

                    b.Property<string>("TheirTramId")
                        .HasColumnName("ftptheirtraid");

                    b.Property<int?>("TramId")
                        .HasColumnName("ftptraid");

                    b.Property<long>("TripId")
                        .HasColumnName("ftptripid");

                    b.HasKey("ID");

                    b.HasIndex("FetchId");

                    b.HasIndex("TramId");

                    b.ToTable("fetchpassages");
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

                    b.Property<string>("ExtraInfo")
                        .HasColumnName("traextrainfo");

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

            modelBuilder.Entity("TTSSXApi.Models.Db.FetchPassage", b =>
                {
                    b.HasOne("TTSSXApi.Models.Db.Fetch", "Fetch")
                        .WithMany("FetchPassages")
                        .HasForeignKey("FetchId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TTSSXApi.Models.Db.Tram", "Tram")
                        .WithMany("FetchPassages")
                        .HasForeignKey("TramId");
                });

            modelBuilder.Entity("TTSSXApi.Models.Db.Tram", b =>
                {
                    b.HasOne("TTSSXApi.Models.Db.Depo", "Depo")
                        .WithMany("Trams")
                        .HasForeignKey("DepoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TTSSXApi.Models.Db.TramType", "TramType")
                        .WithMany("Trams")
                        .HasForeignKey("TramTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
