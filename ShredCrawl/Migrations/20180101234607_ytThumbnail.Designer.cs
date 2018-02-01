﻿// <auto-generated />

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShredCrawl.Migrations
{
    [DbContext(typeof(PerpetualShredContext))]
    [Migration("20180101234607_ytThumbnail")]
    partial class YtThumbnail
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ShredCrawl.WebVid", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<string>("OriginTitle");

                    b.Property<string>("OriginUrl");

                    b.Property<string>("PlayerUrl");

                    b.Property<DateTime?>("ReleaseDate");

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
