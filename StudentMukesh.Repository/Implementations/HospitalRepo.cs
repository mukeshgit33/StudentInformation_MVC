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
    public class HospitalRepo : IHospital
    {
        private readonly ApplicationDbContext _context;

        public HospitalRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Delete(int id)
        {
            //var hospital = Get(id); 
            var result = _context.Hospitals.Find(id);
            _context.Hospitals.Remove(result);
           await _context.SaveChangesAsync();
        }

        public async Task <Hospital> Get(int id)
        {
            return await _context.Hospitals.FindAsync(id);
        }

        public async Task<IEnumerable<Hospital>> GetAll()
        {
            return await _context.Hospitals.ToListAsync();
        }

        public async Task Save(Hospital hospital)
        {
            _context.Hospitals.Add(hospital);
           await _context.SaveChangesAsync();
        }

        public async Task Update(Hospital hospital)
        {
            _context.Hospitals.Update(hospital);
           await _context.SaveChangesAsync();
        }
    }
}
