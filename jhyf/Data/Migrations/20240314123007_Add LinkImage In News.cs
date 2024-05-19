using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jhyf.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddLinkImageInNews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LinkImage",
                table: "News",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkImage",
                table: "News");
        }
    }
}
