using Microsoft.EntityFrameworkCore;
using StudentMukesh.Domain;
using StudentMukesh.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMukesh.Repository.Implementations
{
    public class PatientRepo : IPatient
    {
        private readonly ApplicationDbContext _context;

        public PatientRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Delete(int id)
        {
            //var Patient = Get(id);
            var result = await _context.Patients.FindAsync(id);
            _context.Patients.Remove(result);
            _context.SaveChanges();
        }

        public async Task<Patient> Get(int id)
        {
            return await _context.Patients.Include(x=>x.PatientMedicines).FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<IEnumerable<Patient>> GetAll()
        {
            return await _context.Patients.ToListAsync();
        }

        public async Task Save(Patient Patient)
        {
          _context.Patients.Add(Patient);
          await  _context.SaveChangesAsync();
        }

        public async Task Update(Patient Patient)
        {
            _context.Patients.Update(Patient);
           await _context.SaveChangesAsync();
        }
    }
}