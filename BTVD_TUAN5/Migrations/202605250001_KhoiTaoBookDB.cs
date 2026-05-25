using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTVD_TUAN5.Migrations
{
    public partial class KhoiTaoBookDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    TopicId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.TopicId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ImageFileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TopicId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "TopicId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "TopicId", "Name" },
                values: new object[,]
                {
                    { 1, "Cuộc sống" },
                    { 2, "Lập trình" },
                    { 3, "Sức khỏe" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Author", "ImageFileName", "Price", "Quantity", "Title", "TopicId" },
                values: new object[,]
                {
                    { 1, "Nguyễn A", "song-tich-cuc.jpg", 99000m, 5, "Sống tích cực", 1 },
                    { 2, "Trần B", "ky-nang-giao-tiep.jpg", 120000m, 3, "Kỹ năng giao tiếp", 1 },
                    { 3, "Lê C", "aspnet-core.jpg", 200000m, 6, "ASP.NET Core cơ bản", 2 },
                    { 4, "Phạm D", "csharp-nang-cao.jpg", 250000m, 4, "C# nâng cao", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_TopicId",
                table: "Books",
                column: "TopicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Topics");
        }
    }
}
