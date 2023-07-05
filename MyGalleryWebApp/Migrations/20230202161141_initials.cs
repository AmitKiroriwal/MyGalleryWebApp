using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyGalleryWebApp.Migrations
{
    /// <inheritdoc />
    public partial class initials : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "galleryCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoverImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_galleryCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "galleries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Categoryname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_galleries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_galleries_galleryCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "galleryCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "galleryCategories",
                columns: new[] { "Id", "CoverImage", "Name" },
                values: new object[,]
                {
                    { 1, "user.png", "Flower" },
                    { 2, "user.png", "Nature" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_galleries_CategoryId",
                table: "galleries",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "galleries");

            migrationBuilder.DropTable(
                name: "galleryCategories");
        }
    }
}
