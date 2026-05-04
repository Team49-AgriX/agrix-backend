using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddedFavoriteScansForPlantAndDisease : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiseaseScanFavorites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    SavedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PlantScanId = table.Column<Guid>(type: "uuid", nullable: false),
                    PlantScanHistoryId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiseaseScanFavorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiseaseScanFavorites_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DiseaseScanFavorites_PlantScanHistories_PlantScanHistoryId",
                        column: x => x.PlantScanHistoryId,
                        principalTable: "PlantScanHistories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlantScanFavorites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    SavedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PlantScanId = table.Column<Guid>(type: "uuid", nullable: false),
                    PlantScanHistoryId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantScanFavorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlantScanFavorites_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlantScanFavorites_PlantScanHistories_PlantScanHistoryId",
                        column: x => x.PlantScanHistoryId,
                        principalTable: "PlantScanHistories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiseaseScanFavorites_PlantScanHistoryId",
                table: "DiseaseScanFavorites",
                column: "PlantScanHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DiseaseScanFavorites_UserId",
                table: "DiseaseScanFavorites",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantScanFavorites_PlantScanHistoryId",
                table: "PlantScanFavorites",
                column: "PlantScanHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantScanFavorites_UserId",
                table: "PlantScanFavorites",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiseaseScanFavorites");

            migrationBuilder.DropTable(
                name: "PlantScanFavorites");
        }
    }
}
