using Repository.Interface;
using Repository.Implementation;
using Service.Implementation;
using Service.Interface;
using Web.Mapper;

namespace Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();
        
        // Swagger
        builder.Services.AddSwaggerGen();
        
        builder.Services.AddControllers();
        
        // Repository
        builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        // Services
        builder.Services.AddHttpClient<IPlantService, PlantService>();
        builder.Services.AddHttpClient<IDiseaseService, DiseaseService>();
        builder.Services.AddHttpClient<IApiService, ApiService>();
        
        //Mappers
        builder.Services.AddScoped<PlantMapper>();
        builder.Services.AddScoped<DiseaseMapper>();
        builder.Services.AddScoped<ApiMapper>();
            
        var app = builder.Build();
        
        app.MapControllers();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            // Swagger
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.Run();
    }
}