using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pariplay_Eval.Migrations
{
    /// <inheritdoc />
    public partial class LeagueNamesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LeagueName",
                table: "Matches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LeagueName",
                table: "Matches");
        }
    }
}
