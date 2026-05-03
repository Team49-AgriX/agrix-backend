using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class fruitAndVegetableTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string[]>(
                name: "AgroecologicalZones",
                table: "Vegetables",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);

            migrationBuilder.AddColumn<string[]>(
                name: "CommonNames",
                table: "Vegetables",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Vegetables",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string[]>(
                name: "CulinaryUses",
                table: "Vegetables",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);

            migrationBuilder.AddColumn<string>(
                name: "EdiblePart",
                table: "Vegetables",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Family",
                table: "Vegetables",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Genus",
                table: "Vegetables",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HarvestSeason",
                table: "Vegetables",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsLeafy",
                table: "Vegetables",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "NutritionalInfo",
                table: "Vegetables",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OriginRegion",
                table: "Vegetables",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ScientificName",
                table: "Vegetables",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Vegetables",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string[]>(
                name: "AgroecologicalZones",
                table: "Fruits",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);

            migrationBuilder.AddColumn<string[]>(
                name: "CommonNames",
                table: "Fruits",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Fruits",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string[]>(
                name: "CulinaryUses",
                table: "Fruits",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);

            migrationBuilder.AddColumn<string>(
                name: "Family",
                table: "Fruits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Genus",
                table: "Fruits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HarvestSeason",
                table: "Fruits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "HasSeeds",
                table: "Fruits",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "NutritionalInfo",
                table: "Fruits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OriginRegion",
                table: "Fruits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ScientificName",
                table: "Fruits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TasteProfile",
                table: "Fruits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Fruits",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgroecologicalZones",
                table: "Vegetables");

            migrationBuilder.DropColumn(
                name: "CommonNames",
                table: "Vegetables");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Vegetables");

            migrationBuilder.DropColumn(
                name: "CulinaryUses",
                table: "Vegetables");

            migrationBuilder.DropColumn(
                name: "EdiblePart",
                table: "Vegetables");

            migrationBuilder.DropColumn(
                name: "Family",
                table: "Vegetables");

            migrationBuilder.DropColumn(
                name: "Genus",
                table: "Vegetables");

            migrationBuilder.DropColumn(
                name: "HarvestSeason",
                table: "Vegetables");

            migrationBuilder.DropColumn(
                name: "IsLeafy",
                table: "Vegetables");

            migrationBuilder.DropColumn(
                name: "NutritionalInfo",
                table: "Vegetables");

            migrationBuilder.DropColumn(
                name: "OriginRegion",
                table: "Vegetables");

            migrationBuilder.DropColumn(
                name: "ScientificName",
                table: "Vegetables");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Vegetables");

            migrationBuilder.DropColumn(
                name: "AgroecologicalZones",
                table: "Fruits");

            migrationBuilder.DropColumn(
                name: "CommonNames",
                table: "Fruits");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Fruits");

            migrationBuilder.DropColumn(
                name: "CulinaryUses",
                table: "Fruits");

            migrationBuilder.DropColumn(
                name: "Family",
                table: "Fruits");

            migrationBuilder.DropColumn(
                name: "Genus",
                table: "Fruits");

            migrationBuilder.DropColumn(
                name: "HarvestSeason",
                table: "Fruits");

            migrationBuilder.DropColumn(
                name: "HasSeeds",
                table: "Fruits");

            migrationBuilder.DropColumn(
                name: "NutritionalInfo",
                table: "Fruits");

            migrationBuilder.DropColumn(
                name: "OriginRegion",
                table: "Fruits");

            migrationBuilder.DropColumn(
                name: "ScientificName",
                table: "Fruits");

            migrationBuilder.DropColumn(
                name: "TasteProfile",
                table: "Fruits");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Fruits");
        }
    }
}
