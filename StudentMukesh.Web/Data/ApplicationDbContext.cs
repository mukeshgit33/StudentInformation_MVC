
using Microsoft.EntityFrameworkCore;
using StudentMukesh.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMukesh.Web.Data
{
    public class ApplicationDbContext :  DbContext // ORM
    { 
        // Call DbContextOptionBuilder
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
                
        }
        public DbSet<People> Peoples { get; set; }

    }
}
