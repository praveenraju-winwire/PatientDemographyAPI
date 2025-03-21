using PatientDemographyAPI.Data;
using PatientDemographyAPI.Repositories.Interfaces;
using PatientDemographyAPI.Repositories;
using PatientDemographyAPI.Services.Interfaces;
using PatientDemographyAPI.Services;
using Swashbuckle.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System;
using PatientDemographyAPI.Models;
namespace PatientDemographyAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();
            // Register services
            builder.Services.AddScoped<IPatientService, PatientService>();
            builder.Services.AddScoped<IPatientRepository, PatientRepository>();

            // Configure PostgreSQL connection
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            //builder.Services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseNpgsql(connectionString));

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("InMemoryDb"));

            var app = builder.Build();


            // Automatically apply any pending migrations (including seed data)
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                context.Database.EnsureCreated();  // Ensure that the database is created (if not already)
            }
           
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();

            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
