using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pet_hotel_7._0.Migrations
{
    /// <inheritdoc />
    public partial class changeTableId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "PetOwners",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "PetOwners",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PetOwners",
                newName: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "PetOwners",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "PetOwners",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "PetOwners",
                newName: "Id");
        }
    }
}
