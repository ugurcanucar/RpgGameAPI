using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgGameAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedRelationShip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Class",
                table: "Characters",
                newName: "ClassId");

            migrationBuilder.AddColumn<int>(
                name: "MaxLevel",
                table: "Classes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ClassId",
                table: "Characters",
                column: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Classes_ClassId",
                table: "Characters",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Classes_ClassId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_ClassId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "MaxLevel",
                table: "Classes");

            migrationBuilder.RenameColumn(
                name: "ClassId",
                table: "Characters",
                newName: "Class");
        }
    }
}
