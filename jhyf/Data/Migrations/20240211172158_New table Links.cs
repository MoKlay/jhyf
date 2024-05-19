using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jhyf.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewtableLinks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "data");

            migrationBuilder.CreateTable(
                name: "Links",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameFromLink = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Linki = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "data",
                table: "Links",
                columns: new[] { "Id", "Linki", "NameFromLink" },
                values: new object[] { 1, "www.youtube.com", "Мой YouTube канал" });

            //migrationBuilder.Sql(@"");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Links",
                schema: "data");
        }
    }
}
