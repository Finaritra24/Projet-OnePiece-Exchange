using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnePiece.Migrations
{
    /// <inheritdoc />
    public partial class AddPasswordToPirate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Pirates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Pirates");
        }
    }
}
