using Microsoft.EntityFrameworkCore;
using StudentMukesh.Domain;
using StudentMukesh.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMukesh.Repository.Implementation
{
    public class DoctorRepo : IDoctor
    {
        private readonly ApplicationDbContext _context;

        public DoctorRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task DeleteById(int id)
        {
           //var result = GetById(id);
            var result = _context.Doctors.Find(id);
            _context.Doctors.Remove(result);
           await _context.SaveChangesAsync();
        }

        public async Task <IEnumerable<Doctor>> GetAll()
        {
            return await _context.Doctors.ToListAsync();
        }

        public async Task<Doctor> GetById(int id)
        {
            return await _context.Doctors.FindAsync(id);
        }

        public async Task Save(Doctor doctor)
        {
            ArgumentNullException.ThrowIfNull(doctor);
            _context.Doctors.Add(doctor);
           await _context.SaveChangesAsync();
        }

        public async Task Update(Doctor doctor)
        {
            ArgumentNullException.ThrowIfNull(doctor);
            _context.Doctors.Update(doctor);
           await _context.SaveChangesAsync();
        }
    }
}
