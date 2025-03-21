using Microsoft.EntityFrameworkCore;
using PatientDemographyAPI.Models;
namespace PatientDemographyAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Additional model configuration can be done here


            modelBuilder.Entity<Patient>().HasData(
            new Patient { Id = 1, FirstName = "Patient A", LastName = "", Age = 1, DateOfBirth = DateTime.Now, Gender = "Male", MedicalRecordNumber = "P001" },
            new Patient { Id = 2, FirstName = "Patient B", LastName = "", Age = 2, DateOfBirth = DateTime.Now, Gender = "Male", MedicalRecordNumber = "P002" },
            new Patient { Id = 3, FirstName = "Patient C", LastName = "", Age = 3, DateOfBirth = DateTime.Now, Gender = "Female", MedicalRecordNumber = "P003" }
        );


        }
    }
}