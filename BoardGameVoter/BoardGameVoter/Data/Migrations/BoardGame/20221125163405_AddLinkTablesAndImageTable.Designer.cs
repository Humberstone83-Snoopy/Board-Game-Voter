﻿// <auto-generated />
using System;
using BoardGameVoter.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BoardGameVoter.Data.Migrations.BoardGame
{
    [DbContext(typeof(BoardGameDBContext))]
    [Migration("20221125163405_AddLinkTablesAndImageTable")]
    partial class AddLinkTablesAndImageTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc.1.22426.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BoardGameVoter.Models.EntityModels.BoardGames.BoardGame", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("AgeRating")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BoardGameTypeID")
                        .HasColumnType("int");

                    b.Property<string>("Description_Long")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description_Short")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MaximumPlayTime")
                        .HasColumnType("int");

                    b.Property<int?>("MaximumPlayers")
                        .HasColumnType("int");

                    b.Property<int?>("MinimumPlayTime")
                        .HasColumnType("int");

                    b.Property<int>("MinimumPlayers")
                        .HasColumnType("int");

                    b.Property<string>("Publisher")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Rating")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Weight")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("BoardGameTypeID");

                    b.ToTable("BoardGames");
                });

            modelBuilder.Entity("BoardGameVoter.Models.EntityModels.BoardGames.BoardGameCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.ToTable("BoardGameCategories");
                });

            modelBuilder.Entity("BoardGameVoter.Models.EntityModels.BoardGames.BoardGameImage", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("BoardGameID")
                        .HasColumnType("int");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("BoardGameID");

                    b.ToTable("ImageData");
                });

            modelBuilder.Entity("BoardGameVoter.Models.EntityModels.BoardGames.BoardGameMechanism", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.ToTable("BoardGameMechanisms");
                });

            modelBuilder.Entity("BoardGameVoter.Models.EntityModels.BoardGames.BoardGameType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.ToTable("BoardGameTypes");
                });

            modelBuilder.Entity("BoardGameVoter.Models.EntityModels.BoardGames.BoardGame_BoardGameCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("BoardGameCategoryID")
                        .HasColumnType("int");

                    b.Property<int>("BoardGameID")
                        .HasColumnType("int");

                    b.Property<Guid>("UID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("BoardGameCategoryID");

                    b.HasIndex("BoardGameID");

                    b.ToTable("BoardGameCategoryData");
                });

            modelBuilder.Entity("BoardGameVoter.Models.EntityModels.BoardGames.BoardGame_BoardGameMechanism", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("BoardGameID")
                        .HasColumnType("int");

                    b.Property<int>("BoardGameMechanismID")
                        .HasColumnType("int");

                    b.Property<Guid>("UID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("BoardGameID");

                    b.HasIndex("BoardGameMechanismID");

                    b.ToTable("BoardGameMechanismData");
                });

            modelBuilder.Entity("BoardGameVoter.Models.EntityModels.BoardGames.BoardGame", b =>
                {
                    b.HasOne("BoardGameVoter.Models.EntityModels.BoardGames.BoardGameType", "BoardGameType")
                        .WithMany()
                        .HasForeignKey("BoardGameTypeID");

                    b.Navigation("BoardGameType");
                });

            modelBuilder.Entity("BoardGameVoter.Models.EntityModels.BoardGames.BoardGameImage", b =>
                {
                    b.HasOne("BoardGameVoter.Models.EntityModels.BoardGames.BoardGame", "BoardGame")
                        .WithMany()
                        .HasForeignKey("BoardGameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BoardGame");
                });

            modelBuilder.Entity("BoardGameVoter.Models.EntityModels.BoardGames.BoardGame_BoardGameCategory", b =>
                {
                    b.HasOne("BoardGameVoter.Models.EntityModels.BoardGames.BoardGameCategory", "BoardGameCategory")
                        .WithMany()
                        .HasForeignKey("BoardGameCategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BoardGameVoter.Models.EntityModels.BoardGames.BoardGame", "BoardGame")
                        .WithMany()
                        .HasForeignKey("BoardGameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BoardGame");

                    b.Navigation("BoardGameCategory");
                });

            modelBuilder.Entity("BoardGameVoter.Models.EntityModels.BoardGames.BoardGame_BoardGameMechanism", b =>
                {
                    b.HasOne("BoardGameVoter.Models.EntityModels.BoardGames.BoardGame", "BoardGame")
                        .WithMany()
                        .HasForeignKey("BoardGameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BoardGameVoter.Models.EntityModels.BoardGames.BoardGameMechanism", "BoardGameMechanism")
                        .WithMany()
                        .HasForeignKey("BoardGameMechanismID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BoardGame");

                    b.Navigation("BoardGameMechanism");
                });
#pragma warning restore 612, 618
        }
    }
}