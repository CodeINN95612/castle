using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Castle.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    Identification = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Initials = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    Number = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Voters",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "bytea", maxLength: 32, nullable: false),
                    DateOfBirthBytes = table.Column<byte[]>(type: "bytea", maxLength: 32, nullable: false),
                    SignCodebytes = table.Column<byte[]>(type: "bytea", maxLength: 32, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ElectionEntries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdElection = table.Column<Guid>(type: "uuid", nullable: false),
                    IdCandidate = table.Column<Guid>(type: "uuid", nullable: false),
                    IdParty = table.Column<Guid>(type: "uuid", nullable: false),
                    IdRole = table.Column<Guid>(type: "uuid", nullable: false),
                    IdLocation = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectionEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ElectionEntries_Candidates_IdCandidate",
                        column: x => x.IdCandidate,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElectionEntries_Locations_IdLocation",
                        column: x => x.IdLocation,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElectionEntries_Parties_IdParty",
                        column: x => x.IdParty,
                        principalTable: "Parties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElectionEntries_Roles_IdRole",
                        column: x => x.IdRole,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Elections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", maxLength: 32, nullable: false),
                    IdWinnerResult = table.Column<Guid>(type: "uuid", nullable: true),
                    RoundCount = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rounds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdElection = table.Column<Guid>(type: "uuid", nullable: false),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    VoteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsClosed = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rounds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rounds_Elections_IdElection",
                        column: x => x.IdElection,
                        principalTable: "Elections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoundResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdRound = table.Column<Guid>(type: "uuid", nullable: false),
                    IdElectionEntry = table.Column<Guid>(type: "uuid", nullable: false),
                    Votes = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoundResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoundResults_ElectionEntries_IdElectionEntry",
                        column: x => x.IdElectionEntry,
                        principalTable: "ElectionEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoundResults_Rounds_IdRound",
                        column: x => x.IdRound,
                        principalTable: "Rounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Votes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdentificationVoter = table.Column<byte[]>(type: "bytea", nullable: false),
                    IdRound = table.Column<Guid>(type: "uuid", nullable: false),
                    IdElectionEntry = table.Column<Guid>(type: "uuid", nullable: false),
                    DateUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ElectionEntryId = table.Column<Guid>(type: "uuid", nullable: true),
                    RoundId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Votes_ElectionEntries_ElectionEntryId",
                        column: x => x.ElectionEntryId,
                        principalTable: "ElectionEntries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Votes_ElectionEntries_IdElectionEntry",
                        column: x => x.IdElectionEntry,
                        principalTable: "ElectionEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Votes_Rounds_IdRound",
                        column: x => x.IdRound,
                        principalTable: "Rounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Votes_Rounds_RoundId",
                        column: x => x.RoundId,
                        principalTable: "Rounds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Votes_Voters_IdentificationVoter",
                        column: x => x.IdentificationVoter,
                        principalTable: "Voters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ElectionEntries_IdCandidate",
                table: "ElectionEntries",
                column: "IdCandidate");

            migrationBuilder.CreateIndex(
                name: "IX_ElectionEntries_IdElection",
                table: "ElectionEntries",
                column: "IdElection");

            migrationBuilder.CreateIndex(
                name: "IX_ElectionEntries_IdLocation",
                table: "ElectionEntries",
                column: "IdLocation");

            migrationBuilder.CreateIndex(
                name: "IX_ElectionEntries_IdParty",
                table: "ElectionEntries",
                column: "IdParty");

            migrationBuilder.CreateIndex(
                name: "IX_ElectionEntries_IdRole",
                table: "ElectionEntries",
                column: "IdRole");

            migrationBuilder.CreateIndex(
                name: "IX_Elections_IdWinnerResult",
                table: "Elections",
                column: "IdWinnerResult",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parties_Initials",
                table: "Parties",
                column: "Initials",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoundResults_IdElectionEntry",
                table: "RoundResults",
                column: "IdElectionEntry");

            migrationBuilder.CreateIndex(
                name: "IX_RoundResults_IdRound",
                table: "RoundResults",
                column: "IdRound");

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_IdElection",
                table: "Rounds",
                column: "IdElection");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_ElectionEntryId",
                table: "Votes",
                column: "ElectionEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_IdElectionEntry",
                table: "Votes",
                column: "IdElectionEntry");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_IdRound",
                table: "Votes",
                column: "IdRound");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_IdentificationVoter",
                table: "Votes",
                column: "IdentificationVoter");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_RoundId",
                table: "Votes",
                column: "RoundId");

            migrationBuilder.AddForeignKey(
                name: "FK_ElectionEntries_Elections_IdElection",
                table: "ElectionEntries",
                column: "IdElection",
                principalTable: "Elections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Elections_RoundResults_IdWinnerResult",
                table: "Elections",
                column: "IdWinnerResult",
                principalTable: "RoundResults",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ElectionEntries_Candidates_IdCandidate",
                table: "ElectionEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_ElectionEntries_Elections_IdElection",
                table: "ElectionEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_Elections_IdElection",
                table: "Rounds");

            migrationBuilder.DropTable(
                name: "Votes");

            migrationBuilder.DropTable(
                name: "Voters");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "Elections");

            migrationBuilder.DropTable(
                name: "RoundResults");

            migrationBuilder.DropTable(
                name: "ElectionEntries");

            migrationBuilder.DropTable(
                name: "Rounds");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Parties");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
