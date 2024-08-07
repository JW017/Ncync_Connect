using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NCL.Migrations
{
    /// <inheritdoc />
    public partial class Moment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Moments",
                columns: table => new
                {
                    Moment__ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Moment__Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Moment__Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Moment__DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Moment__FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Moment__Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeEmployee__ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moments", x => x.Moment__ID);
                    table.ForeignKey(
                        name: "FK_Moments_Employees_EmployeeEmployee__ID",
                        column: x => x.EmployeeEmployee__ID,
                        principalTable: "Employees",
                        principalColumn: "Employee__ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Moments_EmployeeEmployee__ID",
                table: "Moments",
                column: "EmployeeEmployee__ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Moments");
        }
    }
}
