﻿// <auto-generated />
using System;
using GameDay;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GameDay.Migrations
{
    [DbContext(typeof(GameContext))]
    [Migration("20221014085311_v4")]
    partial class v4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("GameDay.Models.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("GameId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("GameDay.Models.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("UserDataUserId")
                        .HasColumnType("int");

                    b.HasKey("GroupId");

                    b.HasIndex("GameId");

                    b.HasIndex("UserDataUserId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("GameDay.Models.GroupAttendees", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<int?>("UserDataUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserDataUserId");

                    b.ToTable("GroupAttendees");
                });

            modelBuilder.Entity("GameDay.Models.UserData", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DiscordName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SteamName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("UserId");

                    b.ToTable("UserData");
                });

            modelBuilder.Entity("GameDay.Models.Group", b =>
                {
                    b.HasOne("GameDay.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameDay.Models.UserData", null)
                        .WithMany("UserGroupsOwned")
                        .HasForeignKey("UserDataUserId");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("GameDay.Models.GroupAttendees", b =>
                {
                    b.HasOne("GameDay.Models.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameDay.Models.UserData", null)
                        .WithMany("UserAttendeens")
                        .HasForeignKey("UserDataUserId");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("GameDay.Models.UserData", b =>
                {
                    b.Navigation("UserAttendeens");

                    b.Navigation("UserGroupsOwned");
                });
#pragma warning restore 612, 618
        }
    }
}
