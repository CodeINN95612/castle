using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Castle.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UniqueCandidateElectionEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ElectionEntries_IdElection",
                table: "ElectionEntries");

            migrationBuilder.CreateIndex(
                name: "IX_ElectionEntries_IdElection_IdCandidate",
                table: "ElectionEntries",
                columns: new[] { "IdElection", "IdCandidate" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ElectionEntries_IdElection_IdCandidate",
                table: "ElectionEntries");

            migrationBuilder.CreateIndex(
                name: "IX_ElectionEntries_IdElection",
                table: "ElectionEntries",
                column: "IdElection");
        }
    }
}
