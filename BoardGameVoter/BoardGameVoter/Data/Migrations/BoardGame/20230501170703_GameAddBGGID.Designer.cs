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
    [Migration("20230501170703_GameAddBGGID")]
    partial class GameAddBGGID
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

                    b.Property<int>("BoardGameGeekID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
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

                    b.ToTable("BoardGames");
                });

            modelBuilder.Entity("BoardGameVoter.Models.EntityModels.BoardGames.BoardGameArtist", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("BoardGameGeekID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.ToTable("BoardGameArtists");
                });

            modelBuilder.Entity("BoardGameVoter.Models.EntityModels.BoardGames.BoardGameCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("BoardGameGeekID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.ToTable("BoardGameCategories");
                });

            modelBuilder.Entity("BoardGameVoter.Models.EntityModels.BoardGames.BoardGameDesigner", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("BoardGameGeekID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.ToTable("BoardGameDesigners");
                });

            modelBuilder.Entity("BoardGameVoter.Models.EntityModels.BoardGames.BoardGameFamily", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("BoardGameGeekID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.ToTable("BoardGameFamilies");
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

                    b.ToTable("BoardGameImages");
                });

            modelBuilder.Entity("BoardGameVoter.Models.EntityModels.BoardGames.BoardGameImplementation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("BoardGameGeekID")
                        .HasColumnType("int");

                    b.Property<int?>("BoardGameID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("BoardGameID");

                    b.ToTable("BoardGameImplementations");
                });

            modelBuilder.Entity("BoardGameVoter.Models.EntityModels.BoardGames.BoardGameMechanism", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("BoardGameGeekID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.ToTable("BoardGameMechanisms");
                });

            modelBuilder.Entity("BoardGameVoter.Models.EntityModels.BoardGames.BoardGamePublisher", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("BoardGameGeekID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.ToTable("BoardGamePublishers");
                });

            modelBuilder.Entity("BoardGameVoter.Models.EntityModels.BoardGames.BoardGame_BoardGameArtist", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("BoardGameArtistID")
                        .HasColumnType("int");

                    b.Property<int>("BoardGameID")
                        .HasColumnType("int");

                    b.Property<Guid>("UID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("BoardGameArtistID");

                    b.HasIndex("BoardGameID");

                    b.ToTable("BoardGame_BoardGameArtists");
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

                    b.ToTable("BoardGame_BoardGameCategories");
                });

            modelBuilder.Entity("BoardGameVoter.Models.EntityModels.BoardGames.BoardGame_BoardGameDesigner", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("BoardGameDesignerID")
                        .HasColumnType("int");

                    b.Property<int>("BoardGameID")
                        .HasColumnType("int");

                    b.Property<Guid>("UID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("BoardGameDesignerID");

                    b.HasIndex("BoardGameID");

                    b.ToTable("BoardGame_BoardGameDesigners");
                });

            modelBuilder.Entity("BoardGameVoter.Models.EntityModels.BoardGames.BoardGame_BoardGameFamily", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("BoardGameFamilyID")
                        .HasColumnType("int");

                    b.Property<int>("BoardGameID")
                        .HasColumnType("int");

                    b.Property<Guid>("UID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("BoardGameFamilyID");

                    b.HasIndex("BoardGameID");

                    b.ToTable("BoardGame_BoardGameFamilies");
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

                    b.ToTable("BoardGame_BoardGameMechanisms");
                });

            modelBuilder.Entity("BoardGameVoter.Models.EntityModels.BoardGames.BoardGame_BoardGamePublisher", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("BoardGameID")
                        .HasColumnType("int");

                    b.Property<int>("BoardGamePublisherID")
                        .HasColumnType("int");

                    b.Property<Guid>("UID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("BoardGameID");

                    b.HasIndex("BoardGamePublisherID");

                    b.ToTable("BoardGame_BoardGamePublishers");
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

            modelBuilder.Entity("BoardGameVoter.Models.EntityModels.BoardGames.BoardGameImplementation", b =>
                {
                    b.HasOne("BoardGameVoter.Models.EntityModels.BoardGames.BoardGame", null)
                        .WithMany("Implementations")
                        .HasForeignKey("BoardGameID");
                });

            modelBuilder.Entity("BoardGameVoter.Models.EntityModels.BoardGames.BoardGame_BoardGameArtist", b =>
                {
                    b.HasOne("BoardGameVoter.Models.EntityModels.BoardGames.BoardGameArtist", "BoardGameArtist")
                        .WithMany()
                        .HasForeignKey("BoardGameArtistID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BoardGameVoter.Models.EntityModels.BoardGames.BoardGame", "BoardGame")
                        .WithMany("Artists")
                        .HasForeignKey("BoardGameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BoardGame");

                    b.Navigation("BoardGameArtist");
                });

            modelBuilder.Entity("BoardGameVoter.Models.EntityModels.BoardGames.BoardGame_BoardGameCategory", b =>
                {
                    b.HasOne("BoardGameVoter.Models.EntityModels.BoardGames.BoardGameCategory", "BoardGameCategory")
                        .WithMany()
                        .HasForeignKey("BoardGameCategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BoardGameVoter.Models.EntityModels.BoardGames.BoardGame", "BoardGame")
                        .WithMany("Categories")
                        .HasForeignKey("BoardGameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BoardGame");

                    b.Navigation("BoardGameCategory");
                });

            modelBuilder.Entity("BoardGameVoter.Models.EntityModels.BoardGames.BoardGame_BoardGameDesigner", b =>
                {
                    b.HasOne("BoardGameVoter.Models.EntityModels.BoardGames.BoardGameDesigner", "BoardGameDesigner")
                        .WithMany()
                        .HasForeignKey("BoardGameDesignerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BoardGameVoter.Models.EntityModels.BoardGames.BoardGame", "BoardGame")
                        .WithMany("Designers")
                        .HasForeignKey("BoardGameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BoardGame");

                    b.Navigation("BoardGameDesigner");
                });

            modelBuilder.Entity("BoardGameVoter.Models.EntityModels.BoardGames.BoardGame_BoardGameFamily", b =>
                {
                    b.HasOne("BoardGameVoter.Models.EntityModels.BoardGames.BoardGameFamily", "BoardGameFamily")
                        .WithMany()
                        .HasForeignKey("BoardGameFamilyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BoardGameVoter.Models.EntityModels.BoardGames.BoardGame", "BoardGame")
                        .WithMany("Families")
                        .HasForeignKey("BoardGameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BoardGame");

                    b.Navigation("BoardGameFamily");
                });

            modelBuilder.Entity("BoardGameVoter.Models.EntityModels.BoardGames.BoardGame_BoardGameMechanism", b =>
                {
                    b.HasOne("BoardGameVoter.Models.EntityModels.BoardGames.BoardGame", "BoardGame")
                        .WithMany("Mechanisms")
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

            modelBuilder.Entity("BoardGameVoter.Models.EntityModels.BoardGames.BoardGame_BoardGamePublisher", b =>
                {
                    b.HasOne("BoardGameVoter.Models.EntityModels.BoardGames.BoardGame", "BoardGame")
                        .WithMany("Publishers")
                        .HasForeignKey("BoardGameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BoardGameVoter.Models.EntityModels.BoardGames.BoardGamePublisher", "BoardGamePublisher")
                        .WithMany()
                        .HasForeignKey("BoardGamePublisherID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BoardGame");

                    b.Navigation("BoardGamePublisher");
                });

            modelBuilder.Entity("BoardGameVoter.Models.EntityModels.BoardGames.BoardGame", b =>
                {
                    b.Navigation("Artists");

                    b.Navigation("Categories");

                    b.Navigation("Designers");

                    b.Navigation("Families");

                    b.Navigation("Implementations");

                    b.Navigation("Mechanisms");

                    b.Navigation("Publishers");
                });
#pragma warning restore 612, 618
        }
    }
}
