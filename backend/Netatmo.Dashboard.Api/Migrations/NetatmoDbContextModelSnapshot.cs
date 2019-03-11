﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Netatmo.Dashboard.Api;

namespace Netatmo.Dashboard.Api.Migrations
{
    [DbContext(typeof(NetatmoDbContext))]
    partial class NetatmoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Netatmo.Dashboard.Api.Models.DashboardData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DeviceId");

                    b.Property<DateTime>("TimeUtc");

                    b.Property<string>("type")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.ToTable("DashboardData");

                    b.HasDiscriminator<string>("type").HasValue("DashboardData");
                });

            modelBuilder.Entity("Netatmo.Dashboard.Api.Models.Device", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(17)
                        .IsUnicode(true);

                    b.Property<int>("Firmware");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(true);

                    b.Property<int>("StationId");

                    b.Property<string>("module_type")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("StationId");

                    b.ToTable("Devices");

                    b.HasDiscriminator<string>("module_type").HasValue("Device");
                });

            modelBuilder.Entity("Netatmo.Dashboard.Api.Models.Station", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(true);

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Stations");
                });

            modelBuilder.Entity("Netatmo.Dashboard.Api.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccessToken")
                        .HasMaxLength(64)
                        .IsUnicode(true);

                    b.Property<bool>("Enabled")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("ExpiresAt");

                    b.Property<string>("RefreshToken")
                        .HasMaxLength(64)
                        .IsUnicode(true);

                    b.Property<string>("Uid")
                        .IsRequired()
                        .HasMaxLength(64)
                        .IsUnicode(true);

                    b.Property<string>("UpdateJobId")
                        .HasMaxLength(100)
                        .IsUnicode(true);

                    b.HasKey("Id");

                    b.HasIndex("Uid")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Netatmo.Dashboard.Api.Models.IndoorDashboardData", b =>
                {
                    b.HasBaseType("Netatmo.Dashboard.Api.Models.DashboardData");

                    b.Property<int>("CO2");

                    b.Property<int>("Humidity");

                    b.HasDiscriminator().HasValue("NAModule4");
                });

            modelBuilder.Entity("Netatmo.Dashboard.Api.Models.MainDashboardData", b =>
                {
                    b.HasBaseType("Netatmo.Dashboard.Api.Models.DashboardData");

                    b.Property<int>("CO2")
                        .HasColumnName("MainDashboardData_CO2");

                    b.Property<int>("Humidity")
                        .HasColumnName("MainDashboardData_Humidity");

                    b.Property<int>("Noise");

                    b.HasDiscriminator().HasValue("NAMain");
                });

            modelBuilder.Entity("Netatmo.Dashboard.Api.Models.OutdoorDashboardData", b =>
                {
                    b.HasBaseType("Netatmo.Dashboard.Api.Models.DashboardData");

                    b.Property<int>("Humidity")
                        .HasColumnName("OutdoorDashboardData_Humidity");

                    b.HasDiscriminator().HasValue("NAModule1");
                });

            modelBuilder.Entity("Netatmo.Dashboard.Api.Models.RainGaugeDashboardData", b =>
                {
                    b.HasBaseType("Netatmo.Dashboard.Api.Models.DashboardData");

                    b.Property<decimal>("Rain");

                    b.Property<decimal>("Sum1H");

                    b.Property<decimal>("Sum24H");

                    b.HasDiscriminator().HasValue("NAModule3");
                });

            modelBuilder.Entity("Netatmo.Dashboard.Api.Models.WindGaugeDashboardData", b =>
                {
                    b.HasBaseType("Netatmo.Dashboard.Api.Models.DashboardData");

                    b.Property<int>("GustAngle");

                    b.Property<decimal>("GustStrength");

                    b.Property<int>("WindAngle");

                    b.Property<decimal>("WindStrength");

                    b.HasDiscriminator().HasValue("NAModule2");
                });

            modelBuilder.Entity("Netatmo.Dashboard.Api.Models.MainDevice", b =>
                {
                    b.HasBaseType("Netatmo.Dashboard.Api.Models.Device");

                    b.Property<int>("WifiStatus");

                    b.HasDiscriminator().HasValue("main");
                });

            modelBuilder.Entity("Netatmo.Dashboard.Api.Models.ModuleDevice", b =>
                {
                    b.HasBaseType("Netatmo.Dashboard.Api.Models.Device");

                    b.Property<int>("RfStatus");

                    b.Property<int>("Type");

                    b.HasDiscriminator().HasValue("module");
                });

            modelBuilder.Entity("Netatmo.Dashboard.Api.Models.DashboardData", b =>
                {
                    b.HasOne("Netatmo.Dashboard.Api.Models.Device", "Device")
                        .WithMany("DashboardData")
                        .HasForeignKey("DeviceId");
                });

            modelBuilder.Entity("Netatmo.Dashboard.Api.Models.Device", b =>
                {
                    b.HasOne("Netatmo.Dashboard.Api.Models.Station", "Station")
                        .WithMany("Devices")
                        .HasForeignKey("StationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Netatmo.Dashboard.Api.Models.Station", b =>
                {
                    b.HasOne("Netatmo.Dashboard.Api.Models.User", "User")
                        .WithMany("Stations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("Netatmo.Dashboard.Api.Models.Location", "Location", b1 =>
                        {
                            b1.Property<int>("StationId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<decimal>("Altitude");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(256)
                                .IsUnicode(true);

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasMaxLength(256)
                                .IsUnicode(true);

                            b1.Property<string>("StaticMap")
                                .HasMaxLength(1024)
                                .IsUnicode(true);

                            b1.Property<string>("Timezone")
                                .IsRequired()
                                .HasMaxLength(32)
                                .IsUnicode(true);

                            b1.HasKey("StationId");

                            b1.ToTable("Stations");

                            b1.HasOne("Netatmo.Dashboard.Api.Models.Station")
                                .WithOne("Location")
                                .HasForeignKey("Netatmo.Dashboard.Api.Models.Location", "StationId")
                                .OnDelete(DeleteBehavior.Cascade);

                            b1.OwnsOne("Netatmo.Dashboard.Api.Models.GeoPoint", "GeoLocation", b2 =>
                                {
                                    b2.Property<int>("LocationStationId")
                                        .ValueGeneratedOnAdd()
                                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                                    b2.Property<decimal>("Latitude");

                                    b2.Property<decimal>("Longitude");

                                    b2.HasKey("LocationStationId");

                                    b2.ToTable("Stations");

                                    b2.HasOne("Netatmo.Dashboard.Api.Models.Location")
                                        .WithOne("GeoLocation")
                                        .HasForeignKey("Netatmo.Dashboard.Api.Models.GeoPoint", "LocationStationId")
                                        .OnDelete(DeleteBehavior.Cascade);
                                });
                        });
                });

            modelBuilder.Entity("Netatmo.Dashboard.Api.Models.User", b =>
                {
                    b.OwnsOne("Netatmo.Dashboard.Api.Models.Units", "Units", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<int?>("FeelLike");

                            b1.Property<int?>("PressureUnit");

                            b1.Property<int?>("Unit");

                            b1.Property<int?>("WindUnit");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.HasOne("Netatmo.Dashboard.Api.Models.User")
                                .WithOne("Units")
                                .HasForeignKey("Netatmo.Dashboard.Api.Models.Units", "UserId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Netatmo.Dashboard.Api.Models.IndoorDashboardData", b =>
                {
                    b.OwnsOne("Netatmo.Dashboard.Api.Models.TemperatureData", "Temperature", b1 =>
                        {
                            b1.Property<int>("IndoorDashboardDataId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<decimal>("Current");

                            b1.Property<int>("Trend");

                            b1.HasKey("IndoorDashboardDataId");

                            b1.ToTable("DashboardData");

                            b1.HasOne("Netatmo.Dashboard.Api.Models.IndoorDashboardData")
                                .WithOne("Temperature")
                                .HasForeignKey("Netatmo.Dashboard.Api.Models.TemperatureData", "IndoorDashboardDataId")
                                .OnDelete(DeleteBehavior.Cascade);

                            b1.OwnsOne("Netatmo.Dashboard.Api.Models.TemperatureMinMax", "Max", b2 =>
                                {
                                    b2.Property<int>("TemperatureDataIndoorDashboardDataId")
                                        .ValueGeneratedOnAdd()
                                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                                    b2.Property<DateTime>("Timestamp");

                                    b2.Property<decimal>("Value");

                                    b2.HasKey("TemperatureDataIndoorDashboardDataId");

                                    b2.ToTable("DashboardData");

                                    b2.HasOne("Netatmo.Dashboard.Api.Models.TemperatureData")
                                        .WithOne("Max")
                                        .HasForeignKey("Netatmo.Dashboard.Api.Models.TemperatureMinMax", "TemperatureDataIndoorDashboardDataId")
                                        .OnDelete(DeleteBehavior.Cascade);
                                });

                            b1.OwnsOne("Netatmo.Dashboard.Api.Models.TemperatureMinMax", "Min", b2 =>
                                {
                                    b2.Property<int>("TemperatureDataIndoorDashboardDataId")
                                        .ValueGeneratedOnAdd()
                                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                                    b2.Property<DateTime>("Timestamp");

                                    b2.Property<decimal>("Value");

                                    b2.HasKey("TemperatureDataIndoorDashboardDataId");

                                    b2.ToTable("DashboardData");

                                    b2.HasOne("Netatmo.Dashboard.Api.Models.TemperatureData")
                                        .WithOne("Min")
                                        .HasForeignKey("Netatmo.Dashboard.Api.Models.TemperatureMinMax", "TemperatureDataIndoorDashboardDataId")
                                        .OnDelete(DeleteBehavior.Cascade);
                                });
                        });
                });

            modelBuilder.Entity("Netatmo.Dashboard.Api.Models.MainDashboardData", b =>
                {
                    b.OwnsOne("Netatmo.Dashboard.Api.Models.PressureData", "Pressure", b1 =>
                        {
                            b1.Property<int>("MainDashboardDataId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<decimal>("Absolute");

                            b1.Property<int>("Trend");

                            b1.Property<decimal>("Value");

                            b1.HasKey("MainDashboardDataId");

                            b1.ToTable("DashboardData");

                            b1.HasOne("Netatmo.Dashboard.Api.Models.MainDashboardData")
                                .WithOne("Pressure")
                                .HasForeignKey("Netatmo.Dashboard.Api.Models.PressureData", "MainDashboardDataId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Netatmo.Dashboard.Api.Models.TemperatureData", "Temperature", b1 =>
                        {
                            b1.Property<int>("MainDashboardDataId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<decimal>("Current")
                                .HasColumnName("TemperatureData_Temperature_Current");

                            b1.Property<int>("Trend")
                                .HasColumnName("TemperatureData_Temperature_Trend");

                            b1.HasKey("MainDashboardDataId");

                            b1.ToTable("DashboardData");

                            b1.HasOne("Netatmo.Dashboard.Api.Models.MainDashboardData")
                                .WithOne("Temperature")
                                .HasForeignKey("Netatmo.Dashboard.Api.Models.TemperatureData", "MainDashboardDataId")
                                .OnDelete(DeleteBehavior.Cascade);

                            b1.OwnsOne("Netatmo.Dashboard.Api.Models.TemperatureMinMax", "Max", b2 =>
                                {
                                    b2.Property<int>("TemperatureDataMainDashboardDataId")
                                        .ValueGeneratedOnAdd()
                                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                                    b2.Property<DateTime>("Timestamp")
                                        .HasColumnName("TemperatureMinMax_Temperature_Max_Timestamp");

                                    b2.Property<decimal>("Value")
                                        .HasColumnName("TemperatureMinMax_Temperature_Max_Value");

                                    b2.HasKey("TemperatureDataMainDashboardDataId");

                                    b2.ToTable("DashboardData");

                                    b2.HasOne("Netatmo.Dashboard.Api.Models.TemperatureData")
                                        .WithOne("Max")
                                        .HasForeignKey("Netatmo.Dashboard.Api.Models.TemperatureMinMax", "TemperatureDataMainDashboardDataId")
                                        .OnDelete(DeleteBehavior.Cascade);
                                });

                            b1.OwnsOne("Netatmo.Dashboard.Api.Models.TemperatureMinMax", "Min", b2 =>
                                {
                                    b2.Property<int>("TemperatureDataMainDashboardDataId")
                                        .ValueGeneratedOnAdd()
                                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                                    b2.Property<DateTime>("Timestamp")
                                        .HasColumnName("TemperatureMinMax_Temperature_Min_Timestamp");

                                    b2.Property<decimal>("Value")
                                        .HasColumnName("TemperatureMinMax_Temperature_Min_Value");

                                    b2.HasKey("TemperatureDataMainDashboardDataId");

                                    b2.ToTable("DashboardData");

                                    b2.HasOne("Netatmo.Dashboard.Api.Models.TemperatureData")
                                        .WithOne("Min")
                                        .HasForeignKey("Netatmo.Dashboard.Api.Models.TemperatureMinMax", "TemperatureDataMainDashboardDataId")
                                        .OnDelete(DeleteBehavior.Cascade);
                                });
                        });
                });

            modelBuilder.Entity("Netatmo.Dashboard.Api.Models.OutdoorDashboardData", b =>
                {
                    b.OwnsOne("Netatmo.Dashboard.Api.Models.TemperatureData", "Temperature", b1 =>
                        {
                            b1.Property<int>("OutdoorDashboardDataId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<decimal>("Current")
                                .HasColumnName("TemperatureData_Temperature_Current1");

                            b1.Property<int>("Trend")
                                .HasColumnName("TemperatureData_Temperature_Trend1");

                            b1.HasKey("OutdoorDashboardDataId");

                            b1.ToTable("DashboardData");

                            b1.HasOne("Netatmo.Dashboard.Api.Models.OutdoorDashboardData")
                                .WithOne("Temperature")
                                .HasForeignKey("Netatmo.Dashboard.Api.Models.TemperatureData", "OutdoorDashboardDataId")
                                .OnDelete(DeleteBehavior.Cascade);

                            b1.OwnsOne("Netatmo.Dashboard.Api.Models.TemperatureMinMax", "Max", b2 =>
                                {
                                    b2.Property<int>("TemperatureDataOutdoorDashboardDataId")
                                        .ValueGeneratedOnAdd()
                                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                                    b2.Property<DateTime>("Timestamp")
                                        .HasColumnName("TemperatureMinMax_Temperature_Max_Timestamp1");

                                    b2.Property<decimal>("Value")
                                        .HasColumnName("TemperatureMinMax_Temperature_Max_Value1");

                                    b2.HasKey("TemperatureDataOutdoorDashboardDataId");

                                    b2.ToTable("DashboardData");

                                    b2.HasOne("Netatmo.Dashboard.Api.Models.TemperatureData")
                                        .WithOne("Max")
                                        .HasForeignKey("Netatmo.Dashboard.Api.Models.TemperatureMinMax", "TemperatureDataOutdoorDashboardDataId")
                                        .OnDelete(DeleteBehavior.Cascade);
                                });

                            b1.OwnsOne("Netatmo.Dashboard.Api.Models.TemperatureMinMax", "Min", b2 =>
                                {
                                    b2.Property<int>("TemperatureDataOutdoorDashboardDataId")
                                        .ValueGeneratedOnAdd()
                                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                                    b2.Property<DateTime>("Timestamp")
                                        .HasColumnName("TemperatureMinMax_Temperature_Min_Timestamp1");

                                    b2.Property<decimal>("Value")
                                        .HasColumnName("TemperatureMinMax_Temperature_Min_Value1");

                                    b2.HasKey("TemperatureDataOutdoorDashboardDataId");

                                    b2.ToTable("DashboardData");

                                    b2.HasOne("Netatmo.Dashboard.Api.Models.TemperatureData")
                                        .WithOne("Min")
                                        .HasForeignKey("Netatmo.Dashboard.Api.Models.TemperatureMinMax", "TemperatureDataOutdoorDashboardDataId")
                                        .OnDelete(DeleteBehavior.Cascade);
                                });
                        });
                });

            modelBuilder.Entity("Netatmo.Dashboard.Api.Models.ModuleDevice", b =>
                {
                    b.OwnsOne("Netatmo.Dashboard.Api.Models.Battery", "Battery", b1 =>
                        {
                            b1.Property<string>("ModuleDeviceId");

                            b1.Property<decimal>("Percent");

                            b1.Property<int>("Vp");

                            b1.HasKey("ModuleDeviceId");

                            b1.ToTable("Devices");

                            b1.HasOne("Netatmo.Dashboard.Api.Models.ModuleDevice")
                                .WithOne("Battery")
                                .HasForeignKey("Netatmo.Dashboard.Api.Models.Battery", "ModuleDeviceId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
