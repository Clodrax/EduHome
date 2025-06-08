using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduHome.Migrations
{
    /// <inheritdoc />
    public partial class AddIsDeactiveColumnToSlidersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Sliders",
                newName: "Id");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeactive",
                table: "Sliders",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeactive",
                table: "Sliders");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Sliders",
                newName: "id");
        }
    }
}
