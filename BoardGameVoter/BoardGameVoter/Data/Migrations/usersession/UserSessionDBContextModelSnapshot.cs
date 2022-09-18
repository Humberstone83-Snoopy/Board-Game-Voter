﻿// <auto-generated />
using System;
using BoardGameVoter.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BoardGameVoter.data.migrations.usersession
{
    [DbContext(typeof(UserSessionDBContext))]
    partial class UserSessionDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc.1.22426.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BoardGameVoter.Models.EntityModels.UserSession", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("LastInteraction")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SessionStartTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("UserSessions");
                });
#pragma warning restore 612, 618
        }
    }
}