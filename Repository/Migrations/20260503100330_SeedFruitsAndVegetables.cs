using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class SeedFruitsAndVegetables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Fruits",
                columns: new[] { "Id", "AgroecologicalZones", "CommonNames", "CreatedAt", "CulinaryUses", "Description", "Family", "Genus", "HarvestSeason", "HasSeeds", "ImageUrl", "Name", "NutritionalInfo", "OriginRegion", "ScientificName", "TasteProfile", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new[] { "Temperate" }, new[] { "Apple", "Red Apple" }, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new[] { "Raw", "Juice", "Pie" }, "A sweet red fruit", "Rosaceae", "Malus", "Autumn", true, "https://upload.wikimedia.org/wikipedia/commons/1/15/Red_Apple.jpg", "Apple", "Rich in fiber and vitamin C", "Central Asia", "Malus domestica", "Sweet", null },
                    { 2, new[] { "Tropical" }, new[] { "Banana" }, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new[] { "Raw", "Smoothies", "Baking" }, "A tropical yellow fruit", "Musaceae", "Musa", "Year-round", false, "", "Banana", "Rich in potassium and vitamin B6", "Southeast Asia", "Musa acuminata", "Sweet", null },
                    { 3, new[] { "Temperate" }, new[] { "Strawberry" }, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new[] { "Raw", "Jam", "Desserts" }, "A small red sweet fruit", "Rosaceae", "Fragaria", "Spring", true, "", "Strawberry", "Rich in vitamin C and antioxidants", "Europe and Americas", "Fragaria ananassa", "Sweet and Sour", null },
                    { 4, new[] { "Tropical", "Subtropical" }, new[] { "Mango" }, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new[] { "Raw", "Juice", "Desserts" }, "A tropical stone fruit", "Anacardiaceae", "Mangifera", "Summer", true, "", "Mango", "Rich in vitamin A and C", "South Asia", "Mangifera indica", "Sweet", null }
                });

            migrationBuilder.InsertData(
                table: "Vegetables",
                columns: new[] { "Id", "AgroecologicalZones", "CommonNames", "CreatedAt", "CulinaryUses", "Description", "EdiblePart", "Family", "Genus", "HarvestSeason", "ImageUrl", "IsLeafy", "Name", "NutritionalInfo", "OriginRegion", "ScientificName", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new[] { "Temperate" }, new[] { "Carrot" }, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new[] { "Raw", "Cooked", "Soup" }, "An orange root vegetable", "Root", "Apiaceae", "Daucus", "Autumn", "", false, "Carrot", "Rich in beta-carotene and vitamin A", "Central Asia", "Daucus carota", null },
                    { 2, new[] { "Temperate" }, new[] { "Spinach" }, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new[] { "Raw", "Cooked", "Salads" }, "A leafy green vegetable", "Leaf", "Amaranthaceae", "Spinacia", "Spring", "", true, "Spinach", "Rich in iron and vitamin K", "Central and Western Asia", "Spinacia oleracea", null },
                    { 3, new[] { "Temperate", "Tropical" }, new[] { "Tomato" }, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new[] { "Raw", "Sauce", "Salads" }, "A red fruit often used as a vegetable", "Fruit", "Solanaceae", "Solanum", "Summer", "", false, "Tomato", "Rich in lycopene and vitamin C", "South America", "Solanum lycopersicum", null },
                    { 4, new[] { "Temperate" }, new[] { "Broccoli" }, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new[] { "Cooked", "Steamed", "Stir-fry" }, "A green cruciferous vegetable", "Flower head", "Brassicaceae", "Brassica", "Autumn", "", false, "Broccoli", "Rich in vitamin C and K", "Mediterranean", "Brassica oleracea", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Fruits",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Fruits",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Fruits",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Fruits",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Vegetables",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vegetables",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vegetables",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vegetables",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
