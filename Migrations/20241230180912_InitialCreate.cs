using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnePiece.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denomination = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamID);
                });

            migrationBuilder.CreateTable(
                name: "Pirates",
                columns: table => new
                {
                    PirateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denomination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeamID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pirates", x => x.PirateID);
                    table.ForeignKey(
                        name: "FK_Pirates_Teams_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Teams",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Treasures",
                columns: table => new
                {
                    TreasureID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denomination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PirateID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treasures", x => x.TreasureID);
                    table.ForeignKey(
                        name: "FK_Treasures_Pirates_PirateID",
                        column: x => x.PirateID,
                        principalTable: "Pirates",
                        principalColumn: "PirateID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proposals",
                columns: table => new
                {
                    ProposalID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProposedTreasureID = table.Column<int>(type: "int", nullable: false),
                    ProposingPirateID = table.Column<int>(type: "int", nullable: false),
                    RequestingPirateID = table.Column<int>(type: "int", nullable: false),
                    ProposedOfferAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    CounterOfferAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    Category = table.Column<int>(type: "int", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    DateProposal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateReplyProposal = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proposals", x => x.ProposalID);
                    table.ForeignKey(
                        name: "FK_Proposals_Pirates_ProposingPirateID",
                        column: x => x.ProposingPirateID,
                        principalTable: "Pirates",
                        principalColumn: "PirateID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Proposals_Pirates_RequestingPirateID",
                        column: x => x.RequestingPirateID,
                        principalTable: "Pirates",
                        principalColumn: "PirateID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Proposals_Treasures_ProposedTreasureID",
                        column: x => x.ProposedTreasureID,
                        principalTable: "Treasures",
                        principalColumn: "TreasureID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pirates_TeamID",
                table: "Pirates",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_ProposedTreasureID",
                table: "Proposals",
                column: "ProposedTreasureID");

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_ProposingPirateID",
                table: "Proposals",
                column: "ProposingPirateID");

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_RequestingPirateID",
                table: "Proposals",
                column: "RequestingPirateID");

            migrationBuilder.CreateIndex(
                name: "IX_Treasures_PirateID",
                table: "Treasures",
                column: "PirateID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Proposals");

            migrationBuilder.DropTable(
                name: "Treasures");

            migrationBuilder.DropTable(
                name: "Pirates");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
