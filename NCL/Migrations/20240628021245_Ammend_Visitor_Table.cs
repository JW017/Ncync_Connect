using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NCL.Migrations
{
    /// <inheritdoc />
    public partial class Ammend_Visitor_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Locations_LocationLocation__ID",
                table: "Videos");

            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropColumn(
                name: "Image__Desc",
                table: "Images");

            migrationBuilder.AlterColumn<string>(
                name: "Video__Name",
                table: "Videos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LocationLocation__ID",
                table: "Videos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location__Name",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    Visitor__ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Visitor__Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visitor__Contact = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.Visitor__ID);
                });

            migrationBuilder.CreateTable(
                name: "VisitorActivities",
                columns: table => new
                {
                    VisitorActivity__ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitorVisitor__ID = table.Column<int>(type: "int", nullable: false),
                    VisitorActivity__DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LocationLocation__ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitorActivities", x => x.VisitorActivity__ID);
                    table.ForeignKey(
                        name: "FK_VisitorActivities_Locations_LocationLocation__ID",
                        column: x => x.LocationLocation__ID,
                        principalTable: "Locations",
                        principalColumn: "Location__ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VisitorActivities_Visitors_VisitorVisitor__ID",
                        column: x => x.VisitorVisitor__ID,
                        principalTable: "Visitors",
                        principalColumn: "Visitor__ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VisitorActivities_LocationLocation__ID",
                table: "VisitorActivities",
                column: "LocationLocation__ID");

            migrationBuilder.CreateIndex(
                name: "IX_VisitorActivities_VisitorVisitor__ID",
                table: "VisitorActivities",
                column: "VisitorVisitor__ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Locations_LocationLocation__ID",
                table: "Videos",
                column: "LocationLocation__ID",
                principalTable: "Locations",
                principalColumn: "Location__ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Locations_LocationLocation__ID",
                table: "Videos");

            migrationBuilder.DropTable(
                name: "VisitorActivities");

            migrationBuilder.DropTable(
                name: "Visitors");

            migrationBuilder.AlterColumn<string>(
                name: "Video__Name",
                table: "Videos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "LocationLocation__ID",
                table: "Videos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Location__Name",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Image__Desc",
                table: "Images",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    Guest__ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationLocation__ID = table.Column<int>(type: "int", nullable: false),
                    Guest__Contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guest__DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Guest__Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Locations_LocationLocation__ID",
                table: "Videos",
                column: "LocationLocation__ID",
                principalTable: "Locations",
                principalColumn: "Location__ID");
        }
    }
}
