using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NCL.Migrations
{
    /// <inheritdoc />
    public partial class Ammend_ForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VideoProgress");

            migrationBuilder.DropColumn(
                name: "Employee__VideoProgress",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "VideoLocation__ID",
                table: "Videos",
                newName: "LocationLocation__ID");

            migrationBuilder.AddColumn<DateTime>(
                name: "Employee__Log",
                table: "Employees",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Videos_LocationLocation__ID",
                table: "Videos",
                column: "LocationLocation__ID");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_VideoTypeVideoType__ID",
                table: "Videos",
                column: "VideoTypeVideoType__ID");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ImageTagImageTag__ID",
                table: "Images",
                column: "ImageTagImageTag__ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_ImageTags_ImageTagImageTag__ID",
                table: "Images",
                column: "ImageTagImageTag__ID",
                principalTable: "ImageTags",
                principalColumn: "ImageTag__ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Locations_LocationLocation__ID",
                table: "Videos",
                column: "LocationLocation__ID",
                principalTable: "Locations",
                principalColumn: "Location__ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_VideoTypes_VideoTypeVideoType__ID",
                table: "Videos",
                column: "VideoTypeVideoType__ID",
                principalTable: "VideoTypes",
                principalColumn: "VideoType__ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_ImageTags_ImageTagImageTag__ID",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Locations_LocationLocation__ID",
                table: "Videos");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_VideoTypes_VideoTypeVideoType__ID",
                table: "Videos");

            migrationBuilder.DropIndex(
                name: "IX_Videos_LocationLocation__ID",
                table: "Videos");

            migrationBuilder.DropIndex(
                name: "IX_Videos_VideoTypeVideoType__ID",
                table: "Videos");

            migrationBuilder.DropIndex(
                name: "IX_Images_ImageTagImageTag__ID",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Employee__Log",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "LocationLocation__ID",
                table: "Videos",
                newName: "VideoLocation__ID");

            migrationBuilder.AddColumn<string>(
                name: "Employee__VideoProgress",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "VideoProgress",
                columns: table => new
                {
                    VideoProgress__ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeEmployee__ID = table.Column<int>(type: "int", nullable: false),
                    VideoProgress__Complete = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoProgress__Progress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoVideo__ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoProgress", x => x.VideoProgress__ID);
                });
        }
    }
}
