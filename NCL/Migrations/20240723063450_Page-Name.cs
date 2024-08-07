using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NCL.Migrations
{
    /// <inheritdoc />
    public partial class PageName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Pages_Page__ID",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Classes_Class__ID",
                table: "Events");

            migrationBuilder.AddColumn<string>(
                name: "Page__SecondName",
                table: "Pages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Event__FilePath",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Class__ID",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Page__ID",
                table: "Classes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Pages_Page__ID",
                table: "Classes",
                column: "Page__ID",
                principalTable: "Pages",
                principalColumn: "Page__ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Classes_Class__ID",
                table: "Events",
                column: "Class__ID",
                principalTable: "Classes",
                principalColumn: "Class__ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Pages_Page__ID",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Classes_Class__ID",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Page__SecondName",
                table: "Pages");

            migrationBuilder.AlterColumn<string>(
                name: "Event__FilePath",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Class__ID",
                table: "Events",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Page__ID",
                table: "Classes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Pages_Page__ID",
                table: "Classes",
                column: "Page__ID",
                principalTable: "Pages",
                principalColumn: "Page__ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Classes_Class__ID",
                table: "Events",
                column: "Class__ID",
                principalTable: "Classes",
                principalColumn: "Class__ID");
        }
    }
}
