using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Management_Schedule_BE.Migrations
{
    /// <inheritdoc />
    public partial class configUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prerequisites",
                table: "Courses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Prerequisites",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
