using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NCL.Migrations
{
    /// <inheritdoc />
    public partial class Video2 : Migration
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

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_VideoTypes_VideoTypeVideoType__ID",
                table: "Videos");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "VideoTypes");

            migrationBuilder.DropTable(
                name: "ImageTags");

            migrationBuilder.DropIndex(
                name: "IX_Videos_VideoTypeVideoType__ID",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "VideoTypeVideoType__ID",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "ViewBy",
                table: "Videos");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Pages_Page__ID",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Classes_Class__ID",
                table: "Events");

            migrationBuilder.AddColumn<int>(
                name: "VideoTypeVideoType__ID",
                table: "Videos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "ViewBy",
                table: "Videos",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
                name: "Images",
                columns: table => new
                {
                    Image__ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageTagImageTag__ID = table.Column<int>(type: "int", nullable: false),
                    Image__Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image__Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Image__ID);
                    table.ForeignKey(
                        name: "FK_Images_ImageTags_ImageTagImageTag__ID",
                        column: x => x.ImageTagImageTag__ID,
                        principalTable: "ImageTags",
                        principalColumn: "ImageTag__ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Videos_VideoTypeVideoType__ID",
                table: "Videos",
                column: "VideoTypeVideoType__ID");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ImageTagImageTag__ID",
                table: "Images",
                column: "ImageTagImageTag__ID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_VideoTypes_VideoTypeVideoType__ID",
                table: "Videos",
                column: "VideoTypeVideoType__ID",
                principalTable: "VideoTypes",
                principalColumn: "VideoType__ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
