using Domain.Models.DiseaseID;
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
}