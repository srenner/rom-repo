﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RomRepo.console;

#nullable disable

namespace RomRepo.console.Migrations
{
    [DbContext(typeof(RomRepoContext))]
    [Migration("20240602131225_SettingsFields-20240602")]
    partial class SettingsFields20240602
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("RomRepo.console.Models.Core", b =>
                {
                    b.Property<int>("CoreID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FileExtensions")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsFavorite")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("SevenZipAsRom")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ZipAsRom")
                        .HasColumnType("INTEGER");

                    b.HasKey("CoreID");

                    b.HasIndex("Path")
                        .IsUnique();

                    b.ToTable("Core");
                });

            modelBuilder.Entity("RomRepo.console.Models.Rom", b =>
                {
                    b.Property<int>("RomID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CoreID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsFavorite")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsPatch")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ParentRomID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("StarRating")
                        .HasColumnType("INTEGER");

                    b.HasKey("RomID");

                    b.HasIndex("CoreID");

                    b.HasIndex("ParentRomID");

                    b.ToTable("Rom");
                });

            modelBuilder.Entity("RomRepo.console.Models.SystemSetting", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("DataType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsReadOnly")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsRequired")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Name");

                    b.ToTable("SystemSetting");
                });

            modelBuilder.Entity("RomRepo.console.Models.Rom", b =>
                {
                    b.HasOne("RomRepo.console.Models.Core", "Core")
                        .WithMany("Roms")
                        .HasForeignKey("CoreID");

                    b.HasOne("RomRepo.console.Models.Rom", "ParentRom")
                        .WithMany()
                        .HasForeignKey("ParentRomID");

                    b.Navigation("Core");

                    b.Navigation("ParentRom");
                });

            modelBuilder.Entity("RomRepo.console.Models.Core", b =>
                {
                    b.Navigation("Roms");
                });
#pragma warning restore 612, 618
        }
    }
}
