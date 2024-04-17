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
    public class MedicineRepo : IMedicine
    {
        private readonly ApplicationDbContext _context;

        public MedicineRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Delete(int id)
        {
            //var medicine = Get(id);
            var result = _context.Medicines.Find(id);
            _context.Medicines.Remove(result);
           await _context.SaveChangesAsync();
        }

        public async Task<Medicine> Get(int id)
        {
            return await _context.Medicines.FindAsync(id);
        }

        public async Task <IEnumerable<Medicine>> GetAll()
        {
            return await _context.Medicines.ToListAsync();
        }

        public async Task Save(Medicine medicine)
        {
            _context.Medicines.Add(medicine);
           await _context.SaveChangesAsync();
        }

        public async Task Update(Medicine medicine)
        {
            _context.Medicines.Update(medicine);
           await _context.SaveChangesAsync();
        }
    }
}
