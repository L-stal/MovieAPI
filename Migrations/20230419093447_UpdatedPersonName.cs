using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedPersonName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Persons",
                newName: "FirstName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Persons",
                newName: "Name");
        }
    }
}
