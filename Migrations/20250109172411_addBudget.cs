using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnePiece.Migrations
{
    /// <inheritdoc />
    public partial class addBudget : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "treasure",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Budget",
                table: "pirate",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "treasure");

            migrationBuilder.DropColumn(
                name: "Budget",
                table: "pirate");
        }
    }
}
