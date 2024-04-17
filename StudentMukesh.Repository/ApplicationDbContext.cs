
using Microsoft.EntityFrameworkCore;
using StudentMukesh.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMukesh.Repository
{
    public class ApplicationDbContext :  DbContext // ORM
    { 
        // Call DbContextOptionBuilder
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
                
        }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Patient> Patients { get; set; }


        //fluentAPI
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientMedicine>().HasKey(x => new {x.PatientId,x.MedicineId });           
            base.OnModelCreating(modelBuilder);
        }

    }
}
