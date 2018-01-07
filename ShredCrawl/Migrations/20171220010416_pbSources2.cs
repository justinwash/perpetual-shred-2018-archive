using Microsoft.EntityFrameworkCore.Migrations;

namespace ShredCrawl.Migrations
{
    public partial class PbSources2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PinkBikeVideoSource");

            migrationBuilder.AddColumn<string>(
                name: "SourceList",
                table: "WebVid",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SourceList",
                table: "WebVid");

            migrationBuilder.CreateTable(
                name: "PinkBikeVideoSource",
                columns: table => new
                {
                    Id = table.Column<string>(),
                    Source = table.Column<string>(nullable: true),
                    WebVidId = table.Column<int>(nullable: true)
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
    }
}
