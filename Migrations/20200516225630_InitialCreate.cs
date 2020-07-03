using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PeerSupport4.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Support",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Day = table.Column<DateTime>(nullable: false),
                    Hours = table.Column<float>(nullable: false),
                    TotalHours = table.Column<float>(nullable: false),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Support", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Support");
        }
    }
}
