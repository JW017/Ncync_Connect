using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NCL.Migrations
{
    /// <inheritdoc />
    public partial class New_Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Document__ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Document__Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Document__Path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Document__ID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Employee__ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Employee__Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Employee__VideoProgress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Employee__ID);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Image__ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image__Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image__Desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image__Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageTagImageTag__ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Image__ID);
                });

            migrationBuilder.CreateTable(
                name: "ImageTags",
                columns: table => new
                {
                    ImageTag__ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageTag__Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageTags", x => x.ImageTag__ID);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Location__ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location__Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Location__ID);
                });

            migrationBuilder.CreateTable(
                name: "VideoProgress",
                columns: table => new
                {
                    VideoProgress__ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoProgress__Progress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoProgress__Complete = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeEmployee__ID = table.Column<int>(type: "int", nullable: false),
                    VideoVideo__ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoProgress", x => x.VideoProgress__ID);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Video__ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Video__Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Video__Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoTypeVideoType__ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Video__ID);
                });

            migrationBuilder.CreateTable(
                name: "VideoTypes",
                columns: table => new
                {
                    VideoType__ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoType__Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoTypes", x => x.VideoType__ID);
                });

            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    Guest__ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guest__Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guest__Contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guest__DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LocationLocation__ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.Guest__ID);
                    table.ForeignKey(
                        name: "FK_Guests_Locations_LocationLocation__ID",
                        column: x => x.LocationLocation__ID,
                        principalTable: "Locations",
                        principalColumn: "Location__ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Guests_LocationLocation__ID",
                table: "Guests",
                column: "LocationLocation__ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "ImageTags");

            migrationBuilder.DropTable(
                name: "VideoProgress");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "VideoTypes");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
