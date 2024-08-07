using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NCL.Migrations
{
    /// <inheritdoc />
    public partial class Class : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sequence__No",
                table: "Events",
                newName: "Event__SequenceNo");

            migrationBuilder.RenameColumn(
                name: "File__Type",
                table: "Events",
                newName: "Event__FileType");

            migrationBuilder.RenameColumn(
                name: "File__Path",
                table: "Events",
                newName: "Event__FilePath");

            migrationBuilder.RenameColumn(
                name: "File__Description",
                table: "Events",
                newName: "Event__FileDescription");

            migrationBuilder.AddColumn<int>(
                name: "Class__SequenceNo",
                table: "Classes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Class__SequenceNo",
                table: "Classes");

            migrationBuilder.RenameColumn(
                name: "Event__SequenceNo",
                table: "Events",
                newName: "Sequence__No");

            migrationBuilder.RenameColumn(
                name: "Event__FileType",
                table: "Events",
                newName: "File__Type");

            migrationBuilder.RenameColumn(
                name: "Event__FilePath",
                table: "Events",
                newName: "File__Path");

            migrationBuilder.RenameColumn(
                name: "Event__FileDescription",
                table: "Events",
                newName: "File__Description");
        }
    }
}
