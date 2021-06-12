﻿// <auto-generated />
using System;
using CultureEventsBot.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CultureEventsBot.Persistance.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210612111840_UpdateLLDBEvent")]
    partial class UpdateLLDBEvent
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("CultureEventsBot.Domain.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Age_Restriction")
                        .HasColumnType("text");

                    b.Property<string>("BodyText")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("Is_Free")
                        .HasColumnType("boolean");

                    b.Property<string>("Price")
                        .HasColumnType("text");

                    b.Property<string>("Short_Title")
                        .HasColumnType("text");

                    b.Property<string>("Site_Url")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("CultureEventsBot.Domain.Entities.ImageResponse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int?>("EventId")
                        .HasColumnType("integer");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("ImageResponse");
                });

            modelBuilder.Entity("CultureEventsBot.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<long>("ChatId")
                        .HasColumnType("bigint");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("boolean");

                    b.Property<int>("Language")
                        .HasColumnType("integer");

                    b.Property<string>("SecondName")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CultureEventsBot.Domain.Entities.Event", b =>
                {
                    b.HasOne("CultureEventsBot.Domain.Entities.User", null)
                        .WithMany("Favourites")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CultureEventsBot.Domain.Entities.ImageResponse", b =>
                {
                    b.HasOne("CultureEventsBot.Domain.Entities.Event", null)
                        .WithMany("Images")
                        .HasForeignKey("EventId");
                });

            modelBuilder.Entity("CultureEventsBot.Domain.Entities.Event", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("CultureEventsBot.Domain.Entities.User", b =>
                {
                    b.Navigation("Favourites");
                });
#pragma warning restore 612, 618
        }
    }
}
