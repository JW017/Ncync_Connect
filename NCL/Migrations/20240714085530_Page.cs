using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NCL.Migrations
{
    /// <inheritdoc />
    public partial class Page : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    Page__ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Page__SequenceNo = table.Column<int>(type: "int", nullable: false),
                    Page__Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.Page__ID);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Class__ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Class__Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Class_Page__ID = table.Column<int>(type: "int", nullable: false),
                    Page__ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Class__ID);
                    table.ForeignKey(
                        name: "FK_Classes_Pages_Page__ID",
                        column: x => x.Page__ID,
                        principalTable: "Pages",
                        principalColumn: "Page__ID");
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Event__ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sequence__No = table.Column<int>(type: "int", nullable: false),
                    Event__Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Event__Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    File__Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    File__Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    File__Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Event_Class__ID = table.Column<int>(type: "int", nullable: false),
                    Event_Page__ID = table.Column<int>(type: "int", nullable: false),
                    Class__ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Event__ID);
                    table.ForeignKey(
                        name: "FK_Events_Classes_Class__ID",
                        column: x => x.Class__ID,
                        principalTable: "Classes",
                        principalColumn: "Class__ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_Page__ID",
                table: "Classes",
                column: "Page__ID");

            migrationBuilder.CreateIndex(
                name: "IX_Events_Class__ID",
                table: "Events",
                column: "Class__ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Pages");
        }
    }
}
