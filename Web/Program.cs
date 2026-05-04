using Domain.Models.Identity;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using Repository;
using Repository.Interface;
using Repository.Implementation;
using Service.Implementation;
using Service.Interface;
using Web.Mapper;
using Scalar.AspNetCore;

namespace Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        // Firebase Admin SDK
        FirebaseApp.Create(new AppOptions
        {
            Credential = GoogleCredential.GetApplicationDefault()
        });
        
        // Database
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
        
        // Identity
        builder.Services.AddIdentityCore<AppUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
        
        // JWT Auth via Firebase
        var projectId = builder.Configuration["Firebase:ProjectId"];

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = $"https://securetoken.google.com/{projectId}";
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = $"https://securetoken.google.com/{projectId}",
                    ValidateAudience = true,
                    ValidAudience = projectId,
                    ValidateLifetime = true
                };
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        Console.WriteLine($"Auth failed: {context.Exception.Message}");
                        return Task.CompletedTask;
                    },
                    OnTokenValidated = async context =>
                    {
                        var uid = context.Principal?.FindFirst("user_id")?.Value;
                        if (string.IsNullOrEmpty(uid))
                        {
                            context.Fail("Missing user_id claim");
                            return;
                        }
                        
                        var userManager = context.HttpContext.RequestServices
                            .GetRequiredService<UserManager<AppUser>>();

                        var user = await userManager.FindByLoginAsync("Firebase", uid);

                        if (user == null)
                        {
                            var email = context.Principal?.FindFirst(
                                "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"
                            )?.Value ?? context.Principal?.FindFirst("email")?.Value;

                            user = new AppUser
                            {
                                UserName = uid,
                                Email = email,
                                FirebaseUserId = uid,
                                DisplayName = context.Principal?.FindFirst("name")?.Value ?? string.Empty
                            };

                            await userManager.CreateAsync(user);
                            await userManager.AddLoginAsync(user,
                                new UserLoginInfo("Firebase", uid, "Firebase"));
                        }
                    },
                    OnChallenge = context =>
                    {
                        Console.WriteLine($"OnChallange: {context.Error}, {context.ErrorDescription}");
                        return Task.CompletedTask;
                    }
                };
            });
        
        // Add services to the container.
        builder.Services.AddAuthorization();
        builder.Services.AddControllers();
        
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi(options =>
        {
            options.AddDocumentTransformer((document, context, cancellationToken) =>
            {
                document.Components ??= new();
                document.Components.SecuritySchemes = new Dictionary<string, IOpenApiSecurityScheme>
                {
                    ["Bearer"] = new OpenApiSecurityScheme
                    {
                        Type = SecuritySchemeType.Http,
                        Scheme = "bearer",
                        BearerFormat = "JWT",
                        Description = "Enter your Firebase JWT token"
                    }
                };
                return Task.CompletedTask;
            });
        });
        
        // Swagger
        
        
        // Repository
        builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        // Services
        builder.Services.AddHttpClient<IPlantService, PlantService>();
        builder.Services.AddHttpClient<IDiseaseService, DiseaseService>();
        builder.Services.AddHttpClient<IApiService, ApiService>();
        builder.Services.AddScoped<IFruitService, FruitService>();
        builder.Services.AddScoped<IVegetableService, VegetableService>();
        builder.Services.AddScoped<IHistoryService, HistoryService>();
        builder.Services.AddScoped<IFavoriteService, FavoriteService>();

        //Mappers
        builder.Services.AddScoped<PlantMapper>();
        builder.Services.AddScoped<DiseaseMapper>();
        builder.Services.AddScoped<ApiMapper>();
        builder.Services.AddScoped<FruitMapper>();
        builder.Services.AddScoped<VegetableMapper>();
        builder.Services.AddScoped<HistoryMapper>();
        builder.Services.AddScoped<FavoritesMapper>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.MapScalarApiReference();
            // Swagger
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        
        app.Run();
    }
}