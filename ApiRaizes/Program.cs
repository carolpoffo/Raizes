using ApiRaizes.Contracts.Infrastructure;
using ApiRaizes.Contracts.Repository;
using ApiRaizes.Contracts.Services;
using ApiRaizes.Infrastructure;
using ApiRaizes.Repository;
using ApiRaizes.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace ApiRaizes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Serviços compartilhados
            builder.Services.AddSingleton<IConnection, Connection>();
            builder.Services.AddScoped<IAuthentication, Authentication>();

            // Injeções de dependência
            builder.Services.AddScoped<IHarvestService, HarvestService>();
            builder.Services.AddScoped<IHarvestRepository, HarvestRepository>();
            builder.Services.AddScoped<IHarvestStorageService, HarvestStorageService>();
            builder.Services.AddScoped<IHarvestStorageRepository, HarvestStorageRepository>();
            builder.Services.AddScoped<ISaleService, SaleService>();
            builder.Services.AddScoped<ISaleRepository, SaleRepository>();
            builder.Services.AddScoped<ISpeciesService, SpeciesService>();
            builder.Services.AddScoped<ISpeciesRepository, SpeciesRepository>();
            builder.Services.AddScoped<ICityService, CityService>();
            builder.Services.AddScoped<ICityRepository, CityRepository>();
            builder.Services.AddScoped<IPropertyService, PropertyService>();
            builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();
            builder.Services.AddScoped<IRawMaterialStockService, RawMaterialStockService>();
            builder.Services.AddScoped<IRawMaterialStockRepository, RawMaterialStockRepository>();
            builder.Services.AddScoped<ISoilHistoricService, SoilHistoricService>();
            builder.Services.AddScoped<ISoilHistoricRepository, SoilHistoricRepository>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddTransient<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ISupplierService, SupplierService>();
            builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
            builder.Services.AddScoped<IMeasureUnitService, MeasureUnitService>();
            builder.Services.AddScoped<IMeasureUnitRepository, MeasureUnitRepository>();
            builder.Services.AddScoped<IPlantingRawMaterialService, PlantingRawMaterialService>();
            builder.Services.AddScoped<IPlantingRawMaterialRepository, PlantingRawMaterialRepository>();
            builder.Services.AddScoped<IRawMaterialService, RawMaterialService>();
            builder.Services.AddScoped<IRawMaterialRepository, RawMaterialRepository>();
            builder.Services.AddScoped<IPlantingService, PlantingService>();
            builder.Services.AddScoped<IPlantingRepository, PlantingRepository>();
            builder.Services.AddScoped<ISoilTypeService, SoilTypeService>();
            builder.Services.AddScoped<ISoilTypeRepository, SoilTypeRepository>();
            builder.Services.AddScoped<IEquipmentService, EquipmentService>();
            builder.Services.AddScoped<IEquipmentRepository, EquipmentRepository>();
            builder.Services.AddScoped<IPlantingEquipmentService, PlantingEquipmentService>();
            builder.Services.AddScoped<IPlantingEquipmentRepository, PlantingEquipmentRepository>();
            builder.Services.AddScoped<IStockMovementService, StockMovementService>();
            builder.Services.AddScoped<IStockMovementRepository, StockMovementRepository>();
            builder.Services.AddScoped<IEventService, EventService>();
            builder.Services.AddScoped<IEventRepository, EventRepository>();
            builder.Services.AddScoped<ITaskService, TaskService>();
            builder.Services.AddScoped<ITaskRepository, TaskRepository>();

            // JWT Authentication
            var key = Encoding.ASCII.GetBytes(builder.Configuration["JwtSettings:SecretKey"]);
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key)
                    };
                });

            // CORS - FIXED: Allow requests from any origin during development
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend", policy =>
                {
                    policy.AllowAnyOrigin() // Allow any origin during development
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            // Swagger com suporte a Bearer
            builder.Services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    In = ParameterLocation.Header
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });

            // Outros serviços
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            var app = builder.Build();

            // Pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowFrontend");
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
