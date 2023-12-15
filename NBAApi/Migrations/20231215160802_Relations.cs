using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NBAApi.Migrations
{
    /// <inheritdoc />
    public partial class Relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Arenas_States_StateId",
                table: "Arenas");

            migrationBuilder.DropForeignKey(
                name: "FK_Arenas_Teams_TeamId",
                table: "Arenas");

            migrationBuilder.RenameColumn(
                name: "TeamId",
                table: "Arenas",
                newName: "ArenaTeamId");

            migrationBuilder.RenameColumn(
                name: "StateId",
                table: "Arenas",
                newName: "ArenaStateId");

            migrationBuilder.RenameIndex(
                name: "IX_Arenas_TeamId",
                table: "Arenas",
                newName: "IX_Arenas_ArenaTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Arenas_StateId",
                table: "Arenas",
                newName: "IX_Arenas_ArenaStateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Arenas_States_ArenaStateId",
                table: "Arenas",
                column: "ArenaStateId",
                principalTable: "States",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Arenas_Teams_ArenaTeamId",
                table: "Arenas",
                column: "ArenaTeamId",
                principalTable: "Teams",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Arenas_States_ArenaStateId",
                table: "Arenas");

            migrationBuilder.DropForeignKey(
                name: "FK_Arenas_Teams_ArenaTeamId",
                table: "Arenas");

            migrationBuilder.RenameColumn(
                name: "ArenaTeamId",
                table: "Arenas",
                newName: "TeamId");

            migrationBuilder.RenameColumn(
                name: "ArenaStateId",
                table: "Arenas",
                newName: "StateId");

            migrationBuilder.RenameIndex(
                name: "IX_Arenas_ArenaTeamId",
                table: "Arenas",
                newName: "IX_Arenas_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Arenas_ArenaStateId",
                table: "Arenas",
                newName: "IX_Arenas_StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Arenas_States_StateId",
                table: "Arenas",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Arenas_Teams_TeamId",
                table: "Arenas",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id");
        }
    }
}
