using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ShredCrawl.Migrations
{
    public partial class pbSources : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WebVid",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OriginTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlayerUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Synopsis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoService = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebVid", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PinkBikeVideoSource",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebVidId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PinkBikeVideoSource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PinkBikeVideoSource_WebVid_WebVidId",
                        column: x => x.WebVidId,
                        principalTable: "WebVid",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PinkBikeVideoSource_WebVidId",
                table: "PinkBikeVideoSource",
                column: "WebVidId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PinkBikeVideoSource");

            migrationBuilder.DropTable(
                name: "WebVid");
        }
    }
}
