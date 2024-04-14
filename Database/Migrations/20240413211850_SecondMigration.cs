using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Machines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GymId",
                table: "Machines",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Machines_CategoryId",
                table: "Machines",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Machines_GymId",
                table: "Machines",
                column: "GymId");

            migrationBuilder.AddForeignKey(
                name: "FK_Machines_Categories_CategoryId",
                table: "Machines",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Machines_Gyms_GymId",
                table: "Machines",
                column: "GymId",
                principalTable: "Gyms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Machines_Categories_CategoryId",
                table: "Machines");

            migrationBuilder.DropForeignKey(
                name: "FK_Machines_Gyms_GymId",
                table: "Machines");

            migrationBuilder.DropIndex(
                name: "IX_Machines_CategoryId",
                table: "Machines");

            migrationBuilder.DropIndex(
                name: "IX_Machines_GymId",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "GymId",
                table: "Machines");
        }
    }
}
