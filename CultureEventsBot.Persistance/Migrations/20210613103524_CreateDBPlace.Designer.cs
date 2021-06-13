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
    [Migration("20210613103524_CreateDBPlace")]
    partial class CreateDBPlace
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("CultureEventsBot.Domain.Entities.Favourite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Site_Url")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Favourite");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Favourite");
                });

            modelBuilder.Entity("CultureEventsBot.Domain.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int?>("FilmId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("FilmId");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("CultureEventsBot.Domain.Entities.ImageResponse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int?>("FavouriteId")
                        .HasColumnType("integer");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("FavouriteId");

                    b.ToTable("ImageResponse");
                });

            modelBuilder.Entity("CultureEventsBot.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<long>("ChatId")
                        .HasColumnType("bigint");

                    b.Property<int>("CurrentEvent")
                        .HasColumnType("integer");

                    b.Property<int>("CurrentFilm")
                        .HasColumnType("integer");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsAdminWritingPost")
                        .HasColumnType("boolean");

                    b.Property<int>("Language")
                        .HasColumnType("integer");

                    b.Property<bool>("MayNotification")
                        .HasColumnType("boolean");

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
                    b.HasBaseType("CultureEventsBot.Domain.Entities.Favourite");

                    b.Property<string>("BodyText")
                        .HasColumnType("text");

                    b.Property<string[]>("Categories")
                        .HasColumnType("text[]");

                    b.Property<bool>("Is_Free")
                        .HasColumnType("boolean");

                    b.Property<string>("Price")
                        .HasColumnType("text");

                    b.Property<string>("Short_Title")
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("Event");
                });

            modelBuilder.Entity("CultureEventsBot.Domain.Entities.Film", b =>
                {
                    b.HasBaseType("CultureEventsBot.Domain.Entities.Favourite");

                    b.HasDiscriminator().HasValue("Film");
                });

            modelBuilder.Entity("CultureEventsBot.Domain.Entities.Place", b =>
                {
                    b.HasBaseType("CultureEventsBot.Domain.Entities.Favourite");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("Timetable")
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("Place");
                });

            modelBuilder.Entity("CultureEventsBot.Domain.Entities.Favourite", b =>
                {
                    b.HasOne("CultureEventsBot.Domain.Entities.User", null)
                        .WithMany("Favourites")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("CultureEventsBot.Domain.Entities.Genre", b =>
                {
                    b.HasOne("CultureEventsBot.Domain.Entities.Film", null)
                        .WithMany("Genres")
                        .HasForeignKey("FilmId");
                });

            modelBuilder.Entity("CultureEventsBot.Domain.Entities.ImageResponse", b =>
                {
                    b.HasOne("CultureEventsBot.Domain.Entities.Favourite", null)
                        .WithMany("Images")
                        .HasForeignKey("FavouriteId");
                });

            modelBuilder.Entity("CultureEventsBot.Domain.Entities.Favourite", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("CultureEventsBot.Domain.Entities.User", b =>
                {
                    b.Navigation("Favourites");
                });

            modelBuilder.Entity("CultureEventsBot.Domain.Entities.Film", b =>
                {
                    b.Navigation("Genres");
                });
#pragma warning restore 612, 618
        }
    }
}
