using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pet_hotel_7._0.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedPetCaseAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetOwners_PetOwnerId",
                table: "Pets");

            migrationBuilder.RenameColumn(
                name: "PetOwnerId",
                table: "Pets",
                newName: "petOwnerId");

            migrationBuilder.RenameColumn(
                name: "PetColor",
                table: "Pets",
                newName: "petColor");

            migrationBuilder.RenameColumn(
                name: "PetBreed",
                table: "Pets",
                newName: "petBreed");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Pets",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "CheckedInAt",
                table: "Pets",
                newName: "checkedInAt");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Pets",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_PetOwnerId",
                table: "Pets",
                newName: "IX_Pets_petOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_PetOwners_petOwnerId",
                table: "Pets",
                column: "petOwnerId",
                principalTable: "PetOwners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetOwners_petOwnerId",
                table: "Pets");

            migrationBuilder.RenameColumn(
                name: "petOwnerId",
                table: "Pets",
                newName: "PetOwnerId");

            migrationBuilder.RenameColumn(
                name: "petColor",
                table: "Pets",
                newName: "PetColor");

            migrationBuilder.RenameColumn(
                name: "petBreed",
                table: "Pets",
                newName: "PetBreed");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Pets",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "checkedInAt",
                table: "Pets",
                newName: "CheckedInAt");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Pets",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_petOwnerId",
                table: "Pets",
                newName: "IX_Pets_PetOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_PetOwners_PetOwnerId",
                table: "Pets",
                column: "PetOwnerId",
                principalTable: "PetOwners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
