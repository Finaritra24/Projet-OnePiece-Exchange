using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnePiece.Migrations
{
    /// <inheritdoc />
    public partial class addcolumnpassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pirates_Teams_TeamID",
                table: "Pirates");

            migrationBuilder.DropForeignKey(
                name: "FK_Proposals_Pirates_ProposingPirateID",
                table: "Proposals");

            migrationBuilder.DropForeignKey(
                name: "FK_Proposals_Pirates_RequestingPirateID",
                table: "Proposals");

            migrationBuilder.DropForeignKey(
                name: "FK_Proposals_Treasures_ProposedTreasureID",
                table: "Proposals");

            migrationBuilder.DropForeignKey(
                name: "FK_Treasures_Category_CategoryID",
                table: "Treasures");

            migrationBuilder.DropForeignKey(
                name: "FK_Treasures_Pirates_PirateID",
                table: "Treasures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Treasures",
                table: "Treasures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teams",
                table: "Teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Proposals",
                table: "Proposals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pirates",
                table: "Pirates");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "category");

            migrationBuilder.RenameTable(
                name: "Treasures",
                newName: "treasure");

            migrationBuilder.RenameTable(
                name: "Teams",
                newName: "team");

            migrationBuilder.RenameTable(
                name: "Proposals",
                newName: "proposal");

            migrationBuilder.RenameTable(
                name: "Pirates",
                newName: "pirate");

            migrationBuilder.RenameIndex(
                name: "IX_Treasures_PirateID",
                table: "treasure",
                newName: "IX_treasure_PirateID");

            migrationBuilder.RenameIndex(
                name: "IX_Treasures_CategoryID",
                table: "treasure",
                newName: "IX_treasure_CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Proposals_RequestingPirateID",
                table: "proposal",
                newName: "IX_proposal_RequestingPirateID");

            migrationBuilder.RenameIndex(
                name: "IX_Proposals_ProposingPirateID",
                table: "proposal",
                newName: "IX_proposal_ProposingPirateID");

            migrationBuilder.RenameIndex(
                name: "IX_Proposals_ProposedTreasureID",
                table: "proposal",
                newName: "IX_proposal_ProposedTreasureID");

            migrationBuilder.RenameIndex(
                name: "IX_Pirates_TeamID",
                table: "pirate",
                newName: "IX_pirate_TeamID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_category",
                table: "category",
                column: "CategoryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_treasure",
                table: "treasure",
                column: "TreasureID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_team",
                table: "team",
                column: "TeamID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_proposal",
                table: "proposal",
                column: "ProposalID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pirate",
                table: "pirate",
                column: "PirateID");

            migrationBuilder.AddForeignKey(
                name: "FK_pirate_team_TeamID",
                table: "pirate",
                column: "TeamID",
                principalTable: "team",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_proposal_pirate_ProposingPirateID",
                table: "proposal",
                column: "ProposingPirateID",
                principalTable: "pirate",
                principalColumn: "PirateID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_proposal_pirate_RequestingPirateID",
                table: "proposal",
                column: "RequestingPirateID",
                principalTable: "pirate",
                principalColumn: "PirateID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_proposal_treasure_ProposedTreasureID",
                table: "proposal",
                column: "ProposedTreasureID",
                principalTable: "treasure",
                principalColumn: "TreasureID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_treasure_category_CategoryID",
                table: "treasure",
                column: "CategoryID",
                principalTable: "category",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_treasure_pirate_PirateID",
                table: "treasure",
                column: "PirateID",
                principalTable: "pirate",
                principalColumn: "PirateID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pirate_team_TeamID",
                table: "pirate");

            migrationBuilder.DropForeignKey(
                name: "FK_proposal_pirate_ProposingPirateID",
                table: "proposal");

            migrationBuilder.DropForeignKey(
                name: "FK_proposal_pirate_RequestingPirateID",
                table: "proposal");

            migrationBuilder.DropForeignKey(
                name: "FK_proposal_treasure_ProposedTreasureID",
                table: "proposal");

            migrationBuilder.DropForeignKey(
                name: "FK_treasure_category_CategoryID",
                table: "treasure");

            migrationBuilder.DropForeignKey(
                name: "FK_treasure_pirate_PirateID",
                table: "treasure");

            migrationBuilder.DropPrimaryKey(
                name: "PK_category",
                table: "category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_treasure",
                table: "treasure");

            migrationBuilder.DropPrimaryKey(
                name: "PK_team",
                table: "team");

            migrationBuilder.DropPrimaryKey(
                name: "PK_proposal",
                table: "proposal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pirate",
                table: "pirate");

            migrationBuilder.RenameTable(
                name: "category",
                newName: "Category");

            migrationBuilder.RenameTable(
                name: "treasure",
                newName: "Treasures");

            migrationBuilder.RenameTable(
                name: "team",
                newName: "Teams");

            migrationBuilder.RenameTable(
                name: "proposal",
                newName: "Proposals");

            migrationBuilder.RenameTable(
                name: "pirate",
                newName: "Pirates");

            migrationBuilder.RenameIndex(
                name: "IX_treasure_PirateID",
                table: "Treasures",
                newName: "IX_Treasures_PirateID");

            migrationBuilder.RenameIndex(
                name: "IX_treasure_CategoryID",
                table: "Treasures",
                newName: "IX_Treasures_CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_proposal_RequestingPirateID",
                table: "Proposals",
                newName: "IX_Proposals_RequestingPirateID");

            migrationBuilder.RenameIndex(
                name: "IX_proposal_ProposingPirateID",
                table: "Proposals",
                newName: "IX_Proposals_ProposingPirateID");

            migrationBuilder.RenameIndex(
                name: "IX_proposal_ProposedTreasureID",
                table: "Proposals",
                newName: "IX_Proposals_ProposedTreasureID");

            migrationBuilder.RenameIndex(
                name: "IX_pirate_TeamID",
                table: "Pirates",
                newName: "IX_Pirates_TeamID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "CategoryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Treasures",
                table: "Treasures",
                column: "TreasureID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teams",
                table: "Teams",
                column: "TeamID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Proposals",
                table: "Proposals",
                column: "ProposalID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pirates",
                table: "Pirates",
                column: "PirateID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pirates_Teams_TeamID",
                table: "Pirates",
                column: "TeamID",
                principalTable: "Teams",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Proposals_Pirates_ProposingPirateID",
                table: "Proposals",
                column: "ProposingPirateID",
                principalTable: "Pirates",
                principalColumn: "PirateID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Proposals_Pirates_RequestingPirateID",
                table: "Proposals",
                column: "RequestingPirateID",
                principalTable: "Pirates",
                principalColumn: "PirateID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Proposals_Treasures_ProposedTreasureID",
                table: "Proposals",
                column: "ProposedTreasureID",
                principalTable: "Treasures",
                principalColumn: "TreasureID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Treasures_Category_CategoryID",
                table: "Treasures",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Treasures_Pirates_PirateID",
                table: "Treasures",
                column: "PirateID",
                principalTable: "Pirates",
                principalColumn: "PirateID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
