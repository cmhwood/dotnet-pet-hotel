using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pet_hotel_7._0.Migrations
{
    /// <inheritdoc />
    public partial class ChangedPetbreed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "color",
                table: "Pets",
                newName: "PetColor");

            migrationBuilder.RenameColumn(
                name: "breed",
                table: "Pets",
                newName: "PetBreed");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PetColor",
                table: "Pets",
                newName: "color");

            migrationBuilder.RenameColumn(
                name: "PetBreed",
                table: "Pets",
                newName: "breed");
        }
    }
}
