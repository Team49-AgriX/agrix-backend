using Domain.Models.DiseaseID;
using Domain.Models.Favorites;
using Domain.Models.History;
using Domain.Models.Identity;
using Domain.Models.PlantID;
using Domain.Models.Plants;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<AppUser>(options)
{
    public DbSet<Fruit> Fruits { get; set; }
    public DbSet<Vegetable> Vegetables { get; set; }
    public DbSet<Plant> Plants { get; set; }
    public DbSet<Disease> Diseases { get; set; }
    //History
    public DbSet<PlantScanHistory> PlantScanHistories { get; set; }
    public DbSet<DiseaseScanHistory> DiseaseScanHistories { get; set; }
    //Favorite-Scans
    public DbSet<PlantScanFavorites> PlantScanFavorites { get; set; }
    public DbSet<DiseaseScanFavorites> DiseaseScanFavorites { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Fruit>().ToTable("Fruits");
        modelBuilder.Entity<Vegetable>().ToTable("Vegetables");

        // Seed Fruits
        modelBuilder.Entity<Fruit>().HasData(
            new Fruit
            {
                Id = 1,
                Name = "Apple",
                Description = "A sweet red fruit",
                ScientificName = "Malus domestica",
                Family = "Rosaceae",
                Genus = "Malus",
                CommonNames = ["Apple", "Red Apple"],
                OriginRegion = "Central Asia",
                AgroecologicalZones = ["Temperate"],
                HarvestSeason = "Autumn",
                CulinaryUses = ["Raw", "Juice", "Pie"],
                NutritionalInfo = "Rich in fiber and vitamin C",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/1/15/Red_Apple.jpg",
                HasSeeds = true,
                TasteProfile = "Sweet",
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Fruit
            {
                Id = 2,
                Name = "Banana",
                Description = "A tropical yellow fruit",
                ScientificName = "Musa acuminata",
                Family = "Musaceae",
                Genus = "Musa",
                CommonNames = ["Banana"],
                OriginRegion = "Southeast Asia",
                AgroecologicalZones = ["Tropical"],
                HarvestSeason = "Year-round",
                CulinaryUses = ["Raw", "Smoothies", "Baking"],
                NutritionalInfo = "Rich in potassium and vitamin B6",
                ImageUrl = "",
                HasSeeds = false,
                TasteProfile = "Sweet",
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Fruit
            {
                Id = 3,
                Name = "Strawberry",
                Description = "A small red sweet fruit",
                ScientificName = "Fragaria ananassa",
                Family = "Rosaceae",
                Genus = "Fragaria",
                CommonNames = ["Strawberry"],
                OriginRegion = "Europe and Americas",
                AgroecologicalZones = ["Temperate"],
                HarvestSeason = "Spring",
                CulinaryUses = ["Raw", "Jam", "Desserts"],
                NutritionalInfo = "Rich in vitamin C and antioxidants",
                ImageUrl = "",
                HasSeeds = true,
                TasteProfile = "Sweet and Sour",
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Fruit
            {
                Id = 4,
                Name = "Mango",
                Description = "A tropical stone fruit",
                ScientificName = "Mangifera indica",
                Family = "Anacardiaceae",
                Genus = "Mangifera",
                CommonNames = ["Mango"],
                OriginRegion = "South Asia",
                AgroecologicalZones = ["Tropical", "Subtropical"],
                HarvestSeason = "Summer",
                CulinaryUses = ["Raw", "Juice", "Desserts"],
                NutritionalInfo = "Rich in vitamin A and C",
                ImageUrl = "",
                HasSeeds = true,
                TasteProfile = "Sweet",
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            }
        );

        // Seed Vegetables
        modelBuilder.Entity<Vegetable>().HasData(
            new Vegetable
            {
                Id = 1,
                Name = "Carrot",
                Description = "An orange root vegetable",
                ScientificName = "Daucus carota",
                Family = "Apiaceae",
                Genus = "Daucus",
                CommonNames = ["Carrot"],
                OriginRegion = "Central Asia",
                AgroecologicalZones = ["Temperate"],
                HarvestSeason = "Autumn",
                CulinaryUses = ["Raw", "Cooked", "Soup"],
                NutritionalInfo = "Rich in beta-carotene and vitamin A",
                ImageUrl = "",
                EdiblePart = "Root",
                IsLeafy = false,
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Vegetable
            {
                Id = 2,
                Name = "Spinach",
                Description = "A leafy green vegetable",
                ScientificName = "Spinacia oleracea",
                Family = "Amaranthaceae",
                Genus = "Spinacia",
                CommonNames = ["Spinach"],
                OriginRegion = "Central and Western Asia",
                AgroecologicalZones = ["Temperate"],
                HarvestSeason = "Spring",
                CulinaryUses = ["Raw", "Cooked", "Salads"],
                NutritionalInfo = "Rich in iron and vitamin K",
                ImageUrl = "",
                EdiblePart = "Leaf",
                IsLeafy = true,
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Vegetable
            {
                Id = 3,
                Name = "Tomato",
                Description = "A red fruit often used as a vegetable",
                ScientificName = "Solanum lycopersicum",
                Family = "Solanaceae",
                Genus = "Solanum",
                CommonNames = ["Tomato"],
                OriginRegion = "South America",
                AgroecologicalZones = ["Temperate", "Tropical"],
                HarvestSeason = "Summer",
                CulinaryUses = ["Raw", "Sauce", "Salads"],
                NutritionalInfo = "Rich in lycopene and vitamin C",
                ImageUrl = "",
                EdiblePart = "Fruit",
                IsLeafy = false,
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Vegetable
            {
                Id = 4,
                Name = "Broccoli",
                Description = "A green cruciferous vegetable",
                ScientificName = "Brassica oleracea",
                Family = "Brassicaceae",
                Genus = "Brassica",
                CommonNames = ["Broccoli"],
                OriginRegion = "Mediterranean",
                AgroecologicalZones = ["Temperate"],
                HarvestSeason = "Autumn",
                CulinaryUses = ["Cooked", "Steamed", "Stir-fry"],
                NutritionalInfo = "Rich in vitamin C and K",
                ImageUrl = "",
                EdiblePart = "Flower head",
                IsLeafy = false,
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            }
        );
    }
}
