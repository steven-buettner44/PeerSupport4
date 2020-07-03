using Microsoft.EntityFrameworkCore.Migrations;

namespace PeerSupport4.Migrations
{
    public partial class once : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalHours",
                table: "Support");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "TotalHours",
                table: "Support",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
