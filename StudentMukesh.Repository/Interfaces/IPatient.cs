using StudentMukesh.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMukesh.Repository.Interfaces
{
    public interface IPatient
    {
        Task<IEnumerable<Patient>> GetAll();
        Task <Patient> Get(int id);
        Task Save(Patient Patient);
        Task Update(Patient Patient);
        Task Delete(int id);
    }
}
