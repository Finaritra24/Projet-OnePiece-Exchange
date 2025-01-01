using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnePiece.Migrations
{
    /// <inheritdoc />
    public partial class updatePirate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Treasures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denomination = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Treasures_CategoryID",
                table: "Treasures",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Treasures_Category_CategoryID",
                table: "Treasures",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Treasures_Category_CategoryID",
                table: "Treasures");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Treasures_CategoryID",
                table: "Treasures");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Treasures");
        }
    }
}
