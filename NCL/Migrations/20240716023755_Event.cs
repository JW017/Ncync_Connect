using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NCL.Migrations
{
    /// <inheritdoc />
    public partial class Event : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Event_Page__ID",
                table: "Events",
                newName: "Event__FileSequenceNo");

            migrationBuilder.AddColumn<bool>(
                name: "Event__Thumbnail",
                table: "Events",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Event__Thumbnail",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "Event__FileSequenceNo",
                table: "Events",
                newName: "Event_Page__ID");
        }
    }
}
