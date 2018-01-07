using Microsoft.EntityFrameworkCore.Migrations;

namespace PerpetualShred.Migrations
{
    public partial class Thumbies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SourceList",
                table: "WebVid",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Thumbnail",
                table: "WebVid",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SourceList",
                table: "WebVid");

            migrationBuilder.DropColumn(
                name: "Thumbnail",
                table: "WebVid");
        }
    }
}
