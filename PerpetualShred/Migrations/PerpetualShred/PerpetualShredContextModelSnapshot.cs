﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using PerpetualShred.Models;
using System;

namespace PerpetualShred.Migrations.PerpetualShred
{
    [DbContext(typeof(PerpetualShredContext))]
    partial class PerpetualShredContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PerpetualShred.Models.WebVid", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("OriginTitle");

                    b.Property<string>("OriginUrl");

                    b.Property<string>("PlayerUrl");

                    b.Property<DateTime>("ReleaseDate");

                    b.Property<string>("SourceList");

                    b.Property<string>("Synopsis");

                    b.Property<string>("Thumbnail");

                    b.Property<string>("Title");

                    b.Property<string>("VideoService");

                    b.HasKey("Id");

                    b.ToTable("WebVid");
                });
#pragma warning restore 612, 618
        }
    }
}
